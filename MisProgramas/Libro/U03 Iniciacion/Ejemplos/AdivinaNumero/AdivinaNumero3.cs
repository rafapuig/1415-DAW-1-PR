using System;

namespace Programacion.Iniciacion.Ejemplos.AdivinaNumero
{
    static class AdivinaNumeroVersion3
    {
        static void Main()
        {
            int numeroSecreto = 15; //Numero secreto entre 0 y 100

            int numero;
            do  //Repetir el bucle hasta que se acierte el numero
            {
                Console.Write("Adivina el numero secreto: ");
                numero = Int32.Parse(Console.ReadLine());
            
                if (numero == numeroSecreto)    //Si el numero introducido coincide con el numero secreto
                    Console.WriteLine("Enhorabuena! Has adivinado el numero secreto.");
                else	// Si no, (el numero es distinto al numero secreto)
                    if (numero > numeroSecreto)     //Si ademas de distinto es mayor
                        Console.WriteLine("No es correcto, has introducido un numero demasiado grande.");
                    else     //Si no, entonces sera menor                       
                        Console.WriteLine("No es correcto, has introducido un numero demasiado pequeño");
            } while (numero != numeroSecreto);  //Repetir hasta <condicion> es lo mismo que repetir mientras no se cumpla <condicion>

            Console.ReadKey();
        }
    }
}
