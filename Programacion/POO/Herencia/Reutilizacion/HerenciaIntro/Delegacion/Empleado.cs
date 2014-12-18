using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaDemo.Delegacion
{
    class Empleado
    {
        private Persona laPersonaQueTodoEmpleadoLlevaDentro;

        public decimal Salario { get; set; }

        public Empleado()
        {
            this.laPersonaQueTodoEmpleadoLlevaDentro = new Persona();
        }

        public string Nombre
        {
            get { return this.laPersonaQueTodoEmpleadoLlevaDentro.Nombre; }
            set { this.laPersonaQueTodoEmpleadoLlevaDentro.Nombre = value; }
        }
        public string Apellido 
        {
            get { return this.laPersonaQueTodoEmpleadoLlevaDentro.Apellido; }
            set { this.laPersonaQueTodoEmpleadoLlevaDentro.Apellido = value; }
        }

        public string NombreCompleto
        {
            get { return this.laPersonaQueTodoEmpleadoLlevaDentro.NombreCompleto; }
        }

    }
}
