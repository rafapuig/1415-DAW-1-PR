using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace TestPersona
{
    static class Programa
    {
        static void Main()
        {
            string res = Persona.CapitalizarIniciales("jose luis");
            Console.WriteLine(res);

            Console.ReadKey();
        }

        static void TestCasarse()
        {
            Persona p1 = new Persona("Jaime");
            p1.Apellido = "Lopez";
            p1.FechaNacimiento = new DateTime(1989, 4, 12);

            Persona p2 = new Persona("Maria")
            {
                Apellido = "Gil",
                FechaNacimiento = new DateTime(2000, 12, 13)
            };

            Console.WriteLine("{0} esta casado? {1}",
                p1.NombreCompleto,
                p1.Casado ? "Si" : "No");

            Console.WriteLine("{0} esta casado? {1}",
                p2.NombreCompleto,
                p2.Casado ? "Si" : "No");
                        
           
            Console.WriteLine(p1.Conyuge.NombreCompleto);
            Console.WriteLine(p2.Conyuge.NombreCompleto);
            
            //El conyuge de mi conyuge soy yo?
            Console.WriteLine(
                p1.Conyuge.Conyuge == p1 ? "Si" : "No");

            Persona p3 = null;
            try
            {
                p1.Casarse(p3);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }  

           

            Console.ReadKey();
        }

                
        static void TestCreacion()
        {
            Persona p = new Persona("Alfredo");

            Console.WriteLine(p.Nombre);

            p.Apellido = "Giner";
            Console.WriteLine(p.Apellido);

            Console.ReadKey();
        }

        static void TestReferenciaNula()
        {
            Persona p = new Persona("Pepito");

            Console.WriteLine(p.Nombre);

            p = null; //Desreferenciar la variable

            try
            {
                Console.WriteLine(p.Nombre);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (p != null)
            {
                Console.WriteLine(p.Nombre);
                p.Apellido = "Hernandez";
            }
                
            Console.ReadKey();
        }

        static void TestPresentarse()
        {
            Persona p1 = new Persona("Roberto");          
            p1.Apellido = "Perez";

            Persona p2 = new Persona("Rodolfo");          
            p2.Apellido = "Gomez";     

            Console.WriteLine(p1.Presentarse());
            Console.WriteLine(p2.Presentarse());
            
            Console.ReadKey();
        }

        static void TestPresentarAOtra()
        {
            Persona p1 = new Persona("Roberto");
            p1.Apellido = "Perez";

            Persona p2 = new Persona("Rodolfo")
            {
                Apellido = "Gomez"
            };

            Console.WriteLine(p1.PresentarA(p2));
            Console.WriteLine(p1.PresentarA(p1));

            try
            {
                Console.WriteLine(p1.PresentarA(null));
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
                
        static void TestEdad()
        {
            Persona p = new Persona("Javier")
            {
                FechaNacimiento = DateTime.Parse("18/02/1977")
            };

            Console.WriteLine("Edad de {0} {1} años", p.Nombre, p.Edad);
            Console.ReadKey();
        }

    }
}
