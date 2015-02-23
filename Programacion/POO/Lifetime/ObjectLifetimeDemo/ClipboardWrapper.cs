using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Programacion.POO.Lifetime
{
    class ClipboardWrapper : IDisposable
    {

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

        //Dispose lo llama el codigo cliente cuando quiere liberar los recursos
        //Gracias al campo isOpen
        //Nos permite asegurar el que codigo de limpieza no se ejecuta mas de una vez
        public void Dispose()
        {
            Close();
        }

        //Lo llama el GC cuando el objeto ha sido seleccionado para ser destruido
        //(Si el cliente ya ha llamado a Dispose en realidad no se hace nada porque
        //el recurso ya ha sido liberado)
        ~ClipboardWrapper()
        {
            Close();
        }

    }

}
