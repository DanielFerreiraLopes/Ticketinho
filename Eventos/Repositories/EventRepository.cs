using Ticketinho.Eventos.Application.Interfaces;
using Ticketinho.Eventos.Domains.Entities;
using Ticketinho.Eventos.Domains.ValueObjects;
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
                eventDomain.Name.Value,
                eventDomain.Description.Value,
                eventDomain.Singer.Value,
                eventDomain.Price.Value,
                eventDomain.EventDate,
                eventDomain.MaxCapacity.Value,
                0,
                eventDomain.Available,
                eventDomain.Location.Value
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
                new Name(event1.Name),
                new Description(event1.Description),
                new Singer(event1.Singer),
                new Price(event1.Price),
                event1.EventDate,
                new MaxCapacity(event1.MaxCapacity),
                event1.Available,
                new Location(event1.Location)
            );
        }
    }
}