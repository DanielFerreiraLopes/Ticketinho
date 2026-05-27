using Ticketinho.Vendas.Application.Interfaces;
using Ticketinho.Vendas.Domains.Entities;
using Ticketinho.Vendas.Presentation.Interfaces;

namespace Ticketinho.Vendas.Application.UseCases
{
    public class GetTicketsByDocumentUseCase : IGetTicketsByDocumentUseCase
    {
        private readonly IOrderTicketRepository _ticketRepository;
        private readonly IOrderDomainRepository _orderRepository;

        public GetTicketsByDocumentUseCase(IOrderTicketRepository ticketRepository, IOrderDomainRepository orderRepository)
        {
            _ticketRepository = ticketRepository;
            _orderRepository = orderRepository;
        }

        public List<OrderTicket> Run(long document)
        {
            List<OrderDomain> orders = _orderRepository.GetOrdersByDocument(document);
            List<OrderTicket> tickets = new List<OrderTicket>();
            foreach (OrderDomain order in orders)
            {
                tickets.AddRange(_ticketRepository.GetByOrderId(order.Id));
            }
            return tickets;
        }
    }
}
