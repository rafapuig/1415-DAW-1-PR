﻿using System;

namespace Programacion.Iniciacion.Ejemplos.AdivinaNumero
{
    static class AdivinaNumeroVersion8
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
                bool quedanIntentos = true;   //Verdadero si quedan intentos, es decir, intentos mayor que cero

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
                    quedanIntentos = intentos > 0;
                    if (quedanIntentos) Console.WriteLine("Numero de intentos restantes: {0}", intentos);
                }

                volverAIntentar = !acertado && quedanIntentos;

            } while (volverAIntentar);  //Repetir hasta <condicion> es lo mismo que repetir mientras no se cumpla <condicion>

            //Con operador ternario <condicion> ? expresion si cierto : expresion si falso;
            Console.WriteLine(acertado ? "Enhorabuena! Has adivinado el numero secreto." : "Lo sentimos, pero se te han agotado los intentos.");
            
            Console.ReadKey();
        }
    }
}
