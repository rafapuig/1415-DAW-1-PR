using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Interfaces
{
    class PersonaComparerByEdad : IComparer<Persona>
    {
        public int Compare(Persona x, Persona y)
        {
            if (x == null && y == null) return 0; //Iguales
            if (x == null) return 1;
            if (y == null) return -1;
             
            //La comparacion de fechas nos da -1 si fx es anterior a fy, 0 si igual, 1 si fx es posterior a fy
            //Si fx es anterior a fy -> entonces la persona x es mayor que la persona y por eso cambimos el signo
            return -x.FechaNacimiento.CompareTo(y.FechaNacimiento);
        }

        private static readonly PersonaComparerByEdad _Default = new PersonaComparerByEdad();

        public static PersonaComparerByEdad Default { get { return _Default; } }
    }
}
