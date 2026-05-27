
namespace Ticketinho.Infrastructure.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Singer { get; set; }
        public double Price { get; set; }
        public DateTime EventDate { get; set; }
        public int MaxCapacity { get; set; }
        public int TicketsSold { get; set; }
        public bool Available { get; set; }
        public string Location { get; set; }
        public List<Order> Orders { get; set; }


        public Event(Guid id, string name, string description, string singer, double price, DateTime eventDate, int maxCapacity, int ticketsSold, bool available, string location)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Singer = singer;
            this.Price = price;
            this.EventDate = eventDate;
            this.MaxCapacity = maxCapacity;
            this.TicketsSold = ticketsSold;
            this.Available = available;
            this.Location = location;
        }
    }
}
