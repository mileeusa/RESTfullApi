using NUnit.Framework.Internal.Execution;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class PermutationOps
    {
        // Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.
        //
        // *** Key ideas ***
        //   Backtracking approach:
        //     - Build permutations by adding one number at a time
        //     - Use a boolean array to track used numbers
        //
        // Time: O(n * n!)
        // Space: O(n * n!)
        //
        // Difficulty: Medium
        //
        public static IList<IList<int>> Permute(int[] numbers)
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
        // Time:  O(n * n!)
        // Space: O(n * n!)
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
        // Build permutations step by step:
        //   - Start with an empty permutation
        //   - For each number, insert it into every possible position of existing permutations
        //
        // Time:  O(n * n!)
        // Space: O(n * n!)
        //
        // Note: Any algorithm that enumerates all permutations has a lower bound of O(n!) time.
        //
        public static IList<IList<int>> Permute_Iterative(int[] nums)
        {
            var result = new List<IList<int>>
            {
                new List<int>(),
            };

            foreach (int num in nums)
            {
                int count = result.Count;
                for (int i = 0; i < count; i++)
                {
                    var oldPerm = result[0];
                    result.RemoveAt(0);

                    for (int pos = 0; pos <= oldPerm.Count; pos++)
                    {
                        var newPerm = new List<int>(oldPerm);
                        newPerm.Insert(pos, num);
                        result.Add(newPerm);
                    }
                }
            }

            return result;
        }

        // Given a collection of numbers, nums, that might contain duplicates, return
        // all possible unique permutations in any order.
        //
        // *** Key ideas ***
        //   Sort first to let duplicates become adjacent
        //   When inserting a number, stop after inserting past an identical value
        //
        public static IList<IList<int>> PermuteUnique_Iterative(int[] nums)
        {
            var result = new List<IList<int>>
            {
                new List<int>(),
            };

            foreach (int num in nums)
            {
                int count = result.Count;
                for (int i = 0; i < count; i++)
                {
                    var oldPerm = result[0];
                    result.RemoveAt(0);

                    for (int pos = 0; pos <= oldPerm.Count; pos++)
                    {
                        if (pos > 0 && oldPerm[pos - 1] == num)
                        {
                            break;
                        }

                        var newPerm = new List<int>(oldPerm);
                        newPerm.Insert(pos, num);
                        result.Add(newPerm);
                    }
                }
            }

            return result;
        }
    }
}
