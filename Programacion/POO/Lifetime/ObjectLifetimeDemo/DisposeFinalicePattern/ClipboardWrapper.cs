using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Programacion.POO.Lifetime.DisposeFinalicePattern
{
    class ClipboardWrapper
    {
        //El GC llama al destructor aunque ya se haya llamado a Dispose  y liberado el recurso
        //Afecta negativamente, porque hará falta una recoleccion adicional para liberar la memoria

        //Debemos avisar al GC en la implementacion del Dispose que ya no hace falta llamar al destructor

        //Si el objeto hace referencia a otros objetos no debemos acceder a ellos si estamos en una finalizacion del objeto
        //(puede que estos objetos referenciados ya esten finalizados)

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool CloseClipboard();

        //Recordar si el portapapeles ya esta abierto
        bool isOpen;

        public void Open(int hWnd)
        {
            if (OpenClipboard((IntPtr)hWnd))
                throw new Exception("No es posible abrir el portapapeles");
            isOpen = true;
        }

        public void Close()
        {
            if (isOpen) CloseClipboard();
            isOpen = false;
        }


        protected bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            //Salir si el objeto ya ha sido desechado (liberado sus recursos no administrados)
            if (disposed) return;

            if(disposing) //El objeto se esta desechando desde el codigo cliente
            {
                //Es seguro acceder a otros objetos en este bloque de {}
                ;
                ;

                //Recordar que ha sido desechado
                disposed = true;
                //Decirle al CLR de .NET, al GC, que no llame al destructor (y que proceda directamente a liberar la memoria utilizada)
                GC.SuppressFinalize(this);
            }

            //Realizar las tareas de limpieza/eliminacion/descarte ... que hay que hace en cualquier caso (Dispose o Finalize)
            Close();
        }


        //Dispose lo llama el codigo cliente cuando quiere liberar los recursos        
        public void Dispose()
        {
            Dispose(true);  //Delega en el metodo sobrecargado Dispose indicando que es un Dipose desde el cliente
        }

        //Lo llama el GC cuando el objeto ha sido seleccionado para ser destruido
        //Incluso aunque nunca se haya llamado al metodo Open y se haya asignado el recurso!!!        
        ~ClipboardWrapper()
        {
            Dispose(false); //Llama al metodo Dispose sobrecargado indicando que no es un disposal, es una destruccion
        }
    }
}
