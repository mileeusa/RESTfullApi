using NUnit.Framework;
using TreeInActions.src;
using TreeInActions.src.model;

namespace TreeInActions.UnitTests
{
    [TestFixture]
    public class BalanceOpsTests
    {
        [Test]
        public void IsBalanced_TestOne()
        {
            /*
                 15
               /    \
              9      17
                     /  \
                    15   20
            */

            // arrange
            var root = new TreeNode(15);
            root.left = new TreeNode(9);
            root.right = new TreeNode(17);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(20);

            // act
            bool result = TreeInActions.src.BalanceOps.IsBalanced(root);
            Console.WriteLine($"Is tree balanced: {result}");

            // assert
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void IsBalanced_TestTwo()
        {
            /*
                 15
               /    \
              9      17
                     /  \
                    15   20
                          \
                            25
            */

            // arrange
            var root = new TreeNode(15);
            root.left = new TreeNode(9);
            root.right = new TreeNode(17);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(20);
            root.right.right.right = new TreeNode(25);

            // act
            bool result = TreeInActions.src.BalanceOps.IsBalanced(root);
            Console.WriteLine($"Is tree balanced: {result}");

            // assert
            Assert.That(result, Is.EqualTo(false));
        }
    }
}
