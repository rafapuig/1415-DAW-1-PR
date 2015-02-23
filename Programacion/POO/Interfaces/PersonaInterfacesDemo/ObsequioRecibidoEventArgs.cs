using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Interfaces
{
    public class ObsequioRecibidoEventArgs
    {
        public readonly IObsequiador Obsequiador;
        public readonly string Obsequio;

        public ObsequioRecibidoEventArgs(IObsequiador obsequiador, string obsequio)
        {
            this.Obsequiador = obsequiador;
            this.Obsequio = obsequio;
        }
    }    
}

