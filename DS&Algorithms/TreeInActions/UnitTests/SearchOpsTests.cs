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
    public class SearchOpsTests
    {
        [Test]
        public void SearchBST_Test_Found()
        {
            // Construct the BST
            //       4
            //      / \
            //     2   7
            //    / \
            //   1   3
            var root = new src.model.TreeNode(4,
                new src.model.TreeNode(2,
                    new src.model.TreeNode(1),
                    new src.model.TreeNode(3)),
                new src.model.TreeNode(7));
            int valToSearch = 2;
            var result = src.SearchOps.SearchBST(root, valToSearch);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.val, Is.EqualTo(2));
        }

        [Test]
        public void GoodNodes_Test()
        {
            // Construct the BT
            //       3
            //      / \
            //     1   4
            //    /   / \
            //   3   1   5
            //
            var root = new TreeNode(3,
                new TreeNode(1,
                    new TreeNode(3)),
                new TreeNode(4,
                    new TreeNode(1),
                    new TreeNode(5)));
            var result = SearchOps.GoodNodes(root);

            Assert.That(result, Is.EqualTo(4));
        }
    }
}
