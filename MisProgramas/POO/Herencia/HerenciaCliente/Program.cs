using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programacion.POO.Herencia;

namespace HerenciaCliente
{
    static class Program
    {
        static void Main()
        {
            Hombre hombre = new Hombre("Ramon", "Rodriguez", "Ruiz");
            Mujer mujer = new Mujer("Carmen", "Lopez", "Gil");

            hombre.Embarazar(mujer);
            Persona lucas = mujer.Engendrar(Genero.Hombre, "Lucas");

            Console.WriteLine("Es un Hombre? {0}", lucas is Hombre ? "Si" : "No");

            Mujer isabel = new Mujer("Isabel", "Garcia", "Fernandez");
            (lucas as Hombre).Embarazar(isabel);

            Persona lidia = isabel.Engendrar(Genero.Mujer, "Lidia");
            Console.WriteLine("Es una mujer? {0}", lidia is Mujer ? "Si" : "No");
        }
    }
}
