using Ticketinho.Vendas.Application.Interfaces;
using Ticketinho.Vendas.Domains.Entities;
using Ticketinho.Vendas.Presentation.DTOs;
using Ticketinho.Vendas.Presentation.Interfaces;

namespace Ticketinho.Vendas.Application.UseCases
{
    public class FindOrderUseCase : IFindOrderUseCase
    {
        private readonly IOrderDomainRepository _orderRepository;
        public FindOrderUseCase(IOrderDomainRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public OrderResponse Run(Guid id)
        {

            try
            {
                if (id == Guid.Empty)
                    throw new Exception("Id do pedido é inválido.");

                OrderDomain order = _orderRepository.FindById(id);

                if (order == null)
                    throw new Exception("Pedido não encontrado.");

             
                return _MapToOrderResponse(order);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private OrderResponse _MapToOrderResponse(OrderDomain order)
        {
            return new OrderResponse
            {
                Id = order.Id,
                Name_user = order.Name_user.Value,
                Document_user = order.Document_user.Value,
                Email_user = order.Email_user.Value,
                EventId = order.EventId,
                Quantity = order.Quantity.Value,
                FinalPrice = order.FinalPrice.Value,
                PaymentMethod = order.PaymentMethod.Value,
                DateOrder = order.DateOrder,
                Status = order.Status.Value
            };
        }
    }
}
