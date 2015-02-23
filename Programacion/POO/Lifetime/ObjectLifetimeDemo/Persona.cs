using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Lifetime
{
    class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public int ID { get; private set; }

        private static int Poblacion;

        public Persona(string nombre, string apellido)
        {
            this.ID = ++Poblacion;
            
            this.Nombre = nombre;
            this.Apellido = apellido;
        }


        //Los objetos que definen un metodo finalizador no son destruidos en la primera recoleccion de objetos
        //El GC los deja con vida, porque los añade a una cola de objetos pendientes de finalizar
        //Un hilo en segundo plano ejecuta los metodos finalizadores de los objetos en la cola
        ~Persona()
        {
            //Nunca acceder a ningun objeto externo desde el metodo finalizador/destructor (puede estar ya destruido)
            //Los metodos estaticos son seguros salvo cuando se este terminando la aplicacion
            //Por eso no debemos utilizar tampoco Console.Writeline en ese caso
            //El objeto Debug es uno de los pocos que .NET garantiza que permanecera con vida hasta el final
            //Como saber si se ha empezado a cerrar la aplicacion: Environment.HasShutdownStarted
            if (!Environment.HasShutdownStarted)
            {
                //Aqui se puede usar cualquier metodo estatico de cualquier otra clase  
                //Por ejemplo Console.WriteLine
            }

            System.Diagnostics.Debug.WriteLine(
                    "Persona [{0,5}] {1} {2} esta siendo destruida...",
                    this.ID, this.Nombre, this.Apellido);
        }

    }
}
