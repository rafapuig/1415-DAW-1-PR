using System;

namespace Programacion.Iniciacion.Ejemplos.AdivinaNumero
{
    static class AdivinaNumeroVersion1
    {
        static void Main()
        {
            int numeroSecreto = 15; //Numero secreto entre 0 y 100

            Console.Write("Adivina el numero secreto: ");
            int numero = Int32.Parse(Console.ReadLine());

            if (numero == numeroSecreto)
                Console.WriteLine("Enhorabuena! Has adivinado el numero secreto.");
            else
                Console.WriteLine("Lo sentimos, pero el numero {0} no es el numero secreto.", numero);

            Console.ReadKey();
        }
    }
}
