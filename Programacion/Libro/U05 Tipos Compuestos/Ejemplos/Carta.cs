using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.TiposCompuestos
{

    enum Palo  { Oros, Copas, Espadas, Bastos }
    enum Rango { As, Dos, Tres, Cuatro, Cinco, Seis, Siete, Sota, Caballo, Rey }        


    struct Carta
    {
        public Palo Palo;
        public Rango Rango;        
    }

    static class CartaDemo
    {
        static void Main()
        {
            TestCarta1();
            Console.ReadKey();
        }

        static void TestCarta1()
        {
            Carta c = new Carta();

            c.Palo = Palo.Espadas;
            c.Rango = Rango.Rey;

            Console.WriteLine("La carta es: {0} de {1}", c.Rango, c.Palo);
        }        
    }

}
