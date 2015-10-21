using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.DAOO.Patterns.Behavioral.ChainOfResposibility
{
    class PersonaComparerByPrimerApellido: ChainedComparer<Persona>
    {
        protected override int HandleComparison(Persona x, Persona y)
        {
            return x[OrdenApellido.Primero].CompareTo(y[OrdenApellido.Primero]);
        }
    }
}
