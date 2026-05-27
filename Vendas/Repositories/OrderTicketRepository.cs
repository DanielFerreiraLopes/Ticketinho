using Ticketinho.Infrastructure.Entities;
using Ticketinho.Infrastructure.Persistence;
using Ticketinho.Vendas.Application.Interfaces;
using Ticketinho.Vendas.Domains.Entities;

namespace Ticketinho.Vendas.Repositories
{
    public class OrderTicketRepository : IOrderTicketRepository
    {
        private readonly OrderDbContext _context;

        public OrderTicketRepository(OrderDbContext context)
        {
            _context = context;
        }

        public void AddTicket(long ticketNumber, Guid orderId)
        {
            Ticket ticketEntity = new Ticket
            (
                Guid.NewGuid(),
                ticketNumber,
                orderId
            );
            _context.Tickets.Add(ticketEntity);
            _context.SaveChanges();
        }

        public List<OrderTicket> GetTickets()
        {
            List<Ticket> tickets = _context.Tickets.ToList();
            List<OrderTicket> orderTickets = new List<OrderTicket>();
            foreach (Ticket ticket in tickets)
            {
                orderTickets.Add(this._MapTicket(ticket));
            }
            return orderTickets;
        }

        public OrderTicket FindById(Guid id)
        {
            Ticket findTicket = _context.Tickets.
                Select(t => t)
                .Where(t => t.Id == id)
                .FirstOrDefault();
            if (findTicket == null) throw new Exception("Ingresso não encontrado.");
            return this._MapTicket(findTicket);
        }

        public List<OrderTicket> GetByOrderId(Guid orderId)
        {
            List<Ticket> tickets = _context.Tickets
                .Where(t => t.OrderId == orderId)
                .ToList();
            List<OrderTicket> orderTickets = new List<OrderTicket>();
            foreach (Ticket ticket in tickets)
            {
                orderTickets.Add(this._MapTicket(ticket));
            }
            return orderTickets;
        }

        private OrderTicket _MapTicket(Ticket ticket)
        {
            return new OrderTicket
            (
                ticket.Id,
                ticket.TicketNumber,
                ticket.OrderId
            );
        }
    }
}
