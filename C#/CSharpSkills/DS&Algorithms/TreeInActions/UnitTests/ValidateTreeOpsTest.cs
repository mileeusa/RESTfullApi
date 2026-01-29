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
    public class ValidateTreeOpsTest
    {
        [Test]
        public void ValidateTreeOps_Test()
        {
            // arrange
            var root = new TreeNode(10)
            {
                left = new TreeNode(5)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(7)
                },
                right = new TreeNode(15)
                {
                    right = new TreeNode(18)
                }
            };
            // act
            bool isValidBST = ValidateTreeOps.IsValidBST(root);
            Console.WriteLine($"Is the tree a valid BST? {isValidBST}");
            // assert
            Assert.That(isValidBST, Is.EqualTo(true));
        }
    }
}
