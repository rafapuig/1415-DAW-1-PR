using System;
using System.Collections.Generic;
using System.Text;


namespace Programacion.Funciones.Actividades
{
    static class Ejercicio11
    {

        static void Main()
        {
            int numero;
            Console.WriteLine("Introduce numero: ");
            while (!Int32.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine("Numero incorrecto, repita por favor.");
            }

            Console.WriteLine("Numero invertido: {0}", Invertir(numero));
            Console.WriteLine("Es palindromo? {0}", EsPalindromo(numero) ? "Si" : "No");

            Console.ReadKey();
        }


        static string Invertir(int n)
        {
            //return (n % 10).ToString() + (n / 10 == 0 ? String.Empty : Invertir(n / 10));

            return string.Concat((n % 10).ToString(), n / 10 == 0 ? String.Empty : Invertir(n / 10));
        }

        static bool EsPalindromo(int n)
        {
            //return n.ToString() == Invertir(n);

            char[] cifras = n.ToString().ToCharArray();

            Array.Reverse(cifras);

            return n.ToString() == new String(cifras);
        }

        static bool EsPalindromo_v2(int n)
        {
            string sNum = n.ToString();

            for (int i = 0, j = sNum.Length - 1; i <= j; i++, j--)
            {
                if (sNum[i] != sNum[j]) return false;
            }
            return true;
        }
    

    }
}
