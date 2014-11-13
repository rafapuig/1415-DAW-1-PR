using System;

namespace Programacion.Iniciacion.Actividades
{

    /// <summary>
    /// Programa para determinar si un numero es o no primo
    /// Un numero entero n es primo existen 2 numeros enteros p y q tales que p * q = n
    /// Y tanto p como q son distintos de 1 o n.
    /// p y q son divisores de n, por tanto un numero es primo si solo se puede dividir por n o por 1
    /// </summary>
    static class Ejercicio21
    {

        static void Main()
        {
            Console.Write("Introduce un numero: ");
            int numero = Int32.Parse(Console.ReadLine());

            bool esPrimo = true;
            int divisor = 2;            
            
            //if (numero == 1 || numero == 2) esPrimo = true;   //Si es numero es 1 o 2 seguro que es primo                
            //else                                              //Si no, numero > 3 habra que probar que no lo es

            if (numero > 3 && numero % divisor == 0) esPrimo = false;   //Si el munero es para no es primo
            else
            {
                //Nos marcamos como limite para probar divisores un maximo igual a la raiz de n, 
                //Porque si se tiene que dar n = p * q buscamos q probando si n/p da de resto 0
                //pero es lo mismo que n = q * p y buscar p haciendo n/q
                // el mayor valor de p y q se dará cuando ambos sean iguales y eso implica que tanto p = q 
                //luego n = p * p   o   n = q * q , es decir raiz(n) = p = q
                
                int limite = (int)Math.Sqrt(numero);    

                for (divisor = 3; divisor <= limite; divisor += 2)  //Probamos a encontrar un divisor desde 3 hasta el limite, probamos solo los impares
                {
                    if (numero % divisor != 0) continue;  //Si el numero no es divisible por divisor continuamos directamente probrando con el siguiente
                    esPrimo = false;    //Si pasamos alguna vez del continue hemos encontrado un divisor, n no es primo
                    break;              //Como lo hemos encontrado, salimos del bucle antes del final porque ya no hace falta seguir probando
                }
            }
            
            Console.WriteLine("{0} es {1}primo", numero, !esPrimo ? "no " : "");

            if (!esPrimo)            
                Console.WriteLine("El numero {0} se puede obtener haciendo {1} x {2}", numero, divisor, numero / divisor);          
            
            
            Console.ReadKey();
        }          
      
    }

}
