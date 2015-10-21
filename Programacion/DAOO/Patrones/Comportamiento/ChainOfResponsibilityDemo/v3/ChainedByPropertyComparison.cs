using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.DAOO.Patterns.Behavioral.ChainOfResposibility.v3
{
    class ChainedByPropertyComparison<T> : ChainedComparison<T>
    {  
        ChainedByPropertyComparison()
            :base(null)
        { 
        }

        public void setProperty<TKey>(Func<T,TKey> propertySelector) where TKey:IComparable<TKey>
        {
            setComparison((x, y) => propertySelector(x).CompareTo(propertySelector(y)));
        }

        public static Comparison<T> setPropertyX<TKey>(Func<T, TKey> propertySelector) where TKey : IComparable<TKey>
        {
            return (x, y) => propertySelector(x).CompareTo(propertySelector(y));
        }

    }

}
