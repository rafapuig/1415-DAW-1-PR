using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaDemo
{
    class Persona
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public string NombreCompleto()
        {
            return this.Nombre + " " + this.Apellidos;
        }
    }
}
