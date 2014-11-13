using System;

namespace Programacion.Iniciacion.Actividades
{
    static class Ejercicio16
    {
        static void Main()
        {
            int lado;
            Console.Write("Introduce el lado del cuadrado: ");
            while (!Int32.TryParse(Console.ReadLine(), out lado) || lado <= 0 || lado > 20)
                Console.WriteLine("Valor introducido incorrecto, introduce un numero entre 0 y 20");

            for (int i = 0; i < lado; i++) //Bucle para repetirse por cada fila
            {
                for (int j = 0; j < lado; j++)
                {
                    if (i == 0 || i == lado - 1)    //Si es la primera o ultima fila todo figuras
                        Console.Write("@");
                    else                            //si no solo la primera y ultima columnas
                        Console.Write(j == 0 || j == lado - 1 ? "@" : " ");

                    //Otra forma de hacerlo sin el if
                    //Console.Write(i == 0 || i == lado - 1 || j == 0 || j == lado - 1 ? "@" : " ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
