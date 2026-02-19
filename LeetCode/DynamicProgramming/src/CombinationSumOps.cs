using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DynamicProgrammingInActions.src
{
    public class CombinationSumOps
    {
        // 
        // Find all valid combinations of k numbers that sum up to n such that the
        // following conditions are true:
        //
        // -- Only numbers 1 through 9 are used.
        // -- Each number is used at most once.
        //
        // Return a list of all possible valid combinations. The list must not
        // contain the same combination twice, and the combinations may be
        // returned in any order.
        //
        // LeetCode 216: Combination Sum III
        //
        // Time complexity:  O(C(9, k)) <-- C(9, k) = 9! / (k! * (9 - k)!)
        // Space complexity: O(k)
        // 
        // Difficulty: Medium
        //
        public static IList<IList<int>> CombinationSum3(int k, int n)
        {
            var result = new List<IList<int>>();
            Backtrack(1, k, n, new List<int>(), result);
            return result;
        }

        private static void Backtrack(int start, int k, int remaining, List<int> path, IList<IList<int>> result)
        {
            if (path.Count == k && remaining == 0)
            {
                result.Add(new List<int>(path));
                return;
            }

            if (path.Count >= k || remaining < 0)
            {
                return;
            }

            if (remaining < k - path.Count)
            {
                return;
            }

            for (int i = start; i <= 9; i++)
            {
                path.Add(i);
                Backtrack(i + 1, k, remaining - i, path, result);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
