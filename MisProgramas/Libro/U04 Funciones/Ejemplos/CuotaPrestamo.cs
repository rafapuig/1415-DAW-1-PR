using System;

static class EjercicioCuotaPrestamo
{
    static void Main()
    {        
        decimal cantidad = ObtenerCantidadValida();
        int plazo = ObtenerPlazoValido();
        double TIN = ObtenerTINValido();

        decimal cuota = CalcularCuota(cantidad, plazo, TIN, 12);

        Console.WriteLine("La cuota mensual es: {0:N2}", cuota);    //N2 es formato para numeros con 2 decimales
        Console.ReadKey();
    }

#region Parte de interaccion con el usuario

    private static double ObtenerTINValido()
    {
        Console.WriteLine("Introduce el Tipo de Interes Nominal anual");
        double TIN;
        //bool esUnDouble = false;
        //do
        //{
        //    esUnDouble = Double.TryParse(Console.ReadLine(), out TIN);
        //    if (!(esUnDouble && TIN >= 0))
        //        Console.WriteLine("Introduce un valor numerico mayor que cero");
        //} while (!esUnDouble || TIN < 0);   //(!(esUnDouble && TIN >= 0));

        while (!double.TryParse(Console.ReadLine(), out TIN) || TIN < 0)
            Console.WriteLine("Introduce un valor numerico positivo");
        return TIN;
    }

    private static decimal ObtenerCantidadValida()
    {
        decimal cantidad;

        Console.WriteLine("Introduce la cantidad solicitada");
        
        while (!decimal.TryParse(Console.ReadLine(), out  cantidad) || cantidad < 0)
            Console.WriteLine("No es un munero valido, intentelo otra vez");
        return cantidad;
    }

    private static int ObtenerPlazoValido()
    {
        int plazo;
        bool plazoValido = false;

        Console.WriteLine("Introduce el plazo de devolucion en años");       
        do
        {
            string entrada = Console.ReadLine();
            bool esUnEntero = int.TryParse(entrada, out plazo);
            if (!esUnEntero)
                Console.WriteLine("La entrada >>{0}<< no es un numero entero, intentalo de nuevo", entrada);
            else if (!(plazo > 0))
                Console.WriteLine("El plazo tiene que ser un numero positivo");
            else
                plazoValido = true;
        } while (!plazoValido);
        return plazo;
    }

#endregion

#region Parte de calculos
    private static decimal CalcularCuota(decimal cantidad, int plazo, double TIN, int cuotasAño)
    {
        TIN /= 100.0;   // TIN = TIN / 100

        int n = plazo * cuotasAño; //numero de cuotas mensuales     
        double i = TIN / cuotasAño;    //tipo de interes mensual

        decimal razon = TIN == 0.0 ? n : (decimal)((1 - Math.Pow(1 + i, -n)) / i);
        decimal cuota = cantidad / razon;
        return cuota;
    }

#endregion

}
