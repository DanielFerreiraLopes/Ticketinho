namespace Ticketinho.Vendas.Application.Interfaces
{
    public interface IPaymentAdapter
    {
        public Task<bool> ProcessPayment(Guid orderId, double amount, string paymentMethod);
    }
}
