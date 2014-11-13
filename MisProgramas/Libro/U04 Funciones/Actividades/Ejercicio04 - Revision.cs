using System;
using System.Collections;
using System.Text;

namespace Programacion.Funciones.Actividades
{
    static class Ejercicio04Version2
    {
        static void Main()
        {          
            ulong numBinario;
            string entrada;

            Console.Write("Introduce el numero binario a convertir a decimal: ");
            while (!UInt64.TryParse(entrada = Console.ReadLine(), out numBinario) || !SoloCerosYUnos(entrada))
                Console.WriteLine("No has instroducido un numero con solo cifras 0 y 1");

            ulong numDecimal = ConvertirBinarioADecimal(numBinario);
            Console.WriteLine("El numero {0} b en decimal es {1}", numBinario, numDecimal);
            Console.ReadKey();

            BitArray binario = new BitArray(32);
            binario.Set(31, true);
            binario[30] = true;

            //MostrarBinario(binario);
            //MostrarBinario(Parse("10111011000"));
            //int n = ConvertirBinarioADecimal(Parse("10100"));
            //Console.WriteLine(n);

            Console.WriteLine(ConvertirBinarioADecimal(10100ul));
            Console.ReadKey();
        }

        static bool SoloCerosYUnos(string texto)
        {
            foreach (char c in texto)
                if (c != '0' && c != '1') return false;

            return true;
            //Se puede hacer tambien con Linq
        }

        static void MostrarBinario(bool[] binario)
        {
            MostrarBinario(new BitArray(binario));
            //for (int i = binario.Length - 1; i >= 0; i--)
            //    Console.Write(binario[i] ? "1" : "0");

            //Console.WriteLine();
        }
        
        static void MostrarBinario(BitArray binario)
        {
            for (int i = binario.Length - 1; i >= 0; i--)
                Console.Write(binario[i] ? "1" : "0");

            Console.WriteLine();
        }

        static string ToString(bool[] binario)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = binario.Length - 1; i >= 0; i--)
                sb.Append(binario[i] ? "1" : "0");

            sb.AppendLine();

            return sb.ToString();
        }

        static bool[] Parse(string sBinario)
        {
            if (!SoloCerosYUnos(sBinario))
                throw new FormatException("La cadena no tiene el formato correcto, solo puede contener 0's o 1's.");

            int posPrimer1 = sBinario.IndexOf('1');  //Buscamos el primer 1
            sBinario = sBinario.Substring(posPrimer1);  //Nos quedamos con lo que va desde ahi
            
            int tamaño = sBinario.Length;
            bool[] bin = new bool[tamaño];

            int pos = tamaño - 1;
            foreach (char cifra in sBinario)
            {
                if (cifra != '0' && cifra != '1') 
                    throw new FormatException("La cadena no tiene el formato correcto, solo 0's y 1's");
                bin[pos--] = cifra == '1';
            }
            return bin;
        }

        static ulong ConvertirBinarioADecimal(string binario)
        {
            return ConvertirBinarioADecimal(Parse(binario));
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

        static ulong ConvertirBinarioADecimal(bool[] binario)
        {
            ulong valor = 0;
            for (int i = 0; i < binario.Length; i++)
            {
                valor += binario[i] ? (ulong)Math.Pow(2, i) : 0;
            }
            return valor;
        }

        static ulong ConvertirBinarioADecimal(BitArray binario)
        {
            ulong valor = 0;
            for (int i = 0; i < binario.Length; i++)
            {
                valor += binario[i] ? (ulong)Math.Pow(2, i) : 0;
            }
            return valor;
        }
    }

}
