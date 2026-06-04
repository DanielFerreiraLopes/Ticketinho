namespace Ticketinho.Vendas.Domains.ValueObjects
{
    public class Quantity
    {
        public int Value { get; private set; }
        public Quantity(int value)
        {
            if (value <= 0)
                throw new Exception("A quantidade deve ser maior que zero.");
            Value = value;
        }   
    }
}
