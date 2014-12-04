using System;

namespace Finanzas
{
    public struct Capital
    {
        public decimal Nominal;
        public System.DateTime FechaVencimiento;
        public LeyFinanciera Ley;
        public IMedidorTiempo MedidorTiempo;

        public Capital(decimal nominal, DateTime fechaVencimiento) :
            this(nominal, fechaVencimiento, Leyes.LeyCapitalizacionCompuesta) { }

        public Capital(decimal nominal, DateTime fechaVencimiento, LeyFinanciera ley) :
            this(nominal, fechaVencimiento, ley, new MedidorTiempo.MedidorPorAñosEnterosYFraccion()) { }

        public Capital(decimal nominal, DateTime fechaVencimiento, LeyFinanciera ley, IMedidorTiempo medidorTiempo)
        {
            this.Nominal = nominal;
            this.FechaVencimiento = fechaVencimiento;
            this.Ley = ley;
            this.MedidorTiempo = medidorTiempo;
        }
                

        double Intervalo(DateTime inicio, DateTime fin)
        {
            return this.MedidorTiempo.Intervalo(inicio, fin);
        }

        public static Capital Sumar(double tipoInteres, params Capital[] capitales)
        {
            decimal suma = 0M;
            foreach (var item in capitales)
            {
                suma = suma + item.VA(tipoInteres);
            }
            return new Capital(suma, DateTime.Today);         
        }   

        //public decimal VA(double ti, Func<double, double, double> ley = null)
        //{
        //    DateTime inicio = DateTime.Today;

        //    double tiempo = Intervalo(inicio, this.FechaVencimiento);

        //    return Nominal / (decimal)ley(ti, tiempo);
        //}
        
        #region Calculo del Valor Actual
      
        public decimal VA(double tipoInteres)
        {
            return VA(tipoInteres, DateTime.Today, this.Ley);
        }

        public decimal VA(double tipoInteres, DateTime fechaActualizacion)
        {
            return VA(tipoInteres, fechaActualizacion, this.Ley);
           // return this.Nominal / this.Ley(tipoInteres, Intervalo(fechaActualizacion, this.FechaVencimiento));
        }

        public decimal VA(double tipoInteres, DateTime fechaActualizacion, LeyFinanciera ley)
        {
            return this.Nominal / ley(tipoInteres, Intervalo(fechaActualizacion, this.FechaVencimiento));
        }

        public decimal VA(double ti, LeyFinanciera ley)
        {
            return VA(ti, DateTime.Today, ley);
        }

        #endregion

        
                
    }

}