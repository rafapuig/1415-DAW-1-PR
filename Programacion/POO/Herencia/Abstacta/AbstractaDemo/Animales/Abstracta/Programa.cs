using System;

namespace Programacion.POO.Herencia.Animales.Abstracta
{
    /// <summary>
    /// En esta version solamente podemos instanciar subtipos concretos Perro, Gato, Gallo y Pato
    /// porque Animal y Ave son abstractas y no se puede instanciar objetos abstractos, solo son ideas  
    /// </summary>
    class Programa
    {
        public static void Main()
        {
            TestInstanciacion();
            TestRefenciasEspecificas();
            TestRefenciasGenericas();
            TestRefencias();
            TestEscribirSonidoPorConsola();
            TestAnimales();
            
            Console.ReadKey();
        }


        static void EscribirSonidoConsola(Animal a)
        {
            //Llama a la implementacion segun el tipo del objeto
            //Como la clase base no aporta ninguna implementacion 
            //Los subtipos concretos que especializan estan obligados a proporcionar una implemtacion a la que llamar            
            Console.WriteLine(a.EmitirSonido()); 
        }


        static void TestInstanciacion()
        {
            //Mo es valido
            //Animal animal = new Animal();
            //Ave ave = new Ave();

            //Si es valido
            Animal gallo = new Gallo();
            Ave pato = new Pato();
            Animal gato = new Gato();

            //No es posible
            //Ave a = new Gato();
        }


        static void TestRefenciasEspecificas()
        {
            //Refencias especificas 
            Gato gato = new Gato();
            Perro perro = new Perro();
            Gallo gallo = new Gallo();
            Pato pato = new Pato();
            
            Console.WriteLine(gato.EmitirSonido());
            Console.WriteLine(perro.EmitirSonido());
            Console.WriteLine(gallo.EmitirSonido());
            Console.WriteLine(pato.EmitirSonido());
            
            Console.ReadKey();
        }

        static void TestRefenciasGenericas()
        {
            //Refencias genericas (conversion implicita de ampliacion) 
            Animal gato = new Gato();
            Animal perro = new Perro();
            Animal gallo = new Gallo();
            Animal pato = new Pato();

            Console.WriteLine(gato.EmitirSonido());
            Console.WriteLine(perro.EmitirSonido());
            Console.WriteLine(gallo.EmitirSonido());
            Console.WriteLine(pato.EmitirSonido());
            
            Console.ReadKey();
        }

        static void TestRefencias()
        {
            Pato pato = new Pato();

            Console.WriteLine(pato.EmitirSonido());    //Se llama a la implementacion de EmitirSonido de la clase Pato
            
            //Copiar la referencia de tipo Perro al objeto perro en una variable de tipo Animal
            Animal a = pato; //Se puede porque Perro es un subtipo de Animal, conversion implicita ampliacion
            
            Console.WriteLine(a.EmitirSonido());    //Se llama a la implementacion de EmitirSonido de la clase Pato

            Ave ave = pato; //Tambien se puede tratar un pato como ave generica
            //Todas las aves pueden responder al metodo PuedeVolar
            Console.WriteLine(ave.PuedeVolar());

            Console.ReadKey();
        }
        
        static void TestEscribirSonidoPorConsola()
        {
            Gato gato = new Gato();
            Perro perro = new Perro();

            EscribirSonidoConsola(gato);
            EscribirSonidoConsola(perro);
            EscribirSonidoConsola(new Pato());
            EscribirSonidoConsola(new Gallo());

            Console.ReadKey();
        }

        static Random random = new Random();


        static Animal GeneraAnimalAleatorio()
        {
            double prob = random.NextDouble();

            if (prob < 0.25) return new Perro();
            if (prob < 0.5) return new Gato();
            if (prob < 0.75) return new Gallo();
            return new Pato();

        }
        
        /// <summary>
        /// Este metodo muestra las ventajas en cuanto a flexibilidad que proporciona el polimorfismo
        /// Las dos ultimas lineas iteran sobre un vector de animales y le hace emitir su sonido, dependiendo 
        /// del tipo concreto de animal se llamara polimorficamente a la implementacion correcta
        /// segun el verdarero tipo del objeto
        /// </summary> 
        static void TestAnimales()
        {
            Animal[] animales= new Animal[10];

            for (int i = 0; i < 10; i++)           
                animales[i] = GeneraAnimalAleatorio();
           
            foreach (Animal a in animales)
                Console.WriteLine(a.EmitirSonido());
        }
    }
}
