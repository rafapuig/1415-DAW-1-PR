using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.DAOO.Patterns.Creational.Builder
{
    class PersonaDirector : Director<Persona>
    {  
        public void Construct(ComparerBuilder<Persona> builder)
        {
            builder.Add((Persona p) => p[OrdenApellido.Primero]);
            builder.Add(p => p[OrdenApellido.Segundo]);
            builder.Add(p => p.Nombre);
        }
    }
}
