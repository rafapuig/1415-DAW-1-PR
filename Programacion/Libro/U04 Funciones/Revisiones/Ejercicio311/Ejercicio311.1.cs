using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Programacion.Iniciacion.Actividades.Revisiones.Ejercicio11.V1
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
            int maxPotencia = 0;    //Exponente para potencia 10 de la cifra + significativa
            
            int temp = num;     //Copia del numero para no perderlo
            for (maxPotencia = 0; temp >= 10; maxPotencia++) temp /= 10;

            for (int i = maxPotencia; i >= 0; i--)
            {      
                int cifra = (int)(num / Math.Pow(10, i)) % 10;
                MostrarCifra(cifra, i == 0);
            }
        } 
    }    
}
