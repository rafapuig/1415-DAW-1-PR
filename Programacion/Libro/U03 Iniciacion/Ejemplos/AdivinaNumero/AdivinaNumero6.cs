using System;

namespace Programacion.Iniciacion.Ejemplos.AdivinaNumero
{
    static class AdivinaNumeroVersion6
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
                    mensaje = "Enhorabuena! Has adivinado el numero secreto."; 

                else	// Si no, (el numero es distinto al numero secreto)
                {
                    if (numero > numeroSecreto)     //Si ademas de distinto es mayor
                        mensaje = "No es correcto, has introducido un numero demasiado grande.";
                    else     //Si no, entonces sera menor                       
                        mensaje = "No es correcto, has introducido un numero demasiado pequeño.";

                    intentos--;                    
                }

                //Forma 1
                volverAIntentar = numero != numeroSecreto && intentos > 0;  //Se vuelve a intentar si no se ha adivinado Y quedan intentdos                
                
                //Forma 2
                volverAIntentar = !(numero == numeroSecreto || intentos == 0);  //Si es falso que se ha acertado o que se han acabado los intentos
                
                bool acertado = numero == numeroSecreto;    //Verdadero si ha acertado el numero, si numero es igual a numeroSecreto
                bool quedanIntentos = intentos > 0;         //Verdadero si quedan intentos, es decir, intentos mayor que cero
                
                volverAIntentar = !acertado && quedanIntentos;      //Equivalente a la forma 1 -> A y B 
                volverAIntentar = !(acertado || !quedanIntentos);  //Equivalente a la forma 2 -> no( no(A) O no(B) )

                Console.WriteLine(mensaje);               

            } while (volverAIntentar);  //Repetir hasta <condicion> es lo mismo que repetir mientras no se cumpla <condicion>

            Console.ReadKey();
        }
    }
}
