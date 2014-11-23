using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estado.SinEstado
{
    static class Lector
    {
        public static int PasarPagina(int paginaActual)
        {
            return paginaActual + 1;
        }
        public static int PasarPaginas(int paginaActual, int numPaginas)
        {
            return paginaActual + numPaginas;
        }

        
    }

    class Programa
    {
        static void Main()
        {
            int miPaginaActual = 0;

            Console.WriteLine("La pagina actual es: {0}", miPaginaActual);

            int nuevaPaginaActual = Lector.PasarPagina(miPaginaActual);
            Console.WriteLine("La pagina actual es? {0}", miPaginaActual);
            Console.WriteLine("La nueva pagina actual es: {0}", nuevaPaginaActual);

            miPaginaActual = nuevaPaginaActual;
            Console.WriteLine("La pagina actual es: {0}", miPaginaActual);


            nuevaPaginaActual = Lector.PasarPagina(miPaginaActual);
            miPaginaActual = nuevaPaginaActual;

            nuevaPaginaActual = Lector.PasarPaginas(miPaginaActual, 5);
            miPaginaActual = nuevaPaginaActual;
        }

    }
}
