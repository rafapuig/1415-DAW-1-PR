using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.TiposCompuestos.Ordenacion
{
    static class InsercionDirectaDemo
    {
        static Random alea = new Random();

        static void Main()
        {
            Console.Title = "Algoritmos de ordenacion - Insercion Directa";
            InsercionTest1();
            InsercionTest2();
            TestInsercionDirectaPerformance();
            Console.ReadKey();
        }


        static void InsercionTest1()
        {
            int[] numeros = { 5, 9, 2, 4, 8, 1, 3, 7, 6 }; //{ 12, 5, 3, 13, 2, 9, 7 };

            InsercionDirecta.Ordenar(numeros);

            MostrarItems(numeros);
        }

        static void InsercionTest2()
        {
            string[] palabras = { "hola", "adios", "abracadabra", "lunes", "domingo" };

            palabras.Ordenar();

            MostrarItems(palabras);
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

   
        static void TestInsercionDirectaPerformance()
        {
            ulong numComparaciones = 0;
            ulong numAsignaciones = 0;       

            int talla = 15000;
            int[] numeros = CrearArray(talla);
            
            System.Diagnostics.Stopwatch crono = System.Diagnostics.Stopwatch.StartNew();

            numeros.Ordenar(
                () => numComparaciones++, () => numAsignaciones++);

            Console.WriteLine("Tiempo transcurrido {0}", crono.Elapsed);


            Console.WriteLine("Total Comparaciones {0,4:N0}", numComparaciones);
            Console.WriteLine("Total Asignaciones  {0,4:N0}", numAsignaciones);

            //Console.WriteLine("\nTeoricamente:");
            //Console.WriteLine("Coste (n * n - n) / 2 = {1:N0}", talla, (talla * talla - talla) / 2);
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

    }
    
}
