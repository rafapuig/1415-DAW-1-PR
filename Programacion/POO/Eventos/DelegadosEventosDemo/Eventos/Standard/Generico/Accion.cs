using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Eventos.StandardPattern.Generico
{
    //Clase que hereda de EventArgs
    public class PrecioChangedEventArgs : System.EventArgs
    {
        public readonly decimal PrecioAnterior;
        public readonly decimal PrecioNuevo;

        public PrecioChangedEventArgs(decimal anterior, decimal nuevo)
        {
            this.PrecioAnterior = anterior;
            this.PrecioNuevo = nuevo;
        }
    }

    //Delegado
    //public delegate void PrecioChangedEventHandler(decimal precioAnterior, decimal precioNuevo);
    //public delegate void PrecioChangedEventHandler(object sender, PrecioChangedEventArgs e);    

    //public delegate void EventHandler<T>(object sender,T e);

    class Accion
    {
        public string Simbolo { get; set; }

        public event EventHandler<PrecioChangedEventArgs> PrecioChanged;

        private decimal precio;
        public decimal Precio
        {
            get { return this.precio; }
            set
            {
                if (precio == value) return;    //El precio no ha cambiado
                decimal precioAnterior = this.precio;
                this.precio = value;
                //if (this.PrecioChanged != null) this.PrecioChanged(precioAnterior, this.precio); 
                OnPrecioChanged(new PrecioChangedEventArgs(precioAnterior, this.precio));
            }
        }

        protected virtual void OnPrecioChanged(PrecioChangedEventArgs e)
        {
            if (this.PrecioChanged != null) this.PrecioChanged(this, e);
        }
    }
}
