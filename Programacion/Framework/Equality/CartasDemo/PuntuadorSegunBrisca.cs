using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasDemo
{
    class PuntuadorSegunBrisca : IPuntuador
    {
        public static readonly PuntuadorSegunBrisca Default = new PuntuadorSegunBrisca();

        public int Puntos(Carta carta)
        {
            switch (carta.Numero)
            {
                case Numero.Dos:
                case Numero.Cuatro:
                case Numero.Cinco:
                case Numero.Seis:
                case Numero.Siete: return 0;
                case Numero.Sota: return 2;
                case Numero.Caballo: return 3;
                case Numero.Rey: return 4;
                case Numero.Tres: return 10;
                case Numero.As: return 11;
            }
            return 0;
        }
    }
}
