using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Eventos
{
    class TestPersona
    {
        static void Main()
        {
            Persona juan = new Persona(Genero.Hombre, "Juan","Garcia","Soria");
            Persona alicia = new Persona(Genero.Mujer, "Alicia", "Garrido", "Perez");

            //juan.RegaloRecibido+=juan_RegaloRecibido;
            juan.RegaloRecibido += RegalosRecibidosHandler;
            alicia.RegaloRecibido += RegalosRecibidosHandler;

            juan.Regalar(alicia, "anillo de compromiso");
            alicia.Regalar(juan, "PlayStation 4");
            
            juan.Casandose += CasandoseHandler;
            alicia.Casandose += CasandoseHandler;

            juan.RecienCasado += RecienCasadoHandler;
            alicia.RecienCasado += RecienCasadoHandler;  

            juan.Casarse(alicia);

            Console.ReadKey();
        }

        //static void juan_RegaloRecibido(object sender, RegaloRecibidoEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        static private void CasandoseHandler(object sender, CasandoseEventArgs e)
        {
            Persona p = sender as Persona;
            Console.WriteLine(p + " se esta casando con " + e.Novio);
            Console.WriteLine("Permitir? (y/n)");
            ConsoleKeyInfo cki = Console.ReadKey(true);
            if (cki.KeyChar == 'n') 
            {
                e.AnularMatrimonio = true;
                Console.WriteLine("Matrimonio anulado.");
            }
        }

        static private void RecienCasadoHandler(object sender, EventArgs e)
        {
            Persona p = sender as Persona;
            Console.WriteLine(
                p.NombreCompleto + " se acaba de casar con " + p.Conyuge.NombreCompleto);
        }
       
        static private void RegalosRecibidosHandler(object sender, RegaloRecibidoEventArgs e)
        {
            Persona obsequiado = sender as Persona;
            Console.WriteLine(obsequiado.NombreCompleto + " ha recibido " + e.Regalo +
                " como regalo por parte de " + e.Obsequiador.NombreCompleto);
        }
    }
}
