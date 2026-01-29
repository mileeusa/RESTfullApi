using FluentAssertions;
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
    public class TraverseTreeTests
    {
        [Test]
        public void PreOrderTraversal_Iterative_Test()
        {
            // arrange
            TreeNode? root = BuildSampleTree();
            Console.WriteLine();
            Console.WriteLine("Using TraverseTree.PreorderTraverseIterative()");

            // act
            var result = TraverseTree.PreOrderTraverse_Iterative(root);

            // assert
            var nodeValues = result.Select(x => x.val).ToArray();
            Console.WriteLine(string.Join(", ", nodeValues));
            Assert.That(nodeValues[0], Is.EqualTo(10));
        }

        [Test]
        public void PreOrderTraversal_Recurdive_Test()
        {
            // arrange
            TreeNode? root = BuildSampleTree();
            Console.WriteLine();
            Console.WriteLine("Using TraverseTree.PreOrderTraverseRecursive()");

            // act
            var result = new List<int>();
            TraverseTree.PreOrderTraversal_Recursive(root, result);

            // assert
            var nodeValues = result.Select(x => x).ToArray();
            Console.WriteLine(string.Join(", ", nodeValues));
            Assert.That(nodeValues[0], Is.EqualTo(10));
        }

        [Test]
        public static void InOrderTraversal_Iterative_Test()
        {
            // arrange
            TreeNode? root = BuildSampleTree();
            Console.WriteLine();
            Console.WriteLine("Using TraverseTree.InOrderTraversal_Iterative()");

            // act
            var result = TraverseTree.InOrderTraversal_Iterative(root);

            // assert
            var nodeValues = result.Select(x => x.val).ToArray();
            Console.WriteLine(string.Join(", ", nodeValues));
            Assert.That(nodeValues[0], Is.EqualTo(5));
        }

        [Test]
        public void PostOrderTraversal_Iterative_Test()
        {
            // arrange
            TreeNode? root = BuildSampleTree();
            Console.WriteLine();
            Console.WriteLine("Using TraverseTree.PostOrderTraversal_Iterative()");
            
            // act
            var result = TraverseTree.PostOrderTraversal_Iterative(root);

            // assert
            var nodeValues = result.Select(x => x.val).ToArray();
            Console.WriteLine(string.Join(", ", nodeValues));
            Assert.That(nodeValues[0], Is.EqualTo(5));
        }

        [Test]
        public static void TreeTraversal_ByLayer_Test()
        {
            // arrange
            TreeNode? root = BuildSampleTree();

            // act
            Console.WriteLine();
            Console.WriteLine("Using RetrieveNodeOps.TreeTraversal_ByLayer()");
            var result = TraverseTree.TreeTraversal_ByLayer(root);

            // assert
            foreach (var layer in result)
            {
                Console.WriteLine(string.Join(", ", layer));
            }

            result[0][0].Should().Be(10);
        }

        [Test]
        public static void TreeTraversal_ByLevel_Test()
        {
            // arrange
            TreeNode root = BuildSampleTree();

            // act
            Console.WriteLine();
            Console.WriteLine("Using RetrieveNodeOps.TreeTraversal_ByLevel()");
            var result = TraverseTree.TreeTraversal_ByLevel(root);

            // assert
            Console.WriteLine(string.Join(", ", result));

            result[0].Should().Be(10);
        }

        //
        //         10
        //       /    \ 
        //      7     15
        //     / \    / \
        //    5   9  12  17
        //
        private static TreeNode? BuildSampleTree()
        {
            TreeNode root = new TreeNode(10);
            root.left = new TreeNode(7);
            root.left.left = new TreeNode(5);
            root.left.right = new TreeNode(9);
            root.right = new TreeNode(15);
            root.right.left = new TreeNode(12);
            root.right.right = new TreeNode(17);

            return root;
        }
    }
}
