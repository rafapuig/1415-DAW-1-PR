using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.Iniciacion.Actividades
{
    /// <summary>
    /// Realiza un programa que pida al usuario un año y muestre por pantalla si este es bisiesto
    /// </summary>
    static class Ejercicio07
    {
        static void Main()
        {
            Console.Write("Introduce un año: ");
            int año = Int32.Parse(Console.ReadLine());

            bool esBisiesto = false;

            if (año % 100 != 0 && año % 4 == 0 || año % 400 == 0)
                esBisiesto = true;

            //bool esBisiesto = año % 4 == 0 && (año % 100 != 0 || año % 400 == 0);

            Console.WriteLine("El año {0} {1} es bisiesto.", !esBisiesto ? "no" : "");
        }
       
    }
}
