using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaDemo
{
    class Hombre : Persona
    {
        public void Embarazar(Mujer pareja)
        {
            pareja.Embarazada = true;
        }
    }
}
