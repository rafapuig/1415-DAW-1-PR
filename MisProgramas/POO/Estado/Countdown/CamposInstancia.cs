using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estado.Countdown.CamposInstancia
{
    class Countdown
    {
        int valorAnterior = 10;

        public int Descuenta()
        {
            return --this.valorAnterior;
        }

        public int GetEstadoCuenta()
        {
            return this.valorAnterior;
        }        
    }

    static class Programa
    {
        static void Main()
        {
            Countdown c1 = new Countdown();              
            
            int cuentaAtras = c1.Descuenta();            
            MuestraCuentaAtras(cuentaAtras);

            c1.Descuenta();
            MuestraCuentaAtras(c1.Descuenta());

            Countdown c2 = new Countdown();
            c2.Descuenta();
            c2.Descuenta();
            c2.Descuenta();
            int cuenta2 = c2.Descuenta();
            
            MuestraCuentaAtras(cuenta2);
            MuestraCuentaAtras(c2.Descuenta());
            MuestraCuentaAtras(c1.Descuenta());

            MuestraCuentaAtras(c1.GetEstadoCuenta());
            MuestraCuentaAtras(c2.GetEstadoCuenta());
       
        }

        static void MuestraCuentaAtras(int cuenta)
        {
            Console.WriteLine("La cuenta atras va por {0}", cuenta);
        }
    }
}
