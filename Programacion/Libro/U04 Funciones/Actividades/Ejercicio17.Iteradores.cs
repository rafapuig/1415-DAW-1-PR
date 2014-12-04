using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.Funciones.Actividades.Ejercicio17.Iteradores
{
    static class CUI
    {
        static void Main()
        {
            int numero = GetNumero();

            foreach(int divisor in Logica.Divisores(numero))
            {
                Console.Write("{0} ", divisor);
            }
            Console.WriteLine();

            foreach (int divisor in numero.Divisores())
            {
                Console.Write("{0} ", divisor);
            }

            Console.ReadKey();
        }


        static int GetNumero()
        {
            int numero;
            bool esPositivo = false;

            Console.WriteLine("Introduce un numero por teclado: ");
            do
            {
                string entrada;

                entrada = Console.ReadLine();
                bool esNumero = Int32.TryParse(entrada, out numero);
                if (!esNumero)
                    Console.WriteLine("No se puede extraer numero de la entrada proporcionada.");
                else
                {
                    esPositivo = numero > 0;
                    if (!esPositivo) Console.WriteLine("Debe proporcionar un numero positivo.");
                }
            } while (!esPositivo);

            return numero;
        }        
    }

    static class Logica
    {
        public static IEnumerable<int> Divisores(this int num)
        {
            for (int i = 1; i <= num; i++)
            {
                //if(EsDivisor(i,num))
                if (i.EsDivisor(num))
                    yield return i;
            }
        }

        public static bool EsDivisor(this int divisor, int numero)
        {
            return numero % divisor == 0;
        }
    }

}
