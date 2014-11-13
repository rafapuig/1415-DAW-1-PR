using System;

class HipotenusaDemo
{
    static void Main()
    {
        Console.Write("Dame un cateto:");
        string entrada = Console.ReadLine();
        double lado1 = Double.Parse(entrada);

        Console.Write("Dame otro cateto:");
        entrada = Console.ReadLine();
        double lado2 = Double.Parse(entrada);

        double hipotenusa = CalcularHipotenusa(lado1, lado2);

        Console.WriteLine("La hipotenusa es {0}", hipotenusa);
        Console.ReadKey();
    }

    static double CalcularHipotenusa(double cateto1, double cateto2)
    {
        cateto1 = cateto1 * cateto1;
        cateto2 = cateto2 * cateto2;
        double hipo2 = cateto1 + cateto2;
        double hipo = Math.Sqrt(hipo2);
        return hipo;
    }
}