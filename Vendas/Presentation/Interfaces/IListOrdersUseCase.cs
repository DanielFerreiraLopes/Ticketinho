using Ticketinho.Vendas.Domains.Entities;
using Ticketinho.Vendas.Presentation.DTOs;

namespace Ticketinho.Vendas.Presentation.Interfaces
{
    public interface IListOrdersUseCase
    {
        public List<OrderResponse> Run();
    }
}
