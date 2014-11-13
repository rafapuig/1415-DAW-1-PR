using System;
using System.Collections.Generic;
using System.Linq;

namespace Programacion.Iniciacion.Actividades.Revisiones.Ejercicio14.V2
{
    delegate bool PredicadoSobreInt(int n);

    static class Ejercicio314
    {
        static void Main()
        {
            PredicadoSobreInt cond = i => i % 5 == 0 && i % 3 != 0;
            Devolver(0, 100, cond);
            Console.ReadKey();
        }

        //static bool SerMultiploDe5YNoDe3(int i)
        //{
        //    return i % 5 == 0 && i % 3 != 0;
        //}

        static void Devolver(int min, int max, PredicadoSobreInt condicion)
        {
            for (int i = min; i <= max; i++)
            {
                if (condicion(i))
                    Console.WriteLine(i);
            }
        }
    }
}
