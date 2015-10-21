using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.DAOO.Patterns.Behavioral.ChainOfResposibility.v3
{
    abstract class ChainedComparison<T>
    {
        Comparison<T> comparison;

        protected void setComparison(Comparison<T> comparison)
        {
            this.comparison = comparison;
        }

        public ChainedComparison(Comparison<T> comparison)
        {
            this.comparison = comparison;
        }

        bool CanHandle(T x ,T y)
        {
            return this.succesor == null || comparison(x, y) != 0;
        }

        ChainedComparison<T> succesor;

        public ChainedComparison<T> Succesor
        {
            set { succesor = value; }
        }        

        public int Compare(T x,T y)
        {
            if (x != null && y != null)
            {
                if (CanHandle(x, y)) return performComparison(x, y);                
                return this.succesor.Compare(x, y);
            }
            if (x != null) return 1;
            if (y != null) return -1;
            return 0; // x es null & y tambien es null
        }

        protected virtual int performComparison(T x , T y)
        {
            return comparison(x, y);
        }
    }
}
