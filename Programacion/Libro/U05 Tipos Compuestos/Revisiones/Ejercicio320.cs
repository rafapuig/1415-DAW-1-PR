using System;

namespace Programacion.Iniciacion.Revisiones
{
    enum Mes { Enero, Febrero, Marzo, Abril, Mayo, Junio, Julio, Agosto, Septiempre, Octibre, Noviembre, Diciembre }
    static class Ejercicio20
    {
        static int[] DiasMes = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
 
        static void Main()
        {
            Console.Write("Dia: ");
            int dia = Int32.Parse(Console.ReadLine());

            Console.Write("Mes: ");
            int mes = Int32.Parse(Console.ReadLine());

            Console.Write("Año: ");
            int año = Int32.Parse(Console.ReadLine());

            int diasDesde1Enero = CalcularDiasDesde1Enero(dia, mes, año);
            //int diasDesde1Enero = Console.WriteLine(new DateTime(año, mes, dia).DayOfYear);   //Asi es como se hace utilizando .NET
            
            Console.WriteLine("Han pasado {0} dias desde el 1/1/{3} al {1}/{2}/{3}", diasDesde1Enero, dia, mes, año);
            Console.ReadKey();
        }

        /// <summary>
        /// Calcula los dias transcurridos entre 
        /// el 1 de enero del año indicado y la fecha indicada
        /// </summary>
        /// <param name="dia">valor numerico del dia de la fecha</param>
        /// <param name="mes">Valor entre 1 y 12 que representa el mes</param>
        /// <param name="año">valor numerico del año de la fecha</param>
        /// <returns></returns>
        private static int CalcularDiasDesde1Enero(int dia, int mes, int año)
        {
            DiasMes[(int)Mes.Febrero] += EsBisiesto(año) ? 1 : 0;

            int diasDesde1Enero = dia;

            int m = (int)Mes.Enero;

            while (m < mes - 1)
                diasDesde1Enero += DiasMes[m++];

            return diasDesde1Enero;
        }

        private static bool EsBisiesto(int año)
        {
            return (año % 4 == 0 && (año % 400 == 0 || año % 100 != 0));
        }
    }
}
