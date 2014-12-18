using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Herencia.Formas
{
    class Cuadrado : Forma
    {
        public float Lado { get; set; }

        public override void Display()
        {
            //Dibujar el cuadrado
            Console.WriteLine("Dibujando un cuadrado de lado: {0}", this.Lado);
        }
    }
}
