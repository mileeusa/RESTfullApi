using TreeInActions.src.model;

namespace TreeInActions.src
{
    public class DiameterOrDistanceOps
    {
        public static int DiameterOfBinaryTree(TreeNode? root)
        {
            int diameter = 0;
            Depth(root, ref diameter);
            return diameter;
        }

        public static int Depth(TreeNode? node, ref int diameter)
        {
            if (node == null)
            {
                return 0;
            }
            int leftDepth = Depth(node.left, ref diameter);
            int rightDepth = Depth(node.right, ref diameter);
            diameter = Math.Max(diameter, leftDepth + rightDepth);

            return Math.Max(leftDepth, rightDepth) + 1;
        }

        //
        // Time complexity: O(N)
        // Space complexity: O(h) where h is the height of the tree
        //
        public static int DistanceBetweenNodes(TreeNode? root, TreeNode? p, TreeNode? q)
        {
            if (root == null || p == null || q == null)
            {
                return -1;
            }
            TreeNode? lca = BinaryTreeAncestorOps.LowestCommonAncestor(root, p, q);
            if (lca == null)
            {
                return -1;
            }
            int distanceP = DistanceFromAncestor(lca, p);
            int distanceQ = DistanceFromAncestor(lca, q);
            return distanceP + distanceQ;
        }

        public static int DistanceFromAncestor(TreeNode? ancestor, TreeNode? node)
        {
            if (ancestor == null)
            {
                return -1;
            }
            if (ancestor == node)
            {
                return 0;
            }
            int leftDistance = DistanceFromAncestor(ancestor.left, node);
            if (leftDistance != -1)
            {
                return leftDistance + 1;
            }
            int rightDistance = DistanceFromAncestor(ancestor.right, node);
            if (rightDistance != -1)
            {
                return rightDistance + 1;
            }
            return -1;
        }

        public static int DistanceBetweenNodes_DFS(TreeNode? root, TreeNode? p, TreeNode? q)
        {
            Dfs(root, p, q, out var result);

            return result;
        }

        private static int Dfs(TreeNode? node, TreeNode? p, TreeNode? q, out int result)
        {
            result = -1;

            if (node == null)
            {
                return -1;
            }

            int left  = Dfs(node.left, p, q, out int leftResult);
            int right = Dfs(node.right, p, q, out int rightResult);

            if (node == p || node == q)
            {
                if (left >= 0)
                {
                    result = left + 1;
                }
                else if (right >= 0)
                {
                    result = right + 1;
                }
                return 0;
            }

            if (left >= 0 && right >= 0)
            {
                result = left + right + 2;
                return -1;
            }

            if (left >= 0)
            {
                result = left + 1;
                return 0;
            }

            if (right >= 0)
            {
                result = right + 1;
                return 0;
            }

            return -1;
        }
    }
}
