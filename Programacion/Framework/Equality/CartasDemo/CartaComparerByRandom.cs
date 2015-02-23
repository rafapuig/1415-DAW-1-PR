using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasDemo
{
    class CartaComparerByRandom : IComparer<Carta>
    {
        static Random random = new Random();

        public int Compare(Carta x, Carta y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
            
            if (x == y) return 0;

            return random.Next(-1, 1);
        }
    }
}
