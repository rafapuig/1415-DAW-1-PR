using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.DAOO.Patrones.Creacion.Factoria
{  
    class Program
    {
        public static object Create(string className, Dictionary<string,object> initialState)
        {
            Type type = Type.GetType(className);
            object instance = Activator.CreateInstance(type, new object[]{"Lucas"} );
            foreach (var entry in initialState)
            {
                type.GetProperty(entry.Key).SetValue(instance, entry.Value);                
            }            
            return instance;
        }

        static void Main(string[] args)
        {
            string @namespace = typeof(Program).Namespace;
            object p = Create(@namespace + ".Persona",
                new Dictionary<string, object>() { 
                    //{"Nombre", "Rafa Puig"},
                    {"Genero", Genero.Hombre}
                });
            Console.WriteLine(p);
            Console.ReadKey();
        }
    }
}
