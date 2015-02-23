using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    static class Instituto
    {
        static List<Profesor> Profesores = new List<Profesor>()
        {
            new Profesor() { Nombre = "Rafael", PrimerApellido = "Puig", SegundoApellido = "Pozo" },
            new Profesor() { Nombre = "Raul", PrimerApellido = "", SegundoApellido = "" },
            new Profesor() { Nombre = "Sonsoles", PrimerApellido = "", SegundoApellido = "" },
            new Profesor() { Nombre = "Fidel", PrimerApellido = "", SegundoApellido = "" }
        };

        static List<Asignatura> Asignaturas = new List<Asignatura>()
        {
            new Asignatura() { Nombre = "Programacion", Horas = 8 },
            new Asignatura() { Nombre = "Lenguajes de marcas y sistemas de gestion de la información", Horas = 3 },
            new Asignatura() { Nombre = "Despliegue de aplicaciones web", Horas = 4 }
        };

        static List<Docencia> Docencias = new List<Docencia>()
        {
            new Docencia() { Asignatura = Asignaturas[0], Profesor = Profesores[0], Horas = Asignaturas[0].Horas },
            new Docencia() { Asignatura = Asignaturas[1], Profesor = Profesores[0], Horas = Asignaturas[1].Horas },
            new Docencia() { Asignatura = Asignaturas[2], Profesor = Profesores[0], Horas = Asignaturas[2].Horas },
        };               
    
    }

}
