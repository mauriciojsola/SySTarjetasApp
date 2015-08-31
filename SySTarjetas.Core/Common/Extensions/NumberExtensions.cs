using System;

namespace SySTarjetas.Core.Common.Extensions
{
    public static class NumberExtensions
    {
        public static bool EsNumero(this string current)
        {
            // trato de convertirlo a decimal, que es el que funciona con todos
            try
            {
                decimal.Parse(current);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static int ToInt32(this string current)
        {
            return int.Parse(current);
        }

    }
}
