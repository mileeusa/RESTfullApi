using Microsoft.Testing.Platform.Extensions.Messages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src;
using TreeInActions.src.model;

namespace TreeInActions.UnitTests
{
    [TestFixture]
    public class TreeSerializationOpsTests
    {
        [Test]
        public void SerializeTree_ByLevel_Test()
        {
            // serialization //
            //
            // arrange
            TreeNode? root = BuildSampleTree();
            var result = TraverseTree.TreeTraversal_ByLayer(root);
           
            foreach (var layer in result)
            {
                Console.WriteLine(string.Join(",", layer));
            }

            // act
            string data = TreeSerializationOps.SerializeTree_ByLevel(root);
            Console.WriteLine($"SerializeTree_ByLevel: {data}" );

            // assert
            string[] items = data.Split(",");
            Assert.That(items[0], Is.EqualTo("10"));
            Assert.That(items[1], Is.EqualTo("8" ));
            Assert.That(items[2], Is.EqualTo("15"));

            // serialization //
            TreeNode newRoot = TreeSerializationOps.Deserialize_ByLevel(data);

            var newResult = TraverseTree.TreeTraversal_ByLayer(newRoot);

            foreach (var layer in newResult)
            {
                Console.WriteLine(string.Join(",", layer));
            }
        }

        [Test]
        public void SerializeTree_DFS_Recursive_Test()
        {
            // serialization //
            //
            // arrange
            TreeNode? root = BuildSampleTree();
            var result = TraverseTree.TreeTraversal_ByLayer(root);

            foreach (var layer in result)
            {
                Console.WriteLine(string.Join(",", layer));
            }

            // act
            string? data = TreeSerializationOps.SerializeTree_DFS_Recursive(root);
            Console.WriteLine($"SerializeTree_DFS_Recursive: {data}");

            // assert
            string[] items = data.Split(",");
            Assert.That(items[0], Is.EqualTo("10"));
            Assert.That(items[1], Is.EqualTo("8" ));
            Assert.That(items[2], Is.EqualTo("5" ));

            // serialization //
            TreeNode newRoot = TreeSerializationOps.DeserializeTree_DFS_Recursive(data);

            var newResult = TraverseTree.TreeTraversal_ByLayer(newRoot);

            foreach (var layer in newResult)
            {
                Console.WriteLine(string.Join(",", layer));
            }
        }

        [Test]
        public void SerializeTree_DFS_Iterative_Test()
        {
            // serialization //
            //
            // arrange
            TreeNode? root = BuildSampleTree();
            var result = TraverseTree.TreeTraversal_ByLayer(root);

            foreach (var layer in result)
            {
                Console.WriteLine(string.Join(",", layer));
            }

            // act
            string? data = TreeSerializationOps.SerializeTree_DFS_Iterative(root);
            Console.WriteLine($"SerializeTree_DFS_Recursive: {data}");

            // assert
            string[] items = data.Split(",");
            Assert.That(items[0], Is.EqualTo("10"));
            Assert.That(items[1], Is.EqualTo("8"));
            Assert.That(items[2], Is.EqualTo("5"));

            // serialization //
            TreeNode newRoot = TreeSerializationOps.DeserializeTree_DFS_Iterative(data);

            var newResult = TraverseTree.TreeTraversal_ByLayer(newRoot);

            foreach (var layer in newResult)
            {
                Console.WriteLine(string.Join(",", layer));
            }
        }

        private static TreeNode? BuildSampleTree()
        {
            TreeNode root = new TreeNode(10);
            root.left = new TreeNode(8);
            root.left.left = new TreeNode(5);
            root.left.right = new TreeNode(9);

            root.right = new TreeNode(15);
            root.right.left = new TreeNode(12);
            root.right.right = new TreeNode(16);
            root.right.right.right = new TreeNode(18);

            return root;
        }
    }
}
