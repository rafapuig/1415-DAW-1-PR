using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estado.Countdown.SinEstado
{
    static class CountdownSinEstado
    {
        static int Descuenta(int valorAnterior)
        {
            return --valorAnterior;
        }

        static void Main()
        {
            int cuentaAtras = 10;            
            int nuevoCuentaAtras = Descuenta(cuentaAtras);
            cuentaAtras = nuevoCuentaAtras;
            MuestraCuentaAtras(cuentaAtras);
            
            cuentaAtras = Descuenta(cuentaAtras);
            MuestraCuentaAtras(cuentaAtras);
            
            //Esto es un uso no correcto semanticamente pero posible
            cuentaAtras = Descuenta(25);
            MuestraCuentaAtras(cuentaAtras);
        }

        static void MuestraCuentaAtras(int cuenta)
        {
            Console.WriteLine("La cuenta atras va por {0}", cuenta);
        }
    }
}
