using Ticketinho.Vendas.Domains.Entities;

namespace Ticketinho.Vendas.Presentation.Interfaces
{
    public interface IFindOrderUseCase
    {
        public OrderDomain Run(Guid id);
    }
}
