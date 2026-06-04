namespace Ticketinho.Eventos.Domains.ValueObjects
{
    public class Name
    {
        public string Value { get; private set; }

        public Name(string value)
        {
            if (value == null)
                throw new Exception("O campo Nome é obrigatório");
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("O campo Nome não pode ser vazio ou conter apenas espaços em branco");
            if (value.Length < 3)
                throw new Exception("O campo Nome deve conter no mínimo 3 caracteres");
            if (value.Length > 50)
                throw new Exception("O campo Nome deve conter no máximo 50 caracteres");
            Value = value;
        }
    }
}
