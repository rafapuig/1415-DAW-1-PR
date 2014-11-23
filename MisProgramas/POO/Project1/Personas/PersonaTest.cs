using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Personas
{
    static class PersonaTest
    {
        static void Main()
        {
            Persona p1 = new Persona();

            p1.Nombre = "Fulanito";
            p1.Edad = 25;

            Persona p2 = new Persona();
            p2.Nombre = "Menganita";
            p2.Edad = 21;

            Console.WriteLine(p1.Presentarse());
            Console.WriteLine(p2.Presentarse());

            Console.WriteLine(p1.SaludarA(p2));
            Console.WriteLine(p2.SaludarA(p1));

            Console.WriteLine("{0}{1} es mas mayor que {2}",
                p1.Nombre,
                p1.EsMasMayorQue(p2) ? "" : " no",
                p2.Nombre);

            Console.WriteLine("{0} y {1}{2} son tocayos", p1.Nombre, p2.Nombre,
                p1.EsTocayoDe(p2) ? "" : " no");
        }
    }
}
