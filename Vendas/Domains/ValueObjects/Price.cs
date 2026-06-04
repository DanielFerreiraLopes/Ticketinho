namespace Ticketinho.Vendas.Domains.ValueObjects
{
    public class Price
    {
        public double Value { get; private set; }
        public Price(double value)
        {
            if (value <= 0)
                throw new Exception("O preço deve ser maior que zero.");
            Value = value;
        }
    }
}
