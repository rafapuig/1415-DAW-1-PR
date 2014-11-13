using System;
using System.Collections.Generic;
using System.Text;


namespace Programacion.Funciones.Actividades.Revision.Extension
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

            Console.WriteLine("Numero invertido: {0}", numero.Invertir());
            Console.WriteLine("Es palindromo? {0}", numero.EsPalindromo() ? "Si" : "No");

            Console.ReadKey();
        }


        static string Invertir(this int n)
        {
            return (n % 10).ToString() + (n / 10 > 0 ? Invertir(n / 10) : ""); 
        }
       
        static bool EsPalindromo(this int n)
        {
            return n.ToString() == n.Invertir();
        }

        static bool EsPalindromo_v2(this int n)
        {
            string sNum = n.ToString();

            for (int i = 0, j = sNum.Length; i <= j; i++, j--)
            {
                if (sNum[i] != sNum[j]) return false;
            }
            return true;
        }
    

    }
}
