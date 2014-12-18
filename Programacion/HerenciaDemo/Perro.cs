using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaDemo
{
    class Perro : Animal
    {
        //public Perro() : base(TipoAnimal.Perro) { }

        public override string EmitirSonido()
        {
            return "Guau";
        }

    }
}
