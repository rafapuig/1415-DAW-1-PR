using System;

namespace Programacion.TiposCompuestos.Ordenacion
{
    static class QuickSortDemo
    {
        static Random alea = new Random();

        static void Main()
        {
            Console.Title = "Algoritmos de ordenacion - Quicksort Demo";
            TestQuickSort();
            TestQuicksortPerformance();
            Console.ReadKey();
        }
           
     
        static void TestQuickSort()
        {
            int[] numeros = { 5, 9, 2, 4, 8, 1, 3, 7, 6 };//{ 12, 5, 3, 13, 2, 9, 7 };

            numeros.QuickSort(0, numeros.Length - 1, null, null, MostrarOrdenacionQuickSort);

            MostrarItems(numeros);         
        }
        
        static void MostrarOrdenacionQuickSort(int[] items, int central, int primero, int ultimo, int i, int j)
        {
            ConsoleColor colorPrevio = Console.ForegroundColor;
            ConsoleColor fondoPrevio = Console.BackgroundColor;

            for (int n = 0; n < items.Length; n++)
            {
                //Console.Write(" ");

                if (n >= primero && n <= ultimo)
                    Console.BackgroundColor = ConsoleColor.DarkBlue;

                if (n == i) Console.ForegroundColor = ConsoleColor.Red;

                if (n == j) Console.ForegroundColor = ConsoleColor.Green;

                if (n == central) Console.BackgroundColor = ConsoleColor.DarkYellow;

                Console.Write(" {0,3}", items[n]);

                Console.ForegroundColor = colorPrevio;
                Console.BackgroundColor = fondoPrevio;
            }

            Console.WriteLine();
            Console.ReadKey();
        }
        
        public static void MostrarItems<T>(T[] elems)
        {
            Console.WriteLine(String.Join(", ", elems));
            //Array.ForEach(elems, elem => Console.Write("{0} ", elem));
            //Console.WriteLine();
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
        
        static void TestQuicksortPerformance()
        {
            int talla = 5000000;
            int[] valores = CrearArray(talla);

            ulong contadorComparaciones = 0;
            ulong contadorAsignaciones = 0;

            System.Diagnostics.Stopwatch cronometro = System.Diagnostics.Stopwatch.StartNew();
            
            QuickSort.QuickSort(valores, 0, valores.Length - 1,
                () => contadorComparaciones++,
                () => contadorAsignaciones++);

            Console.WriteLine("Tiempo transcurrido {0}", cronometro.Elapsed);

            Console.WriteLine("Total Comparaciones {0,4:N0}", contadorComparaciones);
            Console.WriteLine("Total Asignaciones  {0,4:N0}", contadorAsignaciones);

            Console.WriteLine("\nTeoricamente:");
            Console.WriteLine("Coste n * Log2({0}) = {1:N0}", talla, talla * Math.Log10(talla) / Math.Log10(2));
        }
                
    }

}
