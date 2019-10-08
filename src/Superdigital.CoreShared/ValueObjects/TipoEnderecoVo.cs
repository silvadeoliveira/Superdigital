using System.Collections.Generic;
using System.Linq;

namespace Superdigital.CoreShared.ValueObjects
{
    public class TipoEnderecoVo
    {
        public string Tipo { get; set; }

        public bool Validar(string tipo)
        {
            if (!string.IsNullOrEmpty(tipo))
            {
                return ValidaTipo(tipo);
            }
            return true;
        }

        private bool ValidaTipo(string tipo)
        {
            var listaTipo = GetTipo();
            if (listaTipo.All(x => x.Tipo != tipo))
            {
                return false;
            }
            return true;
        }

        public List<TipoEnderecos> GetTipo()
        {
            return new List<TipoEnderecos>()
            {
                new TipoEnderecos { Tipo = "Comercial"},
                new TipoEnderecos { Tipo = "Entrega"},
                new TipoEnderecos { Tipo = "Residencial"},
            };
        }
    }
}