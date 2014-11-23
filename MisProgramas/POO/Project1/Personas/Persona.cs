using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Personas
{
    class Persona
    {
        public string Nombre;
        public int Edad;

        public string Presentarse()
        {
            return this.Nombre + ": " + "Hola me llamo " + this.Nombre;
        }

        public string SaludarA(Persona otra)
        {
            return this.Nombre + ": " + "Hola " + otra.Nombre + "! ¿Como estas?";
        }

        public bool EsMasMayorQue(Persona otra)
        {
            return this.Edad > otra.Edad;
        }

        public bool EsTocayoDe(Persona otra)
        {
            return this.Nombre == otra.Nombre;
        }
    }
}
