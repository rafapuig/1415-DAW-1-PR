using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    class Docencia
    {
        public Profesor Profesor { get; set; }
        public Asignatura Asignatura { get; set; }
        public int Horas { get; set; }
    }
}
