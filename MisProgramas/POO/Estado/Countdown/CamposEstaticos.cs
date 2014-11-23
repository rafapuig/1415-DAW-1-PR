using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estado.Countdown.CamposEstaticos
{
    static class Countdown
    {
        static int ValorAnterior = 10;

        static int Descuenta()
        {
            return --ValorAnterior;
        }

        static void Main()
        {             
            int cuentaAtras = Descuenta();
            MuestraCuentaAtras(cuentaAtras);
            
            cuentaAtras = Descuenta();
            MuestraCuentaAtras(cuentaAtras);

            MuestraCuentaAtras(Descuenta());
            
            Descuenta();
            Descuenta();
            MuestraCuentaAtras(ValorAnterior);
            

            //Nos lo podemos cargar asi
            ValorAnterior = 50;
            cuentaAtras = Descuenta();
            MuestraCuentaAtras(cuentaAtras);
        }

        static void MuestraCuentaAtras(int cuenta)
        {
            Console.WriteLine("La cuenta atras va por {0}", cuenta);
        }
    }
}
