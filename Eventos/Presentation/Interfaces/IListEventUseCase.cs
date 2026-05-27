using Ticketinho.Eventos.Domains.Entities;

namespace Ticketinho.Eventos.Presentation.Interfaces
{
    public interface IListEventUseCase
    {
        public List<EventDomain> Run();
    }
}
