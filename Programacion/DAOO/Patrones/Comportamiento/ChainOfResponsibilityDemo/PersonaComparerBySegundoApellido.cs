using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.DAOO.Patterns.Behavioral.ChainOfResposibility
{
    class PersonaComparerBySegundoApellido:ChainedComparer<Persona>
    {
        protected override int HandleComparison(Persona x, Persona y)
        {
            return x[OrdenApellido.Segundo].CompareTo(y[OrdenApellido.Segundo]);
        }
    }
}
