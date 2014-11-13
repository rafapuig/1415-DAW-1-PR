using System;

namespace Programacion.Iniciacion.Actividades
{
    static class Ejercicio20
    {
        static void Main()
        {
            const int diasEnero = 31;
            const int diasMarzo = 31;
            const int diasFebrero = 28;
            const int diasAbril = 30;
            const int diasMayo = 31;
            const int diasJunio = 30;
            const int diasJulio = 31;
            const int diasAgosto = 31;
            const int diasSeptiembre = 30;
            const int diasOctubre = 31;
            const int diasNoviembre = 30;
            const int diasDiciembre = 31;

            Console.Write("Dia: ");
            int dia = Int32.Parse(Console.ReadLine());

            Console.Write("Mes: ");
            int mes = Int32.Parse(Console.ReadLine());

            Console.Write("Año: ");
            int año = Int32.Parse(Console.ReadLine());

           int diasFebreroEseAño = diasFebrero + ((año % 4 == 0 && (año % 400 == 0 || año % 100 != 0)) ? 1 : 0);

            int diasDesde1Enero = dia;

            if (mes > 1) diasDesde1Enero += diasEnero;
            if (mes > 2) diasDesde1Enero += diasFebreroEseAño;
            if (mes > 3) diasDesde1Enero += diasMarzo;
            if (mes > 4) diasDesde1Enero += diasAbril;
            if (mes > 5) diasDesde1Enero += diasMayo;
            if (mes > 6) diasDesde1Enero += diasJunio;
            if (mes > 7) diasDesde1Enero += diasJulio;
            if (mes > 8) diasDesde1Enero += diasAgosto;
            if (mes > 9) diasDesde1Enero += diasSeptiembre;
            if (mes > 10) diasDesde1Enero += diasOctubre;
            if (mes > 11) diasDesde1Enero += diasNoviembre;

            Console.WriteLine("Han pasado {0} dias desde el 1/1/{3} al {1}/{2}/{3}", diasDesde1Enero, dia, mes, año);
            Console.ReadKey();
        }
    }
}
