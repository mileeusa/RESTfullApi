using NUnit.Framework;
using TreeInActions.src;
using TreeInActions.src.model;

namespace TreeInActions.UnitTests
{
    [TestFixture]
    public class MaxDepthOpsTests
    {
        [Test]
        public static void MaxDepthDPS_Test()
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);

            int maxDepth = MaxDepthOps.MaxDepthDPS(root);
            Console.WriteLine();
            Console.WriteLine("BinaryTreeInActions.MaxDepthOps.MaxDepthDPS");
            Console.WriteLine($"Maximum depth of the binary tree: {maxDepth}"); // Output: 3

            Assert.That(maxDepth, Is.EqualTo(3));
        }

        [Test]
        public static void MaxDepthBFS_Test()
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            int maxDepth = MaxDepthOps.MaxDepthBFS(root);
            Console.WriteLine();
            Console.WriteLine("BinaryTreeInActions.MaxDepthOps.MaxDepthBFS");
            Console.WriteLine($"Maximum depth of the binary tree: {maxDepth}"); // Output: 3
        }
    }
}
