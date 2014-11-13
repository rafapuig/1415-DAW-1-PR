using System;

namespace Programacion.Iniciacion.Actividades
{
    /// <summary>
    /// Realice un programa que calcule el factorial de un numero dado por el usuario
    /// </summary>
    static class Ejercicio308
    {
        static void Main()
        {
            Console.Write("Introduce un numero: ");
            int n = System.Int32.Parse(Console.ReadLine());

            long factorial = 1;
            int i = 2;
            while (i <= n)
            {
                factorial = factorial * i++;
            }            

            Console.WriteLine("Factorial({0}={1})", n, factorial);
            Console.ReadKey();
        }

    }
}
