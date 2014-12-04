using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.Iniciacion.Actividades
{
    static class Ejercicio11
    {
        static void Main()
        {
            int numero = 43001007;

            int cifra;  //Al final del bucle tendrá la cifra correspondiente a la iteracion actual
            int cifras = numero;    //Al final del bucle interno contiene el numero sin las cifras  procesadas
            int potencia = 1;

            while (cifras >= 10)
            {
                cifra = cifras;
                potencia = 1;
                while (cifra >= 10)
                {
                    cifra = cifra / 10;
                    potencia *= 10;
                }
                cifras -= cifra * potencia;
                Console.Write("{0}-", cifra);
                while (potencia > 10 && cifras < (potencia /= 10)) Console.Write("{0}-", 0);
            }

            Console.Write("{0}", cifras);

            Console.ReadKey();
        } 

    } 
    
}
