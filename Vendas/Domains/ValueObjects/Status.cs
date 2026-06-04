namespace Ticketinho.Vendas.Domains.ValueObjects
{
    public class Status
    {
        public int Value { get; private set; }
        public Status(int value)
        {
            if (value != 0 && value != 1 && value != 2)
                throw new Exception("Status inválido.");

            // O status 0 representa "Pendente", 1 representa "Aprovado" e 2 representa "Cancelado".
            Value = value;
        }
    }
}
