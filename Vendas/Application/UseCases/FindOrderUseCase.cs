using Ticketinho.Vendas.Application.Interfaces;
using Ticketinho.Vendas.Domains.Entities;
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
        public OrderDomain Run(Guid id)
        {

            try
            {
                if (id == Guid.Empty)
                    throw new Exception("Id do pedido é inválido.");

                OrderDomain order = _orderRepository.FindById(id);

                if (order == null)
                    throw new Exception("Pedido não encontrado.");

                return order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
