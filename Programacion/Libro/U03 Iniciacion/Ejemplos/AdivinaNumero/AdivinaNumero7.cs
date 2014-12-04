using System;

namespace Programacion.Iniciacion.Ejemplos.AdivinaNumero
{
    static class AdivinaNumeroVersion7
    {
        static void Main()
        {
            int numeroSecreto = 15; //Numero secreto entre 0 y 100

            int intentos = 10;  //Numero de intentos para adivinar el numero

            bool volverAIntentar = true;
            bool acertado = false;  //Verdadero si ha acertado el numero, si numero es igual a numeroSecreto

            //Repetir el bucle hasta que se acierte el numero
            do
            {
                Console.Write("Adivina el numero secreto: ");
                int numero = Int32.Parse(Console.ReadLine());

                acertado = numero == numeroSecreto;

                if (!acertado)	// Si no ha acertado, (el numero es distinto al numero secreto)
                {
                    string mensaje;

                    if (numero > numeroSecreto)     //Si ademas de distinto es mayor
                        mensaje = "No es correcto, has introducido un numero demasiado grande.";
                    else     //Si no, entonces sera menor                       
                        mensaje = "No es correcto, has introducido un numero demasiado pequeño.";

                    Console.WriteLine(mensaje);
                    
                    intentos--;
                    Console.WriteLine("Numero de intentos restantes: {0}", intentos);
                }

                bool quedanIntentos = intentos > 0;         //Verdadero si quedan intentos, es decir, intentos mayor que cero
                
                volverAIntentar = !acertado && quedanIntentos; 

            } while (volverAIntentar);  //Repetir hasta <condicion> es lo mismo que repetir mientras no se cumpla <condicion>

            if (acertado)
                Console.WriteLine("Enhorabuena! Has adivinado el numero secreto.");
            else
                Console.WriteLine("Lo sentimos, pero se te han agotado los intentos.");

            Console.ReadKey();
        }
    }
}
