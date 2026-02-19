using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortActions.src
{
    public class BubbleSortOps
    {
        //
        // Bubble Sort repeatedly swaps adjacent elements to move the largest values to
        // the end, shrinking the unsorted portion on each pass.
        //        
        // Time complexity:  O(N^2)
        // Space complexity: O(1)
        //
        public static void BubbleSort(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
            {
                return;
            }

            int n = nums.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        // swap
                        (nums[j], nums[j + 1]) = (nums[j + 1], nums[j]);
                    }
                }
            }
        }

        //
        // you can improve the algorithm by adding a flag to detect if any swaps were made during a pass. If no
        // swaps were made, the array is already sorted, and you can terminate early.
        //
        // Time complexity:  O(N^2)  (best case O(N) when already sorted)
        // Space complexity: O(1)
        //
        public static void BubbleSort_Optimized(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
            {
                return;
            }

            int n = nums.Length;
            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;

                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        // swap
                        (nums[j + 1], nums[j]) = (nums[j], nums[j + 1]);
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break; // array is already sorted
                }
            }
        }
    }
}
