using System;
using System.Collections.Generic;

namespace Programacion.TiposCompuestos.Busqueda.v4
{
    public delegate int EstrategiaBusquedaContador(int[] items, int key, out int counter);
    public delegate int EstrategiaBusquedaDelegate(int[] items, int key, Action WhenComparison);
    
    class BusquedasDemo
    {
        static void Main()
        {
            TestGenerico();
            TestIterador();
            Console.ReadKey();
        }

#region "Test Rendimiento"

        const int MaxNum = 10000; //10000000;
        static Random alea = new Random();

        static EstrategiaBusquedaDelegate[] AlgoritmosBusqueda = { Arrays.BusquedaSecuencial, 
                                                                     Arrays.BusquedaBinaria };
        static void TestsRendimiento()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = 
                System.Globalization.CultureInfo.GetCultureInfo("es-ES");

            int numTests = 100;

            //Con numero en la lista de elementos
            Console.WriteLine("Prueba con la clave perteneciente a la lista\n");
            Func<int[],int> generarClaveExistenteEnArray = 
                elems => elems[GenerarEnteroAleatorio(0, elems.Length - 1)];

            TestRendimiento(numTests, generarClaveExistenteEnArray);
            Console.WriteLine();

            Console.ReadKey();

            //Sin seguridad de que la clave se encuenta
            Console.WriteLine("Prueba sin seguridad de que la clave se encuentre en la lista\n");
            TestRendimiento(numTests, elems => GenerarEnteroAleatorio(0, elems.Length - 1));

            //Resultados
            Console.WriteLine("\nTeoricamente:");
            Console.WriteLine("La busqueda binaria es Log2({0}) = {1:N2}",
                MaxNum, Math.Log10(MaxNum) / Math.Log10(2));
            
            Console.WriteLine("La busqueda secuencial es {0} / 2 = {1:N0} (si la clave esta en la lista)", 
                MaxNum, MaxNum / 2);
           
            Console.ReadKey();
        }

        private static void TestRendimiento(int numTests, Func<int[],int> generarClave)
        {
            //Generar un vector con numeros entre 0 y maxNum y ordenado
            int[] numeros = GenerarArray(MaxNum, ordenado: true); 
            
            //Matriz de resultados una fila por cada test y una columna por cada Algoritmo
            int[,] resultados = new int[numTests, AlgoritmosBusqueda.Length];            

            //Repetir el test numTest veces
            for (int test = 0; test < numTests; test++)
            {
                //Invocamos al delegado para que llame a la funcion que debe generar una clave
                int clave = generarClave.Invoke(numeros);

                //Por cada estrategia de busqueda buscamos la misma clave en el mismo vector
                for (int alg = 0; alg < AlgoritmosBusqueda.Length; alg++)
                {
                    EstrategiaBusquedaDelegate algoritmoBusqueda = AlgoritmosBusqueda[alg];
                    resultados[test, alg] = RealizarBusqueda(numeros, clave, algoritmoBusqueda);
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

        static int RealizarBusqueda(EstrategiaBusquedaContador estrategia, int clave, int[] elems)
        {
            int contador;
            estrategia(elems, clave, out contador);
            return contador;
        }

        static int RealizarBusqueda(int[] elems, int clave, EstrategiaBusquedaDelegate estrategia)
        {
            int contador = 0;
            Action incrementarContador = () => contador++;
            estrategia(elems, clave, incrementarContador);
            
            //estrategia(elems, clave, () => contador++);
            return contador;
        }

#endregion

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



        private static void Test1()
        {
            int[] numeros = { 0, 1, 2, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            int pos = Arrays.BusquedaSecuencial(numeros, 3);

            pos = numeros.BusquedaSecuencial(5);

            Console.WriteLine("Encontrado en la posicion {0}", pos);

            Array.Sort(numeros);
            Arrays.BusquedaBinaria(numeros, 3);
            pos = numeros.BusquedaBinaria(7);
            
        }
        
        static void TestGenerico()
        {
            string[] palabras = { "uno", "dos", "tres", "cuatro", "cinco" };
            string key = "dos";

            int index = Arrays.BusquedaSecuencial(palabras, key);
            Console.WriteLine("Encontada en pos: {0} palabra {1}", index, palabras[index]);            
        }
           
     
        static void TestIterador()
        {
            byte[] numeros = { 4, 5, 7, 1, 2, 6, 1, 6, 2, 3, 5, 1, 8, 2, 1 };

            foreach(int index in numeros.BusquedaSecuencialIterador((byte)1))
            {
                Console.WriteLine("Encontrado en posicion: {0,3} ", index);
            }
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
               
        public static int BusquedaSecuencial(this int[] items, int key, Action comparisonPerformed)
        {
            for (int index = 0; index < items.Length; index++)
            {
                comparisonPerformed();                
                if (items[index] == key) return index;
            }

            return -1;
        }

        public static int BusquedaSecuencial<T>(this T[] items, T key)
        {
            for (int index = 0; index < items.Length; index++)
                if (items[index].Equals(key)) return index;

            return -1;
        }

        public static IEnumerable<int> BusquedaSecuencialIterador<T>(this T[] items, T key)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Equals(key)) yield return i;
            }
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

        public static int BusquedaBinaria(this int[] items, int key, Action comparisonPerformed)
        {
            int lowBound = 0;
            int highBound = items.Length - 1;            

            while (lowBound <= highBound)
            {
                comparisonPerformed();

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
