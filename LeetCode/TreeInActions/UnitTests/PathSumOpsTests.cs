using NUnit.Framework;
using TreeInActions.src;
using TreeInActions.src.model;

namespace TreeInActions.UnitTests
{
    [TestFixture]
    public class PathSumOpsTests
    {
        [Test]
        public static void PathSum_Test()
        {
            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(4);
            root.right = new TreeNode(8);
            root.left.left = new TreeNode(11);
            root.left.left.left = new TreeNode(7);
            root.left.left.right = new TreeNode(2);
            root.right.left = new TreeNode(13);
            root.right.right = new TreeNode(4);
            root.right.right.right = new TreeNode(1);
            int targetSum = 22;
            bool hasPathSum = PathFromRootSumOps.HasPathSum(root, targetSum);
            Console.WriteLine();
            Console.WriteLine("BinaryTreeInActions.PathSumOps.HasPathSum");
            Console.WriteLine($"Tree has path sum {targetSum}: {hasPathSum}"); // Output: True
        }

        [Test]
        public static void PathSumAll_Test()
        {
            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(4);
            root.right = new TreeNode(8);
            root.left.left = new TreeNode(11);
            root.left.left.left = new TreeNode(7);
            root.left.left.right = new TreeNode(2);
            root.right.left = new TreeNode(13);
            root.right.right = new TreeNode(4);
            root.right.right.right = new TreeNode(1);
            int targetSum = 22;
            List<List<int>> allPaths = PathFromRootSumOps.PathSumAll(root, targetSum);
            Console.WriteLine();
            Console.WriteLine("BinaryTreeInActions.PathSumOps.PathSumAll");
            Console.WriteLine($"All root-to-leaf paths with sum {targetSum}:");
            foreach (var path in allPaths)
            {
                Console.WriteLine(string.Join(" -> ", path));
            }
        }

        [Test]
        public static void PathSumAll_Test_2()
        {
            TreeNode root = new TreeNode(10);
            root.left = new TreeNode(5);
            root.right = new TreeNode(-3);
            root.left.left = new TreeNode(3);
            root.left.left.left = new TreeNode(3);
            root.left.left.right = new TreeNode(-2);
            root.left.right = new TreeNode(2);
            root.left.right.left = new TreeNode(1);
            root.right.left = new TreeNode(11);
            int targetSum = 8;

            List<List<int>> allPaths = PathFromRootSumOps.PathSumAll(root, targetSum);
            Console.WriteLine();
            Console.WriteLine("BinaryTreeInActions.PathSumOps.PathSumAll");
            Console.WriteLine($"All root-to-leaf paths with sum {targetSum}:");
            foreach (var path in allPaths)
            {
                Console.WriteLine(string.Join(" -> ", path));
            }
        }

        [Test]
        public static void MaxPathSum_Test()
        {
            TreeNode root = new TreeNode(-10);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);

            root.right.right = new TreeNode(7);
            int maxPathSum = PathFromRootSumOps.MaxPathSum(root);

            Console.WriteLine();
            Console.WriteLine("BinaryTreeInActions.PathSumOps.MaxPathSum");
            Console.WriteLine($"Maximum path sum of the binary tree: {maxPathSum}"); // Output: 42

            Assert.That(maxPathSum, Is.EqualTo(42));
        }

        [Test]
        public static void MaxPathSum_Iterative_Test()
        {
            TreeNode root = new TreeNode(-10);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);

            root.right.right = new TreeNode(7);
            int maxPathSum = PathFromRootSumOps.MaxPathSum_Iterative(root);

            Console.WriteLine();
            Console.WriteLine("BinaryTreeInActions.PathSumOps.MaxPathSum_Iterative");
            Console.WriteLine($"Maximum path sum of the binary tree: {maxPathSum}"); // Output: 42

            Assert.That(maxPathSum, Is.EqualTo(42));
        }
    }
}
