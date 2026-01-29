using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src.model;
using TreeInActions.src;

namespace TreeInActions.UnitTests
{
    [TestFixture]
    public class InvertBSTOpsTests
    {
        [Test]
        public void InvertTree_Recursive_Test()
        {
            // arrange
            TreeNode? root = BuildSampleTree();

            var result = TraverseTree.TreeTraversal_ByLayer(root);

            foreach (var layer in result)
            {
                Console.WriteLine(string.Join(",", layer));
            }

            // act
            TreeNode? newNode = InvertBSTOps.InvertTree_Recursive(root);

            Console.WriteLine("\nInvertBSTOps.InvertTree =>\n");

            var newResult = TraverseTree.TreeTraversal_ByLayer(newNode);

            foreach (var layer in newResult)
            {
                Console.WriteLine(string.Join(",", layer));
            }

            // assert
            Assert.That(newNode, Is.Not.Null);
            Assert.That(newNode?.right?.val, Is.EqualTo(7));
        }

        [Test]
        public void InvertTree_Iterative_ByLevel_Test()
        {
            // arrange
            TreeNode? root = BuildSampleTree();

            var result = TraverseTree.TreeTraversal_ByLayer(root);

            foreach (var layer in result)
            {
                Console.WriteLine(string.Join(",", layer));
            }

            // act
            TreeNode? newNode = InvertBSTOps.InvertTree_Iterative_ByLevel(root);

            Console.WriteLine("\nInvertBSTOps.InvertTree_Iterative_ByLevel =>\n");

            var newResult = TraverseTree.TreeTraversal_ByLayer(newNode);

            foreach (var layer in newResult)
            {
                Console.WriteLine(string.Join(",", layer));
            }

            // assert
            Assert.That(newNode, Is.Not.Null);
            Assert.That(newNode?.right?.val, Is.EqualTo(7));
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
