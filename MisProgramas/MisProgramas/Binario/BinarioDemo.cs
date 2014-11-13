using System;
using System.Collections.Generic;
using System.Text;

namespace Programacion.Binario
{    
    static class BinarioDemo
    {
        static void Main()
        {
            int x;

            ComplementoA1(0x3F57FEFE);
            //ComplementoA1(1234567890);
            AndBinario(100, 200);
            OrBinario(100, 200);
            XOrBinario(100, 200);
            Console.ReadKey();

            Console.Clear();
            x = DeplazarIzqBits(240, 2);
            DeplazarDerechaBits(x, 3);
            Console.ReadKey();

            Console.Clear();
            x = EncenderBit(192, 4);
            ApagarBit(x, 4);

            NegativosDemo(1000);
            XorDemo();

            Console.ReadKey();
        }



        static void EscribirLinea(string expr, int x)
        {
            Console.Write("{0,-14} ", expr);
            Console.Write("{0,12} / ", x);
            //Console.Write(Converter.ToHexadecimal(x));
            Console.Write(x.ToHexadecimal(endianType: Endian.BigEndian));
            //Console.Write(BitConverter.ToString(BitConverter.GetBytes(x)));
            //Console.Write(" / {0}", Converter.ToBinary(x, zero: '-', one: 'P'));
            Console.Write(" / {0}", x.ToBinaryString(endianType: Endian.BigEndian));
            //Console.Write(" / {0}", x.ToBinary(zero: '-', one: 'P'));
            Console.WriteLine();
        }
           
 
        static int ComplementoA1(int x)
        {
            Console.WriteLine("El operador NOT [ ~ ] o Complemento (a 1) intercambia 1's por 0's");
            EscribirLinea(string.Format("x = {0}", x), x);
            EscribirLinea("x = ~x", x = ~x);
            Console.WriteLine();
            return x;
        }

        static int AndBinario(int x, int y)
        {
            Console.WriteLine("El operador AND [ & ] a nivel de bit ");
            EscribirLinea(string.Format("x = {0}", x), x);
            EscribirLinea(string.Format("y = {0}", y), y);
            EscribirLinea("x & y", x = x & y);
            Console.WriteLine();
            return x;
        }

        static int OrBinario(int x, int y)
        {
            Console.WriteLine("El operador OR [ | ] a nivel de bit ");
            EscribirLinea(string.Format("x = {0}", x), x);
            EscribirLinea(string.Format("y = {0}", y), y);
            EscribirLinea("x | y", x = x | y);
            Console.WriteLine();
            return x;
        }

        static int XOrBinario(int x, int y)
        {
            Console.WriteLine("El operador XOR [ ^ ] a nivel de bit ");
            EscribirLinea(string.Format("x = {0}", x), x);
            EscribirLinea(string.Format("y = {0}", y), y);
            EscribirLinea("x ^ y", x = x ^ y);
            Console.WriteLine();
            return x;
        }

        static int DeplazarIzqBits(int num, int bits)
        {
            int x;
            Console.WriteLine("Desplazar a la izquierda {0} bits", bits);
            EscribirLinea(string.Format("x = {0}", num), x = num);
            EscribirLinea(string.Format("x = x << {0}", bits), x = x << bits);
            Console.WriteLine();
            return x;
        }

        static int DeplazarDerechaBits(int num, int bits)
        {
            int x;
            Console.WriteLine("Desplazar a la izquierda {0} bits", bits);
            EscribirLinea(string.Format("x = {0}", num), x = num);
            EscribirLinea(string.Format("x = x >> {0}", bits), x = x >> bits);
            Console.WriteLine();
            return x;
        }
        

        static int ApagarBit(int num, int bit)
        {
            int x;
            string expr;
            Console.WriteLine("Apagar un bit {0}", bit);

            expr = string.Format("x = {0}", num);
            EscribirLinea(expr, x = num);

            expr = (1 << bit).ToString();
            //EscribirLinea(expr, 1 << bit);

            expr = "~" + expr;
            EscribirLinea(expr, ~(1 << bit));

            expr = string.Format("x = x & ~{0}", 1 << bit);
            EscribirLinea(expr, x = x & ~(1 << bit));
            
            Console.WriteLine();
            return x;
        }

        static int EncenderBit(int num, int bit)
        {
            int x;
            Console.WriteLine("Encender bit {0}", bit);
            EscribirLinea(string.Format("x = {0}", num), x = num);
            EscribirLinea(string.Format("bit {0} -> {1}", bit, 1 << bit), 1 << bit);
            EscribirLinea(string.Format("x = x | {0}", 1 << bit), x = x | 1 << bit);
            Console.WriteLine();
            return x;
        }


        static void NegativosDemo(int num)
        {
            int x;
            Console.WriteLine("Demo -x = ~x + 1");
            EscribirLinea(string.Format("x = {0}", num), x = num);
            EscribirLinea("~x", ~x);
            EscribirLinea("1", 1);
            EscribirLinea("~x + 1", ~x + 1);
            EscribirLinea("-x", -x);
            Console.WriteLine();
        }

        static void XorDemo()
        {
            int x, y;
            Console.WriteLine("Demo x XOR y != x + y");
            EscribirLinea("x = 1047", x = 1047);
            EscribirLinea("y = 2060", y = 2060);
            EscribirLinea("x ^ y", x ^ y);
            EscribirLinea("x + y", x + y);
            Console.WriteLine();
        }

        private static void ApagarBitDemo()
        {
            int x;
            Console.WriteLine("Demo apagar un bit");
            EscribirLinea("x = 37", x = 37);
            EscribirLinea("32", 32);
            EscribirLinea("~32", ~32);
            EscribirLinea("x= x & ~32", x = x & ~32);
            Console.WriteLine();
        }

        private static void EncenderBitDemo()
        {
            int x;
            Console.WriteLine("Demo encender un bit");
            EscribirLinea("x = 5", x = 5);
            EscribirLinea("32", 32);
            EscribirLinea("x = x | 32", x = x | 32);
            Console.WriteLine();            
        }

    }

}
