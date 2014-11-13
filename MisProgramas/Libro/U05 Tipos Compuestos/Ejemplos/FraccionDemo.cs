using System;

namespace Programacion.TiposCompuestos
{
    struct Fraccion
    {
        public long Numerador;
        public long Denominador;
    }

    static class FraccionDemo
    {
        static void Main()
        {
            TestSumar();
            TestRestar();
            TestMultiplicar();
            TestFromDouble();
            Console.ReadKey();
        }
        
        static void TestReducir()
        {
            Fraccion f;

            f.Numerador = 6666;
            f.Denominador = 9999;

            Console.WriteLine(f.Reducir().FraccionToString());
        }

        static void TestSumar()
        {
            Fraccion f1, f2;

            f1.Numerador = 2;
            f1.Denominador = 30;

            f2.Numerador = 3;
            f2.Denominador = 15;            
            
            Fraccion fm = f1.Sumar(f2);
            Console.WriteLine("{0} + {1} = {2}", f1.FraccionToString(), f2.FraccionToString(), fm.FraccionToString());
        }

        static void TestRestar()
        {
            Fraccion f1, f2;

            f1.Numerador = 25;
            f1.Denominador = 30;

            f2.Numerador = 5;
            f2.Denominador = 15;

            Fraccion fm = f1.Restar(f2);
            Console.WriteLine("{0} - {1} = {2}", f1.FraccionToString(), f2.FraccionToString(), fm.FraccionToString());
        }

        static void TestMultiplicar()
        {
            Fraccion f1, f2;
            
            f1.Numerador = 2;
            f1.Denominador = 3;
            
            f2.Numerador = 3;
            f2.Denominador = 5;

            Fraccion fm = f1.Multiplicar(f2);
            Console.WriteLine("{0} * {1} = {2}", f1.FraccionToString(), f2.FraccionToString(), fm.FraccionToString());
        }

        static void TestFromDouble()
        {
            Fraccion f;

            f.Numerador = 6666;
            f.Denominador = 9999;

            double d = 0.142857; //1 / 7.0; //2.46; //0.16; //57.18; //629/11.0;
            f = FromDouble(d, 6);
            MostrarFraccion(f);
        }

        static void MostrarFraccion(Fraccion f)
        {
            Console.Write(f.FraccionToString());
        }





        static string FraccionToString(this Fraccion f)
        {
            return String.Format("{0} / {1}", f.Numerador, f.Denominador);
        }


        static Fraccion ToDenominador(this Fraccion f, long denominadorObjetivo)
        {
            long factor = denominadorObjetivo / f.Denominador;
            Fraccion t;
            t.Numerador = f.Numerador * factor;
            t.Denominador = denominadorObjetivo;
            return t;
        }

        static Fraccion Reducir(this Fraccion f)
        {
            long mcd = MCD(f.Numerador, f.Denominador);
            Fraccion s;
            s.Numerador = f.Numerador / mcd;
            s.Denominador = f.Denominador / mcd;
            return s;
        }

        
        static Fraccion Sumar(this Fraccion f1, Fraccion f2)
        {
            long mcm = MCM(f1.Denominador, f2.Denominador);
            Fraccion suma;

            f1 = f1.ToDenominador(mcm);
            f2 = f2.ToDenominador(mcm);

            suma.Denominador = mcm;
            suma.Numerador = f1.Numerador + f2.Numerador;

            //suma.Numerador = f1.Numerador * mcm / f1.Denominador + f2.Numerador * mcm / f2.Denominador;
            return Reducir(suma);
        }

        static Fraccion Restar(this Fraccion f1, Fraccion f2)
        {
            f2.Numerador = -f2.Numerador;
            return f1.Sumar(f2);
        }
              

        static Fraccion Multiplicar(this Fraccion f1, Fraccion f2)
        {            
            Fraccion mult;
            mult.Denominador = f1.Denominador * f2.Denominador;
            mult.Numerador = f1.Numerador * f2.Numerador;
            return Reducir(mult);
        }
        
        static Fraccion Invertir(this Fraccion f)
        {
            Fraccion fi;
            fi.Numerador = f.Denominador;
            fi.Denominador = f.Numerador;
            return fi;
        }


        static Fraccion Dividir(this Fraccion f1, Fraccion f2)
        {
            return f1.Multiplicar(f2.Invertir());
            //return f1.Invertir().Multiplicar(f2).Invertir();
        }

        static double ToDouble(this Fraccion f)
        {
            return (double)f.Numerador / f.Denominador;
        }

        static Fraccion FromDouble(double d, int cifrasPeriodo = 15)
        {
            string sNum = d.ToString();
            string decimalSeparador = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentDecimalSeparator;
            string[] partes = sNum.Split(new string[] { decimalSeparador }, StringSplitOptions.RemoveEmptyEntries);

            cifrasPeriodo = Math.Min(partes[1].Length, cifrasPeriodo);

            int cifrasAnteperiodo = partes[1].Length - cifrasPeriodo;
            string sAnteperiodo = partes[1].Substring(0, cifrasAnteperiodo);

            string sDenominador = string.Concat(new string('9', cifrasPeriodo), new string('0', cifrasAnteperiodo));
            long iDenominador = Int64.Parse(sDenominador);

            string sNumeroEntero = String.Concat(partes);
            long iNumeroEntero = Int64.Parse(sNumeroEntero);

            string sPeriodo = partes[1].Substring(partes[1].Length - cifrasPeriodo, cifrasPeriodo);
            long iPeriodo = Int64.Parse(sPeriodo);

            string sParteNoPeriodica = string.Concat(partes[0], sAnteperiodo);
            long iParteNoPeriodica = Int64.Parse(sParteNoPeriodica);

            bool restar1 = (iPeriodo % 10 >= 5) && cifrasAnteperiodo + cifrasPeriodo + partes[0].Length == 15;
            
            Fraccion f;
            f.Numerador = iNumeroEntero - ( restar1 ? 1 : 0) - iParteNoPeriodica;
            f.Denominador = iDenominador;

            return Reducir(f);
        }

        static long MCM(long a, long b)
        {
            return a / MCD(a, b) * b;    //primero dividir para evitar desbordamiento
        }

        static long MCD(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            long dividendo = Math.Max(a, b);
            long divisor = Math.Min(a, b);

            long resto;
            do
            {
                if ((resto = dividendo % divisor) == 0) return divisor;
                dividendo = divisor;
                divisor = resto;
            } while (true);
        }

    }
}
