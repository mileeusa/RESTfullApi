using TreeInActions.src;
using TreeInActions.src.model;

namespace TreeInActions.UnitTests
{
    public class MiniDepthOpsTests
    {
        public static void MinDepthDPS_Test()
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            int minDepth = MiniDepthOps.MinDepthDPS(root);
            Console.WriteLine();
            Console.WriteLine("BinaryTreeInActions.MiniDepthOps.MinDepthDPS");
            Console.WriteLine($"Minimum depth of the binary tree: {minDepth}"); // Output: 2
        }
        
        public static void MinDepthBFS_Test()
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            int minDepth = MiniDepthOps.MinDepthBFS(root);
            Console.WriteLine();
            Console.WriteLine("BinaryTreeInActions.MiniDepthOps.MinDepthBFS");
            Console.WriteLine($"Minimum depth of the binary tree: {minDepth}"); // Output: 2
        }

        public static void MinDepthBFS_2_Test()
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            int minDepth = MiniDepthOps.MinDepthBFS_2(root);
            Console.WriteLine();
            Console.WriteLine("BinaryTreeInActions.MiniDepthOps.MinDepthBFS");
            Console.WriteLine($"Minimum depth of the binary tree: {minDepth}"); // Output: 2
        }
    }
}

