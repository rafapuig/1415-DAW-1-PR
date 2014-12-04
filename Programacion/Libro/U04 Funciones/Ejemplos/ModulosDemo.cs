using System;

namespace Programacion.Funciones.Ejemplos.ModulosDemo
{
    static class CircunferenciaTestCUI
    {
        static void Main()
        {
            Console.Write("Introduce el radio de la circunferencia: ");
            double radio = Double.Parse(Console.ReadLine());

            double area = Circunferencia.CalcularArea(radio);

            Console.WriteLine("El area de la circunferencia de radio {0} es {1}", radio, area);
        }
    }

    static class Circunferencia
    {
        internal static double CalcularArea(double radio)
        {
            return radio * 2 * Math.PI;
        }
    }
}
