using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas
{
    public interface IMedidorTiempo
    {
        /// <summary>
        /// Calcula el tiempo en años que media entre 2 fechas
        /// </summary>
        /// <param name="fechaInicial">Fecha de inicio del intervalo</param>
        /// <param name="fechaFinal">Fecha final del intervalo</param>
        /// <returns>El valor numerico en años y fraccion de año entre las 2 fechas</returns>
        double Intervalo(DateTime fechaInicial, DateTime fechaFinal);
    }
}
