using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.Iniciacion.Actividades.Revisiones.Ejercicio14.V10
{
    static class Ejercicio314
    {
        static void Main()
        {
            foreach (int num in Devolver(0, 100, i => i % 5 == 0 && i % 3 != 0))
            {
                Console.WriteLine(num);
            }
            Console.ReadKey();
        }

        static IEnumerable<int> Devolver(int min, int max, Predicate<int> condicion)
        {
            for (int i = min; i <= max; i++)
            {
                //if (i % 5 == 0 && i % 3 != 0)
                if(condicion(i))
                    yield return i;
            }
        }
    }
}
