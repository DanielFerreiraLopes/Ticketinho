using Microsoft.EntityFrameworkCore;
using Ticketinho.Eventos.Domains.Entities;
using Ticketinho.Eventos.Presentation.DTOs;

namespace Ticketinho.Eventos.Application.Interfaces
{
    public interface IEventRepository
    {
        public void AddEvent(EventDomain eventDomain);
        public List<EventDomain> GetEvents();

        public EventDomain FindById(Guid id);
    }
}
