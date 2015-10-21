using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.DAOO.Patterns.Behavioral.ChainOfResposibility.v2
{
    class ChainedComparerBuilder<T>
    {
        public static ChainedComparer<T> Build(params Comparer<T>[] comparers)
        {
            ChainedComparer<T> comparer = new ChainedComparer<T>(comparers[0]);
            ChainedComparer<T> previo = comparer;
            for (int i = 1; i < comparers.Length; i++)
            {
                previo = previo.SetSuccesor(new ChainedComparer<T>(comparers[i]));
            }
            return comparer;
        }
    }
}
