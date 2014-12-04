using System;

namespace Programacion.POO.TAD.Estructuras.Inmutable
{
    struct Fraccion
    {
        public readonly long Numerador;
        public readonly long Denominador;

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
            return new Fraccion(this.Numerador * factor, denominadorObjetivo);            
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
            return new Fraccion(this.Numerador / mcd, this.Denominador / mcd);            
        }

        public Fraccion Sumar(Fraccion f2)
        {
            long mcm = MCM(this.Denominador, f2.Denominador);            

            this = this.ToDenominador(mcm);
            f2 = f2.ToDenominador(mcm);

            return new Fraccion(this.Numerador + f2.Numerador, mcm).Reducir();
        }

        public Fraccion Restar(Fraccion f2)
        {
            return this.Sumar(new Fraccion(-f2.Numerador, f2.Denominador));
        }

        public Fraccion Multiplicar( Fraccion f2)
        {
            Fraccion mult = new Fraccion(
                this.Numerador * f2.Numerador,
                this.Denominador * f2.Denominador);           
            return mult.Reducir();
        }

        public Fraccion Invertir()
        {
            return new Fraccion(this.Denominador,this.Numerador);   
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

            
            long numerador = iNumeroEntero - (restar1 ? 1 : 0) - iParteNoPeriodica;
            long denominador = iDenominador;

            return new Fraccion(numerador, denominador).Reducir();
        }
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
            Fraccion f = new Fraccion(6666, 9999);

            Console.WriteLine(f.Reducir()); // LLamada automatica al metodo ToString()
        }

        static void TestSumar()
        {
            Fraccion f1 = new Fraccion(2, 30);
            Fraccion f2 = new Fraccion(3, 15);                
            
            Fraccion fm = f1.Sumar(f2);
            Console.WriteLine("{0} + {1} = {2}", f1, f2, fm);
        }

        static void TestRestar()
        {
            Fraccion f1 = new Fraccion(25, 30);
            Fraccion f2 = new Fraccion(5, 15);      

            Fraccion fm = f1.Restar(f2);
            Console.WriteLine("{0} - {1} = {2}", f1, f2, fm);
        }

        static void TestMultiplicar()
        {
            Fraccion f1 = new Fraccion(2, 3);
            Fraccion f2 = new Fraccion(3, 5);  

            Fraccion fm = f1.Multiplicar(f2);
            Console.WriteLine("{0} * {1} = {2}", f1, f2, fm);
        }

        static void TestFromDouble()
        {
            Fraccion f = new Fraccion(6666, 9999);                     

            double d = 0.142857; //1 / 7.0; //2.46; //0.16; //57.18; //629/11.0;
            f = Fraccion.FromDouble(d, 6);
            MostrarFraccion(f);
        }

        static void MostrarFraccion(Fraccion f)
        {
            Console.Write(f.ToString());
        }
                
    }

}
