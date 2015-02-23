using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Lifetime
{
    class Widget:IDisposable
    {
        System.Timers.Timer timer;
        
        public Widget()
        {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += timer_Elapsed;
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            
        }

        public event System.Timers.ElapsedEventHandler Tick
        {
            add { this.timer.Elapsed += value; }
            remove { this.timer.Elapsed -= value; }
        }


        //Implementar un metodo Dipose si:
        //El objeto adjudica/asigna/reserva recursos distintos a memoria
        //y el recurso debe ser liberado lo antes posible
        //El recurso lo puede obtener directamente desde codigo no administrado WinAPI
        //O indirectamente a traves de otro objeto que reserva el recurso

        //El metodo Finalize se usa cuando el objeto es quien reserva el recurso directamente

        //El metodo Dispose debe poder ser llamado varias veces sin causar error
        private bool disposed;
        public void Dispose()
        {
            if (disposed) return;   //Para ignorar el efecto de las llamadas posteriores a la primera
           
            //Liberar los recursos aqui
            this.timer.Dispose();

            disposed = true;
        }

        //Casos:
        //1)Ninguno: El objeto no reserva/asigna recursos aparte de memoria
        
        //2)Solo Dispose: 
        //Cuando el objeto reserva recusos (aparte memoria) 
        //indirectamente a traves de otros objetos y hay que proporcionar al cliente 
        //una forma de liberarlos lo antes posible

        //3)Ambos (Dispose y Finalize)
        //El objeto asigna un recurso no administrado directamente (PInvoke) que requiere 
        //liberacion explicita o limpieza
        //La liberacion se realiza en el metodo Finalize (para que nunca se quede sin liberar)
        //Pero se proporciona el metodo Dispose tambien, para que los clientes pueden liberar
        //los recursos antes de la finalizacion del objeto

        //4)Solo Finalize
        //Cuando se quiere liberar un recurso o hacer alguna cosa cuando el objeto es finalizado (destruido)
        //Este es el caso menos frecuente

    }
}
