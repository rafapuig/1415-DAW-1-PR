using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.TiposCompuestos.Estructuras
{
    struct Punto
    {
        public int X;
        public int Y;        
    }

    class PuntoDemo
    {
        static void Main()
        {
            ConEstructuras();
            Console.ReadKey();
        }

        static void SinEstructuras()
        {
            int punto1X = 6;
            int punto1Y = 5;

            int punto2X;
            int punto2Y;

            punto2X = punto1X;
            punto2Y = punto1X;

            Console.WriteLine("Punto 1 ({0},{1})", punto1X, punto1Y);
            MostrarPuntoPorConsola(punto2X, punto2Y);
            
        }

        static void MostrarPuntoPorConsola(int x, int y)
        {
            Console.WriteLine("Punto ({0},{1})", x, y);
        }
    

        static void ConEstructuras()
        {
            Punto punto1;
            punto1.X = 5;
            punto1.Y = 3;

            Punto punto2;
            punto2 = punto1;    // punto2.x = punto2.x e punto2.y = punto2.y

            Console.WriteLine("Punto ({0},{1})", punto2.X, punto2.Y);
            MostrarPuntoPorConsola(punto2.X, punto2.Y);
            MostrarPuntoPorConsola(punto1);

            Punto p3 = new Punto { X = 6, Y = 2 };
            MostrarPuntoPorConsola(p3);

            Punto p4 = new Punto { X = p3.Y, Y = p3.X };
            MostrarPuntoPorConsola(p4);
        }

        static void MostrarPuntoPorConsola(Punto p)
        {
            Console.WriteLine("Punto ({0},{1})", p.X, p.Y);
        }

        static void MostrarPuntoPorConsolaV2(Punto p)
        {
            MostrarPuntoPorConsola(p.X, p.Y);
        }
    
    }
}
