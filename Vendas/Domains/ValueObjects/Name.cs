namespace Ticketinho.Vendas.Domains.ValueObjects
{
    public class Name
    {
        public string Value { get; private set; }

        public Name(string value) { 
            if (value == null) 
                throw new Exception("O campo Nome é obrigatório");
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("O campo Nome não pode ser vazio ou conter apenas espaços em branco");
            if (value.Length < 3)
                throw new Exception("O campo Nome deve conter no mínimo 3 caracteres");
            if (value.Length > 100)
                throw new Exception("O campo Nome deve conter no máximo 100 caracteres");
            if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^[a-zA-Z\s]+$"))
                throw new Exception("O Nome não pode ter número ou caracteres especiais");
            Value = value;
        }
    }
}
