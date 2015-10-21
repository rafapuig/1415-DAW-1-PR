using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.DAOO.Patterns.Behavioral.ChainOfResposibility.v2
{
    class PersonaComparerByNombre : Comparer<Persona>
    {
        public override int Compare(Persona x, Persona y)
        {
            return x.Nombre.CompareTo(y.Nombre);
        }
    }
}
