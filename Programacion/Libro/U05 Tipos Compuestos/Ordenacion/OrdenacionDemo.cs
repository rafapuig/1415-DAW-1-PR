using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.TiposCompuestos.Ordenacion
{
    class OrdenacionDemo
    {
        static Random alea = new Random();

        static void Main()
        {
            //SeleccionDirectaTest();
            //TestSeleccionDirectaPerformance();
            //TestQuickSort();
            TestQuicksortPerformance();
            Console.ReadKey();
        }
        static void TestQuicksortPerformance()
        {
            int talla=15000000;
            int[] valores = CrearArray(talla);

            int contadorComparaciones = 0;
            int contadorAsignaciones = 0;

            Arrays.QuickSort(valores, 0, valores.Length - 1,
                () => contadorComparaciones++,
                () => contadorAsignaciones++);

            Console.WriteLine("Total Comparaciones {0,4:N0}", contadorComparaciones);
            Console.WriteLine("Total Asignaciones  {0,4:N0}", contadorAsignaciones);

            Console.WriteLine("\nTeoricamente:");
            Console.WriteLine("Coste n * Log2({0}) = {1:N0}", talla, talla * Math.Log10(talla) / Math.Log10(2));

            Console.ReadKey();
        }

        static void TestQuickSort()
        {
            int[] numeros = { 5, 9, 2, 4, 8, 1, 3, 7, 6 };//{ 12, 5, 3, 13, 2, 9, 7 };

            numeros.QuickSort(0, numeros.Length - 1, null, null, MostrarOrdenacionQuickSort);

            foreach (var num in numeros)
            {
                Console.Write("{0} ", num);
            }
            Console.WriteLine();

            Console.ReadKey();

        }
        
        
        
        public static void MostrarItems<T>(T[] elems)
        {
            Array.ForEach(elems, elem => Console.Write("{0} ", elem));
            Console.WriteLine();

            //foreach (var elem in elems)
            //{
            //    Console.Write("{0} ", elem);
            //}
            //Console.WriteLine();
        }


        static void SeleccionDirectaTest()
        {
            int[] numeros = { 12, 5, 3, 13, 2, 9, 7 };
            
            //numeros.SeleccionDirecta();
            //numeros.SeleccionDirecta(null, null, MostrarIntermedioSeleccionDirecta);
            numeros.SeleccionDirecta(show: MostrarIntermedioSeleccionDirecta);

          

            Console.WriteLine();
            Console.WriteLine(String.Join(", ", numeros));        
            
            Console.ReadKey();
        }
                
        static int[] CrearArray(int totalItems)
        {
            int[] elems = new int[totalItems];
            for (int i = 0; i < elems.Length; i++)
            {
                elems[i] = alea.Next(0, 100000);
            }
            return elems;
        }

      
        static void TestSeleccionDirectaPerformance()
        {
            int numComparaciones = 0;
            int numAsignaciones = 0;       

            int talla = 150000;
            int[] numeros = CrearArray(talla);
            numeros.SeleccionDirecta(
                () => numComparaciones++, () => numAsignaciones++);


            Console.WriteLine("Total Comparaciones {0,4:N0}", numComparaciones);
            Console.WriteLine("Total Asignaciones  {0,4:N0}", numAsignaciones);

            Console.WriteLine("\nTeoricamente:");
            Console.WriteLine("Coste (n * n - n) / 2 = {1:N0}", talla, (talla * talla - talla) / 2);
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



        static void InsercionTest1()
        {
            int[] numeros = { 5, 9, 2, 4, 8, 1, 3, 7, 6 }; //{ 12, 5, 3, 13, 2, 9, 7 };

            Arrays.InsercionDirecta(numeros);

            MostrarItems(numeros);          
        }

        static void InsercionTest2()
        {   
            string[] palabras = { "hola", "adios", "abracadabra", "lunes", "domingo" };
            
            palabras.InsercionDirecta();
            
            MostrarItems(palabras);
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
    }



    delegate void MostrarEstadoIntermedioOrdenacionDirecta(int[] items, int minIndex, int ordenadoIndex);
    delegate void MostrarOrdenacionQuickSort(int[] items, int central, int primero, int ultimo, int i, int j);

    static class Arrays
    {
        public static void SeleccionDirecta(this int[] items)
        {
            //Poner en cada posicion i el valor que corresponde
            for (int i = 0; i < items.Length; i++)
            {
                //Asumir de partida que el valor menor de la parte aun no ordenada
                //del array esta en la primera posicion de la parte aun no ordenada
                int notOrderedLowerValueIndex = i;
                //Recorrer el resto del vector para encontrar otro menor
                for (int j = i + 1; j < items.Length; j++)
                    //Si se encuentra un valor menor en la posicion j
                    if (items[j] < items[notOrderedLowerValueIndex])
                        notOrderedLowerValueIndex = j;  //nueva posicion del mejor j

                //Si el valor de la posicion i no estaba en su sitio
                //porque hemos encontrado en una posicion distinta otro valor aun
                //menor intercambiar las posiciones
                if (i != notOrderedLowerValueIndex)
                {
                    int aux = items[i];
                    items[i] = items[notOrderedLowerValueIndex];
                    items[notOrderedLowerValueIndex] = aux;
                }
            }
        }

        public static void SeleccionDirecta<T>(this T[] items) where T : IComparable<T>
        {
            //Poner en cada posicion i el valor que corresponde
            for (int i = 0; i < items.Length; i++)
            {
                //Asumir de partida que el valor menor de la parte aun no ordenada
                //del array esta en la primera posicion de la parte aun no ordenada
                int notOrderedLowerValueIndex = i;
                //Recorrer el resto del vector para encontrar otro menor
                for (int j = i + 1; j < items.Length; j++)
                    //Si se encuentra un valor menor en la posicion j
                    if (items[j].CompareTo(items[notOrderedLowerValueIndex]) < 0)
                        notOrderedLowerValueIndex = j;  //nueva posicion del menor j

                //Si el valor de la posicion i no estaba en su sitio
                //porque hemos encontrado en una posicion distinta otro valor aun
                //menor intercambiar las posiciones
                if (i != notOrderedLowerValueIndex)
                {
                    T aux = items[i];
                    items[i] = items[notOrderedLowerValueIndex];
                    items[notOrderedLowerValueIndex] = aux;
                }
            }
        }

        public static void SeleccionDirecta(this int[] items, Action comparacion = null, Action asignacion = null, MostrarEstadoIntermedioOrdenacionDirecta show = null)
        {
            //Poner en cada posicion i el valor que corresponde
            for (int i = 0; i < items.Length; i++)
            {
                //Asumir de partida que el valor menor de la parte aun no ordenada
                //del array esta en la primera posicion de la parte aun no ordenada
                int notOrderedLowerValueIndex = i;
                //Recorrer el resto del vector para encontrar otro menor
                for (int j = i + 1; j < items.Length; j++)
                {
                    if (comparacion != null) comparacion();
                    //Si se encuentra un valor menor en la posicion j
                    if (items[j] < items[notOrderedLowerValueIndex])
                        notOrderedLowerValueIndex = j;  //nueva posicion del mejor j
                }

                if (show != null) show(items, notOrderedLowerValueIndex, i);
                //Si el valor de la posicion i no estaba en su sitio
                //porque hemos encontrado en una posicion distinta otro valor aun
                //menor intercambiar las posiciones
                if (i != notOrderedLowerValueIndex)
                {
                    if (asignacion != null) asignacion();
                    int aux = items[i];

                    if (asignacion != null) asignacion();
                    items[i] = items[notOrderedLowerValueIndex];

                    if (asignacion != null) asignacion();
                    items[notOrderedLowerValueIndex] = aux;
                }
            }
        }

        public static void InsercionDirecta(this int[] items)
        {
            for (int i = 1; i < items.Length; i++)
            {
                int j = i;
                int aux = items[i];
                while (j > 0 && aux < items[j - 1])
                {
                    items[j] = items[j - 1];
                    j--;
                }
                items[j] = aux;
            }
        }

        public static void InsercionDirecta<T>(this T[] items) where T : System.IComparable<T>
        {
            for (int i = 1; i < items.Length; i++)
            {
                int j = i;
                T aux = items[i];
                while (j > 0 && aux.CompareTo(items[j - 1]) < 0)
                {
                    items[j] = items[j - 1];
                    j--;
                }
                items[j] = aux;
            }
        }

        public static void QuickSort(this int[] items, int primero, int ultimo, Action comparacion = null, Action asignacion = null, MostrarOrdenacionQuickSort show = null)
        {
            int central = (primero + ultimo) / 2;
            int pivote = items[central];

            int i = primero;
            int j = ultimo;

            do
            {
                if (comparacion != null) comparacion();
                while (items[i] < pivote) i++;

                if (comparacion != null) comparacion();
                while (items[j] > pivote) j--;

                if (show != null) show(items, central, primero, ultimo, i, j);

                if (i <= j)
                {

                    int temp = items[i]; if (asignacion != null) asignacion();
                    items[i] = items[j]; if (asignacion != null) asignacion();
                    items[j] = temp; if (asignacion != null) asignacion();
                    i++;
                    j--;
                }

            } while (i <= j);

            if (primero < j) QuickSort(items, primero, j, comparacion, asignacion, show);
            if (i < ultimo) QuickSort(items, i, ultimo, comparacion, asignacion, show);
        }
    }
}
