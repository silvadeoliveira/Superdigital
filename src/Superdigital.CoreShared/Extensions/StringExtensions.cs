using System;
using System.Globalization;
using System.Linq;

namespace Superdigital.CoreShared.Extensions
{
    public static class StringExtensions
    {
        public static string SomenteNumeros(this string strIn)
        {
            if (strIn != null)
            {
                var somenteNumeros = new String(strIn.Where(c => Char.IsDigit(c)).ToArray());
                return somenteNumeros;
            }
            return "";
        }

        public static string SomenteLetras(this string strIn)
        {
            if (strIn != null)
            {
                var somenteLetras = new String(strIn.Where(c => Char.IsLetter(c)).ToArray());
                return somenteLetras;
            }
            return "";
        }

        public static decimal ConvertDecimal(this string strIn, string masc)
        {
            var retorno = decimal.Parse(string.Format(CultureInfo.GetCultureInfo("pt-BR"), masc, strIn));
            return retorno;
        }

        public static string FormatoCpfCnpj(this string strIn)
        {
            if (strIn != null && strIn != "")
            {
                if (strIn.Length == 11)
                {
                    strIn = strIn.Insert(9, "-");
                    strIn = strIn.Insert(6, ".");
                    strIn = strIn.Insert(3, ".");
                    return strIn;
                }
                if (strIn.Length == 14)
                {
                    strIn = strIn.Insert(12, "-");
                    strIn = strIn.Insert(8, "/");
                    strIn = strIn.Insert(5, ".");
                    strIn = strIn.Insert(2, ".");
                    return strIn;
                }
            }
            return "";
        }

        public static string FormatoCep(this string strIn)
        {
            strIn = strIn.Insert(5, "-");
            return strIn;
        }

        public static string FormataTelefone(this string strIn)
        {
            if (strIn.Length == 8)
            {
                strIn = strIn.Insert(4, "-");
            }
            else
            {
                strIn = strIn.Insert(5, "-");
            }
            return strIn;
        }


    }
}
