using System;

namespace Programacion.Iniciacion.Actividades
{
    static class Ejercicio06
    {
        static void Main()
        {
            Console.Write("Introduce importe compra: ");
            string entrada = Console.ReadLine();
            float importe = System.Single.Parse(entrada);

            float porcentajeDescuento;
            if (importe < 200)
                porcentajeDescuento = 0.0f;
            else if (importe >= 200 && importe < 500)
                porcentajeDescuento = 0.05f;
            else if (importe >= 500 && importe < 1000)
                porcentajeDescuento = 0.10f;
            else
                porcentajeDescuento = 0.15f;

            float importeConDescuento = importe * (1 - porcentajeDescuento);

            Console.WriteLine(
                "Para un importe de {0} el descuento aplicado es {1:P} quedando en {2}",
                importe, porcentajeDescuento, importeConDescuento);
            
            Console.ReadKey();
        }
    }
}
