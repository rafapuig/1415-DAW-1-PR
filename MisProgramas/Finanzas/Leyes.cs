using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas
{
    public delegate decimal LeyFinanciera(double tipoInteres, double tiempo);
    static class Leyes
    {
        public static decimal LeyCapitalizacionCompuesta(double tipoInteres, double tiempo)
        {
            return (decimal)Math.Pow(1 + tipoInteres, tiempo);
        }
    }
}
