using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Herencia.Ambito
{
    class Program
    {
        static void Main()
        {

        }

        static void UsarBaseDesdeEnsambladoExterno()
        {
            Base b = new Base();
            b.MetodoPublico();
            int x = b.campoPublico;
        }
    }
}
