using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src.model;

namespace TreeInActions.src.Iterators
{
    public class BSTPreOrderIterator
    {
        private Stack<TreeNode> stack = new Stack<TreeNode>();

        public BSTPreOrderIterator(TreeNode root)
        {
            if (root != null)
                stack.Push(root);
        }

        public bool HasNext()
        {
            return stack.Count > 0;
        }

        public int Next()
        {
            var node = stack.Pop();
            if (node.right != null)
                stack.Push(node.right);

            if (node.left != null)
                stack.Push(node.left);

            return node.val;
        }
    }
}
