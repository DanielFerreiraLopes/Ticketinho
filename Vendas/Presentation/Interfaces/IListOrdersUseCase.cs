using Ticketinho.Vendas.Domains.Entities;

namespace Ticketinho.Vendas.Presentation.Interfaces
{
    public interface IListOrdersUseCase
    {
        public List<OrderDomain> Run();
    }
}
