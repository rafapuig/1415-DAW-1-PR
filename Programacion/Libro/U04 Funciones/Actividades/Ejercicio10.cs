using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.Funciones.Actividades
{
    class Ejercicio10
    {
        static void Main()
        {
            Console.WriteLine(RevesRecursivo(102340500));
            Console.ReadKey();
        }

        static void RevesRecursivov1(int num)
        {
            Console.Write(num % 10);
            if (num / 10 > 0)
                RevesRecursivo(num / 10);
        }

        static string RevesRecursivo(int num)
        {
            StringBuilder sb = new StringBuilder();

            RevesRecursivo(num, sb);

            return sb.ToString();
        }

        static void RevesRecursivo(int num, StringBuilder builder)
        {
            builder.Append(num % 10);
            if (num / 10 > 0)
                RevesRecursivo(num / 10, builder);
        }

    }
}
