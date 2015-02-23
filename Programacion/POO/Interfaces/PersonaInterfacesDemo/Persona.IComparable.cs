using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Interfaces
{
    public partial class Persona : System.IComparable
    {
        public int CompareTo(object obj)
        {
            if (!(obj is Persona)) 
                throw new InvalidOperationException("CompareTo: No es una Persona.");

            if (obj == null) return 1; //Cualquier objeto no nulo es mayor que null. 

            //return -this.FechaNacimiento.CompareTo((obj as Persona).FechaNacimiento); //El comparador compara fecha anterior(-1), igual, posterior (1)
            return this.CompareTo((Persona)obj);
        }
    }
}
