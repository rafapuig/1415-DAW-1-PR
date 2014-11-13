using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.Funciones.Actividades
{
    class Ejercicio03
    {
        static void Main()
        {
            decimal numero; //Hay que hacerlo con tipo decimal, que es exacto en base 10, con double no se puede
            Console.Write("Introduce un numero con parte entera y decimal: ");
            while (!Decimal.TryParse(Console.ReadLine(), out numero))
                Console.WriteLine("No se ha podido extraer un numero del valor introducido, repita");

            int parteEnteraNumero, parteDecimalNumero;
            SepararPartesNumero(numero, out parteEnteraNumero, out parteDecimalNumero);

            Console.WriteLine("La parte entera es {0}", parteEnteraNumero);
            Console.WriteLine("La parte decimal es {0}", parteDecimalNumero);

            Console.ReadKey();
        }

        static void SepararPartesNumero(decimal numero, out int parteEntera, out int parteDecimal)
        {
            parteEntera = (int)Math.Truncate(numero);           

            decimal decimales = numero - Decimal.Truncate(numero);
            do
            {
                decimales = decimales * 10;
                parteDecimal = (int)Math.Truncate(decimales);

            } while (decimales - parteDecimal != 0);            

        }
    }
}
