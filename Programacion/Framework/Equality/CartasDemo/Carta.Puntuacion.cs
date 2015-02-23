using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasDemo
{
    public partial class Carta
    {
        public IPuntuador Puntuador { get; set; }

        public int Puntos
        {
            get
            {
                if (this.Puntuador == null) return 0;
                return this.Puntuador.Puntos(this);
            }
        }
    }
}
