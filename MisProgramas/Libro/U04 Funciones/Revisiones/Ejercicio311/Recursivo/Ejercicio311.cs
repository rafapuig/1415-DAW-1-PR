using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Programacion.Iniciacion.Actividades.Revisiones.Ejercicio11.Recursivo
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


        static void MostrarCifras(int numero)
        {
            ObtenerCifras(numero, numero, MostrarCifra);
        }

        static void MostrarCifra(int cifra, bool ultima)
        {
            Console.Write("{0}{1}", cifra, !ultima ? "-" : "");
        }

        static void ObtenerCifras(int cifra, int cifras, Action<int, bool> accion, int pot = 1)
        {
            if (cifra < 10)
            {
                accion(cifra, pot == 1);
                
                cifras = cifras - cifra * pot;                
                while (cifras < (pot /= 10)) accion(0, pot == 1);
                
                if (cifras > 0) ObtenerCifras(cifras, cifras, accion, 1);
                else if (pot >= 10) ObtenerCifras(0, 0, accion, pot / 10);
            }
            else
            {
                ObtenerCifras(cifra / 10, cifras, accion, pot *= 10);
            }
        }

    }

}
