using Microsoft.AspNetCore.Mvc;
using Ticketinho.Eventos.Domains.Entities;
using Ticketinho.Eventos.Presentation.DTOs;
using Ticketinho.Eventos.Presentation.Interfaces;

namespace Ticketinho.Eventos.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {

        private readonly ICreateEventUseCase _createEventUseCase;
        private readonly IListEventUseCase _listEventUseCase;
        private readonly IFindEventUseCase _findEventUseCase;

        public EventsController(
            ICreateEventUseCase createEventUseCase,
            IListEventUseCase listEventUseCase,
            IFindEventUseCase findEventUseCase)
        {
            _createEventUseCase = createEventUseCase;
            _listEventUseCase = listEventUseCase;
            _findEventUseCase = findEventUseCase;
        }

        [HttpGet("ListarEventos")]
        public IActionResult ListarEventos()
        {
            List<EventDomain> events = _listEventUseCase.Run();
            return Ok(events);
        }

        [HttpGet("BuscarEvento")]
        public IActionResult BuscarEvento([FromQuery] Guid id)
        {
            EventDomain eventFinded = _findEventUseCase.Run(id);
            return Ok(eventFinded);
        }

        [HttpPost("CriarEvento")]
        public IActionResult CriarEvento([FromBody] CreateEventRequest request)
        {
            try
            {
                _createEventUseCase.Run(request);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Criar: {ex.Message}");
            }
        }

        [HttpPut("EditarEvento")]
        public IActionResult EditarEvento([FromQuery] Guid id, [FromBody] CreateEventRequest eventDTO)
        {
            //UseCase para Editar eventos
            return Ok();
        }
    }
}
