using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Herencia.Formas
{
    class TestFormas
    {
        static void Test()
        {
            Forma c = new Cuadrado();
            c.X = 5;
            c.Y = 6;
            c.Mover(-1, -3);
        }

        static void MoverFormaAlaDerecha(Forma f)
        {
            f.Mover(5, 0);
        }
    }
}
