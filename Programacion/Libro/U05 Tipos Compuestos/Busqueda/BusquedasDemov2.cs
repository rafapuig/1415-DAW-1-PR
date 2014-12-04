using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.TiposCompuestos.Busqueda.v2
{
    delegate int Busqueda(int key,int[] items, out int counter);
    
    class BusquedasDemo
    {
        const int MaxNum = 10000000;
        static Random alea = new Random();
        static void Main()
        {
            //Test1();

            //Con numero en la lista de elementos
            Console.WriteLine("Prueba con la clave perteneciente a la lista");
            TestRendimiento((elems => elems[GenerarEnteroAleatorio()]));
            Console.WriteLine();

            //Sin seguridad de que la clave se encuenta
            Console.WriteLine("Prueba sin seguridad de que la clave se encuentre en la lista");
            TestRendimiento((elems => GenerarEnteroAleatorio()));

            Console.WriteLine("Teoricamente");
            Console.WriteLine("La busqueda binaria es Log2({0}) = {1:N2}", MaxNum, Math.Log10(MaxNum) / Math.Log10(2));
            Console.WriteLine("La busqueda secuencial es {0} / 2 = {1:N0} (si la clave esta en la lista)", MaxNum, MaxNum / 2);
           
            Console.ReadKey();
        }

        private static void TestRendimiento(Func<int[],int> generarClave)
        {
            int numTests = 100;

            Busqueda[] algoritmosBusqueda = { BusquedaSecuencial, BusquedaBinaria };

            int[,] resultados = new int[numTests, algoritmosBusqueda.Length];

            int[] numeros = GenerarArray(MaxNum);
            

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
             
        static void ShowResultados(int[,] res)
        {
            int totalTests = res.GetLength(0);
            int totalAlgoritmos = res.GetLength(1);
            int[] suma = new int[totalAlgoritmos];
            
            Console.WriteLine("test        BS          BB");
            // Por cada test de busqueda
            for (int t = 0; t < totalTests; t++)
            {
                Console.Write("{0,3}  ", t + 1);
                
                //Por cada algoritmo
                for (int a = 0; a < totalAlgoritmos; a++)
                {
                    suma[a] += res[t,a];
                    Console.Write("{0,10:N0} ", res[t,a]);
                }
                Console.WriteLine();
            }
            Console.Write(new String(' ', 5));
            for (int col = 0; col < totalAlgoritmos; col++)
            {
                Console.Write("{0,10:N1}{1}", suma[col] / totalTests, col < totalAlgoritmos - 1 ? " " : "\n");
            }
        }

        static int RealizarBusqueda(Busqueda estrategia, int clave, int[] elems)
        {
            int contador;
            estrategia(clave, elems, out contador);
            return contador;
        }

        private static void Test1()
        {
            int[] numeros = { 0, 1, 2, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            int pos = BusquedaSecuencial(3, numeros);

            Array.Sort(numeros);
            BusquedaBinaria(3, numeros);
        }
        
        static int GenerarEnteroAleatorio()
        {
            return alea.Next(MaxNum);
        }

        static int[] GenerarArray(int numItems, bool ordenado = true)
        {
            int[] items = new int[numItems];

            for(int i=0;i<items.Length;i++) 
                items[i] = GenerarEnteroAleatorio();

            if (ordenado) Array.Sort(items);

            return items;
        }


        static int BusquedaSecuencial(int key, int[] elementos)
        {
            for (int index = 0; index < elementos.Length; index++)
                if (elementos[index] == key) return index;

            return -1;
        }

        static int BusquedaSecuencial(int key, int[] elementos, out int counter)
        {
            counter = 0;
            for (int index = 0; index < elementos.Length; index++)
            {
                counter++;
                if (elementos[index] == key) return index;
            }

            return -1;
        }

        static int BusquedaBinaria(int key, int[] items)
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

        static int BusquedaBinaria(int key, int[] items, out int counter)
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
    }  
}
