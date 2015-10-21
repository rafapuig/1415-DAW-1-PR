using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemoSorting
{
    class MergeSortStrategy<T> : ISortingStrategy<T>
    {
        public void Sort(List<T> items, IComparer<T> comparer)
        {
            items.MergeSort(comparer);
        }
    }
}
