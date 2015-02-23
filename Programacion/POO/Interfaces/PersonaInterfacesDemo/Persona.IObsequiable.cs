using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Interfaces
{
    public partial class Persona : IObsequiable, IObsequiador
    {

        #region "Implementacion de la interfaz IObsequiador"

        public void Obsequiar(IObsequiable obsequiado, string obsequio)
        {
            obsequiado.RecibirObsequio(this, obsequio);
        }

        #endregion

        #region "Implementacion de la interfaz IObsequiable"
        public void RecibirObsequio(IObsequiador obsequiante, string obsequio)
        {
            OnObsequioRecibido(new ObsequioRecibidoEventArgs(obsequiante, obsequio));
        }

        public event EventHandler<ObsequioRecibidoEventArgs> ObsequioRecibido;

        protected virtual void OnObsequioRecibido(ObsequioRecibidoEventArgs e)
        {
            if (this.ObsequioRecibido != null) this.ObsequioRecibido.Invoke(this, e);
        }

        #endregion

    }
}