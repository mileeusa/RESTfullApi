using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StringInActions.src
{
    public class DeletionOps
    {
        //
        // You are given a string s of length n and an integer array cost of the same length,
        // where cost[i] is the cost to delete the ith character of s.
        //
        // You may delete any number of characters from s(possibly none), such that the
        // resulting string is non-empty and consists of equal characters.
        //
        // Return an integer denoting the minimum total deletion cost required.

        // LeetCode 3784. Minimum Deletion Cost to Make All Characters Equal
        //
        // Time complexity: O(N)
        // Space compexity: O(1)
        //
        // Key Insight
        //   To minimize deletion cost, think in terms of what to keep instead of what to delete.
        //   Since the final string must contain only one character type:
        //   If you choose to keep all occurrences of character 'c', then:
        //     You must delete all other characters
        //     The cost = total cost of all characters except 'c'
        //     i.e., deletion cost = totalCost − costSumOf('c')
        //
        //   So the optimal solution is to:
        //     Calculate the total cost of all characters
        //     For each character type(like 'a', 'b', …), compute the total deletion cost if we keep that character
        //
        //     Return the minimum of these deletion costs
        //
        //     This is equivalent to keeping the character with the largest total cost and deleting everything else
        //
        public static long MinCost(string s, int[] cost)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 0 || cost == null || cost.Length == 0)
                return 0;

            int n = s.Length;
            var costPerChar = new int[26];
            long totcalCost = 0;

            for (int i = 0; i < n; i++)
            {
                costPerChar[s[i] - 'a'] += cost[i];
                totcalCost += cost[i];
            }

            long maxCostToKeep = 0;
            for (int i = 0; i < 26; i++)
            {
                maxCostToKeep = Math.Max(maxCostToKeep, costPerChar[i]);
            }

            return totcalCost - maxCostToKeep;
        }
    }
}
