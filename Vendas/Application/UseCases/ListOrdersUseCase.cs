using Ticketinho.Vendas.Application.Interfaces;
using Ticketinho.Vendas.Domains.Entities;
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

        public List<OrderDomain> Run()
        {
            try
            {
                return _orderRepository.GetOrders();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while listing orders: {ex.Message}");
                return new List<OrderDomain>();
            }
        }
    }
}
