using Microsoft.AspNetCore.Mvc;
using Ticketinho.Vendas.Presentation.DTOs;
using Ticketinho.Vendas.Presentation.Interfaces;

namespace Ticketinho.Vendas.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderTicketUseCase _orderTicketUseCase;
        private readonly IGetTicketsByDocumentUseCase _getTicketsByDocumentUseCase; 
        private readonly IListOrdersUseCase _listOrdersUseCase;
        private readonly IFindOrderUseCase _findOrderUseCase;

        public OrderController(IOrderTicketUseCase orderTicketUseCase, IGetTicketsByDocumentUseCase getTicketsByDocumentUseCase, IListOrdersUseCase listOrdersUseCase, IFindOrderUseCase findOrderUseCase)
        {
            _orderTicketUseCase = orderTicketUseCase;
            _getTicketsByDocumentUseCase = getTicketsByDocumentUseCase;
            _listOrdersUseCase = listOrdersUseCase;
            _findOrderUseCase = findOrderUseCase;
        }

        [HttpPost("ComprarIngresso")]
        public IActionResult ComprarIngresso([FromBody] ComprarIngressoRequest request)
        {
            try
            {
                _orderTicketUseCase.Run(request);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Comprar: {ex.Message}");
            }
        }

        [HttpGet("BuscarPorDocumento")]
        public IActionResult BuscarPorDocumento([FromQuery] long document)
        {
            try
            {
                var tickets = _getTicketsByDocumentUseCase.Run(document);
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Buscar: {ex.Message}");
            }
        }

        [HttpGet("ListarOrders")]
        public IActionResult ListarOrders()
        {
            try
            {
                var orders = _listOrdersUseCase.Run();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Listar: {ex.Message}");
            }
        }

        [HttpGet("BuscarOrder")]
        public IActionResult BuscarOrder([FromQuery] Guid id)
        {
            try
            {
                var order = _findOrderUseCase.Run(id);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Buscar: {ex.Message}");
            }
        }
    }
}
