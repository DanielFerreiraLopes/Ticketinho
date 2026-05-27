using Ticketinho.Vendas.Domains.ValueObjects;

namespace Ticketinho.Vendas.Presentation.DTOs
{
    public class ComprarIngressoRequest
    {
        public string Name_user { get; set; }
        public long Document_user { get; set; }
        public string Email_user { get; set; }
        public Guid EventId { get; set; }
        public int Quantity { get; set; }
        public string PaymentMethod { get; set; }
    }
}
