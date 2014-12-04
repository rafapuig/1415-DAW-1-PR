using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Herencia
{
    public class Mujer : Persona
    {
        //Todas las mujeres tienen genero femenino
        public Mujer(string nombre, string apellido1, string apellido2)
            : base(Genero.Mujer, nombre, apellido1, apellido2) 
        { }

        internal Mujer(string nombre, Persona padre, Mujer madre)
            : base(Genero.Mujer, nombre, padre, madre)
        { }

        public bool Embazarada { get { return this.Inseminante != null; } }
        public Hombre Inseminante { get; private set; }

        internal void QuedarEmbarazada(Hombre futuroPadre)
        {
            //Si ya esta embarazada no se puede volver a quedar de otro hombre
            if (this.Embazarada) return;

            this.Inseminante = futuroPadre;
        }

        public Persona Engendrar(Genero genero, string nombre)
        {
            if (!this.Embazarada)            
                throw new InvalidOperationException("Mujer no embarazada");

            Persona hijo;

            switch (genero)
            {
                case Genero.Hombre:
                    hijo = new Hombre(nombre, this.Inseminante, this);
                    break;
                case Genero.Mujer:
                    hijo = new Mujer(nombre, this.Inseminante, this);
                    break;             
            }
            return null;
        }

    }
}
