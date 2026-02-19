using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GreedyOps.src
{
    public class MinSwapOps
    {
        //
        // You are given a string num, representing a large integer, and an integer k.
        //
        // We call some integer wonderful if it is a permutation of the digits in
        // num and is greater in value than num.There can be many wonderful integers.
        // However, we only care about the smallest-valued ones.
        //
        // For example, when num = "5489355142":
        //   The 1st smallest wonderful integer is "5489355214".
        //   The 2nd smallest wonderful integer is "5489355241".
        //   The 3rd smallest wonderful integer is "5489355412".
        //   The 4th smallest wonderful integer is "5489355421".
        //
        //   Return the minimum number of adjacent digit swaps that needs to be
        //   applied to num to reach the kth smallest wonderful integer.
        //
        //   The tests are generated in such a way that kth smallest wonderful integer exists.
        //
        // Leet Code 1850. Minimum Adjacent Swaps to Reach the Kth Smallest Number
        //
        // 
        public static int GetMinSwaps(string num, int k)
        {
            if (num == null || k == 0)
                return 0;

            var curr = num.ToArray();
            var perm = num.ToArray();

            for (int i = 0; i < k; i++)
                NextPermutation(perm);

            return CountSteps(curr, perm, num.Length);
        }

        public static int CountSteps(char[] curr, char[] perm, int size)
        {
            int count = 0;

            int i = 0; int j = 0;

            while (i < size)
            {
                j = i;

                // walk through j to find the same character, and then swap neighbors back
                while (curr[j] != perm[i])
                    j++;

                while (i < j)
                {
                    Swap(curr, j, j - 1);
                    j--;
                    count++;
                }

                i++;
            }

            return count;
        }

        private static void Swap(char[] s, int i, int j)
        {
            (s[i], s[j]) = (s[j], s[i]);
        }

        //
        // A permutation of an array of integers is an arrangement of its members into
        // a sequence or linear order.
        //
        // For example, for arr = [1, 2, 3], the following are all the permutations
        // of arr: [1, 2, 3], [1, 3, 2], [2, 1, 3], [2, 3, 1], [3, 1, 2], [3, 2, 1].
        //
        // The next permutation of an array of integers is the next lexicographically
        // greater permutation of its integer.More formally, if all the permutations
        // of the array are sorted in one container according to their lexicographical
        // order, then the next permutation of that array is the permutation that
        // follows it in the sorted container.If such arrangement is not possible,
        // the array must be rearranged as the lowest possible order
        // (i.e., sorted in ascending order).
        //
        // For example, the next permutation of arr = [1, 2, 3] is [1, 3, 2].
        // Similarly, the next permutation of arr = [2, 3, 1] is [3, 1, 2].
        //
        // While the next permutation of arr = [3, 2, 1] is [1, 2, 3] because [3, 2, 1]
        // does not have a lexicographical larger rearrangement.
        //
        // Given an array of integers nums, find the next permutation of nums.
        //
        // The replacement must be in place and use only constant extra memory.
        //
        // LeetCode 31. Next Permutation
        //
        // Time complexity:  O(N)
        // Space complexity: O(1)
        //
        // Difficulty: medium
        //
        public static void NextPermutation(char[] nums)
        {
            if (nums == null || nums.Length <= 1)
                return;

            int n = nums.Length;
            int pivot = n - 1;

            // find the start if decreasing suffix
            while (pivot >= 1 && nums[pivot - 1] >= nums[pivot])
            {
                pivot--;
            }

            if (pivot != 0)
            {
                int i = n - 1;
                while (nums[i] <= nums[pivot - 1])
                {
                    i--;
                }

                (nums[pivot - 1], nums[i]) = (nums[i], nums[pivot - 1]);
            }

            int left = pivot;
            int right = n - 1;
            while (left < right)
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left++;
                right--;
            }
        }
    }
}
