using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.DAOO.Patterns.Behavioral.ChainOfResposibility.v2
{
    class ComparerByProperty<T> : Comparer<T>
    {
        Func<T, IComparable> keySelector;// { get; set; }

        public ComparerByProperty(Func<T,IComparable> keySelector)
        {
            this.keySelector = keySelector;
        }

        public int Compare<TKey>(T x, T y, Func<T,TKey> keySelector)where TKey:IComparable<TKey>,IComparable
        {
            return keySelector(x).CompareTo(keySelector(y));
        }


        public override int Compare(T x, T y)
        {
            return keySelector(x).CompareTo(keySelector(y));
        }
    }
}
