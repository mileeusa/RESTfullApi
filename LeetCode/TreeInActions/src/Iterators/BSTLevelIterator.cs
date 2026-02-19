using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src.model;

namespace TreeInActions.src.Iterators
{
    public class BSTLevelIterator
    {
        private Queue<TreeNode> queue = new Queue<TreeNode>();

        public BSTLevelIterator(TreeNode root) 
        {
            queue.Enqueue(root);
        }

        public bool HasNext()
        {
            return queue.Count > 0;
        }

        public int Next()
        {
            var node = queue.Dequeue();

            if (node.left != null)
                queue.Enqueue(node.left);

            if (node.right != null)
                queue.Enqueue(node.right);

            return node.val;              
        }
    }
}
