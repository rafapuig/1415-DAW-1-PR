using System;

namespace Programacion.Funciones.Ejemplos.AdivinaNumero
{
    static class AdivinaNumeroVersion13
    {
        static Random alea = new Random();
        static void Main()
        {
            bool salir = false;
            do
            {
                Console.Write("Numero de intentos que quieres disfrutar: ");
                int numIntentos;    //Numero de intentos para adivinar el numero
                //Pedir al usuario el numero de intentos mientras no sea un numero valido
                //es decir mientras no se puede convertir a numero o si no, si es menor que cero
                while (!Int32.TryParse(Console.ReadLine(), out numIntentos) || numIntentos <= 0)
                    Console.WriteLine("Introduce un numero de intentos correcto.");

                Console.Write("Cual quieres que se el mayor numero secreto posible? ");
                int maximoSecreto;    //Numero de intentos para adivinar el numero
                //Pedir al usuario el numero de intentos mientras no sea un numero valido
                //es decir mientras no se puede convertir a numero o si no, si es menor que cero
                while (!Int32.TryParse(Console.ReadLine(), out maximoSecreto) || maximoSecreto <= 0)
                    Console.WriteLine("Introduce valor numerico positivo.");

                JugarPartida(numIntentos, maximoSecreto);

                Console.Write("Otra partida (s/n)? ");

                salir = Console.ReadKey().KeyChar != 's';

            } while (!salir);           
        }

        private static int GenerarNumeroSecreto(int maxSecreto)
        {
            int numeroSecreto = alea.Next(0, maxSecreto + 1); //Numero secreto entre 0 y maxSecreto
            return numeroSecreto;
        }

        private static void JugarPartida(int intentos, int maxSecreto)
        {
            int numeroSecreto = GenerarNumeroSecreto(maxSecreto);

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

        }
        
    }
}
