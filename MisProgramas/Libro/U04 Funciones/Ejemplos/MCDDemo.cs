using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.TiposCompuestos.Ejemplos
{
    delegate int AlgoritmoMCD(int a, int b);
    static class MCDDemo
    {
        static void Main()
        {
            //Console.WriteLine(MCDv3(2 * 3 * 5 * 11, 2 * 7 * 13));
            //Console.WriteLine(MCD(2 * 3 * 5 * 11, 2 * 7 * 13, rMCD));
            
            Console.WriteLine("Introduce el numero a");
            int a = Int32.Parse(Console.ReadLine());
            
            Console.WriteLine("Introduce el numero a");
            int b = Int32.Parse(Console.ReadLine());
            
            int mcd = MCDv1(a, b);

            Console.WriteLine("El MCD({0},{1}) = {2}", a, b, mcd);
            Console.ReadKey();
        }


        static int MCM(int a, int b)
        {
            return a / MCDv1(a, b) * b;    //primero dividir para evitar desbordamiento
        }

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
        private static int MCD(int a, int b, AlgoritmoMCD algoritmoMCD)
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
