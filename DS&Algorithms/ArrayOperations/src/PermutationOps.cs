using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Execution;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ArrayInActions.src
{
    public class PermutationOps
    {
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
        public static void NextPermutation(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
                return;

            int n = nums.Length;
            int pivot = n - 1;

            // find the start if decreasing suffix
            while (pivot > 0 && nums[pivot - 1] >= nums[pivot])
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

        // 
        // Build permutations step by step:
        //   - Start with an empty permutation
        //   - For each number, insert it into every possible position of existing permutations
        //
        // Time complexity:  O(n * n!)
        // Space complexity: O(n * n!)
        //
        // Note: Any algorithm that enumerates all permutations has a lower bound of O(n!) time.
        //
        public static IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>
            {
                new List<int>(),
            };

            foreach (int num in nums)
            {
                var next = new List<IList<int>>();

                foreach (var perm in result)
                {
                    for (int i = 0; i <= perm.Count; i++)
                    {
                        var newPerm = new List<int>(perm);
                        newPerm.Insert(i, num);
                        next.Add(newPerm);
                    }
                }

                result = next;
            }

            result.Sort((a, b) =>
            {
                for (int i = 0; i < a.Count; i++)
                {
                    int cmp = a[i].CompareTo(b[i]);
                    if (cmp != 0)
                        return cmp;
                }

                return 0;
            });

            return result;
        }

        // 
        // The simplest solution to do in-place swap 
        //
        public static IList<IList<int>> Permute_Backtrack(int[] nums)
        { 
            var result = new List<IList<int>>();
            Backtrack(nums, 0, result);

            return result;
        }

        private static void Backtrack(int[] nums, int index, IList<IList<int>> result)
        {
            if (index == nums.Length)
            {
                result.Add(nums.ToList());
            }
            else
            {
                for (int i = index; i < nums.Length; i++)
                {
                    (nums[index], nums[i]) = (nums[i], nums[index]);
                    Backtrack(nums, i + 1, result);
                    (nums[index], nums[i]) = (nums[i], nums[index]); // backtrack
                }
            }
        }

        //
        // Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.
        //
        // *** Key ideas ***
        //   Backtracking approach:
        //     - Build permutations by adding one number at a time
        //     - Use a boolean array to track used numbers
        //
        // Time complexity:  O(n * n!)
        // Space complexity: O(n * n!)
        //
        // Difficulty: Medium
        //
        public static IList<IList<int>> Permute_Recursive(int[] numbers)
        {
            var result = new List<IList<int>>();
            Backtrack(numbers, new List<int>(), new bool[numbers.Length], result);
            return result;
        }

        //
        // Backtracking approach:
        //   - Build permutations by adding one number at a time
        //   - Use a boolean array to track used numbers
        //
        // Time complexity:  O(n * n!)
        // Space complexity: O(n * n!)
        //
        private static void Backtrack(int[] arr, List<int> current, bool[] used, IList<IList<int>> result)
        {
            // If current permutation is complete
            if (current.Count == arr.Length)
            {
                result.Add(new List<int>(current)); // add a copy
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (used[i]) continue; // skip already used arr

                // Choose
                used[i] = true;
                current.Add(arr[i]);

                // Explore
                Backtrack(arr, current, used, result);

                // Un-choose (backtrack)
                current.RemoveAt(current.Count - 1);
                used[i] = false;
            }
        }

        //
        // Given a collection of numbers, nums, that might contain duplicates, return
        // all possible unique permutations in any order.
        //
        // *** Key ideas ***
        //   Sort first to let duplicates become adjacent
        //   When inserting a number, stop after inserting past an identical value
        //
        public static IList<IList<int>> PermuteUnique(int[] nums)
        {
            var result = new List<IList<int>>
            {
                new List<int>(),
            };

            Array.Sort(nums);

            foreach (int num in nums)
            {
                var next = new List<IList<int>>();

                foreach (var perm in result)
                {
                    for (int pos = 0; pos <= perm.Count; pos++)
                    {
                        if (pos > 0 && perm[pos - 1] == num)
                        {
                            break;
                        }

                        var newPerm = new List<int>(perm);
                        newPerm.Insert(pos, num);
                        next.Add(newPerm);
                    }
                }

                result = next;
            }

            result.Sort((a, b) =>
            {
                for (int i = 0; i < a.Count; i++)
                {
                    int cmp = a[i].CompareTo(b[i]);

                    if (cmp != 0)
                        return cmp;
                }

                return 0;

            });

            return result;
        }
    }
}
