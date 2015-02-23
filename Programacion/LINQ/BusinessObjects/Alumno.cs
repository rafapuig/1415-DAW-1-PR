using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    class Alumno : Persona
    {
        public string NumExpendiente { get; set; }
        
        public DateTime FechaNacimiento { get; set; }
    }
}
