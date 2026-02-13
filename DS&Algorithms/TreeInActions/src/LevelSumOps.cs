using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src.model;

namespace TreeInActions.src
{
    public class LevelSumOps
    {
        // Given the root of a binary tree, the level of its root is 1, the level of its children is 2, and so on.
        //
        // Return the smallest level x such that the sum of all the values of nodes at level x is maximal.
        //
        public static (int, int) MaxLevelSum(TreeNode root)
        {
            if (root == null) return (0, 0);

            int maxSum = Int32.MinValue;
            int maxLevel = 0;
            int currLevel = 0;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int cnt = queue.Count;
                currLevel++;

                int levelSum = 0;
                for (int i = 0; i < cnt; i++)
                {
                    var curr = queue.Dequeue();
                    levelSum += curr.val;

                    if (curr.left != null)
                        queue.Enqueue(curr.left);

                    if (curr.right != null)
                        queue.Enqueue(curr.right);
                }

                if (levelSum > maxSum)
                {
                    maxSum = levelSum;
                    maxLevel = currLevel;
                }
            }

            return (maxLevel, maxSum);
        }
    }
}
