using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.Iniciacion.Ejemplos
{
    static class TAEDemo
    {
        static void Main()
        {
            double interes = CalcularTAE(0.04, -1000.0M, 300M, 400M, 300M, 200M);
            //interes = CalcularTAE(terminos: new decimal[]{100, 100, 100, 100, 100});
            Console.WriteLine("La TAE es {0:P4}", interes);
            Console.ReadKey();
        }

        static double CalcularTAE(double taeInicial = 0, params decimal[] terminos)
        {
            double tempTAE = taeInicial;
            double prevTAE;

            decimal error = SumarFinancieramente(tempTAE, terminos);
            int signoInicial = Math.Sign(error);

            int signo;
            int limiteIteraciones = 40;
            double margen = 0.01;   //intervalo de margen base que vamos a ampliar para acotar el valor

            //detectar un cambio de signo
            int contador = 0;
            do
            {
                prevTAE = tempTAE;
                tempTAE += signoInicial * margen * Math.Pow(2, contador++);
                error = SumarFinancieramente(tempTAE, terminos);
                signo = Math.Sign(error);

            } while (signo == signoInicial && contador < limiteIteraciones);

            if (contador == limiteIteraciones)
                throw new ArithmeticException("El calculo no converge para los valores proporcionados");

            return CalcularTAE(prevTAE, tempTAE, terminos);
        }

        static double CalcularTAEv2(double taeInicial = 0, params decimal[] terminos)
        {
            double tempTAE;
            double prevTAE = tempTAE = taeInicial;

            int signoInicial = Math.Sign(SumarFinancieramente(tempTAE, terminos));
            
            int limiteIteraciones = 40;
            double margen = 0.01;   //intervalo de margen base que vamos a ampliar para acotar el valor

            //detectar un cambio de signo
            int contador;
            for (contador = 0; contador < limiteIteraciones; contador++)
            {
                prevTAE = tempTAE;
                tempTAE += signoInicial * margen * Math.Pow(2, contador++);                
                if (signoInicial != Math.Sign(SumarFinancieramente(tempTAE, terminos))) break;
            }

            if (contador == limiteIteraciones)
                throw new ArithmeticException("El calculo no converge para los valores proporcionados");

            return CalcularTAE(prevTAE, tempTAE, terminos);
        }

        private static double CalcularTAE(double lowTAE, double highTAE, decimal[] terminos)
        {
            const decimal maxError = 0.099M;
            decimal error = 0M;
            double tempTAE;

            if (lowTAE>highTAE) Swap(ref lowTAE, ref highTAE);

            do
            {
                tempTAE = (lowTAE + highTAE) / 2;
                error = SumarFinancieramente(tempTAE, terminos);
                int signo = Math.Sign(error);
                
                if (signo > 0) lowTAE = tempTAE;        //Si es positivo hay que buscar por la derecha (int + alto)
                else if (signo < 0) highTAE = tempTAE;  //Si es negativo hay que bajar por la izquierda (int + bajo)
                else break;

            } while (Math.Abs(error) > maxError);

            return tempTAE;
        }

        static void Swap(ref double a, ref double b)
        {  
            double temp;
            temp = a;
            a = b;
            b = temp;            
        }     


        private static decimal SumarFinancieramente(double tipoInteres, params decimal[] terminos)
        {
            decimal suma = 0;

            for (int i = 0; i < terminos.Length; i++)
                suma += terminos[i] / (decimal)Math.Pow((1 + tipoInteres), i);
            
            return suma;
        }
    }
}
