using Ticketinho.Eventos.Domains.Entities;

namespace Ticketinho.Eventos.Presentation.Interfaces
{
    public interface IFindEventUseCase
    {
        public EventDomain Run(Guid id);
    }
}
