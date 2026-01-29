using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class MergeSortedArrayOps
    {
        /// <summary>
        /// Merge two sorted array, and assuming the first array can hold all the elements 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="m"></param>
        /// <param name="second"></param>
        /// <param name="n"></param>
        public static void Merge(int[] first, int m, int[] second, int n)
        {
            int i = m - 1;     // first array last index
            int j = n - 1;     // second array last index
            int k = m + n - 1; // last index of merged array

            // Merge in reverse order
            while (i >= 0 && j >= 0)
            {
                if (first[i] > second[j])
                {
                    first[k--] = first[i--];
                }
                else
                {
                    first[k--] = second[j--];
                }
            }

            // If there are remaining elements in second, copy them
            while (j >= 0)
            {
                first[k--] = second[j--];
            }
        }        
    }
}
