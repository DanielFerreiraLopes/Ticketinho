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
                orderDomain.Name_user.Value,
                orderDomain.Document_user.Value,
                orderDomain.Email_user.Value,
                orderDomain.EventId,
                orderDomain.Quantity.Value,
                orderDomain.FinalPrice.Value,
                orderDomain.PaymentMethod.Value,
                orderDomain.DateOrder,
                orderDomain.Status.Value
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

            findOrder.Name_user = orderDomain.Name_user.Value;
            findOrder.Document_user = orderDomain.Document_user.Value;
            findOrder.Email_user = orderDomain.Email_user.Value;
            findOrder.EventId = orderDomain.EventId;
            findOrder.Quantity = orderDomain.Quantity.Value;
            findOrder.FinalPrice = orderDomain.FinalPrice.Value;
            findOrder.PaymentMethod = orderDomain.PaymentMethod.Value;
            findOrder.Status = orderDomain.Status.Value;
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
                new Name(order.Name_user),
                new Document(order.Document_user),
                new Email(order.Email_user),
                order.EventId,
                new Quantity(order.Quantity),
                new Price(order.FinalPrice),
                new PaymentMethod(order.PaymentMethod),
                order.DateOrder,
                new Status(order.Status)
            );
        }
    }
}
