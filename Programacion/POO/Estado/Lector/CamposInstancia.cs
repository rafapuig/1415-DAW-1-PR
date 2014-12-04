using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estado.Lector.CamposInstancia
{
    class Lector
    {
        public int PaginaActual;

        public int PasarPagina()
        {
            return ++this.PaginaActual;
        }
        
        public int PasarPaginas(int numPaginas)
        {
            return this.PaginaActual += numPaginas;
        }

       
    }

    static class Programa
    {
        static void Main()
        {
            Lector l1 = new Lector();

            l1.PaginaActual = 50;

            l1.PasarPagina();
            l1.PasarPagina();
            l1.PasarPagina();
            l1.PasarPaginas(5);
            int nuevaPaginaActual = l1.PasarPaginas(7);

            Console.WriteLine("La pagina actual es: {0}", nuevaPaginaActual);
            Console.WriteLine("La pagina actual es: {0}", l1.PaginaActual);

            l1.PasarPagina();
            Console.WriteLine("La pagina actual es: {0}", l1.PaginaActual);

            l1.PasarPaginas(10);
            Console.WriteLine("La pagina actual es: {0}", l1.PaginaActual);

            Console.WriteLine("La pagina actual es: {0}", l1.PasarPagina());
            Console.WriteLine("La pagina actual es: {0}", l1.PaginaActual);


            Lector l2 = new Lector();
            l2.PaginaActual = 20;

            Console.WriteLine("La pagina Actual de lector 1: {0}", l1.PaginaActual);
            Console.WriteLine("La pagina Actual de lector 1: {0}", l2.PaginaActual);

            Console.ReadKey();
        }

    }
    
}
