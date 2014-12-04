using System;

static class MaximoDemo
{
    static void Main()
    {
        int total = 3;
        double[] num = new double[total];

        RellenarVector(num);
        int pos;
        BuscarMaximo(num, out pos);

        Console.WriteLine("El maximo es {0} y esta en la posicion {1}", num[pos], pos);
        Console.ReadKey();
    }

    static double ObtenerDouble(string message)
    {
        double result;
        bool esValido = false;

        do
        {
            Console.WriteLine(message);
            esValido = Double.TryParse(Console.ReadLine(), out result);
            if (!esValido)
                Console.WriteLine("El numero introducido no es valido");
        } while (!esValido);

        return result;
    }

    private static void RellenarVector(double[] num)
    {
        for (int i = 0; i < num.Length; i++)
        {
            string mensaje = String.Format("Dame el numero {0}", i + 1);
            num[i] = ObtenerDouble(mensaje);
        }
    }

    private static double BuscarMaximo(double[] num)
    {
        int p;
        return BuscarMaximo(num, out p);
    }

    private static double BuscarMaximo(double[] num, out int posicion)
    {       
        posicion = 0;
        int j = posicion + 1;
        while (j < num.Length)
        {
            if (num[j] > num[posicion]) 
                posicion = j;
            j++;
        }            
        return num[posicion];
    }
    
}