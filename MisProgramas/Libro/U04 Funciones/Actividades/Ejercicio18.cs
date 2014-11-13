using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.Funciones.Actividades
{
    static class Ejercicio18
    {
        static void Main()
        {
            Console.Write("Introduce un valor minimo: ");
            int minimo = Int32.Parse(Console.ReadLine());

            Console.Write("Introduce un valor maximo: ");
            int maximo = Int32.Parse(Console.ReadLine());

            MostrarTabla(minimo, maximo);

            Console.ReadKey();
        }

        static int FactorialIterativo(int n)
        {
            int factorial = 1;
            while (n > 0) factorial *= n--;
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


        static void MostrarTabla(int min, int max)
        {
            //Mostrar cabecera
            Console.Write("{0,-5}","n");
            Console.Write(" | ");
            Console.Write("{0,10}","n^2");
            Console.Write(" | ");
            Console.Write("{0,10}","n^3");
            Console.Write(" | ");
            Console.Write("{0,10}  ","n!");
            Console.WriteLine();
            Console.WriteLine(new string('-', 46));            

            //Mostrar valores
            for (int n = min; n <= max; n++)
            {
                Console.Write("{0,-5}", n);
                Console.Write(" | ");
                Console.Write("{0,10}", n * n);
                Console.Write(" | ");
                Console.Write("{0,10}", Potencia(n,3));
                Console.Write(" | ");
                Console.Write("{0,10}  ", Factorial(n));
                Console.WriteLine(); 
            } 
  
        }
    }
}
