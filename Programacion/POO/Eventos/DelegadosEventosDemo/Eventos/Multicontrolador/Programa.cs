using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Eventos.Multicontrolador
{
    class Programa
    {
        static void Main()
        {
            Accion SAN = new Accion { Simbolo = "SAN" };
            Accion BAN = new Accion { Simbolo = "BAN" };

            //Misomo controlador de eventos para distintos objetos
            SAN.PrecioChanged += AccionPrecioChanged;
            BAN.PrecioChanged += AccionPrecioChanged;

            SAN.Precio = 6;
            BAN.Precio = 8;
            SAN.Precio = 7;
            BAN.Precio = 10;

            Accion[] cartera = new[] 
            {
                new Accion {Simbolo="BBVA"},
                new Accion {Simbolo="TEL"}
            };

            foreach (Accion a in cartera)
            {
                a.PrecioChanged += AccionPrecioChanged;
            }

            cartera[0].Precio = 10;
            cartera[1].Precio = 6;
            cartera[0].Precio = 9;
            cartera[1].Precio = 5;

            Console.ReadKey();

        }

        static void AccionPrecioChanged(object sender, PrecioChangedEventArgs e)
        {
            Accion a = sender as Accion;
            Console.Write("Simbolo " + a.Simbolo);
            Console.Write("\tAnterior: {0,2}", e.PrecioAnterior);
            Console.Write("\tActual  : {0,2}", e.PrecioNuevo);
            if (e.PrecioAnterior != 0)
                Console.Write("\tVariacion: {0,7:P}",
                    (e.PrecioNuevo - e.PrecioAnterior) / e.PrecioAnterior);
            Console.WriteLine();        
        }
    }
}
