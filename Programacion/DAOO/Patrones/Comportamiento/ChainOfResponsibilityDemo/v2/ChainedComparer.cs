using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.DAOO.Patterns.Behavioral.ChainOfResposibility.v2
{
    class ChainedComparer<T> : Comparer<T>
    {        

        Comparison<T> comparison;

        ChainedComparer()
        {
            comparison = this.PerformComparison;
        }

        public ChainedComparer(Comparison<T> comparison)
        {
            this.comparison = comparison;
        }

        IComparer<T> comparer;

        public ChainedComparer(IComparer<T> comparer)
            : this()
        {
            this.comparer = comparer;
        }

        public ChainedComparer(Func<T,IComparable> keySelector) 
        {
            this.comparison = (x, y) => keySelector(x).CompareTo(keySelector(y));
        }


        ChainedComparer<T> succesor;

        public ChainedComparer<T> SetSuccesor(ChainedComparer<T> succesor)
        {
            return this.succesor = succesor;
        }

        public ChainedComparer<T> SetSuccesor(Comparison<T> comparison)
        {
            return this.SetSuccesor(new ChainedComparer<T>(comparison));
        }

        public ChainedComparer<T> SetSuccesor(Comparer<T> comparer)
        {
            return this.SetSuccesor(new ChainedComparer<T>(comparer));
        }

        public ChainedComparer<T> SetSuccesor<TKey>(Func<T, TKey> keySelector) where TKey : IComparable<TKey>
        {
            //return this.succesor = new ChainedComparer<T>(new ObjectComparerByProperty<T, TKey>(keySelector));
            return this.SetSuccesor(new ObjectComparerByProperty<T, TKey>(keySelector));
        }


        public override sealed int Compare(T x, T y)
        {
            int orden = comparison(x, y); //PerformComparison(x, y);
            if (orden != 0) return orden;
            return this.succesor != null ? succesor.Compare(x, y) : 0;            
        }

        protected virtual int PerformComparison(T x,T y)
        {
            //if (EqualityComparer<T>.Default.Equals(x, y)) return 0;
            return comparer.Compare(x, y);
        }
        
    }
}
