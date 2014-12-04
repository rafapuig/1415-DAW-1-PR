using System;

namespace Programacion.Iniciacion.Actividades
{
    delegate long AlgoritmoFactorial(int n);
    static class Ejercicio308
    {
        static void Main()
        {
            CalcularFactorial(CalcularFactorialMetodoIterativo);

            CalcularFactorial(FactorialRecursivo);  

            Console.ReadKey();
        }

        static void CalcularFactorial(AlgoritmoFactorial factorial)
        {
            Console.Write("Introduce un numero: ");
            int n = System.Int32.Parse(Console.ReadLine());
            
            long fact = factorial(n);

            Console.WriteLine("Metodo Iterativo: Factorial({0}={1})", n, fact);
        }

        static long CalcularFactorialMetodoIterativo(int n)
        {
            long factorial = 1;
            for(int i=2; i<=n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        /// <summary>
        /// Calculo del factorial de n (version recursiva)
        /// </summary>
        static long FactorialRecursivo(int n)
        {
            if (n == 0) return 1;
            return n * FactorialRecursivo(n - 1);
        }
    }
}
