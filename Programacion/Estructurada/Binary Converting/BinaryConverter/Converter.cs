using System;
using System.Collections.Generic;
using System.Text;


namespace Programacion.Binario
{
    public enum Endian
    {
        LittleEndian, BigEndian
    }

    public static class Converter
    {
        public const char Zero = '0';
        public const char One = '1';
        public const char BinSeparator = ':';
        public const char HexSeparator = '-';

        private const byte BitsInByte = 8;
        private const byte BytesInInt32 = 4;


        public static char ToChar(this bool bit, char zero = Zero, char one = One)
        {
            return bit ? one : zero;
        }

        public static string ToString(this bool[] bits, char zero = Zero, char one = One)
        {
            StringBuilder sbOctet = new StringBuilder(bits.Length);
            foreach (bool bit in bits)
            {
                sbOctet.Insert(0, ToChar(bit, zero, one));
            }
            return sbOctet.ToString();
        }


        public static bool[] GetBits(this byte octet)
        {
            bool[] bits = new bool[BitsInByte];
            for (int i = 0; i < bits.Length; i++)
            {
                bits[i] = octet % 2 != 0;
                octet >>= 1;
            }
            return bits;
        }

        public static byte ToByte(this bool[] bits)
        {
            if (bits == null || bits.Length != BitsInByte)
                throw new ArgumentException("El arrat de bits no es nulo o no tiene 8 bits");

            byte octet = 0;
            for (int i = bits.Length - 1; i >= 0; i--)
            {
                octet += (byte)(bits[i] ? 1 : 0);
                if (i > 0) octet <<= 1;
            }
            return octet;
        }


        public static byte[] GetBytes(this int x)
        {
            int mask = 0xFF;
            byte[] bytes = new byte[BytesInInt32];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = (byte)((x & mask) >> i * BitsInByte);
                mask <<= BitsInByte;
            }
            return bytes;
        }

        public static int ToInt32(this byte[] bytes)
        {
            int x = 0;
            for (int i = bytes.Length - 1; i >= 0; i--)
            {
                x = x | bytes[i];
                if (i > 0) x <<= BitsInByte;
            }
            return x;
        }


        public static IEnumerable<byte> Bytes(this int x, Endian endianType = Endian.LittleEndian)
        {
            byte[] bytes = GetBytes(x);

            Predicate<int> condicion = null;
            Func<int, int> operacion = null;

            int inicial = 0;
            switch (endianType)
            {
                case Endian.LittleEndian:
                    inicial = 0;
                    condicion = (index => index < bytes.Length);
                    operacion = (index => ++index);
                    break;

                case Endian.BigEndian:
                    inicial = bytes.Length - 1;
                    condicion = (index => index >= 0);
                    operacion = (index => --index);
                    break;
            }

            for (int i = inicial; condicion(i); i = operacion(i))
            {
                yield return bytes[i];
            }

        }


        public static string ToBinaryString(this byte octet, char zero = Zero, char one = One)
        {
            bool[] bits = GetBits(octet);
            return ToString(bits, zero, one);

            //return octet.GetBits().ToString(zero, one);   //Orientado a objetos
        }

        public static bool[] ToBinary(this int x)
        {
            bool[] bits = new bool[BytesInInt32 * BitsInByte];
            byte[] bytes = GetBytes(x);
            int i = 0;
            foreach (byte octet in bytes)
            {
                bool[] octetBits = GetBits(octet);
                octetBits.CopyTo(bits, BitsInByte * i++);
            }
            return bits; //little endian
        }


        public static byte[] ToBytes(this bool[] binary)
        {
            if (binary == null || binary.Length % BitsInByte != 0)
                throw new ArgumentException("El array binario es nulo o no es un multiplo de 8 bits");

            int numBytes = binary.Length / BitsInByte;

            byte[] octets = new byte[numBytes];
            for (int n = 0; n < numBytes; n++)
            {
                bool[] bits = new bool[BitsInByte];
                for (int i = 0; i < BitsInByte; i++)
                {
                    bits[i] = binary[BitsInByte * n + i];
                }
                octets[n] = ToByte(bits);
            }
            return octets;
        }

        public static string ToBinaryString(this bool[] binary, Endian endianType = Endian.LittleEndian, bool byteSeparation = true, char zero = Zero, char one = One)
        {
            if (binary == null || binary.Length != BytesInInt32 * BitsInByte)
                throw new ArgumentException("El array binario proporcionado es nulo o no tiene 32 bits");

            byte[] octets = ToBytes(binary);
            int x = ToInt32(octets);
            return ToBinaryString(x, endianType, byteSeparation, zero, one);
        }

        public static string ToBinaryString(this int x, Endian endianType = Endian.LittleEndian, bool byteSeparation = true, char zero = Zero, char one = One)
        {
            StringBuilder sb = new StringBuilder();

            foreach (byte b in Converter.Bytes(x, endianType))
            {
                sb.Append(ToBinaryString(b, zero, one));

                if (byteSeparation) sb.Append(BinSeparator);
            }

            if (byteSeparation) sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }


        public static string ToHexadecimal(this bool[] bits)
        {
            //byte octet = ToByte(bits);
            //return ToHexadecimal(octet);

            //Forma funcional
            //return ToHexadecimal(ToByte(bits));

            //return bits.ToByte().ToHexadecimal();       //Forma orientada a objetos

            switch (bits.Length)
            {
                case BytesInInt32 * BitsInByte:
                    return bits.ToBytes().ToInt32().ToHexadecimal();

                case BitsInByte:
                    return bits.ToByte().ToHexadecimal();

            }
            return string.Empty;
        }

        public static string ToHexadecimal(this byte octet)
        {
            string formatter = "{0,2:X2}";
            return String.Format(formatter, octet);
        }

        public static string ToHexadecimal(this int x, Endian endianType = Endian.LittleEndian, char separator = HexSeparator)
        {
            StringBuilder sb = new StringBuilder();

            foreach (byte octet in GetBytes(x))
            {
                switch (endianType)
                {
                    case Endian.LittleEndian:
                        sb.AppendFormat("{0}{1}", ToHexadecimal(octet), separator);
                        break;
                    case Endian.BigEndian:
                        sb.Insert(0, ToHexadecimal(octet)).Insert(0, separator);
                        break;
                }
            }

            sb.Remove(endianType == Endian.LittleEndian ? sb.Length - 1 : 0, 1);     //Eliminar el ultimo separador

            return sb.ToString();
        }

        //public static string ToHexadecimalv2(int x, bool littleEndian = false, char separator = HexSeparator)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    foreach (byte octet in Bytes(x, littleEndian))
        //    {
        //        sb.AppendFormat("{0,2:X2}", octet);
        //        sb.Append(separator);
        //    }

        //    sb.Remove(sb.Length - 1, 1);    //Eliminar el ultimo separador
        //    return sb.ToString();
        //}



        //public static string ToHexadecimalv1(int x, bool littleEndian = false)
        //{             
        //    byte[] bytes = BitConverter.GetBytes(x);

        //    Predicate<int> condicion;
        //    Func<int, int> operacion;

        //    int inicial;
        //    if (littleEndian)
        //    {
        //        inicial = 0;
        //        condicion = (index => index < bytes.Length);
        //        operacion = (index => ++index);
        //    }
        //    else
        //    {
        //        inicial = bytes.Length - 1;
        //        condicion = (index => index >= 0);
        //        operacion = (index => --index);
        //    }

        //    StringBuilder sb = new StringBuilder();
        //    for (int i = inicial; condicion(i); i = operacion(i))
        //    {
        //        sb.AppendFormat("{0,2:X2}", bytes[i]);
        //        sb.Append("-");
        //    }

        //    sb.Remove(sb.Length - 1, 1);
        //    return sb.ToString();
        //}

        //public static string ToHexadecimalv3(int x)
        //{
        //    return BitConverter.ToString(BitConverter.GetBytes(x));
        //}


        //internal static string ToBinaryv2(int integer32, bool littleEndian = false, bool byteSeparation = true, char zero = Zero, char one = One)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    foreach (byte b in Converter.Bytes(integer32, littleEndian))
        //    {
        //        BitArray ba = new BitArray(new byte[] { b });

        //        for (int i = ba.Length - 1; i >= 0; i--)
        //        {
        //            sb.Append(ba[i] ? one : zero);
        //            //if (byteSeparation && i % 8 == 0 && i != 0) sb.Append(BinSeparator);
        //        }
        //        if (byteSeparation) sb.Append(BinSeparator);
        //    }

        //    if (byteSeparation) sb.Remove(sb.Length - 1, 1);

        //    return sb.ToString();
        //}

    }

}
