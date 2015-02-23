using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestCarta();
            TestCartas();
            Console.ReadKey();
        }

        static void TestCarta()
        {
            Carta c = new Carta(Palo.Espadas, Numero.Sota);
            Carta c2 = new Carta(Palo.Oros, Numero.Rey);
            Console.WriteLine(c);
            Console.WriteLine(c2);
        }


        private static void TestCartas()
        {
            int totalPalos = Enum.GetValues(typeof(Palo)).Length;
            int totalNumeros = Enum.GetValues(typeof(Numero)).Length;

            Carta[] cartas = new Carta[totalPalos * totalNumeros];

            int i = 0;
            foreach (Palo palo in Enum.GetValues(typeof(Palo)))
                foreach (Numero numero in Enum.GetValues(typeof(Numero)))
                    cartas[i++] = new Carta(palo, numero) { Puntuador = PuntuadorSegunBrisca.Default };        

            for (int n = 0; n < 100; n++)
                Array.Sort(cartas, new CartaComparerByRandom());           

            Array.ForEach(cartas, carta => Console.WriteLine(carta));

            Console.WriteLine("Buscando el primer As..");
            Carta c = Array.Find(cartas, carta => carta.Numero == Numero.As);
            Console.WriteLine(c);

            Console.WriteLine("Buscando las copas...");
            Carta[] copas = Array.FindAll(cartas, carta => carta.Palo == Palo.Copas);
            Array.ForEach(copas, carta => Console.WriteLine(carta));

            Console.WriteLine("Ordenando las copas...");
            Array.Sort(copas);
            Array.ForEach(copas, carta => Console.WriteLine(carta));

            Console.WriteLine("Puntuando las copas...");
            Array.ForEach(copas, carta => Console.WriteLine("{0} vale {1} puntos", carta, carta.Puntos));

            Console.WriteLine("Total {0} puntos", copas.Sum(carta => carta.Puntos));           
        }
    }
}
