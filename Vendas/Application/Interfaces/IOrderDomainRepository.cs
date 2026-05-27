using Microsoft.EntityFrameworkCore;
using Ticketinho.Infrastructure.Entities;
using Ticketinho.Vendas.Domains.Entities;

namespace Ticketinho.Vendas.Application.Interfaces
{
    public interface IOrderDomainRepository
    {
        public void AddOrder(OrderDomain orderDomain);

        public void UpdateOrder(OrderDomain orderDomain);

        public OrderDomain FindById(Guid id);

        public List<OrderDomain> GetOrders();

        public List<OrderDomain> GetOrdersByDocument(long document);
    }
}
