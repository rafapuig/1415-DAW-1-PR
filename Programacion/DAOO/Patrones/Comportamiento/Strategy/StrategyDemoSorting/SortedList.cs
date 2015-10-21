using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemoSorting
{
    class SortedList<T> : List<T>
    {
        ISortingStrategy<T> sortingStrategy;

        public SortedList(List<T> items)
            : base(items) { }

        void SetSortingStrategy(ISortingStrategy<T> newSortingStrategy) 
        {
            sortingStrategy = newSortingStrategy;
        }

        void PerfomSort(IComparer<T> comparer)
        {
            //this.sortingStrategy.Sort(this, comparer);
            PerfomSort(this.sortingStrategy, comparer);
        }

        void PerfomSort(ISortingStrategy<T> temporalSortingStrategy, IComparer<T> comparer)
        {
            PerfomSort(temporalSortingStrategy.Sort, comparer);
            //temporalSortingStrategy.Sort(this, comparer);

        }

        void PerfomSort(Action<List<T>, IComparer<T>> sortDelegate, IComparer<T> comparer)
        {
            sortDelegate(this, comparer);
        }

    }
}
