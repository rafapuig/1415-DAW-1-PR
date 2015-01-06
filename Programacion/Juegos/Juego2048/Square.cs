using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego2048
{
    public class Square
    {
        public int Value;        

        internal static Square Default;

        public Square(int value)
        {
            this.Value = value;
        }

        public Square Merge(Square other)
        {
            //Square merged = new Square();
            //merged.Value = this.Value + other.Value;
            //return merged;
            this.Value += other.Value;
            return this;
        }

        public bool CanMerge(Square s2)
        {
            return this.Equals(s2);
        }

        public override bool Equals(object other)
        {
            if (other == null) return false;
            if (this.GetType() != other.GetType()) return false;

            return this.Value.Equals((other as Square).Value);
        }

        public static Square operator +(Square square1, Square square2)
        {
            return square1.Merge(square2);
        }

    }

}
