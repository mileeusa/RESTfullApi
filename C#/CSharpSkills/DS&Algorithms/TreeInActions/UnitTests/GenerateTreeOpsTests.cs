using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src;
using TreeInActions.src.model;
using TreeInActions.src.utilities;

namespace TreeInActions.UnitTests
{
    [TestFixture]
    public class GenerateTreeOpsTests
    {
        [Test]
        public void GenerateTreeFromArray_Test()
        {
            int?[] arr = { -10, -3, 0, 5, 9 };
            Console.WriteLine();
            Console.WriteLine("GenerateTreeOps.GenerateTreeFromArray()");
            Console.WriteLine("Sorted Array: " + string.Join(", ", arr));

            TreeNode? root = GenerateTreeOps.GenerateTreeFromArray(arr);

            TreePrintOps.PrintTreeByLevel(root);
        }

        [Test]
        public void GenerateTreeFromSortedArray_Test()
        {
            int?[] arr = { -10, -3, 0, 5, 9 };
            Console.WriteLine();
            Console.WriteLine("GenerateTreeOps.GenerateTreeFromSortedArray()");
            Console.WriteLine("Sorted Array: " + string.Join(", ", arr));

            TreeNode? root = GenerateTreeOps.GenerateTreeFromSortedArray(arr);

            Console.WriteLine("Generated BST Root Value: " + (root != null ? root.val.ToString() : "null"));
            TreePrintOps.PrintTreeByLevel(root);
        }

        [TestCase("4(2(3)(1))(6(5))")]
        [TestCase("4")]
        public void Str2tree_Test(string s)
        {
            //
            var root = GenerateTreeOps.Str2tree(s);

            TreePrintOps.PrintTreeByLevel(root);
        }

        [Test]
        public void Tree2Str_Test()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(4);
            root.right = new TreeNode(3);

            var str = GenerateTreeOps.Tree2Str(root);

            Console.WriteLine($"String of tree: {str}");
        }

        [Test]
        public void Tree2Str_Iterative_Test()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(4);
            root.right = new TreeNode(3);

            var str = GenerateTreeOps.Tree2Str_Iterative(root);

            Console.WriteLine($"String of tree: {str}");
        }
    }
}
