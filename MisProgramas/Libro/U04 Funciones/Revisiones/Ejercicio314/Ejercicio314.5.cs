using System;

namespace Programacion.Iniciacion.Actividades.Revisiones.Ejercicio14.V5
{
    //delegate bool PredicadoSobreInt(int n);
    delegate void AccionSobreInt(int n);

    static class Ejercicio314
    {
        static void Main()
        {
            AccionSobreInt accion = EscribirInt;
            Devolver(0, 100, i => i % 5 == 0 && i % 3 != 0, accion);
            Console.ReadKey();
        }

        static void EscribirInt(int n)
        {
            Console.WriteLine(n);
        }
        

        static void Devolver(int min, int max, Predicate<int> condicion, AccionSobreInt accion)
        {
            for (int i = min; i <= max; i++)
            {
                if (condicion(i))
                    accion(i);
            }
        }
    }
}
