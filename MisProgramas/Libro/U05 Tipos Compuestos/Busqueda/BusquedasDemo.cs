using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.TiposCompuestos.Busqueda
{
    delegate int Busqueda(int key,int[] items, out int counter);
    
    class BusquedasDemo
    {
        //static int contComp;   //Contador de comparaciones
        //static int contAsign;  //Contador de asignaciones
        //static int Counter;

        const int MaxNum = 20000;
        static Random alea = new Random();
        static void Main()
        {
            //Test1();                      

            int numTests = 20;

            Busqueda[] algoritmosBusqueda = { BusquedaSecuencial, BusquedaBinaria };

            int[][] resultados = new int[algoritmosBusqueda.Length][];
            
            for (int i = 0; i < resultados.Length; i++)
            {
                resultados[i] = new int[numTests];
            }


            int[] numeros = GenerarArray(MaxNum);

            for (int test = 0; test < numTests; test++)
            {
                int clave = numeros[GenerarEnteroAleatorio()-1];

                for (int i = 0; i < algoritmosBusqueda.Length; i++)
                {
                    resultados[i][test] = RealizarBusqueda(algoritmosBusqueda[i], clave, numeros);
                }
            }

            ShowResultadosv2(resultados);
            Console.ReadKey();
        }

        static void ShowResultados(int[][] res)
        {
            // Por cada algoritmo de busqueda
            for (int i = 0; i < res.Length; i++)
            {
                //Por cada test para el algoritmo
                for (int j = 0; j < res[i].Length; j++)
                {
                    Console.Write("{0,4} ",res[i][j]);
                }
                Console.WriteLine();
            }
        }
        static void ShowResultadosv2(int[][] res)
        {
            int[] suma = new int[res.Length];
            
            Console.WriteLine("test\t  BS\t   BB");
            // Por cada test de busqueda
            for (int t = 0; t < res[0].Length; t++)
            {
                Console.Write("{0,3}\t", t + 1);
                //Por cada algoritmo

                for (int a = 0; a < res.Length; a++)
                {
                    suma[a] += res[a][t];
                    Console.Write("{0,5}\t", res[a][t]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\t{0,5:N1}\t{1,5:N1}", suma[0] / res[0].Length, suma[1] / res[1].Length);
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

        static int[] GenerarArray(int numItems)
        {
            int[] items = new int[numItems];
            for(int i=0;i<items.Length;i++)
            {
                items[i] = GenerarEnteroAleatorio();
            }
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
