using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.Iniciacion.Actividades
{
    static class Ejercicio09
    {
        static void Main()
        {
            Console.Write("Dame el primer numero: ");
            int a = Int32.Parse(Console.ReadLine());

            Console.Write("Dame el segundo numero: ");
            int b = Int32.Parse(Console.ReadLine());

            int mayor = a > b ? a : b;

            Console.WriteLine("El mayor es {0}", mayor);

            Console.ReadKey();
        }
    }
}
