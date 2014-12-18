using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Eventos
{
    partial class Persona
    {
        
        public event EventHandler<RegaloRecibidoEventArgs> RegaloRecibido;
        
        public void Regalar(Persona obsequiado, string regalo)
        {
            //Quien lanza el evento es el obsequiado!!!
            obsequiado.OnRegaloRecibido(new RegaloRecibidoEventArgs(this, regalo));
        }

        protected void OnRegaloRecibido(RegaloRecibidoEventArgs e)
        {
            if (RegaloRecibido != null) RegaloRecibido(this, e);
        }
    }

    public class RegaloRecibidoEventArgs : System.EventArgs
    {
        public readonly Persona Obsequiador;
        public readonly string Regalo;

        public RegaloRecibidoEventArgs(Persona obsequiador, string regalo)
        {
            this.Obsequiador = obsequiador;
            this.Regalo = regalo;
        }
    }

}
