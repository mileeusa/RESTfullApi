using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src.model;

namespace TreeInActions.src.traverse
{
    public class LevelTraverseOps
    {
        //
        // binary tree traversal layer by layer (BFS)
        //
        public static IList<int> TreeTraversal_ByLevel(TreeNode? root)
        {
            IList<int> result = [];

            if (root == null)
                return result;

            Queue<TreeNode> queue = [];
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                result.Add(node.val);

                if (node.left != null)
                    queue.Enqueue(node.left);
            
                if (node.right != null)
                    queue.Enqueue(node.right);
            }

            return result;
        }

        //
        // binary tree traversal layer by layer (Queue)
        //
        public static IList<IList<int>> TreeTraversal_ByLayer(TreeNode? root)
        {
            IList<IList<int>> result = [];

            if (root == null)
                return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                List<int> currentLevel = [];

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode currentNode = queue.Dequeue();
                    currentLevel.Add(currentNode.val);

                    if (currentNode.left != null)
                        queue.Enqueue(currentNode.left);

                    if (currentNode.right != null)
                        queue.Enqueue(currentNode.right);
                }
                result.Add(currentLevel);
            }
            return result;
        }

        public static IList<IList<int>> LevelOrderBottom(TreeNode? root)
        {
            IList<IList<int>> level = TreeTraversal_ByLayer(root);

           return level.Reverse().ToList();
        }
    }
}
