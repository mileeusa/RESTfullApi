using TreeInActions.src.model;

namespace TreeInActions.src
{
    public class PathFromRootSumOps
    {
        public static bool HasPathSum(TreeNode? root, int targetSum)
        {
            if (root == null)
            {
                return false;
            }

            if (root.left == null && root.right == null)
            {
                return targetSum == root.val;
            }

            int newTargetSum = targetSum - root.val;

            return HasPathSum(root.left, newTargetSum) || HasPathSum(root.right, newTargetSum);
        }
        
        public static List<List<int>> PathSumAll(TreeNode? root, int targetSum)
        {
            List<List<int>> result = new List<List<int>>();
            PathSumAllHelper(root, targetSum, new List<int>(), result);
            return result;
        }

        private static void PathSumAllHelper(TreeNode? node, int targetSum, List<int> currentPath, List<List<int>> result)
        {
            if (node == null)
            {
                return;
            }
            currentPath.Add(node.val);
            if (node.left == null && node.right == null && targetSum == node.val)
            {
                result.Add(new List<int>(currentPath));
            }
            else
            {
                int newTargetSum = targetSum - node.val;
                PathSumAllHelper(node.left, newTargetSum, currentPath, result);
                PathSumAllHelper(node.right, newTargetSum, currentPath, result);
            }
            currentPath.RemoveAt(currentPath.Count - 1);
        }

        public static int MaxPathSum(TreeNode? root)
        {
            if (root == null)
            {
                return 0;
            }

            int maxSum = int.MinValue;

            MaxPathSumHelper(root, ref maxSum);

            return maxSum;
        }

        private static int MaxPathSumHelper(TreeNode? node, ref int maxSum)
        {
            if (node == null)
            {
                return 0;
            }
            int leftMax = Math.Max(0, MaxPathSumHelper(node.left, ref maxSum));
            int rightMax = Math.Max(0, MaxPathSumHelper(node.right, ref maxSum));

            int currentMax = node.val + leftMax + rightMax;
            maxSum = Math.Max(maxSum, currentMax);

            int max = Math.Max(leftMax, rightMax);

            return (max > 0) ? node.val + max : node.val;
        }

        public static int MaxPathSum_Iterative(TreeNode? root)
        {
            if (root == null) return 0;

            int maxSum = int.MinValue;

            // To simulate postorder traversal
            var stack = new Stack<TreeNode>();
            var visited = new HashSet<TreeNode>();

            // Stores upward gain for each node
            var upwardSum = new Dictionary<TreeNode, int>();

            stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Peek();

                // First time we see the node → push children
                if (!visited.Contains(node))
                {
                    visited.Add(node);
                    if (node.right != null) stack.Push(node.right);
                    if (node.left != null) stack.Push(node.left);
                    continue;
                }

                // Now children are processed → pop and compute values
                stack.Pop();

                int leftGain = node.left != null ? Math.Max(0, upwardSum[node.left]) : 0;
                int rightGain = node.right != null ? Math.Max(0, upwardSum[node.right]) : 0;

                // Path through current node
                int currentMax = node.val + leftGain + rightGain;
                maxSum = Math.Max(maxSum, currentMax);

                // Gain for parent: choose the better child
                upwardSum[node] = node.val + Math.Max(leftGain, rightGain);
            }

            return maxSum;
        }
    }
}
