using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaDemo
{
    class Gato : Animal
    {
        //public Gato():base(TipoAnimal.Gato) { }

        public override string EmitirSonido()
        {
            return "Miau";
        }
    }
}
