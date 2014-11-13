using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.Funciones.Actividades
{
    class Ejercicio21
    {
        static void Main()
        {
            int num = GetNumeroPositivoDeMaximo5Cifras();

            int suma = SumarCifras(num);

            Console.WriteLine("La suma de los {0} primeros numeros es {1}", num, suma);
            Console.ReadKey();
        }

        static int GetNumeroPositivoDeMaximo5Cifras()
        {
            int numero;
            string entrada;
            bool esPositivo = false;
            bool tiene5CifrasMaximo = false;
            Console.WriteLine("Introduce un numero");
            while (!Int32.TryParse(entrada=Console.ReadLine(), out numero)
                    || !(esPositivo = numero >= 0)
                    || !(tiene5CifrasMaximo = numero.ToString().Length <= 5))
            {
                Console.WriteLine("El numero introducido no es valido");
                if (!esPositivo) Console.WriteLine("El numero no es positivo");
                if (!tiene5CifrasMaximo) Console.WriteLine("El tiene mas de 5 cifras");
            }
            return numero;
        }
               

        /// <summary>
        /// La suma de las cifras de un numero de n cifras es 
        /// la cifra mas a derecha + la suma de las cifras de ese numero sin su cifra mas a la derecha
        /// </summary>
        /// <param name="n">numero del cual se va a obtener la suma de sus cifras</param>
        /// <returns></returns>
        static int SumarCifras(int n)
        {
            return n % 10 + (n / 10 == 0 ? 0 : SumarCifras(n / 10));
        }

        /// <summary>
        /// Es una version mas "verbosa" que la anterior pero equivalente
        /// Suma las cifras del numero desde la menos significativa (derecha)
        /// hasta la mas significativa
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int SumarCifras_v1(int n)
        {
            int suma = n % 10;
            if (n / 10 == 0)
                suma += SumarCifras_v1(n / 10);

            return suma;
        }

        /// <summary>
        /// Esta version suma recursivamente desde la cifra mas significativa (izquierda
        /// hasta la menos significativa (derecha)
        /// </summary>
        /// <param name="n">numero de cinco cifras</param>
        /// <returns></returns>
        static int SumarCifras_v2(int n)
        {
            if (n / 10 == 0) return n % 10;
            else return SumarCifras_v2(n / 10) + n % 10;
        }
    }
}
