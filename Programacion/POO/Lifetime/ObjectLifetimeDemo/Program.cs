using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Programacion.POO.Lifetime.ObjectLifetimeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestFinalize();
            TestFinalize2();
            //TestFinalize3();
            Debug.WriteLine("Apunto de terminar la aplicacion");
            Console.ReadKey();
        }

        static void TestFinalize()
        {
            Debug.WriteLine("Apunto de crear un objeto persona...");
            Persona p = new Persona("Perico", "Palotes");
            Debug.WriteLine("Saliendo del metodo TestFinalice()...");
        }

        static void TestFinalize2()
        {
           
            GC.AddMemoryPressure(Int32.MaxValue);
            Persona p;

            for(int i=0;i<10000;i++)
            {
                p = new Persona("Perico", "Palotes");
                Debug.WriteLine("Persona [{0,5}] {1} {2} creada.",
                    p.ID, p.Nombre, p.Apellido);
            }
        }

        static void TestFinalize3()
        {
            Debug.WriteLine("Apunto de crear un objeto Persona...");
            Persona p = new Persona("Perico", "Palotes");
            p = null;
            Debug.WriteLine("Apunto de desencadenar una recoleccion de objetos no utilizados (basura)");
            GC.Collect();   //Nunca se deberia hacer, la recoleccion de manera automatica esta pensada para optimizar el rendimiento
            GC.WaitForPendingFinalizers(); //Esperar a que terminen los finalizadores de los objetos que estan en la cola de objetos pendientes de finalizar
        }


        static void TestDispose()
        {
            Widget obj = new Widget();
            //Usar el objeto

            //Liberar sus recursos
            obj.Dispose();

            //Ya no se hace referencia mas veces a obj, hemos terminado con el y liberado los recursos.
            //Cuando el GC lo considere liberará la memoria utilizada por el objeto
        }
        
        static void TestDispose2()
        {
            Widget obj = new Widget();
            try
            {
                //Usar el objeto
            }
            catch (Exception)
            {                
                throw;
            }
            finally
            {
                obj.Dispose();
            }
        }
        
        static void TestDispose3()
        {
            using (Widget obj = new Widget())
            {
                //obj.Dispose() no hace falta, es automaticamente llamado cuando se sale del bloque using
            }
        }
    
    
    }
}
