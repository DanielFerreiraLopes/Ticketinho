using Ticketinho.Infrastructure.Entities;
using Ticketinho.Infrastructure.Persistence;
using Ticketinho.Vendas.Application.Interfaces;
using Ticketinho.Vendas.Domains.Entities;

namespace Ticketinho.Vendas.Repositories
{
    public class OrderEventRepository : IOrderEventRepository
    {
        private readonly OrderDbContext _context;

        public OrderEventRepository(OrderDbContext context)
        {
            _context = context;
        }

        public OrderEvent FindById (Guid id)
        {
            Event findEvent = _context.Events.
                Select(e => e)
                .Where(e => e.Id == id)
                .FirstOrDefault();
            if (findEvent == null) throw new Exception("Evento não encontrado.");

            OrderEvent orderEvent = this._MapEvent(findEvent);

            return orderEvent;
        }

        public void UpdateEvent(OrderEvent orderEvent)
        {
            Event @event = _context.Events.
                Select(e => e)
                .Where(e => e.Id == orderEvent.Id)
                .FirstOrDefault(); ;

            if (@event == null) throw new Exception("Evento não encontrado.");

            @event.TicketsSold = orderEvent.TicketsSold;
            _context.Events.Update(@event);
            _context.SaveChanges();
        }

        private OrderEvent _MapEvent(Event eventEntity)
        {
            return new OrderEvent
            (
                eventEntity.Id,
                eventEntity.EventDate,
                eventEntity.Price,
                eventEntity.MaxCapacity,
                eventEntity.TicketsSold,
                eventEntity.Available
            );
        }
    }
}
