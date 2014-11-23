using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estado.Countdown.CamposEstaticos.Protegido
{
    static class Countdown
    {
        static int ValorAnterior = 10;

        public static int Descuenta()
        {
            return --ValorAnterior;
        }

        public static int GetEstadoCuenta()
        {
            return ValorAnterior;
        }
    }

    static class Programa
    {
        static void Main()
        {
            int cuentaAtras = Countdown.Descuenta();           

            cuentaAtras = Countdown.Descuenta();
            MuestraCuentaAtras(cuentaAtras);
                        
            //Countdown.ValorAnterior = 50; //error no se puede acceder, es privado
            cuentaAtras = Countdown.Descuenta();
            MuestraCuentaAtras(cuentaAtras);

            MuestraCuentaAtras(Countdown.Descuenta());

            Countdown.Descuenta();
            Countdown.Descuenta();
            Countdown.Descuenta();
            MuestraCuentaAtras(Countdown.GetEstadoCuenta());

            Countdown.Descuenta();
            MuestraCuentaAtras(Countdown.GetEstadoCuenta());

        }

        static void MuestraCuentaAtras(int cuenta)
        {
            Console.WriteLine("La cuenta atras va por {0}", cuenta);
        }
    }
}
