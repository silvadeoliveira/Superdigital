using Superdigital.CoreShared.Extensions;

namespace Superdigital.CoreShared.ValueObjects
{
    public class CepVo
    {
        public string Codigo { get; set; }

        public bool Validar()
        {
            return string.IsNullOrEmpty(Codigo) || ValidaCep(Codigo);
        }

        private bool ValidaCep(string cep)
        {
            if (cep.SomenteLetras().Length != 0) return false;
            return cep.SomenteNumeros().Length == 8;
        }
    }
}