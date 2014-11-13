using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.MedidorTiempo
{
    class MedidorPorAñosEnterosYFraccion : IMedidorTiempo
    {
        
        public double Intervalo(DateTime fechaInicial, DateTime fechaFinal)
        {
            int n = fechaFinal.Year - fechaInicial.Year;    //Numero de años enteros entre fechas

            // Si el tiempo que separa las fechas es menor de una año restar fechar y devoverver fraccion de año
            //return fechaFinal < fechaInicial.AddYears(1) ?
            //                (fechaFinal - fechaInicial).TotalDays / 365.0 :
            //                fechaFinal.Year - fechaInicial.Year + (fechaFinal.AddYears(-n) - fechaInicial).Days / 365.0;    //Años enteros + fraccion de año

            return fechaFinal.Year - fechaInicial.Year + (fechaFinal.AddYears(-n) - fechaInicial).Days / 365.0;

        }
           
    }
}
