using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Eventos.Evento.Explicito
{
    //Delegado
    public delegate void PrecioChangedEventHandler(decimal precioAnterior, decimal precioNuevo);
    class Accion
    {
        public string Simbolo { get; set; }

        //Campo de respaldo privado para no permitir un uso libre por el codigo cliente
        private PrecioChangedEventHandler _PrecioChanged;

        //En realidad un evento es como el equivalente a una propiedad pero para un delegado
        //en lugar de get y set se usan add y remove
        public event PrecioChangedEventHandler PrecioChanged
        {
            add { this._PrecioChanged += value; }
            remove { this._PrecioChanged -= value; }
        }

        private decimal precio;
        public decimal Precio
        {
            get { return this.precio; }
            set
            {
                if (precio == value) return;    //El precio no ha cambiado
                decimal precioAnterior = this.precio;
                this.precio = value;
                if (this.PrecioChanged != null) this.PrecioChanged(precioAnterior, this.precio);                
            }
        }
    }
}
