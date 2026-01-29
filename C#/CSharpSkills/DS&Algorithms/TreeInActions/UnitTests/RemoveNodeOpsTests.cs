using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src;
using TreeInActions.src.model;

namespace TreeInActions.UnitTests
{
    [TestFixture]
    public class RemoveNodeOpsTests
    {
        [Test]
        public void DeleteNode_Test1()
        {
            // Arrange
            var root = new TreeInActions.src.model.TreeNode(9)
            {
                left = new TreeInActions.src.model.TreeNode(5),
                right = new TreeInActions.src.model.TreeNode(13)
            };

            // Act
            var updatedRoot = RemoveNodeOps.DeleteNode(root, 5);

            // Assert
            Assert.That(updatedRoot, Is.Not.Null);
            Assert.That(updatedRoot?.val, Is.EqualTo(9));
            Assert.That(updatedRoot?.left, Is.Null); // Node with value 5 should be deleted
            Assert.That(updatedRoot?.right?.val, Is.EqualTo(13));
        }


        [Test]
        public static void DeleteNode_Test2()
        {
            // arrange
            TreeNode root = new TreeNode(9);
            root.left = new TreeNode(5);
            root.right = new TreeNode(13);
            root.right.left = new TreeNode(11);
            root.right.right = new TreeNode(20);

            Console.WriteLine();
            Console.WriteLine("Using RemoveNodeOps.DeleteNode()");
            int keyToDelete = 13;
            var orgTree = TraverseTree.TreeTraversal_ByLayer(root);

            foreach (var layer in orgTree)
            {
                Console.WriteLine(string.Join(", ", layer));
            }
            Console.WriteLine();

            // act
            TreeNode? newRoot = RemoveNodeOps.DeleteNode(root, keyToDelete);

            // assert
            var result = TraverseTree.TreeTraversal_ByLayer(newRoot);
            foreach (var layer in result)
            {
                Console.WriteLine(string.Join(", ", layer));
            }
        }

        [Test]
        public static void DeleteNode_Test3()
        {
            // arrange
            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(2);
            root.right = new TreeNode(7);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(10);
            root.right.right.left = new TreeNode(9);
            root.right.right.right = new TreeNode(12);

            Console.WriteLine();
            Console.WriteLine("Using RemoveNodeOps.DeleteNode()");
            int keyToDelete = 7;
            var orgTree = TraverseTree.TreeTraversal_ByLayer(root);

            foreach (var layer in orgTree)
            {
                Console.WriteLine(string.Join(", ", layer));
            }
            Console.WriteLine();

            // act
            TreeNode? newRoot = RemoveNodeOps.DeleteNode(root, keyToDelete);

            // assert
            var result = TraverseTree.TreeTraversal_ByLayer(newRoot);
            foreach (var layer in result)
            {
                Console.WriteLine(string.Join(", ", layer));
            }
        }

        [Test]
        public static void DeleteNode_Test4()
        {
            // arrange
            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(3);
            root.left.left = new TreeNode(2);
            root.left.right = new TreeNode(4);
            root.right = new TreeNode(6);
            root.right.right = new TreeNode(7);

            Console.WriteLine();
            Console.WriteLine("Using RemoveNodeOps.DeleteNode()");
            int keyToDelete = 3;
            var orgTree = TraverseTree.TreeTraversal_ByLayer(root);

            foreach (var layer in orgTree)
            {
                Console.WriteLine(string.Join(", ", layer));
            }
            Console.WriteLine();

            // act
            TreeNode? newRoot = RemoveNodeOps.DeleteNode(root, keyToDelete);

            // assert
            var result = TraverseTree.TreeTraversal_ByLayer(newRoot);
            foreach (var layer in result)
            {
                Console.WriteLine(string.Join(", ", layer));
            }
        }
    }
}
