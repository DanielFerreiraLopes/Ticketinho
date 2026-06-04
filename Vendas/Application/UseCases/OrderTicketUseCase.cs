using Ticketinho.Adapters;
using Ticketinho.Vendas.Application.Interfaces;
using Ticketinho.Vendas.Domains.Entities;
using Ticketinho.Vendas.Domains.ValueObjects;
using Ticketinho.Vendas.Presentation.DTOs;
using Ticketinho.Vendas.Presentation.Interfaces;

namespace Ticketinho.Vendas.Application.UseCases
{
    public class OrderTicketUseCase : IOrderTicketUseCase
    {
        private readonly IOrderDomainRepository _orderRepository;
        private readonly IOrderTicketRepository _ticketRepository;
        private readonly IOrderEventRepository _eventRepository;
        private readonly IPaymentAdapter _paymentAdapter;

        public OrderTicketUseCase(IOrderDomainRepository orderRepository, IOrderTicketRepository ticketRepository, IOrderEventRepository eventRepository, IPaymentAdapter paymentAdapter)
        {
            _orderRepository = orderRepository;
            _ticketRepository = ticketRepository;
            _eventRepository = eventRepository;
            _paymentAdapter = paymentAdapter;
        }
        public void Run(ComprarIngressoRequest request)
        {

            OrderEvent orderEvent = _eventRepository.FindById(request.EventId); 
            // Não esta retornando null quando o evento não é encontrado, esta retornando um OrderEvent com valores default, isso pode ser um problema, pois o código continua a execução mesmo quando o evento não é encontrado, e isso pode levar a erros mais adiante no código, como por exemplo, quando tenta acessar as propriedades do orderEvent que estão com valores default.


            if (orderEvent == null)
            {
                throw new Exception("Evento não encontrado.");
            }


            OrderDomain newOrderDomain = new OrderDomain(
                Guid.NewGuid(),
                new Name(request.Name_user),
                new Document(request.Document_user),
                new Email(request.Email_user),
                request.EventId,
                new Quantity(request.Quantity),
                new Price(orderEvent.Price.Value * request.Quantity),
                new PaymentMethod(request.PaymentMethod),
                DateTime.Now,
                new Status(0)
            );


            if (newOrderDomain == null)
            {
                throw new ArgumentNullException(nameof(newOrderDomain));
            }

            bool paymentSuccess = _paymentAdapter.ProcessPayment(newOrderDomain.Id, newOrderDomain.FinalPrice.Value, newOrderDomain.PaymentMethod.Value).Result;

            if (!paymentSuccess)
            {
                throw new Exception("Falha no processamento do pagamento.");
            }         

            newOrderDomain.SaleTicket(newOrderDomain, orderEvent);

            try
            {
                _orderRepository.AddOrder(newOrderDomain);
            } catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar pedido: {ex.Message}");
                throw new Exception("Erro ao processar o pedido.");
            }


            Random ticketNumber = new Random();

            for (var i = 0; i < newOrderDomain.Quantity.Value; i++)
            {
                _ticketRepository.AddTicket(ticketNumber.Next(100000, 999999), newOrderDomain.Id);
            }

            _orderRepository.UpdateOrder(newOrderDomain);
            _eventRepository.UpdateEvent(orderEvent);
        }
    }
}
