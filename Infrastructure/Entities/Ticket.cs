namespace Ticketinho.Infrastructure.Entities
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public long TicketNumber { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }


        public Ticket(Guid id, long ticketNumber, Guid orderId)
        {
            this.Id = id;
            this.TicketNumber = ticketNumber;
            this.OrderId = orderId;
        }
    }
}
