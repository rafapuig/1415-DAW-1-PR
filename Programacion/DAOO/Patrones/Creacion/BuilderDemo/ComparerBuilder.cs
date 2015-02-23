using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.DAOO.Patterns.Creational.Builder
{
    class ComparerBuilder<T>
    {
        LinkedList<Comparison<T>> comparisons;

        public ComparerBuilder()
        {
            this.comparisons = new LinkedList<Comparison<T>>();
        }

        public void Add<TKey>(Func<T, TKey> selector) where TKey : IComparable<TKey>
        {
            Comparison<T> comparison = (x, y) => selector(x).CompareTo(selector(y));
            comparisons.AddLast(comparison);
        }

        public ChainedComparer<T> GetResult()
        {
            if (comparisons.Count == 0) return null;

            Comparison<T> comparison = comparisons.First.Value;
            ChainedComparer<T> comparer = new ChainedComparer<T>(comparison);

            var node = comparisons.First;

            while (node.Next != null)
            {
                comparer.SetSuccesor(new ChainedComparer<T>(node.Value));
                node = node.Next;
            }

            return comparer;
        }
    }
}
