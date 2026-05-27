using Ticketinho.Eventos.Domains.Entities;
using Ticketinho.Eventos.Presentation.DTOs;

namespace Ticketinho.Eventos.Presentation.Interfaces
{
    public interface ICreateEventUseCase
    {
        public void Run(CreateEventRequest request);

    }
}
