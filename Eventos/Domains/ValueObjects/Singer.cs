namespace Ticketinho.Eventos.Domains.ValueObjects
{
    public class Singer
    {
        public string Value { get; private set; }
        public Singer(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new Exception("Nome do cantor é obrigatório.");
            Value = value;
        }
    }
}
