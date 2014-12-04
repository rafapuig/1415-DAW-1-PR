using System;

namespace Programacion.TiposCompuestos.Arrays
{
    class ArraysDemo
    {
        static void Main()
        {
            Test2();
        }

        static void Test3()
        {
            int[] numeros = { 3, 6, 4, 5, 5, 8, 9, 1, 5, 2, 7 };
            int valor = 5;

            int primeraPos = Array.IndexOf(numeros, valor);
            int siguientePos = Array.IndexOf(numeros, valor, primeraPos + 1);

            int ultimaPos = Array.LastIndexOf(numeros, valor);

            Array.Sort(numeros);
            int pos = Array.BinarySearch(numeros, valor);

            Console.ReadKey();

        }

        static void Test2()
        {
            string[] numeros2 = { "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez" };

            foreach (string vocal in new string[] { "a", "e", "i", "o", "u" })
            {
                string[] result = Array.FindAll(numeros2, elem => elem.Contains(vocal));

                Console.Write("Vocal {0}: ", vocal);
                Array.ForEach(result, elem => Console.Write("{0} ", elem));
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        static void Test1()
        {
            int[] numeros = { 3, 6, 4, 8, 9, 1, 5, 2, 7 };
            int key = 5;

            int index = Array.FindIndex(numeros, elem => elem == key);

            Console.WriteLine("Encontrada la clave {0} en la posicion {1} -> {2}",
                key, index, numeros[index]);
            
            Array.Sort(numeros, 
                (x, y) => x % 2 == 0 && y % 2 == 0 ? 0 : x % 2 == 1 ? 1 : -1);

            Comparison<int> comparador =
                (x, y) => x % 2 == 0 && y % 2 == 0 ? 0 : x % 2 == 1 ? 1 : -1;
            Array.Sort(numeros, comparador);

            Array.ForEach(numeros, elem => Console.Write("{0,4} ", elem));
            Console.WriteLine();

            Array.Sort(numeros, (x, y) => x.CompareTo(y));

            Action<int> imprimirElemento = elem => Console.Write("{0,4} ", elem);
            Func<int, bool> esPar = num => num % 2 == 0;

            //imprimirElemento = ImprimirElemento;
            Array.ForEach(numeros, imprimirElemento);

            ForEach(numeros, ImprimirElemento);
        }

        static void ImprimirElemento(int elem)
        {
            Console.Write("{0,4} ", elem);
        }

        static bool EsPar(int num)
        {
            return num % 2 == 0;
        }

        private static void ForEach(int[] numeros, Action<int> accion)
        {
            foreach (int elem in numeros)
            {
                accion(elem);
            }
        }
    }
}
