using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class SortOps
    {
        public static int[] SortArrayAscending(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                //return new int[] { };
                return [];
            }

            // by default, it's ascending order
            Array.Sort(arr);
            return arr;

        }

        public static int[] SortArrayDescending(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                //return new int[] { };
                return [];
            }           

            // descending order
            //Array.Sort(arr, new Comparison<int>((a, b) => b.CompareTo(a)));
            Array.Sort(arr, (a, b) => b.CompareTo(a));

            return arr;
        }
    }
}
