using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.Funciones.Actividades
{

    static class Ejercicio22
    {
        static void Main()
        {
            int num = GetNumeroPositivoDeMaximo10Cifras();

            int digitos = TotalDigitos(num); //num.TotalDigitos();

            Console.WriteLine("El numero {0} tiene {1} digitos", num, digitos);
            Console.ReadKey();
        }


        static int GetNumeroPositivoDeMaximo10Cifras()
        {
            int numero;
            string entrada;
            bool esPositivo = false;
            bool tiene10CifrasMaximo = false;
            Console.WriteLine("Introduce un numero");
            while (!Int32.TryParse(entrada = Console.ReadLine(), out numero)
                    || !(esPositivo = numero >= 0)
                    || !(tiene10CifrasMaximo = numero.ToString().Length <= 10))
            {
                Console.WriteLine("El numero introducido no es valido");
                if (!esPositivo) Console.WriteLine("El numero no es positivo");
                if (!tiene10CifrasMaximo) Console.WriteLine("El tiene mas de 10 cifras");
            }
            return numero;
        }

        public static int TotalDigitos(this int n)
        {
            return n / 10 == 0 ? 1 : 1 + TotalDigitos(n / 10);

            //if (n / 10 == 0) return 1;
            //else return 1 + TotalDigitos(n / 10);
        }

    }


}
