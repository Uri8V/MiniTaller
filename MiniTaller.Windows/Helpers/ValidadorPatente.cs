using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Windows.Helpers
{
    public static class ValidadorPatente
    {
        public static bool Validar(string s)
        {
            return VerificarFormato(s);
        }

        private static bool VerificarFormato(string s)
        {
            if (s == null || (s.Length != 7 && s.Length != 9))
            {
                return false;
            }
            if (s.Length == 9)
            {
                return ValidadorPatenteNueva(s);
            }
            else
            {
                return ValidadorPatenteVieja(s);
            }

        }
        private static bool ValidadorPatenteNueva(string patente) //AA 111 AA
        {
            string[] array = new string[9];
            if (patente.Contains("-"))
            {
                array = patente.Split('-');
            }
            else
            {
                 array = patente.Split(' ');

            }
            var parteAlfabetica = array[0];
            var parteNumerica = array[1];
            var parteAlfa = array[2];

            return validarParteAlfabetica(parteAlfabetica) && ValidarParNumerica(parteNumerica) && validarParteAlfabetica(parteAlfa);
        }
        private static bool ValidadorPatenteVieja(string patente)
        {
            string[] array = new string[7];
            if (patente.Contains("-"))
            {
                array = patente.Split('-');
            }
            else
            {
                array = patente.Split(' ');

            }
            var parteAlfabetica = array[0];
            var parteNumerica = array[1];

            return validarParteAlfabetica(parteAlfabetica) && ValidarParNumerica(parteNumerica);
        }

        private static bool ValidarParNumerica(string parteNumerica)
        {
            foreach (var item in parteNumerica)
            {
                if (!char.IsNumber(item))
                {
                    return false;
                }

            }
            return true;
        }

        private static bool validarParteAlfabetica(string parteAlfabetica)
        {
            foreach (var item in parteAlfabetica)
            {
                if (!char.IsLetter(item))
                {
                    return false;
                }

            }
            return true;
        }

        public static string GetTipo(string s)
        {
            if (s == null)
            {
                return "Patente no ingresada";
            }
            else if (s.Length == 7)
            {
                return "La patente tiene un formato viejo";
            }
            else if (s.Length == 9)
            {
                return "La patente tiene un formato nuevo";
            }
            else
            {
                return "Formato no valido";
            }
        }
    }
}
