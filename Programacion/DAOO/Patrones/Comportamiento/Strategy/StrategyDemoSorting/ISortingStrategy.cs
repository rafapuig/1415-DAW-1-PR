using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemoSorting
{
    interface ISortingStrategy<T>
    {
        void Sort(List<T> items, IComparer<T> comparer);
    }
}
