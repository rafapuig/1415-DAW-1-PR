using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.Iniciacion.Actividades
{
    static class Ejercicio10
    {
        static void Main()
        {
            Console.Write("Dame el primer numero: ");
            int a = Int32.Parse(Console.ReadLine());

            Console.Write("Dame el segundo numero: ");
            int b = Int32.Parse(Console.ReadLine());

            //bool esDivisor = a % b == 0 ? true : false;
            //bool esDivisor = a % b == 0;

            Console.WriteLine(
                "El segundo numero ({1} {2} es divisor del primero numero {0}", 
                a, b, a % b == 0 ? "" : "no");

            Console.ReadKey();
        }
    }
}
