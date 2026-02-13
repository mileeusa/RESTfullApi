using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src.model;

namespace TreeInActions.src.traverse
{
    public class PostOrderTraverseOps
    {
        // left -> right -> root
        public static void PostOrderTraversal_Recursive(TreeNode? root, List<int> res)
        {
            if (root == null) return;

            PostOrderTraversal_Recursive(root.left, res);
            PostOrderTraversal_Recursive(root.right, res);
            res.Add(root.val);
        }

        //
        // We want to generate postorder:
        //
        //   Left → Right → Root
        //
        // But iteratively and with only one stack.
        //
        // This is the trickiest DFS traversal because you must process a node only after its left and
        // right subtrees are fully processed.
        //
        public static IList<TreeNode> PostOrderTraversal_Iterative(TreeNode? root)
        {
            List<TreeNode> result = [];

            if (root == null)
            {
                return result;
            }

            Stack<TreeNode> stack = [];
            TreeNode? current = root;
            TreeNode? prev = null;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }

                var node = stack.Peek();

                if (node.right == null || node.right == prev)
                {
                    stack.Pop();
                    result.Add(node);
                    prev = node;
                }
                else
                {
                    current = node.right;
                }
            }

            return result;
        }

    }
}
