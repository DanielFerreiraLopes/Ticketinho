using Ticketinho.Vendas.Domains.Entities;
using Ticketinho.Vendas.Presentation.DTOs;

namespace Ticketinho.Vendas.Presentation.Interfaces
{
    public interface IFindOrderUseCase
    {
        public OrderResponse Run(Guid id);
    }
}
