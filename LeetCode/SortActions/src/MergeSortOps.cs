using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortActions.src
{
    public class MergeSortOps
    {
        public static void MergeSort(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
            {
                return;
            }

            var temp = new int[nums.Length];

            MergeSort(nums, temp, 0, nums.Length - 1);

        }

        public static void MergeSort(int[] nums, int[] temp, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int mid = left + (right - left) / 2;
            MergeSort(nums, temp, left, mid);
            MergeSort(nums, temp, mid + 1, right);
            Merge(nums, temp, left, mid, right);
        }

        public static void Merge(int[] nums, int[] temp, int left, int mid, int right)
        {
            for (int idx = left; idx <= right; idx++)
            {
                temp[idx] = nums[idx];
            }

            int i = left;
            int j = mid + 1;
            int k = left;

            while (i <= mid && j <= right)
            {
                if (temp[i] <= temp[j])
                {
                    nums[k++] = temp[i++];
                }
                else
                {
                    nums[k++] = temp[j++];
                }
            }
            while (i <= mid)
            {
                nums[k++] = temp[i++];
            }
        }
    }
}
