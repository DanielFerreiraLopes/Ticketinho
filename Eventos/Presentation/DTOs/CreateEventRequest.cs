
namespace Ticketinho.Eventos.Presentation.DTOs
{
    public class CreateEventRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Singer { get; set; }
        public double Price { get; set; }
        public DateTime EventDate { get; set; }
        public int MaxCapacity { get; set; }
        public bool Available { get; set; }
        public string Location { get; set; }

    }
}
