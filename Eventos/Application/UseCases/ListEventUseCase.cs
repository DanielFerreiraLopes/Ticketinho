using Ticketinho.Eventos.Application.Interfaces;
using Ticketinho.Eventos.Domains.Entities;
using Ticketinho.Eventos.Presentation.DTOs;
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

        public List<EventResponse> Run()
        {
            try
            {
                List<EventDomain> events = _eventRepository.GetEvents();
                List<EventResponse> eventResponses = events.Select(e => _MapEventResponse(e)).ToList();

                return eventResponses;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na listagem de eventos: {ex.Message}");
            }
        }

        private EventResponse _MapEventResponse(EventDomain eventDomain)
        {
            return new EventResponse
            {
                Id = eventDomain.Id,
                Name = eventDomain.Name.Value,
                Description = eventDomain.Description.Value,
                Singer = eventDomain.Singer.Value,
                Price = eventDomain.Price.Value,
                EventDate = eventDomain.EventDate,
                MaxCapacity = eventDomain.MaxCapacity.Value,
                Available = eventDomain.Available,
                Location = eventDomain.Location.Value

            };
        }
    }
}
