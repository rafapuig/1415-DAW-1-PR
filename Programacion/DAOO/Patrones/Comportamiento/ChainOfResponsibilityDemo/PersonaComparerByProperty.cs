using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.DAOO.Patterns.Behavioral.ChainOfResposibility
{
    class ComparerByProperty<T> : ChainedComparer<T>
    {
        Comparison<T> comparison;

        public static ComparerByProperty<T> Create<TKey>(Func<T, TKey> propertySelector) where TKey : IComparable<TKey>
        {
            ComparerByProperty<T> obj = new ComparerByProperty<T>();
            obj.setComparison<TKey>(propertySelector);
            return obj;
        }        
        
        public void setComparison<TKey>(Func<T, TKey> propertySelector)
            where TKey : IComparable<TKey>
        {
            this.comparison =
                (x, y) => propertySelector(x).
                    CompareTo(propertySelector(y));
        }
        
        protected override int HandleComparison(T x, T y)
        {
            return comparison(x, y);
        }
    }
}
