using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionInActions.src
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class ComparerOps
    {
        public static void SortStringIgnoreCase(string[] list)
        {
            var comparer = Comparer<string>.Create((a, b) => string.Compare(a, b, StringComparison.OrdinalIgnoreCase));
            Array.Sort(list, comparer);
        }

        public static void CustomComparerOne(List<Person> list)
        {
            var comparer = Comparer<Person>.Create((a, b) =>
            {
                int ageCompare = a.Age.CompareTo(b.Age);

                if (ageCompare != 0)
                {
                    return ageCompare;
                }

                return string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase);

            });

            list.Sort(comparer);
        }

        //
        // Sort Intervals by Start Asc, End Desc
        //
        // Input:
        //   [ [1,3], [2,4], [1,2], [2,2], [1,5] ]
        //
        //  Expected sorted result:
        //   [ [1,5], [1,3], [1,2], [2,4], [2,2] ]
        //
        public static void CustomSortingMultiKey(int[][] intervals)
        {
            var comparer = Comparer<int[]>.Create((a, b) =>
            {
                int cmp = a[0].CompareTo(b[0]);

                if (cmp != 0)
                {
                    return cmp;
                }

                // end descending
                return a[1].CompareTo(b[1]);
            });

            Array.Sort(intervals, comparer);
        }
    }
}
