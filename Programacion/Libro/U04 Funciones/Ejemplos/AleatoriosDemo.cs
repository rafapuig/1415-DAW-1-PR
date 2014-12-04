using System;

namespace Programacion.TiposCompuestos.Ejemplos
{    
    static class AleatoriosDemo
    {
        static Random alea = new Random();

        static void Main()
        {
            Console.Title = "Ejemplo de numeros aleatorios";
            
            int total = 6;
            for (int i = 0; i < total; i++)
            {
                int numero = alea.Next(1, 49);
                Console.Write("{0}{1}", numero, i < total - 1 ? ", " : "\n");                 
            }
            Console.ReadKey();
        }        
    }
}
