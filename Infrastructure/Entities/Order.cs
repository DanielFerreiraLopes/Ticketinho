
namespace Ticketinho.Infrastructure.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Name_user { get; set; }
        public long Document_user { get; set; }
        public string Email_user { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }
        public int Quantity { get; set; }
        public double FinalPrice { get; set; }
        public string PaymentMethod { get; set; }
        public int Status { get; set; }
        public DateTime DateOrder { get; set; }
        public List<Ticket> Tickets { get; set; }

        public Order(Guid id, string name_user, long document_user, string email_user, Guid eventId, int quantity, double finalPrice, string paymentMethod, DateTime dateOrder, int status)
        {
            this.Id = id;
            this.Name_user = name_user;
            this.Document_user = document_user;
            this.Email_user = email_user;
            this.EventId = eventId;
            this.Quantity = quantity;
            this.FinalPrice = finalPrice;
            this.PaymentMethod = paymentMethod;
            this.DateOrder = dateOrder;
            this.Status = status;
        }
    }
}
