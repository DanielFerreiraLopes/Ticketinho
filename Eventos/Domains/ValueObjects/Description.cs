namespace Ticketinho.Eventos.Domains.ValueObjects
{
    public class Description
    {
        public string Value { get; private set; }
        public Description(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception("Descrição do evento é obrigatória.");
            }
            Value = value;
        }
    }
}
