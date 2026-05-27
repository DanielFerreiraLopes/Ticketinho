using Ticketinho.Eventos.Application.Interfaces;
using Ticketinho.Eventos.Domains.Entities;
using Ticketinho.Eventos.Presentation.DTOs;
using Ticketinho.Infrastructure.Entities;
using Ticketinho.Infrastructure.Persistence;

namespace Ticketinho.Eventos.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly OrderDbContext _context;

        public EventRepository(OrderDbContext context)
        {
            _context = context;
        }

        public void AddEvent(EventDomain eventDomain)
        {
            Event eventEntity = new Event(
                eventDomain.Id,
                eventDomain.Name,
                eventDomain.Description,
                eventDomain.Singer,
                eventDomain.Price,
                eventDomain.EventDate,
                eventDomain.MaxCapacity,
                0,
                eventDomain.Available,
                eventDomain.Location
            );
            _context.Events.Add(eventEntity);
            _context.SaveChanges();
        }

        public List<EventDomain> GetEvents()
        {
            List<Event> events = _context.Events.ToList();

            List<EventDomain> eventDomains = new List<EventDomain>();

            foreach (Event event1 in events)
            {
                eventDomains.Add(this._MapEvent(event1));
            }

            return eventDomains;
        } 

        public EventDomain FindById(Guid id)
        {
            Event findEvent = _context.Events.
                Select(e => e)
                .Where(e => e.Id == id)
                .FirstOrDefault();

            return this._MapEvent(findEvent);
        }

        private EventDomain _MapEvent(Event event1)
        {
            return new EventDomain(
                event1.Id,
                event1.Name,
                event1.Description,
                event1.Singer,
                event1.Price,
                event1.EventDate,
                event1.MaxCapacity,
                event1.Available,
                event1.Location
            );
        }
    }
}