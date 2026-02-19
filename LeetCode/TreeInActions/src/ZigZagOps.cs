using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src.model;

namespace TreeInActions.src
{
    public class ZigZagOps
    {
        // 
        // You are given the root of a binary tree.
        //
        // A ZigZag path for a binary tree is defined as follow:
        //   - Choose any node in the binary tree and a direction(right or left).
        //   - If the current direction is right, move to the right child of
        //     the current node; otherwise, move to the left child.
        //   - Change the direction from right to left or from left to right.
        //   - Repeat the second and third steps until you can't move in the tree.
        //
        //   Zigzag length is defined as the number of nodes visited - 1.
        //   (A single node has a length of 0).
        //
        //   Return the longest ZigZag path contained in that tree.
        //
        // LeetCode 1372: Longest ZigZag Path in a Binary Tree
        //
        // Time complexity:  O(N)
        // Space complexity: O(N)
        //
        public static int LongestZigZag(TreeNode node)
        {
            int length = 0;
            DFS(node, true, 0, ref length);

            return length;
        }

        private static void DFS(TreeNode? node, bool goLeft, int steps, ref int length)
        {
            if (node == null) return;

            length = Math.Max(length, steps);

            if (goLeft)
            {
                DFS(node.left, false, steps + 1, ref length);
                DFS(node.right, true, 1, ref length); // start over on the right side

            }
            else
            {
                DFS(node.right, true, steps + 1, ref length);
                DFS(node.left, false, 1, ref length); // start over on the left side
            }
        }
    }
}
