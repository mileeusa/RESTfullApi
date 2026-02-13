using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src.model;

namespace TreeInActions.src.Iterators
{
    //
    // LeetCode 173. Binary Search Tree Iterator
    //
    // Time complexity:  O(1) amortized per call
    // Space complexity: O(H) hight of tree
    //
    // Highlight: A tree iterator replaces recursion with an explicit
    // stack or queue to preserve traversal state across calls,
    // allowing amortized O(1) Next() while keeping space
    // proportional to tree height
    //
    public class BSTInOrderIterator
    {
        private TreeNode current;
        private Stack<TreeNode> stack = new Stack<TreeNode>();

        public BSTInOrderIterator(TreeNode root)
        {
            current = root;
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

            var node = stack.Pop();
            current = node.right;

            return node.val;
        }
    }
}
