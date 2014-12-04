using System;

namespace Programacion.Iniciacion.Ejemplos.AdivinaNumero
{
    static class AdivinaNumeroVersion5
    {
        static void Main()
        {
            int numeroSecreto = 15; //Numero secreto entre 0 y 100



            int intentos = 10;  //Numero de intentos para adivinar el numero

            bool volverAIntentar = true;

            //Repetir el bucle hasta que se acierte el numero
            do
            {
                Console.Write("Adivina el numero secreto: ");
                int numero = Int32.Parse(Console.ReadLine());

                string mensaje = "";

                if (numero == numeroSecreto)    //Si el numero introducido coincide con el numero secreto
                {
                    mensaje = "Enhorabuena! Has adivinado el numero secreto.";
                    volverAIntentar = false;
                }

                else	// Si no, (el numero es distinto al numero secreto)
                {
                    if (numero > numeroSecreto)     //Si ademas de distinto es mayor
                        mensaje = "No es correcto, has introducido un numero demasiado grande.";
                    else     //Si no, entonces sera menor                       
                        mensaje = "No es correcto, has introducido un numero demasiado pequeño.";

                    intentos--;
                    if (intentos == 0) volverAIntentar = false;
                }

                Console.WriteLine(mensaje);               

            } while (volverAIntentar);  //Repetir hasta <condicion> es lo mismo que repetir mientras no se cumpla <condicion>

            Console.ReadKey();
        }
    }
}
