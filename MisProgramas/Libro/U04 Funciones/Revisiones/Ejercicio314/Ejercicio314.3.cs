using System;

namespace Programacion.Iniciacion.Actividades.Revisiones.Ejercicio14.V3
{
    //delegate bool PredicadoSobreInt(int n);

    static class Ejercicio314
    {
        static void Main()
        {
            Predicate<int> cond = i => i % 5 == 0 && i % 3 != 0;
            Devolver(0, 100, cond);
            Console.ReadKey();
        }
        

        static void Devolver(int min, int max, Predicate<int> condicion)
        {
            for (int i = min; i <= max; i++)
            {
                if (condicion(i))
                    Console.WriteLine(i);
            }
        }
    }
}
