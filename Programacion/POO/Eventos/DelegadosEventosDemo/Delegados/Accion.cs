using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Eventos.Delegados
{
    //Delegado
    public delegate void PrecioChangedEventHandler(decimal precioAnterior, decimal precioNuevo);
    class Accion
    {
        public string Simbolo { get; set; }

        public PrecioChangedEventHandler PrecioChanged;

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
