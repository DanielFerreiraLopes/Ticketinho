namespace Ticketinho.Vendas.Domains.Entities
{
    public class OrderTicket
    {
        public Guid Id { get; set; }
        public long TicketNumber { get; set; }
        public Guid OrderId { get; set; }

        public OrderTicket(Guid Id, long ticketNumber, Guid orderId)
        {
            this.Id = Id;
            this.TicketNumber = ticketNumber;
            this.OrderId = orderId;
        }

    }
}
