using System;

namespace Programacion.Funciones.Actividades.Ejercicio23
{
    delegate int AlgoritmoMCD(int a, int b);
    
    static class MCDDemo
    {
        static void MainOld()
        {
            //Console.WriteLine(MCDv3(2 * 3 * 5 * 11, 2 * 7 * 13));
            //Console.WriteLine(MCD(2 * 3 * 5 * 11, 2 * 7 * 13, rMCD            
            
            Console.WriteLine("Introduce el numero a");
            int a = Int32.Parse(Console.ReadLine());
            
            Console.WriteLine("Introduce el numero b");
            int b = Int32.Parse(Console.ReadLine());            
            
            int mcd = Logica.MCD(a, b);

            Console.WriteLine("El MCD({0},{1}) = {2}", a, b, mcd);
            Console.WriteLine("El MCM({0},{1}) = {2}", a, b, Logica.MCM(a, b));
            Console.ReadKey();
        }

        static void Main()
        {
            char opcion;
            do
            {
                opcion = Menu();
                Console.WriteLine();

                switch (opcion)
                {
                    case '1': RealizarOpcion("El MCD({0},{1}) = {2}", Logica.MCD);
                        break;
                    case '2': RealizarOpcion("El MCM({0},{1}) = {2}", Logica.MCM);
                        break;
                    default:
                        return;
                }
                
                Console.ReadKey(true);
            } while (true); 
        }

        static char Menu()
        {            
            Console.WriteLine("\nOpciones:\n");
            Console.WriteLine("1. Calcular el Maximo Comun Divisor");
            Console.WriteLine("2. Calcular el Minimo Comun Multiplo");
            Console.WriteLine("\nCualquier otra tecla para salir");
            return Console.ReadKey(true).KeyChar;
        }

        static void RealizarOpcion(string resultadoFormatter, Func<int,int,int> operacion)
        {
            Console.Write("Introduce el numero a: ");
            int a = Int32.Parse(Console.ReadLine());

            Console.Write("Introduce el numero b: ");
            int b = Int32.Parse(Console.ReadLine());

            Console.WriteLine(resultadoFormatter, a, b, operacion(a, b));
        } 
                
    }

    static class Logica
    {

        static int MCDv1(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            int dividendo = Math.Max(a, b);
            int divisor = Math.Min(a, b);

            int resto;
            do
            {
                resto = dividendo % divisor;
                dividendo = divisor;
                divisor = resto;
            } while (resto != 0);

            return dividendo;   //ultimo divisor con resto no nulo
        }

        static int MCDv2(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            int dividendo = Math.Max(a, b);
            int divisor = Math.Min(a, b);

            int resto;
            do
            {
                resto = dividendo % divisor;
                if (resto == 0) break;
                dividendo = divisor;
                divisor = resto;
            } while (resto != 0);

            return divisor;   //ultimo resto no nulo: el ultimo divisor
        }

        static int MCDv3(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            int dividendo = Math.Max(a, b);
            int divisor = Math.Min(a, b);

            return rMCD(dividendo, divisor);
        }
        public static int MCM(int a, int b)
        {
            return a / MCD(a, b) * b;    //primero dividir para evitar desbordamiento
        }

        private static int rMCD(int dividendo, int divisor)
        {
            int resto = dividendo % divisor;
            if (resto == 0)
                return divisor;
            else
                return rMCD(divisor, resto);
        }

        private static int iMCD(int dividendo, int divisor)
        {
            int resto;
            do
            {
                resto = dividendo % divisor;
                if (resto == 0) return divisor;
                dividendo = divisor;
                divisor = resto;
            } while (resto != 0);

            return 1;
        }

        public static int MCD(int a, int b)
        {
            return MCD(a, b, null);
        }
        static int MCD(int a, int b, AlgoritmoMCD algoritmoMCD = null)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            int dividendo = Math.Max(a, b);
            int divisor = Math.Min(a, b);

            if (algoritmoMCD == null) algoritmoMCD = iMCD;

            return algoritmoMCD(a, b);
        }
    }

    
}
