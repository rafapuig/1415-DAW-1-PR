using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.DAOO.Patterns.Behavioral.ChainOfResposibility
{
    static class Program
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
            TestComparisonDelegate();
            TestThenBy();

            var byGenero = new ComparerByProperty<Persona>();
            byGenero.setComparison(p => (int)p.Genero);

            IChainedComparer<Persona> byEdad = ComparerByProperty<Persona>.Create(p => p.FechaNacimiento);

            IChainedComparer<Persona> comparer = byGenero;

            comparer.setSuccesor(byEdad);
            comparer.ThenBy(p => p.EstadoCivil.ToString()); //by EstadoCivil

            Array.Sort(personas, comparer);

            //Array.Sort(personas, (x, y) => x.Genero.CompareTo(y.Genero));
            Array.ForEach(personas, Console.WriteLine);

            Console.ReadKey();
        }

        static void TestComparisonDelegate()
        {
            Array.Sort(personas, (x, y) => x.Genero.CompareTo(y.Genero));
            Array.ForEach(personas, Console.WriteLine);
        }

        static void Test1()
        {
            ChainedComparer<Persona> comparer = new PersonaComparerByPrimerApellido();

            comparer
                .setSuccesor(new PersonaComparerBySegundoApellido())
                .setSuccesor(new PersonaComparerByNombre());
            
            Array.Sort(personas, comparer);
            Array.ForEach(personas, p => Console.WriteLine(p.NombreCompleto));        
        }

        static void TestThenBy()
        {  
            ChainedComparer<Persona> comparer = ComparerByProperty<Persona>.Create(p => p[OrdenApellido.Primero]);

            comparer
                .ThenBy(p => p[OrdenApellido.Segundo])
                .ThenBy(p => p.Nombre);

            Array.Sort(personas, comparer.Compare);
            
            Console.WriteLine("Ordenando por Apellido1, Apellido2, Nombre");
            Array.ForEach(personas, p => Console.WriteLine(p.NombreCompleto));
        }



        static public IChainedComparer<T> ThenBy<T, TKey>(this IChainedComparer<T> comparer, Func<T, TKey> propertySelector) where TKey : IComparable<TKey>
        {
            ComparerByProperty<T> obj = new ComparerByProperty<T>();
            obj.setComparison(propertySelector);
            comparer.setSuccesor(obj);
            return obj;
        }
    }
}
