namespace Superdigital.CoreShared.ValueObjects
{
    public class EmailVo
    {
        public string Endereco { get; set; }

        public bool Validar(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                return ValidarEmail(email);
            }
            return true;
        }

        private bool ValidarEmail(string email)
        {
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            email = email.Trim();
            if (System.Text.RegularExpressions.Regex.IsMatch(email, strModelo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}