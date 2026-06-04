
using Ticketinho.Vendas.Domains.ValueObjects;

namespace Ticketinho.Vendas.Domains.Entities
{
    public class OrderDomain
    {
        public Guid Id { get; set; }
        public Name Name_user { get; set; }
        public Document Document_user { get; set; }
        public Email Email_user { get; set; }
        public Guid EventId { get; set; }
        public Quantity Quantity { get; set; }
        public Price FinalPrice { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Status Status { get; set; }
        public DateTime DateOrder { get; set; }

        public OrderDomain(Guid Id, Name name_user, Document document, Email email, Guid eventId, Quantity quantity, Price finalPrice, PaymentMethod paymentMethod, DateTime dateOrder, Status status)
        {
            this.Id = Id;
            this.Name_user = name_user;
            this.Document_user = document;
            this.Email_user = email;
            this.EventId = eventId;    
            this.Quantity = quantity;
            this.FinalPrice = finalPrice;
            this.PaymentMethod = paymentMethod;
            this.DateOrder = dateOrder;
            this.Status = status; //Pendente
        }


        public void SaleTicket(OrderDomain orderDomain, OrderEvent orderEvent)
        {

            // Mover as validações para o UseCase, mantendo a entidade mais limpa e focada em suas responsabilidades.
            if (!orderEvent.Available)
                throw new Exception("O Evento não está disponível");

            if(orderEvent.EventDate < DateTime.Now)
                throw new Exception("O Evento não está disponível");

            if (orderEvent.TicketsSold.Value + this.Quantity.Value > orderEvent.MaxCapacity.Value)
                throw new Exception("Não há ingressos suficientes disponíveis");


            this.ApproveOrder();
            orderEvent.TicketsSold = new TicketsSold(orderEvent.TicketsSold.Value + this.Quantity.Value);
        }

        public void ApproveOrder()
        {
            this.Status = new Status(1); //Aprovado
        }
    }
}
