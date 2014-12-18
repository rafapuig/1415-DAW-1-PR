using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Herencia.Animales.Abstracta
{
    abstract class Ave : Animal
    {
        //No reemplaza Emitir sonido, lo que obliga a que siga siendo abstracta

        public virtual bool PuedeVolar()
        {
            return false;
        }
    }
}
