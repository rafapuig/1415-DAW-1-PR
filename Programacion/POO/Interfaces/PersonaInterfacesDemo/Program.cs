using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Programacion.POO.Interfaces;

namespace PersonaInterfacesDemo
{
    class Program
    {
        static void Main()
        {
            //TestObsequiar();
            //TestIComparable();
            TestIComparable2();
            TestIComparer();
            Console.ReadKey();
        }

        #region "Test Obsequiar"
        static void TestObsequiar()
        {
            IObsequiador obsequiador = new Persona(Genero.Hombre, "Perico", Persona.Adan, Persona.Eva);
            IObsequiable obsequiado = new Persona(Genero.Mujer, "Perica", Persona.Adan, Persona.Eva);

            //Registrar controlador de eventos
            obsequiado.ObsequioRecibido += obsequiado_ObsequioRecibido;

            obsequiador.Obsequiar(obsequiado, "Ramo de flores");

            //Desregistrar el controlador de eventos
            obsequiado.ObsequioRecibido -= obsequiado_ObsequioRecibido;
        }

        static void obsequiado_ObsequioRecibido(object sender, ObsequioRecibidoEventArgs e)
        {
            IObsequiable obsequiado = sender as IObsequiable;

            Console.WriteLine("Obsequiado: {0}", obsequiado);
            Console.WriteLine("Ha recibido <{0}> de {1}", e.Obsequio, e.Obsequiador);
        }

        #endregion


        static Persona[] personas = new Persona[]
        {
            new Persona(Genero.Mujer,"Maria", "Gomez", "Rodriguez") { FechaNacimiento = new DateTime(1977, 2, 18) },
            new Persona(Genero.Hombre,"Lucas", "Ortega", "Gasset") { FechaNacimiento = new DateTime(1965, 3, 10) },
            new Persona(Genero.Mujer,"Nuria", "Ramirez", "Garcia") { FechaNacimiento = new DateTime(1965, 1, 17) },
            new Persona(Genero.Hombre,"Jose", "Rubio", "Martin") { FechaNacimiento = new DateTime(1977, 9, 23) },
            new Persona(Genero.Mujer,"Rocio", "Gomez", "Rodriguez") { FechaNacimiento = new DateTime(1977, 9, 1) },
            new Persona(Genero.Mujer, "Julia", "Perez", "Garcia") { FechaNacimiento = new DateTime(2004, 1, 3) }
        };


        static void TestIComparable()
        {
            Persona maria = new Persona(Genero.Mujer,"Maria", "Gomez", "Rodriguez") { FechaNacimiento = new DateTime(1977, 2, 18) };
            Persona lucas = new Persona(Genero.Hombre, "Lucas", "Ortega", "Gasset") { FechaNacimiento = new DateTime(1965, 3, 10) };

            switch(maria.CompareTo(lucas))
            {
                case 0: Console.WriteLine("Tienen la misma edad"); break;
                case -1: Console.WriteLine("Maria menor que Lucas"); break;
                case 1: Console.WriteLine("Maria mayor que Lucas"); break;
            }

        }

        static void TestIComparable2()
        {            
            Array.Sort(personas);
            Array.ForEach(personas, p => Console.WriteLine(p));
        }

        static void TestIComparer()
        {
            //Array.Sort(personas, new PersonaComparerByName());
            Array.Sort(personas, PersonaComparerByName.Default);
            Array.ForEach(personas, p => Console.WriteLine(p.NombreCompleto));

            personas.OrderBy(p => p.Nombre).ThenByDescending(p => p.FechaNacimiento);
        }

    }
}
