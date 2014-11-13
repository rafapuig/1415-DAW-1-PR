using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.TiposCompuestos.Estructuras.DemoPuntos.v2
{
    struct Punto
    {
        public readonly int X;
        public readonly int Y; 
       
        public Punto(int x, int y)
        {
            X = x;
            this.Y = y;
        }

        public static int Distancia(Punto p1, Punto p2)
        {
            return (p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y);
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", this.X, this.Y);
        }
        
    }

    class PuntoDemo
    {
        static void Main()
        {            
            Console.ReadKey();
        }
       

        
    

        static void ConEstructuras()
        {
            Punto punto1 = new Punto(5, 3);
            Console.WriteLine(punto1);  //Llama a ToString de la estructura Punto

            Punto punto2;
            punto2 = punto1;    // punto2.x = punto2.x e punto2.y = punto2.y

            Console.WriteLine("Punto ({0},{1})", punto2.X, punto2.Y);
            
            MostrarPuntoPorConsola(punto2.X, punto2.Y);
            MostrarPuntoPorConsola(punto1);

            Punto p3 = new Punto(6, 2);
            MostrarPuntoPorConsola(p3);

            Punto p4 = new Punto(x: p3.Y, y: p3.X);
            MostrarPuntoPorConsola(p4);

            int distancia = Punto.Distancia(punto1, punto2);
        }

        static void MostrarPuntoPorConsola(int x, int y)
        {
            Console.WriteLine("Punto ({0},{1})", x, y);
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
