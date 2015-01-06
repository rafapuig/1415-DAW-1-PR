using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Herencia
{
    public class Empleado : Persona
    {
        public Empleado(Genero genero, string nombre, 
            string apellido1, string apellido2)
            : base(genero, nombre, apellido1, apellido2) { } 

        public override int Edad
        {
            get
            {
                return DateTime.Now.Year - this.FechaNacimiento.Year;
            }
        }

        public decimal Salario { get; set; }
    }
}
