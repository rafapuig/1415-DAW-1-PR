using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.TiposCompuestos.Busqueda.v3
{
    public delegate int EstrategiaBusqueda(int[] items, int key, out int counter);
    public delegate int Busqueda(int[] items, int key, Action WhenComparison);
    
    class BusquedasDemo
    {
        const int MaxNum = 10000; //10000000;
        static Random alea = new Random();
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("es-ES");
            //Test1();

            //Con numero en la lista de elementos
            Console.WriteLine("Prueba con la clave perteneciente a la lista\n");
            TestRendimiento((elems => elems[GenerarEnteroAleatorio(0, elems.Length - 1)]));
            Console.WriteLine();

            Console.ReadKey();

            //Sin seguridad de que la clave se encuenta
            Console.WriteLine("Prueba sin seguridad de que la clave se encuentre en la lista\n");
            TestRendimiento((elems => GenerarEnteroAleatorio(0, elems.Length)));

            Console.WriteLine("\nTeoricamente:");
            Console.WriteLine("La busqueda binaria es Log2({0}) = {1:N2}", MaxNum, Math.Log10(MaxNum) / Math.Log10(2));
            Console.WriteLine("La busqueda secuencial es {0} / 2 = {1:N0} (si la clave esta en la lista)", MaxNum, MaxNum / 2);
           
            Console.ReadKey();
        }

        private static void TestRendimiento(Func<int[],int> generarClave)
        {
            int numTests = 100;

            Busqueda[] algoritmosBusqueda = { Arrays.BusquedaSecuencial, Arrays.BusquedaBinaria };

            int[,] resultados = new int[numTests, algoritmosBusqueda.Length];

            int[] numeros = GenerarArray(MaxNum, ordenado: true);
            

            for (int test = 0; test < numTests; test++)
            {
                int clave = generarClave(numeros); //= numeros[GenerarEnteroAleatorio() - 1];

                for (int alg = 0; alg < algoritmosBusqueda.Length; alg++)
                {
                    resultados[test, alg] = RealizarBusqueda(algoritmosBusqueda[alg], clave, numeros);
                }
            }

            ShowResultados(resultados);
        }
             
        static void ShowResultados(int[,] resultados)
        {
            int totalTests = resultados.GetLength(0);  //Una fila por cada test
            int totalAlgoritmos = resultados.GetLength(1); //Una columna por cada algoritmo de busqueda
            
            int[] suma = new int[totalAlgoritmos]; //Una suma por cada algoritmo de busqueda

            Console.WriteLine("test".PadRight(12) + "BS".PadRight(12) + "BB");
            Console.WriteLine(new string('-', 30));
            
            // Por cada test de busqueda
            for (int t = 0; t < totalTests; t++)
            {
                Console.Write("{0,3}  ", t + 1); //Escribir el numero de test
                
                //Por cada algoritmo
                for (int a = 0; a < totalAlgoritmos; a++)
                {
                    suma[a] += resultados[t,a];     //Sumar y acumular para el algoritmo 'a' el resultado del test numero 't'
                    Console.Write("{0,10:N0} ", resultados[t,a]);   //Escribir los resultados del test t con el algor. a
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', 30));
            //Console.Write(new String(' ', 5));  //Para dejar la columna de numero de test vacia
            Console.Write("Media");
            for (int col = 0; col < totalAlgoritmos; col++)
            {
                Console.Write("{0,10:N1}{1}", suma[col] / totalTests, col < totalAlgoritmos - 1 ? " " : "\n");
            }
        }

        static int RealizarBusqueda(EstrategiaBusqueda estrategia, int clave, int[] elems)
        {
            int contador;
            estrategia(elems, clave, out contador);
            return contador;
        }

        static int RealizarBusqueda(Busqueda estrategia, int clave, int[] elems)
        {
            int contador = 0;
            estrategia(elems, clave, () => contador++);
            return contador;
        }

        private static void Test1()
        {
            int[] numeros = { 0, 1, 2, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            int pos = Arrays.BusquedaSecuencial(numeros, 3);

            pos = numeros.BusquedaSecuencial(5);

            Array.Sort(numeros);
            Arrays.BusquedaBinaria(numeros, 3);
            pos = numeros.BusquedaBinaria(7);
        }
        
        static int GenerarEnteroAleatorio(int min, int max)
        {
            return alea.Next(min, max + 1);
        }

        static int[] GenerarArray(int numItems, bool ordenado = false)
        {
            int[] items = new int[numItems];

            for (int i = 0; i < items.Length; i++)
                items[i] = GenerarEnteroAleatorio(0, numItems - 1);

            if (ordenado) Array.Sort(items);

            return items;
        }



                
    }


    

    static class Arrays
    {
        public static int BusquedaSecuencial(this int[] items, int key)
        {
            for (int index = 0; index < items.Length; index++)
                if (items[index] == key) return index;

            return -1;
        }

        public static int BusquedaSecuencial(this int[] items, int key, out int counter)
        {
            counter = 0;
            for (int index = 0; index < items.Length; index++)
            {
                counter++;
                if (items[index] == key) return index;
            }

            return -1;
        }

        public static int BusquedaSecuencial(this int[] items, int key, Action comparison)
        {
            for (int index = 0; index < items.Length; index++)
            {
                comparison();                
                if (items[index] == key) return index;
            }

            return -1;
        }


        public static int BusquedaBinaria(this int[] items, int key)
        {
            int lowBound = 0;
            int highBound = items.Length - 1;

            while (lowBound <= highBound)
            {
                int middle = (lowBound + highBound) / 2;

                if (key < items[middle])
                    highBound = middle - 1;
                else if (key > items[middle])
                    lowBound = middle + 1;
                else
                    return middle;
            }
            return -1;
        }

        public static int BusquedaBinaria(this int[] items, int key, out int counter)
        {
            int lowBound = 0;
            int highBound = items.Length - 1;

            counter = 0;

            while (lowBound <= highBound)
            {
                counter++;

                int middle = (lowBound + highBound) / 2;

                if (key < items[middle])
                    highBound = middle - 1;
                else if (key > items[middle])
                    lowBound = middle + 1;
                else
                    return middle;
            }
            return -1;
        }

        public static int BusquedaBinaria(this int[] items, int key, Action comparison)
        {
            int lowBound = 0;
            int highBound = items.Length - 1;            

            while (lowBound <= highBound)
            {
                comparison();

                int middle = (lowBound + highBound) / 2;

                if (key < items[middle])
                    highBound = middle - 1;
                else if (key > items[middle])
                    lowBound = middle + 1;
                else
                    return middle;
            }
            return -1;
        }

    }
}
