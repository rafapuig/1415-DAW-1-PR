using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.DAOO.Patrones.Creacion.Factoria
{
    public enum Genero { Hombre, Mujer }
    class Persona
    {
        public string Nombre { get; set; }
        public virtual Genero Genero { get; set; }
                
        public Persona(string nombre)
        {
            this.Nombre = nombre;
        }

        public override string ToString()
        {
            return string.Format("Nombre = {0}, Genero = {1}",
                this.Nombre, this.Genero);
        }
    }
}
