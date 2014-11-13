using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Programacion.Funciones.Actividades
{
    class Ejercicio07
    {

        static void Main()
        {
            int tiradas = ObtenerNumeroRepticiones();

            int[] veces = Logica.RepetirExperimento(tiradas);

            MostrarResultados(veces, tiradas);

            Console.ReadKey();
        }

        static int ObtenerNumeroRepticiones()
        {
            Console.WriteLine("Cuantas veces quieres repetir el experimento: ");

            int numero;
            string entrada;
            bool esEntero;
            while (!(esEntero = Int32.TryParse(entrada = Console.ReadLine(), out numero)) || numero <= 0)
            {
                if (!esEntero) Console.WriteLine("El texto {0} de la entrada no tiene formato de numero entero.");
                else if (numero < 0) Console.WriteLine("El numero debe ser mayor que 0.");
                Console.WriteLine("Intentalo de nuevo.");
            }

            return numero;
        }

        private static void MostrarResultados(int[] veces, int tiradas)
        {
            for (int i = 0; i < veces.Length; i++)
            {
                Console.WriteLine("El {0} ha salido {1} veces. Frecuencia = {2}",
                        i + 1, veces[i], (double)veces[i] / tiradas);
            }
        }

    }

    static class Logica
    {
        public const int CarasDado = 6;

        static Random alea = new Random();


        public static int LanzarDado()
        {
            return alea.Next(1, CarasDado + 1);
        }

        public static int[] RepetirExperimento(int repeticiones)
        {
            int[] resultados = new int[CarasDado];

            for (int i = 0; i < repeticiones; i++)
            {
                //resultados[alea.Next(1, CarasDado + 1) - 1]++;
                int resultado = LanzarDado();
                resultados[resultado - 1]++;
            }

            return resultados;
        }

    }
}

