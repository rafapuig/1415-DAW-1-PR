using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.DAOO.Patterns.Creational.Builder
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

        static void Main(string[] args)
        {
            Director<Persona> director = new PersonaDirector(); 
          
            var builder = new ComparerBuilder<Persona>();
            director.Construct(builder);
            ChainedComparer<Persona> comparer = builder.GetResult();

            Array.Sort(personas, comparer.Compare);
            Array.ForEach(personas, Console.WriteLine);

            Console.ReadKey();
        }

        public static ChainedComparer<Persona> Construct(ComparerBuilder<Persona> builder)
        {            
            builder.Add((Persona p) => p[OrdenApellido.Primero]);
            builder.Add(p => p[OrdenApellido.Segundo]);
            builder.Add(p => p.Nombre);
            ChainedComparer<Persona> comparer = builder.GetResult();
            return comparer;
        }

    }
}
