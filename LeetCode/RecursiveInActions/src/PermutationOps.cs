using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveInActions.src
{
    public class PermutationOps
    {
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
    }
}
