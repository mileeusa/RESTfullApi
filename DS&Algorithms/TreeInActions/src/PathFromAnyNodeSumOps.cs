using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src.model;

namespace TreeInActions.src
{
    public class PathFromAnyNodeSumOps
    {
        //
        // Given the root of a binary tree and an integer targetSum, return
        // the number of paths where the sum of the values along the path
        // equals targetSum.
        //
        // The path does not need to start or end at the root or a leaf,
        // but it must go downwards(i.e., traveling only from parent
        // nodes to child nodes).
        //
        // LeetCode 437. Path Sum III
        //
        // Time complexity:  O(N^2)
        // Space complexity: O(1)
        //
        public static int PathSum(TreeNode root, int targetSum)
        {
            if (root == null) return 0;

            return CountFrom(root, targetSum) +
                   PathSum(root.left, targetSum) +
                   PathSum(root.right, targetSum);
        }

        private static int CountFrom(TreeNode root, long target)
        {
            if (root == null) return 0;

            int count = 0;

            if (root.val == target) count++;

            count += CountFrom(root.left, target - root.val);
            count += CountFrom(root.right, target - root.val);

            return count;
        }

        public static int PathSum_DFS_Prefix(TreeNode root, int targetSum)
        {
            var prefixCount = new Dictionary<long, int>();
            prefixCount[0] = 1; // base case: empty path

            return DFS(root, 0, targetSum, prefixCount);
        }

        private static int DFS(
            TreeNode node,
            long currentSum,
            int target,
            Dictionary<long, int> prefixCount)
        {
            if (node == null) return 0;

            currentSum += node.val;

            // number of valid paths ending at this node
            int result = 0;
            if (prefixCount.TryGetValue(currentSum - target, out int count))
            {
                result += count;
            }

            // add current prefix sum
            prefixCount[currentSum] =
                prefixCount.GetValueOrDefault(currentSum, 0) + 1;

            // recurse
            result += DFS(node.left, currentSum, target, prefixCount);
            result += DFS(node.right, currentSum, target, prefixCount);

            // backtrack
            prefixCount[currentSum]--;
            if (prefixCount[currentSum] == 0)
                prefixCount.Remove(currentSum);

            return result;
        }
    }
}
