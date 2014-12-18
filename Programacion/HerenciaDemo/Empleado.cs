using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaDemo
{
    class Empleado
    {
        private Persona laPersonaQueTodoEmpleadoLlevaDentro; 

        public Empleado()
        {
            this.laPersonaQueTodoEmpleadoLlevaDentro = new Persona();
        }

        public string Nombre
        {
            get { return this.laPersonaQueTodoEmpleadoLlevaDentro.Nombre; }
            set { this.laPersonaQueTodoEmpleadoLlevaDentro.Nombre = value; }
        }
        public string Apellido { get; set; }

        public string NombreCompleto()
        {
            return this.laPersonaQueTodoEmpleadoLlevaDentro.NombreCompleto();
        }

    }
}
