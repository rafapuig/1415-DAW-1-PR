using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Herencia.Animales.Subclases.Virtual
{
    public class Animal
    {
        //Emitir sonido, depende del tipo de animal
        //Este metodo requiere cambios cuando se añada un nuevo tipo de animal
        public virtual string EmitirSonido()
        {
            return "Esta mudo!";
        }
    }

}
