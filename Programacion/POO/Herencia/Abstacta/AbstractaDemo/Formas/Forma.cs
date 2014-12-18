using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Herencia.Formas
{
    public abstract class Forma
    {
        public float X { get; set; }
        public float Y { get; set; }

        public void Mover(float deltaX, float deltaY)
        {
            X += deltaX;
            Y += deltaY;

            //Redibujar la figura
            Display();
        }

        public abstract void Display();
    }
}
