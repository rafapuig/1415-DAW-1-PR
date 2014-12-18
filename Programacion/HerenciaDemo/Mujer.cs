using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaDemo
{
    class Mujer : Persona
    {
        public bool Embarazada { get; set; }

        public Persona Parir() { return null; }

        //Reemplazar Genero
        //Reemplazar NombreCompleto
        //depende de estado ->Sra o srta.
    }
}
