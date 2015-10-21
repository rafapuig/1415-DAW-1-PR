using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.DAOO.Patterns.Behavioral.ChainOfResposibility
{
    class PersonaComparerByNombre : ChainedComparer<Persona>
    {
        protected override int HandleComparison(Persona x, Persona y)
        {
            return x.Nombre.CompareTo(y.Nombre);
        }

        //protected override bool CanHandle(Persona x, Persona y)
        //{
        //    return x.Nombre.CompareTo(y.Nombre) != 0;
        //}

        //public override int Compare(Persona x, Persona y)
        //{
        //    if (x != null && y != null)
        //    {
        //        int orden = x.Nombre.CompareTo(y.Nombre);
        //        if (orden != 0) return orden;
        //        return this.succesor != null ? this.succesor.Compare(x, y) : 0;
        //    }
        //    if (x != null) return 1;
        //    if (y != null) return -1;
        //    return 0; // x es null & y tambien es null
        //}
    }
}
