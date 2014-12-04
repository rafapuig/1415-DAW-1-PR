using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Herencia
{
    public class Hombre : Persona
    {
        internal Hombre(string nombre, Hombre padre, Mujer madre)
            : base(Genero.Hombre, nombre, padre, madre)
        { }

        public Hombre(string nombre, string apellido1, string apellido2)
            : base(Genero.Hombre, nombre, apellido1, apellido2)
        { }


        public void Embarazar(Mujer pareja)
        {
            pareja.QuedarEmbarazada(this);
        }
    }
}
