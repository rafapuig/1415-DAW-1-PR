using System;

namespace Programacion.Funciones.Revisiones.Ejercicio418.v2
{
    static class Ejercicio18
    {
        static void Main()
        {
            Console.Write("Introduce un valor minimo: ");
            int minimo = Int32.Parse(Console.ReadLine());

            Console.Write("Introduce un valor maximo: ");
            int maximo = Int32.Parse(Console.ReadLine());

            Func<int, int> factorialIterativo = n =>
                {
                    int f = 1;
                    while (n > 0) f *= n--;
                    return f;
                };

            //Una expresion lambda recursiva
            Func<int, int> factorial = null;
            factorial = n => n == 0 ? 1 : n * factorial(n - 1);


            Func<int, int, int> potenciaIterativo = (int x, int n) =>
                {
                    int pot = 1;
                    while (n-- > 0) pot *= x;
                    return pot;
                };

            Func<int, int, int> potencia = null;
            potencia = (int x, int n) => n == 0 ? 1 : x * potencia(x, n - 1);


            MostrarTabla(minimo, maximo,
                new Func<int, int>[] { n => n * n, n => potencia(n, 3), factorial, n => (int)Math.Sqrt(n) },
                new string[] { "n^2", "n^3", "n!", "raiz(n)" });

            Console.ReadKey();
        }

        static int FactorialIterativo(int n)
        {
            int factorial = 1;
            while (n> 0) factorial *= n--;
            return factorial;
        }

        static int Factorial(int n)
        {
            return n == 0 ? 1 : n * Factorial(n - 1);
        }

        static int PotenciaIterativo(int x, int n)
        {
            int pot = 1;
            while (n-- > 0) pot *= x;          
            return pot;
        }
        static int Potencia(int x, int n)
        {
            return n == 0 ? 1 : x * Potencia(x, n - 1);
        }


        static void MostrarTabla(int min, int max, Func<int, int>[] funciones, string[] cabeceras)
        {            
            //Mostrar cabecera
            Console.Write("{0,-5}", "n");

            foreach (string cabecera in cabeceras)
            {
                Console.Write(" | ");
                Console.Write("{0,10}", cabecera);
            }            
            Console.WriteLine("  ");
            Console.WriteLine(new string('-', 5 + 13 * cabeceras.Length + 2));
         
            //Mostrar valores
            for (int n = min; n <= max; n++)
            {
                Console.Write("{0,-5}", n);

                foreach (Func<int, int> funcion in funciones)
                {
                    Console.Write(" | ");
                    Console.Write("{0,10}", funcion(n));                    
                }
                Console.WriteLine("  ");
            }

        }

    }
}
