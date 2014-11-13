using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Programacion.Iniciacion.Actividades.Revisiones.Ejercicio11.V4
{
    static class Ejercicio11
    {
        static void Main()
        {
            int numero;
            string entrada;
            bool esNumero;
            Console.WriteLine("Escribe un numero: ");
            while (!(esNumero = Int32.TryParse(entrada = Console.ReadLine(), out numero)) || numero < 0)
            {
                Console.Write("La entrada {0} no es correcta. ");
                if (!esNumero) Console.WriteLine("No se puede convertir a numero.");
                else if (numero < 0) Console.WriteLine("El numero es menor que 0.");
            }

            MostrarCifras(numero);
            Console.ReadKey();
        }
        
        static void MostrarCifra(int cifra, bool ultima)
        {
            Console.Write("{0}{1}", cifra, !ultima ? "-" : "");
        }

        static void MostrarCifras(int num)
        {
            foreach (int cifra in Cifras(num))
            {
                MostrarCifra(cifra, false);
            }
            Console.CursorLeft -= 1;
            Console.Write(" ");
            Console.CursorLeft -= 1;
        }
                
        static IEnumerable<int> Cifras(int numero)
        {
            int cifra;  //Al final del bucle interno tendrá la cifra correspondiente a la iteracion actual
            int restoCifras = numero;    //Al final del bucle interno contiene el numero restando las cifras procesadas
            int potencia = 1;

            while (restoCifras >= 10)
            {
                cifra = restoCifras;
                potencia = 1;
               
                while (cifra >= 10)
                {
                    cifra = cifra / 10;
                    potencia *= 10;
                }
                
                restoCifras -= cifra * potencia;
                
                yield return cifra;
                while (potencia > 10 && restoCifras < (potencia /= 10)) yield return 0;
            }

            yield return restoCifras;            
        } 
    }    
}
