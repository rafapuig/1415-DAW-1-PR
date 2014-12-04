using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardDemo
{
    struct Rectangle
    {
        public int Top;
        public int Left;
        public int Width { get; set; }
        public int Height { get; set; }

        public int Right { get { return Left + Width; } }
        public int Bottom { get { return Top + Height; } }


        static bool Intersect(Rectangle r1, Rectangle r2)
        {
            //Comprobar si la esquina superior izquerda del rectangulo r2, esta en r1
            if (r1.Contains(r2.Top, r2.Left)) return true;
            if (r1.Contains(r2.Top, r2.Right)) return true;
            if (r1.Contains(r2.Bottom, r2.Left)) return true;
            if (r1.Contains(r2.Bottom, r2.Right)) return true;
            return false;
        }

        private bool Contains(int x, int y)
        {
            return 
                x >= this.Left && 
                x <= this.Right && 
                y > this.Top && 
                y < this.Bottom;
        }
    }
}
