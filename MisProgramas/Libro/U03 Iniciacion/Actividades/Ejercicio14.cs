using System;

namespace Programacion.Iniciacion.Actividades
{
    static class Ejercicio14
    {
        static void Main()
        {
            int min = 0;
            int max = 100;

            for (int i = min; i <= max; i++)
            {
                if (i % 5 == 0 && i % 3 != 0)
                    Console.WriteLine(i);
            }
        }
    }
}
