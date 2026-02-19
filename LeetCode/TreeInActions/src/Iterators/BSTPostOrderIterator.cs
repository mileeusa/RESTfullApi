using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src.model;

namespace TreeInActions.src.Iterators
{
    public class BSTPostOrderIterator
    {
        private Stack<TreeNode> stack = new Stack<TreeNode>();
        private TreeNode? current;
        private TreeNode? lastVisited = null;


        public BSTPostOrderIterator(TreeNode? root)
        {
            this.current = root;
        }

        public bool HasNext()
        {
            return current != null || stack.Count > 0;
        }

        public int Next()
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.left;
            }

            var peek = stack.Peek();
            if (peek.right != null || peek.right != lastVisited)
            {
                current = peek.right;
                return Next();
            }

            stack.Pop();
            lastVisited = peek;

            return peek.val;
        }
    }
}
