using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src.model;

namespace TreeInActions.src.traverse
{
    public class PreOrderTraverseOps
    {
        // Preorder tree trversal using STACK
        //
        // root -> left -> right
        //
        public static IList<TreeNode> PreOrderTraverse_Iterative(TreeNode? root)
        {
            List<TreeNode> result = [];

            if (root == null)
            {
                return result;
            }

            var stack = new Stack<TreeNode>(); ;
            stack.Push(root);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                result.Add(current);

                if (current.right != null)
                    stack.Push(current.right);

                if (current.left != null)
                    stack.Push(current.left);
            }

            return result;
        }

        // root -> left -> right
        public static void PreOrderTraversal_Recursive(TreeNode? root, List<int> result)
        {
            if (root == null) return;

            result.Add(root.val);
            PreOrderTraversal_Recursive(root.left, result);
            PreOrderTraversal_Recursive(root.right, result);
        }
    }
}
