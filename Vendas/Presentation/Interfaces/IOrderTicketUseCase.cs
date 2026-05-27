using Ticketinho.Vendas.Domains.Entities;
using Ticketinho.Vendas.Presentation.DTOs;

namespace Ticketinho.Vendas.Presentation.Interfaces
{
    public interface IOrderTicketUseCase
    {
        public void Run(ComprarIngressoRequest request);
    }
}
