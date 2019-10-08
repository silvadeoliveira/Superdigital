using System.Collections.Generic;
using System.Linq;
using Superdigital.CoreShared.Extensions;

namespace Superdigital.CoreShared.ValueObjects
{
    public class UfVo
    {
        public string Estado { get; set; }

        public bool Validar()
        {
            if (!string.IsNullOrEmpty(Estado))
            {
                return ValidaUf();
            }
            return true;
        }

        private bool ValidaUf()
        {
            if (Estado.SomenteLetras().Length != 2) return false;
            if (Estado.SomenteNumeros().Length != 0) return false;
            var listaEstados = ObterEstados();
            if (listaEstados.All(x => x.Codigo != Estado))
            {
                return false;
            }
            return true;
        }

        public List<Estado> ObterEstados()
        {
            return new List<Estado>()
            {
                new Estado {Codigo = "AC"},
                new Estado {Codigo = "AL"},
                new Estado {Codigo = "AP"},
                new Estado {Codigo = "AM"},
                new Estado {Codigo = "BA"},
                new Estado {Codigo = "CE"},
                new Estado {Codigo = "DF"},
                new Estado {Codigo = "ES"},
                new Estado {Codigo = "GO"},
                new Estado {Codigo = "MA"},
                new Estado {Codigo = "MG"},
                new Estado {Codigo = "MT"},
                new Estado {Codigo = "MS"},
                new Estado {Codigo = "PA"},
                new Estado {Codigo = "PB"},
                new Estado {Codigo = "PI"},
                new Estado {Codigo = "PR"},
                new Estado {Codigo = "RJ"},
                new Estado {Codigo = "RN"},
                new Estado {Codigo = "RO"},
                new Estado {Codigo = "RR"},
                new Estado {Codigo = "SC"},
                new Estado {Codigo = "SE"},
                new Estado {Codigo = "SP"},
                new Estado {Codigo = "TO"},
            };
        }
    }
}