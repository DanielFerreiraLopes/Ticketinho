
namespace Ticketinho.Eventos.Domains.Entities
{
    public class EventDomain
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Singer { get; set; }
        public double Price { get; set; }
        public DateTime EventDate { get; set; }
        public int MaxCapacity { get; set; }
        public bool Available { get; set; }
        public string Location { get; set; }


        public EventDomain(Guid id, string name, string description, string singer, double price, DateTime eventDate, int maxCapacity, bool available, string location)
        {

            if (string.IsNullOrWhiteSpace(name) || name.Length < 3) throw new Exception("Nome do evento é obrigatório e deve ter no minimo 3 caracteres.");
            if (string.IsNullOrWhiteSpace(description) || description.Length < 10) throw new Exception("Descrição do evento é obrigatória e deve ter no minimo 10 caracteres.");
            if (string.IsNullOrWhiteSpace(singer)) throw new Exception("Nome do cantor é obrigatório.");

            //if (eventDate < DateTime.Now) throw new Exception("A data do evento não pode ser no passado.");
            if (maxCapacity <= 0) throw new Exception("A capacidade máxima do evento deve ser maior que zero.");
            //if (ticketsSold <= 0) throw new Exception("O número de ingressos vendidos não pode ser negativo.");

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
