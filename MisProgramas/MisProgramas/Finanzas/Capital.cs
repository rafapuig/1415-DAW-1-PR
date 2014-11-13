using System;

public struct Capital
{
    public decimal Nominal;
    public System.DateTime FechaVencimiento;

    public static Capital Sumar(params Capital[] capitales)
    {
        return new Capital();
    }

    public int xxx()
    {
        return 1;
    }

    public decimal VA(Func<double, double, double> ley = null)
    {
        DateTime inicio, fin;

        inicio = DateTime.Now;
        fin = inicio.AddMonths(13);

        double tiempo = Intervalo(DateTime.Now, DateTime.Now.AddMonths(15));

        return Nominal * (decimal)ley(0.05, tiempo);
    }

    /// <summary>
    /// Calcula el tiempo en años que media entre 2 fechas
    /// </summary>
    /// <param name="inicio">Fecha de inicio del intervalo</param>
    /// <param name="fin">Fecha final del intervalo</param>
    /// <returns>El valor numerico en años y fraccion de año entre las 2 fechas</returns>
    static double Intervalo(DateTime inicio, DateTime fin)
    {
        int n = fin.Year - inicio.Year;

        double t = fin < inicio.AddYears(1) ? (fin - inicio).Days : fin.Year - inicio.Year + (fin.AddYears(-n) - inicio).Days / 365.0;
        return t;
    }

}