using System;

namespace Programacion.POO.Herencia.Animales.Subclases.Hide
{
    /// <summary>
    /// En esta version los subtipos Perro y Gato ocultan o ensombrecen el metodo EmitirSonido de la clase base Animal
    /// Cuando se use una referencia de tipo especifico (Gato o Perro) se usa esa implementacion
    /// Si se usa una refencia de tipo base Animal se llamara a la implementacion de la clase Animal
    /// El tipo de la referencia utilizada para llamar al metodo fija la version del metodo que se va a llamar
    /// </summary>
    class Programa
    {
        public static void Main()
        {
            TestRefenciasEspecificas();
            TestRefenciasGenericas();
            TestRefencias();
            TestEscribirSonidoPorConsola();
            
            Console.ReadKey();
        }

        static void EscribirSonidoConsolaErroneo(Animal a)
        {
            //Llama a la implementacion de la clase Animal (aunque el objeto sea una subclase Gato o Perro)
            Console.WriteLine(a.EmitirSonido()); 
        }

        static void EscribirSonidoConsolaEnmendado(Animal a)
        {
            //Como no queremos que se llame a la version de la clase del metodo emitir sonido...
            //No utilizaremos la referencia generica de tipo Animal

            //Tendremos que comprobar el tipo real de animal y en base a esta informacion convertir la referencia

            //El operador se una cuando el programador no sabe seguro el tipo real del objeto 
            //y quiere hacer una bifurcacion en funcion del tipo
            
            //Operador as: Si el tipo real de la instacia apuntada por la referencia de tipo Animal
            //es un Perro entonces el operador as devuelve una refencia convertida a tipo Perro
            //si no devuelve null
            Perro p = a as Perro;   
            if (p != null) p.EmitirSonido();

            //Podemos utilizar directamente la nueva refencia convertida que no devuelve el operador as  
            //El operador is nos sirve para comprobar si la conversion de una referencia a un determinado tipo tendra exito            
            if(a is Gato) 
                (a as Gato).EmitirSonido();


            //La conversion con un casting o molde sirva que para indicar al compilador que estamos seguros de que el
            //tipo real del objeto es el que indicamos entre parentesis y si estamos equivocados es porque el programa
            //tiene un bug y por tanto debe fallar lanzando una excepcion InvalidCastException
            
            //Este codigo tambien valdria
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
            
            Console.WriteLine(a.EmitirSonido());    //Se llama a la implementacion de EmitirSonido de la clase Animal

            Console.ReadKey();
        }
        
        static void TestEscribirSonidoPorConsola()
        {
            Gato gato = new Gato();
            Perro perro = new Perro();

            EscribirSonidoConsolaErroneo(gato);
            EscribirSonidoConsolaErroneo(perro);

            EscribirSonidoConsolaEnmendado(gato);
            EscribirSonidoConsolaEnmendado(perro);
            Console.ReadKey();
        }
    }
}
