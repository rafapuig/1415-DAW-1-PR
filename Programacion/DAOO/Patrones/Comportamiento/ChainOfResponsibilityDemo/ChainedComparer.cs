using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.DAOO.Patterns.Behavioral.ChainOfResposibility
{
    public abstract class ChainedComparer<T>: IChainedComparer<T>
    {
        protected IChainedComparer<T> succesor;
      
        public IChainedComparer<T> setSuccesor(IChainedComparer<T> succesor)
        {
            return this.succesor = succesor;
        } 

        public int Compare(T x, T y)
        {
            if (x != null && y != null)
            {
                //if (CanHandle(x, y)) return HandleComparison(x, y);
                int orden = HandleComparison(x, y);
                if (orden != 0) return orden;
                return this.succesor != null ? this.succesor.Compare(x, y) : 0;
            }
            if (x != null) return 1;
            if (y != null) return -1;
            return 0; // x es null & y tambien es null
        }

        protected abstract int HandleComparison(T x, T y);
        
        //protected abstract bool CanHandle(T x, T y);

    }
}
