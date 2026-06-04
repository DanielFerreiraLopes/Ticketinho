namespace Ticketinho.Vendas.Domains.ValueObjects
{
    public class TicketsSold
    {
        public int Value { get; private set; }
        public TicketsSold(int value)
        {
            if (value < 0)
                throw new Exception("O número de ingressos vendidos não pode ser negativo.");
            Value = value;
        }
    }
}
