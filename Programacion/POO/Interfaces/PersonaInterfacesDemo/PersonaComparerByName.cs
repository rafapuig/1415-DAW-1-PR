using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Interfaces
{
    class PersonaComparerByName : IComparer<Persona>
    {
        public int Compare(Persona x, Persona y)
        {
            if (x == null && y == null) return 0; //Iguales
            if (x == null) return 1;
            if (y == null) return -1;

            int orden;
            //Comparamos primero el primer apellido
            orden = x[OrdenApellido.Primero].CompareTo(y[OrdenApellido.Primero]);
            if (orden != 0) return orden; //Si son no iguales ya tenemos orden

            //si no, comparamos el segundo apellido
            orden = x[OrdenApellido.Segundo].CompareTo(y[OrdenApellido.Segundo]);
            if (orden != 0) return orden; //Si son no iguales ya tenemos orden

            //si no, el resultado final lo decidira el nombre
            return x.Nombre.CompareTo(y.Nombre);
        }

        private static readonly PersonaComparerByName _Default = new PersonaComparerByName();

        public static PersonaComparerByName Default { get { return _Default; } }
    }
}
