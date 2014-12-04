using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.Iniciacion.Actividades
{
    static class Ejercicio15
    {
        static void Main()
        {
            double x;
            Console.Write("Introduce el valor x de la base de la potencia: ");
            while (!Double.TryParse(Console.ReadLine(), out x))
                Console.WriteLine("Valor introducido incorrecto, introduce un numero.");

            int y;
            Console.Write("Introduce el valor y del expomente de la potencia: ");
            while (!Int32.TryParse(Console.ReadLine(), out y))
                Console.WriteLine("Valor introducido incorrecto, introduce un numero sin decimales.");

            double potencia = 1.0;  //En la variable potencia se acumularan las multiplicaciones de la base

            for (int i = 0; i < y; i++) //Un bucle que se repite y veces (desde 0 hasta y-1)
            {
                potencia *= x;  //Cada vez que operamos se multiplica la base por el resultado acumulado de las mults anteriores
            }

            Console.WriteLine("El numero {0} elevado a {1} es igual a {2}", x, y, potencia);
            Console.ReadKey();

        }
    }
}
