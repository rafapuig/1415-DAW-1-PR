using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Interfaces
{
    public interface IObsequiable
    {
        void RecibirObsequio(IObsequiador obsequiante, string obsequio);

        event EventHandler<ObsequioRecibidoEventArgs> ObsequioRecibido;
    }
}
