using NUnit.Framework;
using TreeInActions.src;
using TreeInActions.src.model;

namespace TreeInActions.UnitTests
{
    [TestFixture]
    public class BinaryTreeAncestorOpsTests
    {
        [Test]
        public void LowestCommonAncestor_Test()
        {
            var root = BuildTree();

            var lca1 = BinaryTreeAncestorOps.LowestCommonAncestor(root, root.left, root.right);

            Console.WriteLine($"LCA of {root.left.val} and {root.right.val}: {lca1.val}"); // Expected: 12

            var lca2 = BinaryTreeAncestorOps.LowestCommonAncestor(root, root.left, root.left.right.right);
            Console.WriteLine($"LCA of {root.left.val} and {root.left.right.right.val}: {lca2.val}"); // Expected: 9

            // Assertions
            Assert.That(lca1.val, Is.EqualTo(12));
            Assert.That(lca2.val, Is.EqualTo(9));
        }

        [Test]
        public void LowestCommonAncestor_Iterative_Test()
        {
            var root = BuildTree();

            var lca1 = BinaryTreeAncestorOps.LowestCommonAncestor_Iterative(root, root.left, root.right);

            Console.WriteLine($"LCA of {root.left.val} and {root.right.val}: {lca1.val}"); // Expected: 11

            var lca2 = BinaryTreeAncestorOps.LowestCommonAncestor_Iterative(root, root.left, root.left.right.right);
            Console.WriteLine($"LCA of {root.left.val} and {root.left.right.right.val}: {lca2.val}"); // Expected: 9

            // Assertions
            Assert.That(lca1.val, Is.EqualTo(12));
            Assert.That(lca2.val, Is.EqualTo(9));
        }

        private TreeNode BuildTree()
        {
            //
            //         12
            //       /    \
            //      9      15
            //     / \    /  \
            //    7  10  14   20
            //   / \   \       / \
            //  2   8  11     22 25
            //
            //
            var root = new TreeNode(12);

            root.left = new TreeNode(9);
            root.left.left = new TreeNode(7);
            root.left.left.left = new TreeNode(2);
            root.left.left.right = new TreeNode(8);
            root.left.right = new TreeNode(10);
            root.left.right.right = new TreeNode(11);

            root.right = new TreeNode(15);
            root.right.left = new TreeNode(14);
            root.right.right = new TreeNode(20);
            root.right.right.left = new TreeNode(22);
            root.right.right.right = new TreeNode(25);

            return root;
        }
    }
}
