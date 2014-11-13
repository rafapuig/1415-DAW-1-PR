using System;

namespace Programacion.TiposCompuestos.Ordenacion
{
    static class SeleccionDirectaDemo
    {
        static Random alea = new Random();

        static void Main()
        {
            Console.Title = "Algoritmos de ordenacion - Seleccion Directa";
            SeleccionDirectaTest();
            TestSeleccionDirectaPerformance();          
            Console.ReadKey();
        }
       
        
        static void SeleccionDirectaTest()
        {
            int[] numeros = { 12, 5, 3, 13, 2, 9, 7 };
            
            //numeros.SeleccionDirecta();
            //numeros.SeleccionDirecta(null, null, MostrarIntermedioSeleccionDirecta);
            numeros.Ordenar(show: MostrarIntermedioSeleccionDirecta);
             
            Console.WriteLine();
            Console.WriteLine(String.Join(", ", numeros));  
        }
        
        /// <summary>
        /// Muestra el array en proceso de ordenacion
        /// </summary>
        /// <param name="elems">array en proceso de ordenacion</param>
        /// <param name="min">posicion donde se encuentra elemento minimo de la parte no ordenada del array</param>
        /// <param name="ordenando">indice que indica la primera posicion de la parte no ordenada del array</param>
        static void MostrarIntermedioSeleccionDirecta(int[] elems, int min, int ordenando)
        {
            //Console.Clear();

            ConsoleColor colorPrevio = Console.ForegroundColor;
            ConsoleColor fondoPrevio = Console.BackgroundColor;

            Console.ForegroundColor = ConsoleColor.Cyan;

            for (int i = 0; i < ordenando; i++)
            {
                Console.Write(" {0,3}", elems[i]);
            }

            Console.Write(" ");
            Console.ForegroundColor = ConsoleColor.Red;
            if (ordenando == min) Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("{0,3}", elems[ordenando]);

            //Console.ForegroundColor = previo;
            for (int i = ordenando + 1; i < elems.Length; i++)
            {
                Console.ForegroundColor = colorPrevio;
                Console.BackgroundColor = fondoPrevio;
                Console.Write(" ");

                if (i == min) Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write("{0,3}", elems[i]);
            }

            Console.WriteLine();
            Console.ForegroundColor = colorPrevio;
            Console.BackgroundColor = fondoPrevio;
            Console.ReadKey();
        }   


        static void TestSeleccionDirectaPerformance()
        {
            ulong numComparaciones = 0;
            ulong numAsignaciones = 0;

            int talla = 20000;
            int[] numeros = CrearArray(talla);

            System.Diagnostics.Stopwatch crono = System.Diagnostics.Stopwatch.StartNew();

            numeros.Ordenar(
                () => numComparaciones++, () => numAsignaciones++);

            Console.WriteLine("Tiempo transcurrido {0}", crono.Elapsed);

            Console.WriteLine("Total Comparaciones {0,4:N0}", numComparaciones);
            Console.WriteLine("Total Asignaciones  {0,4:N0}", numAsignaciones);

            Console.WriteLine("\nTeoricamente:");
            Console.WriteLine("Coste (n * n - n) / 2 = {1:N0}", talla, (talla * talla - talla) / 2);
        }
              
        static int[] CrearArray(int totalItems)
        {
            int[] elems = new int[totalItems];
            for (int i = 0; i < elems.Length; i++)
            {
                elems[i] = alea.Next(0, totalItems);
            }
            return elems;
        }

    }

}
