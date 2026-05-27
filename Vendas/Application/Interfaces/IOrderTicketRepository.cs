using Microsoft.EntityFrameworkCore;
using Ticketinho.Infrastructure.Entities;
using Ticketinho.Vendas.Domains.Entities;

namespace Ticketinho.Vendas.Application.Interfaces
{
    public interface IOrderTicketRepository
    {
        public void AddTicket(long ticketNumber, Guid orderId);

        public List<OrderTicket> GetTickets();

        public OrderTicket FindById(Guid id);

        public List<OrderTicket> GetByOrderId(Guid orderId);
    }
}
