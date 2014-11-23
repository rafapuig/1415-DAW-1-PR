using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estado.CamposEstaticos
{
    static class Lector
    {
        public static int PaginaActual;

        public static int PasarPagina()
        {
            return ++PaginaActual;
        }
        
        public static int PasarPaginas(int numPaginas)
        {
            return PaginaActual += numPaginas;
        }

    }

    static class Programa
    {
        static void Main()
        {
            Lector.PaginaActual = 50;

            Lector.PasarPagina();
            Lector.PasarPagina();
            Lector.PasarPagina();
            Lector.PasarPaginas(5);
            int nuevaPaginaActual = Lector.PasarPaginas(7);

            Console.WriteLine("La pagina actual es: {0}", nuevaPaginaActual);
            Console.WriteLine("La pagina actual es: {0}", Lector.PaginaActual);

            Lector.PasarPagina();
            Console.WriteLine("La pagina actual es: {0}", Lector.PaginaActual);

            Lector.PasarPaginas(10);
            Console.WriteLine("La pagina actual es: {0}", Lector.PaginaActual);

            Console.WriteLine("La pagina actual es: {0}", Lector.PasarPagina());
            Console.WriteLine("La pagina actual es: {0}", Lector.PaginaActual);

            Console.ReadKey();
        }
    }
    
}
