using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.Funciones.Ejemplos
{
    class ExtensionDemo
    {
        static void Main()
        {
            int x = 123;
            x.EsPrimo();

            Int32Extensions.EsPar(123);
            
        }

    }

    public static class Int32Extensions
    {
        public static bool EsPar(this int numero)
        {
            return numero % 2 == 0;
        }

        static bool EsMultiploDe(this int numero, int divisor)
        {
            return numero % divisor == 0;
        }
        
        internal static bool TestPrimo(this int numero, out int divisor1, out int divisor2)
        {
            bool esPrimo = true;
            int divisor = 2;

            //if (numero == 1 || numero == 2) esPrimo = true;   //Si es numero es 1 o 2 seguro que es primo                
            //else                                              //Si no, numero > 3 habra que probar que no lo es

            if (numero > 3 && numero % divisor == 0) esPrimo = false;   //Si el munero es para no es primo
            else
            {
                //Nos marcamos como limite para probar divisores un maximo igual a la raiz de n, 
                //Porque si se tiene que dar n = p * q buscamos q probando si n/p da de resto 0
                //pero es lo mismo que n = q * p y buscar p haciendo n/q
                // el mayor valor de p y q se dará cuando ambos sean iguales y eso implica que tanto p = q 
                //luego n = p * p   o   n = q * q , es decir raiz(n) = p = q

                int limite = (int)Math.Sqrt(numero);

                for (divisor = 3; divisor <= limite; divisor += 2)  //Probamos a encontrar un divisor desde 3 hasta el limite, probamos solo los impares
                {
                    if (numero % divisor != 0) continue;  //Si el numero no es divisible por divisor continuamos directamente probrando con el siguiente
                    esPrimo = false;    //Si pasamos alguna vez del continue hemos encontrado un divisor, n no es primo
                    break;              //Como lo hemos encontrado, salimos del bucle antes del final porque ya no hace falta seguir probando
                }
            }

            divisor1 = divisor;
            divisor2 = numero / divisor1;
            return esPrimo;
        }

        internal static bool EsPrimo(this int num)
        {
            int div1, div2;
            return TestPrimo(num,out div1, out div2);
        }

    }
}
