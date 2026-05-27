namespace Ticketinho.Vendas.Domains.ValueObjects
{
    public class Email
    {
        public string Value { get; private set; }

        public Email(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new Exception("Email não pode ser vazio.");
            if (!IsValidEmail(value))
                throw new Exception("Email inválido.");
            Value = value;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
