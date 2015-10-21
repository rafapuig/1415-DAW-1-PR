using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemoSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>()
            {
                "David","Lucas","Rafa","Emilio","Raul","Ramon"
            };

            names.MergeSort(null);
            
        }

        


    }


    static class ListExt
    {
        public static void MergeSort<T>(this List<T> items, IComparer<T> comparer)
        {

        }

        public static void ShellSort<T>(this List<T> items, IComparer<T> comparer)
        {

        }

        public static void QhuickSort<T>(this List<T> items, IComparer<T> comparer)
        {

        }
    }
}
