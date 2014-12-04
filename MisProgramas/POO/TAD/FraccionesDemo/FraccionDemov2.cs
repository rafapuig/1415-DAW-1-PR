using System;

namespace Programacion.POO.TAD.Estructuras
{
    struct Fraccion
    {
        public long Numerador;
        public long Denominador;

        public  Fraccion(long numerador, long denominador)
        {
            this.Numerador = numerador;
            this.Denominador = denominador;

            //si el denominador es negativo
            if(this.Denominador<0)
            {
                //Mover el signo negativo hacia el numerador
                this.Numerador = -this.Numerador;
                this.Denominador = -this.Denominador;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} / {1}", this.Numerador, this.Denominador);
        }

        public Fraccion ToDenominador(long denominadorObjetivo)
        {
            long factor = denominadorObjetivo / this.Denominador;
            Fraccion f;
            f.Numerador = this.Numerador * factor;
            f.Denominador = denominadorObjetivo;
            return f;
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

        public Fraccion Reducir()
        {
            long mcd = MCD(this.Numerador, this.Denominador);
            Fraccion s;
            s.Numerador = this.Numerador / mcd;
            s.Denominador = this.Denominador / mcd;
            return s;
        }

        public Fraccion Sumar(Fraccion f2)
        {
            long mcm = MCM(this.Denominador, f2.Denominador);
            Fraccion suma;

            this = this.ToDenominador(mcm);
            f2 = f2.ToDenominador(mcm);

            suma.Denominador = mcm;
            suma.Numerador = this.Numerador + f2.Numerador;

            //suma.Numerador = f1.Numerador * mcm / f1.Denominador + f2.Numerador * mcm / f2.Denominador;
            return suma.Reducir();
        }

        public Fraccion Restar(Fraccion f2)
        {
            f2.Numerador = -f2.Numerador;
            return this.Sumar(f2);
        }

        public Fraccion Multiplicar(Fraccion f2)
        {
            Fraccion mult;
            mult.Denominador = this.Denominador * f2.Denominador;
            mult.Numerador = this.Numerador * f2.Numerador;
            return mult.Reducir();
        }

        public Fraccion Invertir()
        {
            Fraccion fi;
            fi.Numerador = this.Denominador;
            fi.Denominador = this.Numerador;
            return fi;
        }
        
        public Fraccion Dividir(Fraccion f2)
        {
            return this.Multiplicar(f2.Invertir());            
        }

        public double ToDouble()
        {
            return (double)this.Numerador / this.Denominador;
        }

        public static Fraccion FromDouble(double d, int cifrasPeriodo = 15)
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
            f.Numerador = iNumeroEntero - (restar1 ? 1 : 0) - iParteNoPeriodica;
            f.Denominador = iDenominador;

            return f.Reducir();
        }
    }

    static class FraccionDemo
    {
        static void Main()
        {
            Fraccion f = new Fraccion(1, 3);

            TestSumar();
            TestRestar();
            TestMultiplicar();
            TestFromDouble();
            Console.ReadKey();
        }
        
        static void TestReducir()
        {
            Fraccion f = new Fraccion(6666, 9999);

            Console.WriteLine(f.Reducir()); // LLamada automatica al metodo ToString()
        }

        static void TestSumar()
        {
            Fraccion f1, f2;

            f1.Numerador = 2;
            f1.Denominador = 30;

            f2.Numerador = 3;
            f2.Denominador = 15;            
            
            Fraccion fm = f1.Sumar(f2);
            Console.WriteLine("{0} + {1} = {2}", f1, f2, fm);
        }

        static void TestRestar()
        {
            Fraccion f1, f2;

            f1.Numerador = 25;
            f1.Denominador = 30;

            f2.Numerador = 5;
            f2.Denominador = 15;

            Fraccion fm = f1.Restar(f2);
            Console.WriteLine("{0} - {1} = {2}", f1, f2, fm);
        }

        static void TestMultiplicar()
        {
            Fraccion f1, f2;
            
            f1.Numerador = 2;
            f1.Denominador = 3;
            
            f2.Numerador = 3;
            f2.Denominador = 5;

            Fraccion fm = f1.Multiplicar(f2);
            Console.WriteLine("{0} * {1} = {2}", f1, f2, fm);
        }

        static void TestFromDouble()
        {
            Fraccion f;

            f.Numerador = 6666;
            f.Denominador = 9999;

            double d = 0.142857; //1 / 7.0; //2.46; //0.16; //57.18; //629/11.0;
            f = Fraccion.FromDouble(d, 6);
            MostrarFraccion(f);
        }

        static void MostrarFraccion(Fraccion f)
        {
            //Console.Write(f.ToString());
            Console.Write(f);
        }
                
    }
}
