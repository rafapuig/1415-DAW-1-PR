using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaDemo
{
    class Programa
    {
        static void Main()
        {
            Gato gato = new Gato();
            Perro perro = new Perro();

            Console.WriteLine(gato.EmitirSonido());
            Console.WriteLine(perro.EmitirSonido());

            EscribirSonidoConsola(perro);
            EscribirSonidoConsola(gato);

            Console.ReadKey();
        }

        //static void Main()
        //{
        //    Animal gato = new Animal(TipoAnimal.Gato);
        //    Animal perro = new Animal(TipoAnimal.Perro);
            
        //    EscribirSonidoConsola(perro);
        //    EscribirSonidoConsola(gato);

        //    Console.ReadKey();
        //}

        static void EscribirSonidoConsola(Animal a)
        {
            //Perro p = a as Perro;
            //if (p != null) p.EmitirSonido();

            //if(a is Gato) (a as Gato).EmitirSonido();

            //if(a is Perro)
            //{
            //    Perro p = (Perro)a;
            //    p.EmitirSonido();
            //}

            //if(a is Gato)
            //{
            //    Gato g = (Gato)a;
            //    g.EmitirSonido();
            //}
            
            Console.WriteLine(a.EmitirSonido());
        }


        //static void Main()
        //{
        //    Mujer m = new Mujer();           
            
        //}
    }
}
