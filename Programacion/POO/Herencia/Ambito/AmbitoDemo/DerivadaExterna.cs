using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Herencia.Ambito
{
    class DerivadaExterna : Base
    {
        private void MetodoDerivadaExterna()
        {
            this.MetodoProtegido();
            base.MetodoProtegido();
            this.MetodoInternoProtegido();
            base.MetodoInternoProtegido();
            this.MetodoPublico();
            base.MetodoPublico();
        }
    }
}
