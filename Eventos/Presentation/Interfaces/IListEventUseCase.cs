using Ticketinho.Eventos.Domains.Entities;
using Ticketinho.Eventos.Presentation.DTOs;

namespace Ticketinho.Eventos.Presentation.Interfaces
{
    public interface IListEventUseCase
    {
        public List<EventResponse> Run();
    }
}
