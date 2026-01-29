using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src.model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TreeInActions.src
{
    public class SearchOps
    {
        public static TreeNode? SearchBST(TreeNode? root, int val)
        {
            while (root != null)
            {
                if (root.val == val)
                {
                    return root;
                }
                else
                {
                    root = val < root.val ? root.left : root.right;
                }
            }

            return null;
        }

        // 
        // Given a binary tree root, a node X in the tree is named good if
        // in the path from root to X there are no nodes with a value
        // greater than X.
        //
        // Return the number of good nodes in the binary tree.
        // 
        // LeetCode: 1448 Count Good Nodes in Binary Tree
        //
        // Time:  O(N)
        // Space: O(N) - worst case
        //
        public static int GoodNodes(TreeNode? root)
        {
            if (root == null) return 0;
            if (root.left == null && root.right == null) return 1;

            int numGoodNodes = 0;
            DFS(root, int.MinValue, ref numGoodNodes);
            return numGoodNodes;
        }

        public static void DFS(TreeNode? node, int maxSofar, ref int numGoodNodes)
        {
            if (maxSofar <= node.val)
                numGoodNodes++;

            if (node.left != null)  DFS(node.left,  Math.Max(maxSofar, node.val), ref numGoodNodes);
            if (node.right != null) DFS(node.right, Math.Max(maxSofar, node.val), ref numGoodNodes);
        }
    }
}
