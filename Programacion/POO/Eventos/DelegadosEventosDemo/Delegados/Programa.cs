using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Eventos.Delegados
{
    class Programa
    {
        static void Main()
        {
            Accion SAN = new Accion { Simbolo = "SAN" };

            SAN.PrecioChanged += (a, n) => Console.WriteLine("Precio: " + a + " -> " + n);
            SAN.PrecioChanged += SAN_PrecioChangedHandler;

            SAN.Precio = 6;
            SAN.Precio = 8;
            SAN.Precio = 7;

            //Problema de los delegados 
            //similar al uso de los campos en general (es un campo de tipo del delegado)
            //El libre acceso al campo desde codigo cliente
            //no permite un control desde la clase del valor del campo 
            SAN.PrecioChanged = SAN_PrecioChangedHandler2; //Esta asginacion elimina al resto de subscriptores
            SAN.Precio = 10;

            Console.ReadKey();

        }

        static void SAN_PrecioChangedHandler(decimal antes, decimal actual)
        {
            Console.WriteLine("El precio de las acciones del Santanter ha variado");
            Console.WriteLine("Precio anterior: {0}", antes);
            Console.WriteLine("Precio actual  : {0}", actual);
        }

        static void SAN_PrecioChangedHandler2(decimal antes, decimal actual)
        {
            Console.WriteLine("Acciones del Santanter");
            Console.WriteLine("Anterior: {0} euros", antes);
            Console.WriteLine("Actual  : {0} euros", actual);
        }
    
    }
}
