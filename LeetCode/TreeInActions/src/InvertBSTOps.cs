using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src.model;

namespace TreeInActions.src
{
    public class InvertBSTOps
    {
        //
        // Invert Binary Tree is a traversal problem where the action is swapping left and right children at each node;
        // traversal order is irrelevant.
        //
        // LeetCode 226. Invert Binary Tree
        //
        // Dificulty: Easy
        //
        public static TreeNode? InvertTree_Recursive(TreeNode? root)
        {
            if (root == null)
            {
                return null;
            }

            // Swap the left and right children
            (root.right, root.left) = (root.left, root.right);

            // Recursively invert the left and right subtrees
            InvertTree_Recursive(root.left);
            InvertTree_Recursive(root.right);

            return root;
        }

        public static TreeNode? InvertTree_Iterative_ByLevel(TreeNode? root)
        {
            if (root == null)
            {
                return null;
            }

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode curr = queue.Dequeue();

                (curr.left, curr.right) = (curr.right, curr.left);

                if (curr.left != null)
                {
                    queue.Enqueue(curr.left);
                }

                if (curr.right != null)
                {
                    queue.Enqueue(curr.right);
                }
            }
            return root;
        }
    }
}
