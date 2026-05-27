using Ticketinho.Vendas.Domains.Entities;

namespace Ticketinho.Vendas.Application.Interfaces
{
    public interface IOrderEventRepository
    {
        public OrderEvent FindById(Guid id);

        public void UpdateEvent(OrderEvent orderEvent);
    }
}
