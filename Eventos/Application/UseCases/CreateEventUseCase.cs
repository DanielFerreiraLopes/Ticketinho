using Ticketinho.Eventos.Application.Interfaces;
using Ticketinho.Eventos.Domains.Entities;
using Ticketinho.Eventos.Presentation.DTOs;
using Ticketinho.Eventos.Presentation.Interfaces;
using Ticketinho.Eventos.Repositories;

namespace Ticketinho.Eventos.Application.UseCases
{
    public class CreateEventUseCase : ICreateEventUseCase
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventUseCase(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public void Run(CreateEventRequest request)
        {

            EventDomain eventDomain = new EventDomain(
                Guid.NewGuid(),
                request.Name,
                request.Description,
                request.Singer,
                request.Price,
                request.EventDate,
                request.MaxCapacity,
                request.Available,
                request.Location
            );
            try
            {
                if (eventDomain == null)
                    throw new ArgumentException("Evento não pode ser null.");

                _eventRepository.AddEvent(eventDomain);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro criando Evento: {ex.Message}");
            }
        }
    }
}
