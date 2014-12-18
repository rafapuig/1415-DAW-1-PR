using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Herencia.Ambito
{
    public class Base
    {
        private int campoPrivado;
        internal int campoAmigo;
        public int campoPublico;

        private void MetodoPrivado() { }

        protected void MetodoProtegido() { }

        internal void MetodoInterno() { }

        public void MetodoPublico() { }

        protected internal void MetodoInternoProtegido() { }

        public virtual void MetodoVirtual()
        {
            Console.WriteLine("BASE: Metodo Virtual");
        }
        

    }
}
