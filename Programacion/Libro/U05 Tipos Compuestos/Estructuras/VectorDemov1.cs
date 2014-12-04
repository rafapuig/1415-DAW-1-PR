using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.TiposCompuestos.Estructuras
{
    struct Vector
    {
        public readonly int X;
        public readonly int Y; 
       
        public Vector(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector operator /(Vector v, int escalar)
        {
            return new Vector(v.X / escalar, v.Y / escalar);
        }

        public double Modulo()
        {
            return Math.Sqrt((this.X * this.X) + (this.Y * this.Y));
        }

        public string ToString()
        {
            return string.Format("({0}, {1})", this.X, this.Y);
        }
        
    }

    class VectorDemo
    {
        static void Main()
        {            
            Console.ReadKey();
        }   
        
        static void TestVector()
        {
            Vector v1 = new Vector(5, 3);
            Console.WriteLine(v1);  //Llama a ToString de la estructura Punto

            Vector v2 = v1;    // punto2.x = punto2.x e punto2.y = punto2.y

            Console.WriteLine("Vector ({0},{1})", v2.X, v2.Y);
            Console.WriteLine("Vector: {0}", v2);           
          
            Vector v3 = new Vector(6, 2);
            Vector v4 = new Vector(x: v3.Y + 1, y: v3.X + 2);

            Vector v5 = v1 + v2;
            Vector v6 = v4 / 2;
      
        }
    
    }
}
