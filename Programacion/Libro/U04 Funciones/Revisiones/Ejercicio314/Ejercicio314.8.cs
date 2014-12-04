using System;

namespace Programacion.Iniciacion.Actividades.Revisiones.Ejercicio14.V8
{

    static class Ejercicio314
    {
        static void Main()
        {

            Devolver(0, 100, i => i % 5 == 0 && i % 3 != 0, i => Console.WriteLine(i));
            Console.ReadKey();
        }


        static void Devolver(int min, int max, Predicate<int> condicion, Action<int> accion)
        {
            for (int i = min; i <= max; i++)
                if (condicion(i)) accion(i);
        }
    }
}
