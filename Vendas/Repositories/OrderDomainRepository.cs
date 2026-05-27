using Ticketinho.Eventos.Domains.Entities;
using Ticketinho.Infrastructure.Entities;
using Ticketinho.Infrastructure.Persistence;
using Ticketinho.Vendas.Application.Interfaces;
using Ticketinho.Vendas.Domains.Entities;
using Ticketinho.Vendas.Domains.ValueObjects;

namespace Ticketinho.Vendas.Repositories
{
    public class OrderDomainRepository : IOrderDomainRepository
    {
        private readonly OrderDbContext _context;

        public OrderDomainRepository(OrderDbContext context)
        {
            _context = context;
        }


        public void AddOrder(OrderDomain orderDomain)
        {
            Order orderEntity = new Order
            (
                orderDomain.Id,
                orderDomain.Name_user,
                orderDomain.Document_user,
                orderDomain.Email_user,
                orderDomain.EventId,
                orderDomain.Quantity,
                orderDomain.FinalPrice,
                orderDomain.PaymentMethod,
                orderDomain.DateOrder,
                orderDomain.Status
            );
             _context.Orders.Add(orderEntity);
             _context.SaveChanges();
        }

        public void UpdateOrder(OrderDomain orderDomain)
        {
            Order findOrder = _context.Orders.
                Select(o => o)
                .Where(o => o.Id == orderDomain.Id)
                .FirstOrDefault();

            if (findOrder == null) throw new Exception("Pedido não encontrado.");

            findOrder.Name_user = orderDomain.Name_user;
            findOrder.Document_user = orderDomain.Document_user;
            findOrder.Email_user = orderDomain.Email_user;
            findOrder.EventId = orderDomain.EventId;
            findOrder.Quantity = orderDomain.Quantity;
            findOrder.FinalPrice = orderDomain.FinalPrice;
            findOrder.PaymentMethod = orderDomain.PaymentMethod;
            findOrder.Status = orderDomain.Status;
            _context.Orders.Update(findOrder);
            _context.SaveChanges();
        }

        public OrderDomain FindById(Guid id)
        {
            Order findOrder = _context.Orders.
                Select(o => o)
                .Where(o => o.Id == id)
                .FirstOrDefault();
            if (findOrder == null) throw new Exception("Pedido não encontrado.");

            OrderDomain orderDomain = this._MapOrder(findOrder);
            
            return orderDomain;
        }

        public List<OrderDomain> GetOrders()
        {
            List<Order> orders = _context.Orders.ToList();
            List<OrderDomain> orderDomains = new List<OrderDomain>();

            foreach (Order order in orders)
            {
                orderDomains.Add(this._MapOrder(order));
            }

            return orderDomains;
        }

        public List<OrderDomain> GetOrdersByDocument(long document)
        {
            List<Order> orders = _context.Orders
                .Where(o => o.Document_user == document)
                .ToList();
            List<OrderDomain> orderDomains = new List<OrderDomain>();
            foreach (Order order in orders)
            {
                orderDomains.Add(this._MapOrder(order));
            }
            return orderDomains;
        }

        private OrderDomain _MapOrder(Order order)
        {
            return new OrderDomain(
                order.Id,
                order.Name_user,
                order.Document_user,
                order.Email_user,
                order.EventId,
                order.Quantity,
                order.FinalPrice,
                order.PaymentMethod,
                order.DateOrder,
                order.Status
            );
        }
    }
}
