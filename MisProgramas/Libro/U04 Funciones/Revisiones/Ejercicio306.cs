using System;

namespace Programacion.Iniciacion.Actividades
{
    delegate float ObtenerPorcentajeDescuento(float importe);

    static class Ejercicio306
    {
        static void Main()
        {
            float importe = ObtenerImporte();            

            ObtenerPorcentajeDescuento criterioDescuento = ObtenerPorcentajeDescuentoSegunCriterioEjemplo;

            float porcentajeDescuento = criterioDescuento(importe);

            float descuento = CalcularDescuento(importe, criterioDescuento);

            float importeConDescuento = importe - descuento;

            Console.WriteLine(
                "Para un importe de {0} el descuento aplicado es {1:P} quedando en {2}",
                importe, porcentajeDescuento, importeConDescuento);
            
            Console.ReadKey();
        }

        private static float ObtenerImporte()
        {
            float importe;
            bool esValido = false;
            do
            {
                Console.Write("Introduce importe compra: ");
                if (!System.Single.TryParse(Console.ReadLine(), out importe))
                {
                    Console.WriteLine("La entrada no sigue el formato de numero con decimales 0,000.00");
                    continue;
                }

                if (!(importe >= 0))
                {
                    Console.WriteLine("El importe debe ser un numero positivo o cero.");
                    continue;
                }

                esValido = true;

            } while (!esValido);
            return importe;
        }

        static float ObtenerPorcentajeDescuentoSegunCriterioEjemplo(float importe)
        {
            importe = Math.Abs(importe);
            if (importe < 200) return 0.0f;
            if (importe < 500) return 0.05f;
            if (importe < 1000) return 0.1f;
            return 0.15f;
        }

        static float CalcularDescuento(float importe, ObtenerPorcentajeDescuento criterioDescuento)
        {
            float porcentajeDescuento = criterioDescuento(importe);

            return importe * porcentajeDescuento;
        }
    }
}
