using Ticketinho.Eventos.Application.Interfaces;
using Ticketinho.Eventos.Domains.Entities;
using Ticketinho.Eventos.Presentation.Interfaces;

namespace Ticketinho.Eventos.Application.UseCases
{
    public class ListEventUseCase : IListEventUseCase
    {
        private readonly IEventRepository _eventRepository;

        public ListEventUseCase(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public List<EventDomain> Run()
        {
            try
            {
                List<EventDomain> events = _eventRepository.GetEvents();
                return events;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na listagem de eventos: {ex.Message}");
            }
        }

    }
}
