using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Herencia.Animales.Subclases.Virtual
{

    class Perro : Animal
    {
        public override string EmitirSonido()
        {
            return "Guau";
        }
    }

}
