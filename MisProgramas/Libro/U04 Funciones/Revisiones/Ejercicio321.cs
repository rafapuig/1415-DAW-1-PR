using System;

namespace Programacion.Iniciacion.Revision.Ejercicio321
{
    static class PrimosCUI
    { 
        static void Main()
        {
            int opcion = MostrarMenu();

            switch (opcion)
            {
                case 1:
                    ComprobarPrimo();
                    break;
                case 2:
                    GenerarNumeroPrimo();
                    break;
                case 3:
                    MostrarListaNumerosPrimos();
                    break;
            }          

            Console.ReadKey();
        }

        static int MostrarMenu()
        {
            Console.WriteLine("Elige una opcion:");
            Console.WriteLine("1. - Comprobar si un numero es primo.");
            Console.WriteLine("2. - Generar un numero primo.");
            Console.WriteLine("3. - Ver una lista de numeros primos.");
            Console.WriteLine("4. - Salir");

            return Int32.Parse(Console.ReadLine());
        }

        private static ulong ObtenerNumeroPorConsola()
        {
            Console.Write("Introduce un numero: "); //1234567890
            ulong numero = UInt64.Parse(Console.ReadLine());
            return numero;
        }       

        private static void MostrarListaNumerosPrimos()
        {
            ulong numero = ObtenerNumeroPorConsola();
            FuncionesPrimos.ListarPrimos(numero);
        }

        private static void GenerarNumeroPrimo()
        {
            ulong numero = ObtenerNumeroPorConsola();
            ulong primo = FuncionesPrimos.GenerarPrimo(numero);
            Console.WriteLine("Numero primo: {0}", primo);
        }

        private static void ComprobarPrimo()
        {
            ulong numero = ObtenerNumeroPorConsola();

            ulong factor = FuncionesPrimos.TestPrimo(numero);
            bool esPrimo = FuncionesPrimos.EsPrimo(numero);

            Console.WriteLine("{0} es {1}primo", numero, !esPrimo ? "no " : "");
            if (!esPrimo)
                Console.WriteLine("Es divisible por {0}", factor);
        }
  
    }

    static class FuncionesPrimos
    {
        internal static void ListarPrimos(ulong max)
        {
            bool esPrimero = true;
            for (ulong i = 1; i <= max; i++)
            {
                ulong divisor = TestPrimo(i);
                if (divisor == 1)
                {
                    Console.Write("{1}{0,9}", i, !esPrimero ? "," : "");
                    esPrimero = false;
                }
            }
        }

        /// <summary>
        /// Comprueba si un numero es divisible por algun numero mayor que 1 (si no, es primo)
        /// </summary>
        /// <param name="num">Numero del que se quiere extraer el divisor</param>
        /// <returns>Devuelve el primer divisor encontrado para el numero dado distinto de 1, 
        /// si es primo devuelve un 1</returns>
        internal static ulong TestPrimo(ulong num)
        {
            if (num == 2 || num == 3 || num == 5) return 1;

            if (num % 2 == 0) return 2;
            if (num % 3 == 0) return 3;
            if (num % 5 == 0) return 5;

            ulong divisor = 2;

            if (num % divisor == 0) return divisor;

            for (divisor = 7; divisor < (ulong)Math.Sqrt(num) + 1; divisor += 2)
                if (num % divisor == 0) return divisor;

            return 1;
        }

        internal static bool EsPrimo(ulong num)
        {
            return TestPrimo(num) == 1;
        }

        internal static ulong GenerarPrimo(ulong semilla)
        {
            if (semilla % 2 == 0) semilla++;
            do
            {
                if (EsPrimo(semilla)) return semilla;
                semilla++;

            } while (true);
        }

    }
}
