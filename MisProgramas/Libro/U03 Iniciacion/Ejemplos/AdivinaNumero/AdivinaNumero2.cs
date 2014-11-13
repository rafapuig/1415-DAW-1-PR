using System;

namespace Programacion.Iniciacion.Ejemplos.AdivinaNumero
{
    static class AdivinaNumeroVersion2
    {
        static void Main()
        {
            int numeroSecreto = 15; //Numero secreto entre 0 y 100

            Console.Write("Adivina el numero secreto: ");
            int numero = Int32.Parse(Console.ReadLine());

            if (numero == numeroSecreto)    //Si el numero introducido coincide con el numero secreto
                Console.WriteLine("Enhorabuena! Has adivinado el numero secreto.");
            else	// Si no, (el numero es distinto al numero secreto)
                if (numero > numeroSecreto)     //Si ademas de distinto es mayor
                    Console.WriteLine("No es correcto, has introducido un numero demasiado grande.");
                else     //Si no, entonces sera menor                       
                    Console.WriteLine("No es correcto, has introducido un numero demasiado pequeño");

            Console.ReadKey();
        }
    }
}
