using Ticketinho.Vendas.Domains.Entities;

namespace Ticketinho.Vendas.Presentation.Interfaces
{
    public interface IGetTicketsByDocumentUseCase
    {
        public List<OrderTicket> Run(long document);
    }
}
