namespace Ticketinho.Vendas.Domains.ValueObjects
{
    public class PaymentMethod
    {
        public string Value { get; private set; }
        public PaymentMethod(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Método de pagamento é obrigatório.");
            Value = value;
        }
    }
}
