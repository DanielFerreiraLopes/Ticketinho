using Ticketinho.Eventos.Application.Interfaces;
using Ticketinho.Eventos.Domains.Entities;
using Ticketinho.Eventos.Presentation.DTOs;
using Ticketinho.Eventos.Presentation.Interfaces;

namespace Ticketinho.Eventos.Application.UseCases
{
    public class FindEventUseCase : IFindEventUseCase
    {
        private readonly IEventRepository _eventRepository;
        public FindEventUseCase(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public EventResponse Run(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    throw new ArgumentException("Event ID cannot be empty.");
                if (id == null)
                    throw new ArgumentException("Event ID cannot be null1.");

                EventDomain eventDomain = _eventRepository.FindById(id);

                if (eventDomain == null)
                    throw new Exception("Nenhum evento encontrado.");

                return _MapEventResponse(eventDomain);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar evento: {ex.Message}");
            }
        }

        private EventResponse _MapEventResponse(EventDomain eventDomain){
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
