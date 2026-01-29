using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortActions.src
{
    public class QuickSortOps
    {
        public static void QuickSort(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
            {
                return;
            }
            QuickSort(nums, 0, nums.Length - 1);
        }

        private static void QuickSort(int[] nums, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(nums, left, right);

                QuickSort(nums, left, pivotIndex - 1);
                QuickSort(nums, pivotIndex + 1, right);
            }
        }

        private static int Partition(int[] nums, int left, int right)
        {
            int pivotIdx = Random.Shared.Next(left, right + 1);
            Swap(nums, pivotIdx, right);

            int pivot = nums[right];
            int i = left;

            for (int j = left; j < right; j++)
            {
                if (nums[j] <= pivot)
                {
                    Swap(nums, i, j);
                    i++;
                }
            }

            // swap i and right to move the pivot from the end into its correct index i, completing
            // the partition invariant so recursive calls exclude the pivot.
            Swap(nums, i, right);

            return i;
        }

        private static void Swap(int[] nums, int i, int j)
        {
            if (i != j)
            {
                (nums[i], nums[j]) = (nums[j], nums[i]);
            }
        }
    }
}
