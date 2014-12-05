using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Eventos.StandardPattern.Generico
{
    class Programa
    {
        static void Main()
        {
            Accion SAN = new Accion { Simbolo = "SAN" };

            SAN.PrecioChanged += (sender, e) => 
                Console.WriteLine("Precio: " + e.PrecioAnterior + " -> " + e.PrecioNuevo);
            
            SAN.PrecioChanged += SAN_PrecioChangedHandler;

            SAN.Precio = 6;
            SAN.Precio = 8;
            SAN.Precio = 7;

            //Problema de los delegados 
            //similar al uso de los campos en general (es un campo de tipo del delegado)
            //El libre acceso al campo desde codigo cliente
            //no permite un control desde la clase del valor del campo 
            //SAN.PrecioChanged = SAN_PrecioChangedHandler2; //Esta asginacion elimina al resto de subscriptores
            SAN.PrecioChanged += SAN_PrecioChangedHandler2; //solo se puede hacer += o -=
            SAN.Precio = 10;

            Console.ReadKey();

        }

        static void SAN_PrecioChangedHandler(object sender, PrecioChangedEventArgs e)
        {
            Accion accion = sender as Accion; //logicamente sera la del Santander pues solo se controla esta por este controlador
            Console.WriteLine("El precio de las acciones del Santanter ha variado");
            Console.WriteLine("Precio anterior: {0}", e.PrecioAnterior);
            Console.WriteLine("Precio actual  : {0}", accion.Precio);
        }

        static void SAN_PrecioChangedHandler2(object sender, PrecioChangedEventArgs e)
        {
            Accion a = sender as Accion;
            Console.WriteLine("Acciones del Santanter " + a.Simbolo);
            Console.WriteLine("Anterior: {0} euros", e.PrecioAnterior);
            Console.WriteLine("Actual  : {0} euros", e.PrecioNuevo);
        }
    }
}
