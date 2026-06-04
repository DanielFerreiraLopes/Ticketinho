namespace Ticketinho.Eventos.Domains.ValueObjects
{
    public class Location
    {
        public string Value { get; private set; }
        public Location(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 5) 
                throw new Exception("Localização é obrigatória e deve ter no mínimo 5 caracteres.");
            Value = value;
        }
    }
}
