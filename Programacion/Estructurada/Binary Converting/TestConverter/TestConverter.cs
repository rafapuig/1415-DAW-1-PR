using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.Binario
{
    static class TestConverter
    {
        static void Main()
        {
            Console.WriteLine(BitConverter.IsLittleEndian);
            
            BitToCharTest();
            ToStringTest();
            GetBitsTest();
            ToByteTest();
            ToInt32Test();
            
            Console.ReadKey();
            Console.Clear();
        }

        static void BitToCharTest()
        {
            bool bit = true;
            char digito = Converter.ToChar(bit);

            Console.WriteLine(digito);

            bit = false;
            digito = Converter.ToChar(bit);
            Console.WriteLine(digito);

            Console.WriteLine(Converter.ToChar(false));
            Console.WriteLine(Converter.ToChar(true));

            Console.WriteLine(false.ToChar());
            Console.WriteLine(true.ToChar());
            Console.WriteLine(bit.ToChar());

            Console.WriteLine(false.ToChar('.', 'P'));
            Console.WriteLine(true.ToChar('.', 'P'));

            Console.WriteLine(false.ToChar(zero: '-', one: 'X'));
            Console.WriteLine(true.ToChar(zero: '-', one: 'X'));

            Console.WriteLine(false.ToChar(zero: '-'));
            Console.WriteLine(true.ToChar(zero: '-'));

            Console.WriteLine(false.ToChar(one: 'X'));
            Console.WriteLine(true.ToChar(one: 'X'));

            Console.WriteLine();
        }

        static void ToStringTest()
        {
            Console.WriteLine("ToStringTest()");

            bool[] p = new bool[16];
            p[4] = true;
            Console.WriteLine(Converter.ToString(p));

            p[7] = true;
            Console.WriteLine(p.ToString('0', '1'));

            for (int n = 10; n < 15; n++)
                p[n] = true;
            Console.WriteLine(Converter.ToString(p, '-', 'X'));

            Console.WriteLine();
        }

        static void GetBitsTest()
        {
            Console.WriteLine("GetBitsTest()");
            byte b = 170;
            Console.WriteLine(b);
            bool[] bits = b.GetBits();
            Console.WriteLine(bits.ToString('0', '1'));

            b >>= 1;
            Console.WriteLine(b.GetBits().ToString('0', '1'));
            Console.WriteLine();
        }


        private static void ToByteTest()
        {
            Console.WriteLine("ToByteTest()");

            bool[] p = new bool[8];
            p[4] = true;
            p[2] = true;
            p[0] = true;
            Console.WriteLine(Converter.ToString(p));

            byte b = Converter.ToByte(p);
            Console.WriteLine(b);

            bool[] p2 = b.GetBits();
            Console.WriteLine(Converter.ToString(p2));
            Console.WriteLine();
        }

        private static void ToInt32Test()
        {
            Console.WriteLine("ToInt32Test()");

            int x = 12345;
            Console.WriteLine(x);
            Console.WriteLine(x.ToBinaryString());

            byte[] bytes = x.GetBytes();
            x = bytes.ToInt32();
            Console.WriteLine(x);
            Console.WriteLine(x.ToBinaryString());

            Console.WriteLine();
        }
            
    }
}
