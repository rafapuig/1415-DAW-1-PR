using System;

namespace Programacion.Funciones.Actividades
{
    static class Ejercicio04
    {
        static void Main()
        {
            ulong numBinario;
            string entrada;

            Console.Write("Introduce el numero binario a convertir a decimal: ");
            while (!UInt64.TryParse(entrada = Console.ReadLine(), out numBinario) || !SoloCerosYUnos(entrada))
                Console.WriteLine("No has instroducido un numero con solo cifras 0 y 1");

            ulong numDecimal = ConvertirBinarioADecimal(numBinario);
            Console.WriteLine("El numero {0} en decimal es {1}", numBinario, numDecimal);


            Console.WriteLine("El numero {0} en decimal es {1}", entrada, Convert.ToUInt32(entrada, 2));
            Console.ReadKey();            
        }

        static bool SoloCerosYUnos(string texto)
        {            
            foreach(char c in texto)            
                if (c != '0' && c != '1') return false;
            
            return true;
            //Se puede hacer tambien con Linq
        }        

        static ulong ConvertirBinarioADecimal(ulong binario)
        {
            const ulong base2 = 2ul;
            ulong valor = 0;
            ulong pot2 = 1;
            while (binario > 0)
            {
                byte cifra = (byte)(binario % base2);
                valor += cifra * pot2;

                binario /= 10;
                pot2 *= base2;
            }            
            return valor;
        }
        
    }
}
