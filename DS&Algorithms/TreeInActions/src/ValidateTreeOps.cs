using TreeInActions.src.model;

namespace TreeInActions.src
{
    public class ValidateTreeOps
    {
        public static bool IsValidBST(TreeNode root)
        {
            if (root == null) return true;

            return IsValidBSTHelper(root, long.MinValue, long.MaxValue);
        }

        public static bool IsValidBSTHelper(TreeNode? node, long min, long max)
        {
            if (node == null) return true;
            if (node.val <= min || node.val >= max)
            {
                return false;
            }
            return IsValidBSTHelper(node.left, min, node.val) &&
                   IsValidBSTHelper(node.right, node.val, max);
        }
    }
}
