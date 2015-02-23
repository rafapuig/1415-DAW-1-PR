using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Programacion.POO.Lifetime.DisposeFinalicePattern
{
    class ClipboardWrapper2
    {  
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool CloseClipboard();


        public ClipboardWrapper2()
        {
            GC.SuppressFinalize(this); //En principio hasta que no se reserve el recurso no es necesario llamar al finalizador
        }

        //Todos los metodos comprueban primero antes de nada si el objeto ha sido desechado
        private void CheckIfDisposed()
        {
            if (disposed) throw new ObjectDisposedException("ClipboardWrapper2");
        }

        //Recordar si el portapapeles ya esta abierto
        bool isOpen;

        public void Open(int hWnd)
        {
            CheckIfDisposed();  //Comprobar si he sido desechado 

            if (OpenClipboard((IntPtr)hWnd))
                throw new Exception("No es posible abrir el portapapeles");
            isOpen = true;
            GC.ReRegisterForFinalize(this); //Ahora si que es necesario el finalizador
        }
               

        public void Close()
        {
            CheckIfDisposed();

            if (isOpen) CloseClipboard();
            isOpen = false;
            GC.SuppressFinalize(this); //Recurso liberado, ya no es necesario llamar al finalizador
        }

        //Descartado/desechado
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
                //GC.SuppressFinalize(this);
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
        ~ClipboardWrapper2()
        {
            Dispose(false); //Llama al metodo Dispose sobrecargado indicando que no es un disposal, es una destruccion
        }
    }
}
