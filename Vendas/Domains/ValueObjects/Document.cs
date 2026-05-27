namespace Ticketinho.Vendas.Domains.ValueObjects
{
    public class Document
    {
        public long Value { get; private set; }
        public Document(long value)
        {
            if (value == 0)
                throw new Exception("CPF não pode ser vazio.");
            if (value.ToString().Length != 11)
                throw new Exception("CPF inválido.");
            Value = value;
        }
    }
}
