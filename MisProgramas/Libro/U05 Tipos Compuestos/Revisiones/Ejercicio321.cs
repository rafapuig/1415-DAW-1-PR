using System;
using System.Collections.Generic;

namespace Programacion.Iniciacion.Actividades
{
    static class Ejercicio321
    {

        static void MainOld()
        {
            Console.Write("Introduce un numero: ");
            ulong numero = UInt64.Parse(Console.ReadLine());

            ulong factor = TestPrimo(numero);
            bool esPrimo = EsPrimo(numero);           

            Console.WriteLine("{0} es {1}primo", numero, !esPrimo ? "no " : "");
            if (!esPrimo)
                Console.WriteLine("Es divisible por {0}", factor);
            Console.ReadKey();           
        }

        static void Main()
        {
            Console.Write("Introduce un numero: "); //1234567890
            ulong numero = UInt64.Parse(Console.ReadLine());

            ulong factor = TestPrimo(numero);
            bool esPrimo = EsPrimo(numero);

            Console.WriteLine("{0} es {1}primo", numero, !esPrimo ? "no " : "");
            if (!esPrimo)
                Console.WriteLine("Es divisible por {0}", factor);


            ulong primo = GenerarPrimo(numero);
            Console.WriteLine("Numero primo: {0}", primo);

            Console.ReadKey();

            ListarPrimos(numero); 

            Console.ReadKey();
        }
                

        //static List<int> primos = new List<int>();
        //Ejercicio21()
        //{
        //    primos.Add(1);
        //}

        //static bool Primo(int num)
        //{
        //    int tope = (int)Math.Sqrt(num);
        //    int maxPrimo =primos.Max();
            
        //    if (primos.Max() > tope)
        //    {
        //        foreach (var p in primos)
        //        {
        //            if (num % p == 0) return false;
        //        }
        //    }
        //    for (int i = primos.Max(); i < tope; i++)
        //        {
        //            bool nuevoPrimo = true;
        //            foreach (var p in primos)
        //            {
        //                if (i % p == 0)
        //                    nuevoPrimo = false;
        //            }
        //            if (nuevoPrimo)
        //                primos.Add(i);
        //        }
        //    }

        

        static void ListarPrimos(ulong max)
        {
            bool esPrimero = true;
            for (ulong i = 1; i <= max; i++)
            {
                ulong divisor = TestPrimo(i);
                if (divisor == 1)
                {
                    Console.Write("{1}{0,9}", i, !esPrimero ? "," : "");
                    esPrimero = false;
                }
            }
        }

        /// <summary>
        /// Comprueba si un numero es divisible por algun numero mayor que 1 (si no, es primo)
        /// </summary>
        /// <param name="num">Numero del que se quiere extraer el divisor</param>
        /// <returns>Devuelve el primer divisor encontrado para el numero dado distinto de 1, 
        /// si es primo devuelve un 1</returns>
        static ulong TestPrimo(ulong num)
        {
            if (num == 2 || num == 3 || num == 5) return 1;

            if (num % 2 == 0) return 2;
            if (num % 3 == 0) return 3;
            if (num % 5 == 0) return 5;
            
            ulong divisor = 2;          

            if (num % divisor == 0) return divisor;

            for (divisor = 7; divisor < (ulong)Math.Sqrt(num) + 1; divisor += 2)
                if (num % divisor == 0) return divisor;
            
            return 1;
        }


        static List<ulong> Primos = new List<ulong>() { 7, 11, 13 };
        static ulong TestPrimo2(ulong num)
        {
            if (num == 2 ||num == 3 || num ==5) return 1;
            
            //if (Primos.BinarySearch(num)) return 1;

            ulong divisor;
            if (num % 2 == 0) return 2;
            if (num % 3 == 0) return 3;
            if (num % 5 == 0) return 5;

            ulong tope = (ulong)Math.Sqrt(num) + 1;

            divisor = 2;

            foreach (ulong primo in Primos)
            {
                divisor = primo;
                if (divisor >= tope) break;
                if (num % divisor == 0) return divisor;
            }            

            for (divisor = divisor % 2 == 0 ? divisor++ : divisor += 2; divisor < tope; divisor += 2)
                if (num % divisor == 0) return divisor;

            if (num > 13)
            {
                int index = Primos.BinarySearch(num);
                Primos.Insert(~index, num);
            }

            return 1;
        }

        static ulong TestPrimo3(ulong num)
        {
            if (num == 2) return 1;
            if (num % 2 == 0) return 2;

            ulong tope = num / 2;
            ulong d = 3;
            while (d < tope)
            {
                if (num % d == 0) return d;
                d += 2;
            }
            return 1;
        }

        static bool EsPrimo(ulong num)
        {
            return TestPrimo(num) == 1;
        }

        static ulong GenerarPrimo(ulong semilla)
        {
            if (semilla % 2 == 0) semilla++;
            do
            {
                if (EsPrimo(semilla)) return semilla;
                semilla++;

            } while (true);
        }
    }
}
