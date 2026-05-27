namespace Ticketinho.Vendas.Domains.Entities
{
    public class OrderEvent
    {
        public Guid Id { get; set; }
        public DateTime EventDate { get; set; }
        public double Price { get; set; }
        public int MaxCapacity { get; set; }
        public int TicketsSold { get; set; }
        public bool Available { get; set; }

        public OrderEvent(Guid id, DateTime eventDate, double price, int maxCapacity, int ticketsSold, bool available)
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
