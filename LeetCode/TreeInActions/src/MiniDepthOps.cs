using TreeInActions.src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeInActions.src
{
    public class MiniDepthOps
    {
        public static int MinDepthDPS(TreeNode? root)
        {
            if (root == null) return 0;

            if (root.left == null && root.right == null)
            {
                return 1;
            }

            if (root.left == null)
            {
                return MinDepthDPS(root.right) + 1;
            }

            if (root.right == null)
            {
                return MinDepthDPS(root.left) + 1;
            }


            return Math.Min(MinDepthDPS(root.left), MinDepthDPS(root.right)) + 1;
        }

        public static int MinDepthBFS(TreeNode? root)
        {
            if (root == null)
            {
                return 0;                
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int depth = 0;

            while (queue.Count > 0)
            {
                int levelSize = queue.Count();
                depth++;
                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode treeNode = queue.Dequeue();
                    if (treeNode.left == null && treeNode.right == null)
                        return depth;
                    
                    if (treeNode.left == null)
                    {
                        queue.Enqueue(treeNode.right);
                    }
                    else if (treeNode.right == null)
                    {
                        queue.Enqueue(treeNode.left);
                    }
                    else
                    {
                        queue.Enqueue(treeNode.left);
                        queue.Enqueue(treeNode.right);
                    }
                }
            }

            return depth;
        }

        public static int MinDepthBFS_2(TreeNode? root)
        {
            if (root == null)
            {
                return 0;
            }

            Queue<(TreeNode, int)> queue = new Queue<(TreeNode, int)>();
            queue.Enqueue((root, 1));

            while (queue.Count > 0)
            {
                (TreeNode node, int currentDepth) = queue.Dequeue();

                if (node.left == null && node.right == null)
                {
                    return currentDepth;
                }
                else if (node.left == null)
                {
                    queue.Enqueue((node.right, currentDepth + 1));
                }
                else if (node.right == null)
                {
                    queue.Enqueue((node.left, currentDepth + 1));
                }
                else
                {
                    queue.Enqueue((node.left, currentDepth + 1));
                    queue.Enqueue((node.right, currentDepth + 1));
                }
            }

            return 0;

        }
    }
}
