using TreeInActions.src.model;

namespace TreeInActions.src
{
    public class MaxDepthOps
    {
        public static int MaxDepthDPS(TreeNode? root)
        {
            if (root == null)
            {
                return 0;                
            }

            return 1 + Math.Max(MaxDepthDPS(root.left), MaxDepthDPS(root.right));
        }

        // Breadth-First Search (BFS)
        public static int MaxDepthBFS(TreeNode? root)
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
                int levelSize = queue.Count;
                depth++;

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode currentNode = queue.Dequeue();
                    if (currentNode.left != null)
                        queue.Enqueue(currentNode.left);
                    
                    if (currentNode.right != null)
                        queue.Enqueue(currentNode.right);
                }
            }
            return depth;
        }
    }
}
