namespace Ticketinho.Eventos.Domains.ValueObjects
{
    public class MaxCapacity
    {
        public int Value { get; private set; }
        public MaxCapacity(int value)
        {
            if (value <= 0) throw new Exception("A capacidade máxima do evento deve ser maior que zero.");
            this.Value = value;
        }
    }
}
