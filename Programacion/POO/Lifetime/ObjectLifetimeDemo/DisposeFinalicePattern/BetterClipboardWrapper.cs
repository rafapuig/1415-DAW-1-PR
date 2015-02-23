using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Lifetime.DisposeFinalicePattern
{
    class BetterClipboardWrapper : ClipboardWrapper2
    {
        //La clase asigna nuevos recursos adicionales

        protected override void Dispose(bool disposing)
        {
            if(disposed) return;

            if(disposing)
            {
                //Podemos acceder a decartar los nuevos objetos referenciados 
                //por esta clase derivada
            }

            //Aqui liberamos los nuevos recursos reservados directamente

            //Llamar a la base
            base.Dispose(disposing);
        }
    }
}
