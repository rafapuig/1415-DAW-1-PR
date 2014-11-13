using System;

namespace Programacion.Iniciacion.Ejemplos
{
    static class Sumar
    {
        static void Main()
        {
            int sumando1;     //Declara una variable de tipo entero
            int sumando2;
            int suma;
            string entrada = "";

            try
            {
                Console.WriteLine("Introduce sumando 1 sin decimales");
                entrada = Console.ReadLine(); //Leer entrada de teclado hasta que se pulsa intro
                sumando1 = int.Parse(entrada);    //Extrae del texto de entrada un valor entero y lo guarda en la variable numero

                Console.WriteLine("Introduce sumando 2 sin decimales");
                entrada = System.Console.ReadLine(); //Leer entrada de teclado hasta que se pulsa intro
                sumando2 = int.Parse(entrada);    //Extrae del texto de entrada un valor entero y lo guarda en la variable numero

                suma = sumando1 + sumando2;
                Console.WriteLine("El resulado de sumar {0} + {1} es: {2}", sumando1, sumando2, suma);
            }
            catch (System.FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("{0} no es un numero valido.", entrada);
            }
            finally
            {
                Console.ReadKey();
            }

        }
    }

}