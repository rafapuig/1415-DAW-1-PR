using System;

namespace Programacion.POO.Herencia.Animales.SinSubclases
{
    class Programa
    {
        public static void Main()
        {
            Animal gato = new Animal(TipoAnimal.Gato);
            Animal perro = new Animal(TipoAnimal.Perro);

            EscribirSonidoConsola(gato);
            EscribirSonidoConsola(perro);            

            Console.ReadKey();         
        }

        static void EscribirSonidoConsola(Animal a)
        {
            Console.WriteLine(a.EmitirSonido());
        }
    }
}
