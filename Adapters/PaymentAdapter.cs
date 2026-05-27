using Ticketinho.Vendas.Application.Interfaces;

namespace Ticketinho.Adapters
{
    public class PaymentAdapter : IPaymentAdapter
    {
        private readonly string _paymentServiceUrl;

        public PaymentAdapter()
        {
            _paymentServiceUrl = "https://26159a3e-d164-400d-a521-828664164bfc.mock.pstmn.io";
        }

        public async Task<bool> ProcessPayment(Guid orderId, double amount, string paymentMethod)
        {
            var paymentRequest = new
            {
                OrderId = orderId,
                Amount = amount,
                PaymentMethod = paymentMethod
            };

            var httpCliente = new HttpClient();

            var response = await httpCliente.PostAsJsonAsync($"{_paymentServiceUrl}/enviarPagamento", paymentRequest);
            if (response.IsSuccessStatusCode)
            {
                return true; //Pagamento feito com sucesso
            }
            else
            {
                return false; //Tá duro dorme
            }
        }

    }
}
