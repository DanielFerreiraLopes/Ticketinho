
using Ticketinho.Eventos.Domains.ValueObjects;

namespace Ticketinho.Eventos.Domains.Entities
{
    public class EventDomain
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }
        public Description Description { get; set; }
        public Singer Singer { get; set; }
        public Price Price { get; set; }
        public DateTime EventDate { get; set; }
        public MaxCapacity MaxCapacity { get; set; }
        public bool Available { get; set; }
        public Location Location { get; set; }

        public EventDomain(Guid id, Name name, Description description, Singer singer, Price price, DateTime eventDate, MaxCapacity maxCapacity, bool available, Location location)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Singer = singer;
            this.Price = price;
            this.EventDate = eventDate;
            this.MaxCapacity = maxCapacity;
            //this.TicketsSold = ticketsSold;
            this.Available = available;
            this.Location = location;
        }        
    }
}
