using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src.model;

namespace TreeInActions.src.traverse
{
    public class InOrderTraverseOps
    {
        // left -> root -> right
        public static void InOrderTraversal_Recursive(TreeNode? root, List<TreeNode> res)
        {
            if (root == null) return;

            InOrderTraversal_Recursive(root.left, res);
            res.Add(root);
            InOrderTraversal_Recursive(root.right, res);
        }

        // Inorder tree trversal using STACK
        //
        // left -> root -> right
        //
        // Time Complexcity: O(N)
        // Space complexity: O(h) <-- O(LogN) for balanced tree, O(N) for skewed
        //
        public static IEnumerable<TreeNode> InOrderTraversal_Iterative(TreeNode? root)
        {
            if (root == null)
            {
                return [];
            }

            var result = new List<TreeNode>();
            var stack = new Stack<TreeNode>();
            TreeNode? current = root;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                current = stack.Pop();
                result.Add(current);

                current = current.right;
            }

            return result;
        }
    }
}
