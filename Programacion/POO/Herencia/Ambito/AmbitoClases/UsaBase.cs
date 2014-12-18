using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Herencia.Ambito
{
    class UsaBaseInterna
    {
        Base miBase = new Base();

        private void Metodo()
        {
            miBase.MetodoInterno();
            miBase.MetodoPublico();
            miBase.MetodoInternoProtegido();
        }
    }
}
