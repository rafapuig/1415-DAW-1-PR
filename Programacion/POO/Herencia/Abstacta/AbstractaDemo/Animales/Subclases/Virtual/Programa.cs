using System;

namespace Programacion.POO.Herencia.Animales.Subclases.Virtual
{
    /// <summary>
    /// En esta version los subtipos Perro y Gato REEMPLAZAN el metodo EmitirSonido de la clase base Animal  
    /// Si se usa una refencia de tipo base Animal se llamara a la implementacion del tipo real del objeto
    /// El tipo real del OBJETO indicara en tiempo de ejecucion la implementacion del metodo que se va a llamar
    /// </summary>
    class Programa
    {
        public static void Main()
        {
            TestRefenciasEspecificas();
            TestRefenciasGenericas();
            TestRefencias();
            TestEscribirSonidoPorConsola();
            TestAnimales();
            
            Console.ReadKey();
        }


        static void EscribirSonidoConsola(Animal a)
        {
            //Llama a la implementacion segun el tipo del objeto, si una subclase reemplaza la implementacion de la base
            //Se usara la version reemplazada
            Console.WriteLine(a.EmitirSonido()); 
        }

        static void TestRefenciasEspecificas()
        {
            //Refencias especificas 
            Gato gato = new Gato();
            Perro perro = new Perro();
            
            Console.WriteLine(gato.EmitirSonido());
            Console.WriteLine(perro.EmitirSonido());

            Console.ReadKey();
        }

        static void TestRefenciasGenericas()
        {
            //Refencias genericas (conversion implicita de ampliacion) 
            Animal gato = new Gato();
            Animal perro = new Perro();

            Console.WriteLine(gato.EmitirSonido());
            Console.WriteLine(perro.EmitirSonido());

            Console.ReadKey();
        }

        static void TestRefencias()
        {
            Perro perro = new Perro();

            Console.WriteLine(perro.EmitirSonido());    //Se llama a la implementacion de EmitirSonido de la clase Perro
            
            //Copiar la referencia de tipo Perro al objeto perro en una variable de tipo Animal
            Animal a = perro; //Se puede porque Perro es un subtipo de Animal, conversion implicita ampliacion
            
            Console.WriteLine(a.EmitirSonido());    //Se llama a la implementacion de EmitirSonido de la clase Perro

            Console.ReadKey();
        }
        
        static void TestEscribirSonidoPorConsola()
        {
            Gato gato = new Gato();
            Perro perro = new Perro();

            EscribirSonidoConsola(gato);
            EscribirSonidoConsola(perro);

            Console.ReadKey();
        }

        static Random random = new Random();
        
        /// <summary>
        /// Este metodo muestra las ventajas en cuanto a flexibilidad que proporciona el polimorfismo
        /// Las dos ultimas lineas iteran sobre un vector de animales y le hace emitir su sonido, dependiendo de si son gatos
        /// o perros se llamara polimorficamente a la implementacion correcta segun el verdarero tipo del objeto
        /// </summary>
        static void TestAnimales()
        {
            Animal[] animales= new Animal[10];  

            for (int i = 0; i < 10; i++)
            {
                animales[i] = (random.NextDouble() > 0.5) ? new Perro() as Animal : new Gato() as Animal;
            }

            foreach (Animal a in animales)
                Console.WriteLine(a.EmitirSonido());
        }
    }
}
