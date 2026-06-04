using Ticketinho.Vendas.Application.Interfaces;
using Ticketinho.Vendas.Domains.Entities;
using Ticketinho.Vendas.Presentation.DTOs;
using Ticketinho.Vendas.Presentation.Interfaces;

namespace Ticketinho.Vendas.Application.UseCases
{
    public class ListOrdersUseCase : IListOrdersUseCase
    {
        private readonly IOrderDomainRepository _orderRepository;

        public ListOrdersUseCase(IOrderDomainRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<OrderResponse> Run()
        {
            try
            {
                List<OrderDomain> orders = _orderRepository.GetOrders();
                return orders.Select(order => _MapToOrderResponse(order)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while listing orders: {ex.Message}");
                return new List<OrderResponse>();
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
