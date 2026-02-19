using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ArrayInActions.src
{
    public class RotateOps
    {
        //
        // Suppose an array of length n sorted in ascending order is rotated
        // between 1 and n times. For example, the array
        //   nums = [0,1,4,4,5,6,7] might become:
        //
        //   [4, 5, 6, 7, 0, 1, 4] if it was rotated 4 times.
        //   [0, 1, 4, 4, 5, 6, 7] if it was rotated 7 times.
        //
        //  Notice that rotating an array[a[0], a[1], a[2], ..., a[n - 1]] 1 time
        //  results in the array[a[n - 1], a[0], a[1], a[2], ..., a[n - 2]].
        //
        //  Given the sorted rotated array nums that may contain duplicates, return
        //  the minimum element of this array.
        //
        //  You must decrease the overall operation steps as much as possible.
        //
        // LeetCode 154: Find Minimum in Rotated Sorted Array II
        //
        //
        public static int FindMinInRotatedArray(int[] nums)
        {
            int low = 0;
            int high = nums.Length - 1;

            while (low < high)
            {
                int pivot = low + (high - low) / 2;

                if (nums[pivot] < nums[high])
                {
                    high = pivot;
                }
                else if (nums[pivot] > nums[high])
                {
                    low = pivot + 1;
                }
                else
                {
                    high--;
                }
            }

            return nums[low];
        }

        //
        // Given an integer array nums, rotate the array to the right by k steps, where k is non-negative.
        //
        // LeetCode: 189. Rotate Array
        //
        public static void Rotate(int[] nums, int k)
        {
            if (k == 0) return;

            int m = nums.Length;

            k %= m;

            if (k == 0) return;

            Reverse(nums, 0, m - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, m - 1);
        }

        private static void Reverse(int[] arr, int l, int r)
        {
            while (l < r)
            {
                (arr[l], arr[r]) = (arr[r], arr[l]);
                l++;
                r--;
            }
        }

        // 
        // Mental model (important)
        //
        //   Think of it as:
        //     Pick up one value, walk it forward by k, drop it, pick up what was there, repeat
        //     until you’re back.
        //
        // Time complexity:  O(N)
        // Space complexity: O(1)
        //
        public static void Rotate_Cyclic(int[] nums, int k)
        {
            int n = nums.Length;
            k %= n;
            if (k == 0) return;

            int total = 0;
            int startIdx = 0;

            while (total < n)
            { 
                int currIdx = startIdx;
                int value = nums[startIdx];

                do
                {
                    int next = (currIdx + k) % n;
                    (nums[next], value) = (value, nums[next]);
                    currIdx = next;
                    total++;
                }
                while (startIdx != currIdx);
                startIdx++;
            }
        }
    }
}
