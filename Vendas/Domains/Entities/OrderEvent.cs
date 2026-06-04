using Ticketinho.Vendas.Domains.ValueObjects;

namespace Ticketinho.Vendas.Domains.Entities
{
    public class OrderEvent
    {
        public Guid Id { get; set; }
        public DateTime EventDate { get; set; }
        public Price Price { get; set; }
        public Quantity MaxCapacity { get; set; }
        public TicketsSold TicketsSold { get; set; }
        public bool Available { get; set; }

        public OrderEvent(Guid id, DateTime eventDate, Price price, Quantity maxCapacity, TicketsSold ticketsSold, bool available)
        {
            this.Id = id;
            this.EventDate = eventDate;
            this.Price = price;
            this.MaxCapacity = maxCapacity;
            this.TicketsSold = ticketsSold;
            this.Available = available;
        }
    }

}
