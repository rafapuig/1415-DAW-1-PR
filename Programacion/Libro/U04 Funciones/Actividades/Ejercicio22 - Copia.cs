using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.Funciones.Actividades.Sucio
{

    static class Ejercicio22
    {
        static void Main()
        {
            int num = GetNumeroPositivoDeMaximo10Cifras();

            int digitos = TotalDigitos(num);

            Console.WriteLine("El numero {0} tiene {1}", num, digitos);
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
                if (!tiene10CifrasMaximo) Console.WriteLine("El tiene mas de 5 cifras");
            }
            return numero;
        }

        public static int TotalDigitos(this int n)
        {
            if (n / 10 == 0) return 1;
            else return 1 + TotalDigitos(n / 10);
        }


        //int maxCifras = 10;
        //Predicate<int> positivo = i => i >= 0;
        //Predicate<int> deMaxCifras = i => i.ToString().Length <= maxCifras;

        //static int GetNumeroPositivoDeMaximo10Cifras(params Predicate<int>[] condiciones)
        //{
        //    bool ok = true;
        //    foreach (var p in condiciones)
        //    {
        //        ok = ok && p(5);
        //        if (!ok) break;
        //    }

        //    int numero;
        //    string entrada;
        //    bool esPositivo = false;
        //    bool tiene10CifrasMaximo = false;
        //    Console.WriteLine("Introduce un numero");
        //    while (!Int32.TryParse(entrada = Console.ReadLine(), out numero)
        //            || !(esPositivo = numero >= 0)
        //            || !(tiene10CifrasMaximo = numero.ToString().Length <= 10))
        //    {
        //        Console.WriteLine("El numero introducido no es valido");
        //        if (!esPositivo) Console.WriteLine("El numero no es positivo");
        //        if (!tiene10CifrasMaximo) Console.WriteLine("El tiene mas de 5 cifras");
        //    }
        //    return numero;
        //}

    }


}
