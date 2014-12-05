using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosDemo
{
    class Programa
    {
        static void Main()
        {
            Perro max = new Perro("Max");
            Persona juan = new Persona("Juan") { Mascota = max };
            
            //max.Sediento += juan.Mascota_Sediento;
        }
    }
}
