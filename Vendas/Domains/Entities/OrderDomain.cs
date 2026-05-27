
using Ticketinho.Vendas.Domains.ValueObjects;

namespace Ticketinho.Vendas.Domains.Entities
{
    public class OrderDomain
    {
        public Guid Id { get; set; }
        public string Name_user { get; set; }
        public long Document_user { get; set; }
        public string Email_user { get; set; }
        public Guid EventId { get; set; }
        public int Quantity { get; set; }
        public double FinalPrice { get; set; }
        public string PaymentMethod { get; set; }
        public int Status { get; set; }
        public DateTime DateOrder { get; set; }

        public OrderDomain(Guid Id, string name_user, long document, string email, Guid eventId, int quantity, double finalPrice, string paymentMethod, DateTime dateOrder, int status)
        {
            if (string.IsNullOrWhiteSpace(name_user)) throw new Exception("Nome do usuário é obrigatório.");
            if (quantity <= 0) throw new Exception("A quantidade de ingressos deve ser maior que zero.");
            if (finalPrice <= 0) throw new Exception("O preço do ingresso deve ser maior que zero.");
            if (string.IsNullOrWhiteSpace(paymentMethod)) throw new Exception("Método de pagamento é obrigatório.");

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

            if (orderEvent.TicketsSold + this.Quantity > orderEvent.MaxCapacity)
                throw new Exception("Não há ingressos suficientes disponíveis");


            this.ApproveOrder();
            orderEvent.TicketsSold += this.Quantity;
        }

        public void ApproveOrder()
        {
            this.Status = 1; //Aprovado
        }
    }
}
