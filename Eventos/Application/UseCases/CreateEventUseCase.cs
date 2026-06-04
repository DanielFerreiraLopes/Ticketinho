using Ticketinho.Eventos.Application.Interfaces;
using Ticketinho.Eventos.Domains.Entities;
using Ticketinho.Eventos.Domains.ValueObjects;
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
                new Name(request.Name),
                new Description(request.Description),
                new Singer(request.Singer),
                new Price(request.Price),
                request.EventDate,
                new MaxCapacity(request.MaxCapacity),
                request.Available,
                new Location(request.Location)
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
