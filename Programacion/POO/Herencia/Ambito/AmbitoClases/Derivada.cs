using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Herencia.Ambito
{
    public class Derivada : Base
    {
        private void MiMetodo()
        {
            base.MetodoInterno();
            this.MetodoInterno();
            this.MetodoProtegido();
            base.MetodoProtegido();
            this.MetodoPublico();
            base.MetodoPublico();
        }

        public override void MetodoVirtual()
        {
            base.MetodoVirtual();
            Console.WriteLine("DERIVADA: Metodo virtual");
        }
    }
}
