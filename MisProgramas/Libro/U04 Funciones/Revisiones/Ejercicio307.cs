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
    static class Ejercicio307
    {
        static void Main()
        {
            Console.Write("Introduce un año: ");
            int año = Int32.Parse(Console.ReadLine());

            bool esBisiesto = EsBisiesto_v3(año);

            Console.WriteLine("El año {0} {1} es bisiesto.", !esBisiesto ? "no" : "");            
        }

        static bool EsBisiesto_v3(int año)
        {
            return año % 4 == 0 && (año % 100 != 0 || año % 400 == 0);
        }
        static bool EsBisiesto_v2(int año)
        {
            bool esBisiesto = false;
            if (año % 4 == 0)
                if (año % 400 == 0)
                    esBisiesto = true;
                else if (año % 100 == 0)
                    esBisiesto = false;
                else
                    esBisiesto = true;
            return esBisiesto;
        }
        static bool EsBisiesto(int año)
        {
            if (año % 4 != 0) return false;
            if (año % 400 == 0) return true;
            if (año % 100 == 0) return false;
            return true;
        }
    }
}
