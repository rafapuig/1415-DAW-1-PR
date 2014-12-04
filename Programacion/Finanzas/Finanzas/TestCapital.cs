using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas
{
    public class TestCapital
    {
        public static void Main()
        {
            Capital c = new Capital();
            c.Nominal = 1050;
            c.FechaVencimiento = DateTime.Today.AddYears(1);
            c.MedidorTiempo = new MedidorTiempo.MedidorPorAñosEnterosYFraccion();

            //Func<double, double, double> ley = Capital.LeyCapitalizacionCompuesta;    //Ya no funciona
            
            LeyFinanciera capitalizacionCompuesta = Leyes.LeyCapitalizacionCompuesta;

            //decimal va = c.VA(0.05, ley);
            decimal va = c.VA(0.05, (i, t) => (decimal)Math.Pow((1 + i), t));

            //decimal va = c.VA(0.05, capitalizacionCompuesta);
            //decimal va = c.VA(0.05, Capital.LeyCapitalizacionCompuesta);
            Console.WriteLine(va);

            Capital c2 = new Capital(1100, DateTime.Today.AddYears(1));
            Console.WriteLine(c2.VA(0.10, DateTime.Today.AddMonths(6)));

            Capital s = Capital.Sumar(0.05, new Capital(1050, DateTime.Today.AddYears(1)), new Capital(1050, DateTime.Today.AddYears(1)));
            Console.WriteLine(s.Nominal);

            Capital c3 = new Capital(1050, DateTime.Today.AddYears(1), new LeyFinanciera(Leyes.LeyCapitalizacionCompuesta));

            
            Console.ReadKey();       

        }
    }
}
