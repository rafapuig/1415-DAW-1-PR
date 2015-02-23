using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasDemo
{
    public enum Palo { Oros, Copas, Espadas, Bastos }

    public enum Numero { As = 1, Dos, Tres, Cuatro, Cinco, Seis, Siete, Sota = 10, Caballo, Rey }

    public partial class Carta : IEquatable<Carta>, IComparable<Carta>, IComparable
    {
        public readonly Palo Palo;
        public readonly Numero Numero;

        public Carta(Palo palo, Numero numero)
        {
            this.Palo = palo;
            this.Numero = numero;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Numero == Numero.Sota ? "La " : "El ");
            sb.Append(this.Numero);
            sb.Append(" de ");
            sb.Append(this.Palo);
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Carta)) return false;
            return this.Equals((Carta)obj);
        }

        public override int GetHashCode()
        {
            return (int)this.Palo * 12 + (int)this.Numero;
        }

        public bool Equals(Carta other)
        {
            if (other == null) return false;
            return this.Palo.Equals(other.Palo) && this.Numero.Equals(other.Numero);
        }

        public static bool operator ==(Carta c1, Carta c2)
        {
            if (ReferenceEquals(c1, null)) return ReferenceEquals(c2, null);
            return c1.Equals(c2);
        }

        public static bool operator !=(Carta c1, Carta c2)
        {
            if ((object)c1 == null) return (object)c2 != null;
            return !c1.Equals(c2);
        }


        public int CompareTo(Carta other)
        {
            if (this.Equals(other)) return 0;

            if (other == null) return 1;

            return this.GetHashCode().CompareTo(other.GetHashCode());
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Carta))
                throw new InvalidOperationException("CompareTo: No es una Carta");

            return CompareTo((Carta)obj);
        }
    }
}
