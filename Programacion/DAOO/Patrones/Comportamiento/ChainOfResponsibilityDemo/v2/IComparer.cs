using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.DAOO.Patterns.Behavioral.ChainOfResposibility.v2
{
    interface IComparer<T, TKey> : IComparer<T> where TKey : IComparable<TKey>
    {
        int Compare(T x, T y, Func<T, TKey> keySelector);
    }
}
