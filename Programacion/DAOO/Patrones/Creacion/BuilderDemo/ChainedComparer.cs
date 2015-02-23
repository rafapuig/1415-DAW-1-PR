using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.DAOO.Patterns.Creational.Builder
{
    class ChainedComparer<T>
    {
        ChainedComparer<T> succesor;

        public ChainedComparer<T> SetSuccesor(ChainedComparer<T> succesor)
        {
            return this.succesor = succesor;            
        }        

        Comparison<T> comparison;
        public Comparison<T> Comparison { set { this.comparison = value; } }
        
        public ChainedComparer(Comparison<T> comparison)
        {
            this.Comparison = comparison;
        }


        public int Compare(T x, T y)
        {
            if (x != null && y != null)
            {
                //if (CanHandle(x, y)) return HandleComparison(x, y);
                int orden = comparison(x, y);
                if (orden != 0) return orden;
                return this.succesor != null ? this.succesor.Compare(x, y) : 0;
            }
            if (x != null) return 1;
            if (y != null) return -1;
            return 0; // x es null & y tambien es null
        }
    }
}
