using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Interfaces
{
    public partial class Persona : System.IComparable<Persona>
    {
        public int CompareTo(Persona other)
        {
            if (other == null) return 1; //Cualquier objeto no nulo es mayor que null. 

            //if (this.Equals(other)) return 0;

            return -this.FechaNacimiento.CompareTo(other.FechaNacimiento); //El comparador compara fecha anterior(-1), igual, posterior (1)            
        }

        public static bool operator <(Persona p1, Persona p2)
        {
            return p1.CompareTo(p2) < 0;
        }

        public static bool operator >(Persona p1, Persona p2)
        {
            return p1.CompareTo(p2) > 0;
        }

    }
}
