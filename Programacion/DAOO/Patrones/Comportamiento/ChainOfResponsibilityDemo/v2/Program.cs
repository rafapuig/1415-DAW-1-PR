using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.DAOO.Patterns.Behavioral.ChainOfResposibility.v2
{
    class Program
    {
        static Persona[] personas = new Persona[]
        {            
            new Persona(Genero.Hombre, "Juan", "Garcia", "Gil"),
            new Persona(Genero.Mujer, "Marta", "Garcia", "Gil"),
            new Persona(Genero.Hombre, "Juan","Perez", "Lopez"),
            new Persona(Genero.Mujer, "Ana", "Perez", "Martinez")
        };

        static void Main()
        {
            ChainedComparer<Persona> comparer = new ChainedComparer<Persona>(new PersonaComparerByPrimerApellido());

            comparer
                .SetSuccesor(new ChainedComparer<Persona>(new PersonaComparerBySegundoApellido()))
                .SetSuccesor(new ChainedComparer<Persona>(new PersonaComparerByNombre()));


            comparer
                .SetSuccesor(new ChainedComparer<Persona>((x, y) => x.Edad.CompareTo(y.Edad)))
                .SetSuccesor(p => p.NombreCompleto);

            comparer
                .SetSuccesor((x, y) => x.Genero.CompareTo(y.Genero));

            comparer = ChainedComparerBuilder<Persona>.Build(
                new PersonaComparerByPrimerApellido(), 
                new PersonaComparerBySegundoApellido(),
                new PersonaComparerByNombre(),
                new ComparerByProperty<Persona>(p => p.Edad));


            comparer
               .SetSuccesor(new PersonaComparerBySegundoApellido())
               .SetSuccesor(new PersonaComparerByNombre())
               .SetSuccesor(new ChainedComparer<Persona>((x, y) => x.Edad.CompareTo(y.Edad)))
               .SetSuccesor(p => p.NombreCompleto);

            //comparer = new ChainedComparer<Persona>(new ComparerByProperty<Persona>(p => p.Edad));

            comparer = new ChainedComparer<Persona>(p => p[OrdenApellido.Primero]);
            comparer
                .SetSuccesor(p => p[OrdenApellido.Segundo])
                .SetSuccesor(p => p.Nombre);

            Array.Sort(personas, comparer);
            Array.ForEach(personas, Console.WriteLine);

            Console.ReadKey();

        }
    }
}
