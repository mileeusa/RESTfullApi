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
    public class ZigZagOpsTests
    {
        [Test]
        public void LongestZigZag_Test()
        {
            //
            //          1
            //           \
            //             1
            //           /  \
            //         1      1
            //              /   \
            //            1       1
            //             \
            //               1
            //                \
            //                  1
            //
            TreeNode root = new TreeNode(1,
                null,
                new TreeNode(1,
                    new TreeNode(1),
                    new TreeNode(1,
                        new TreeNode(1, 
                            null, 
                            new TreeNode(1,
                                null,
                                new TreeNode(1))),
                        new TreeNode(1))));

            var len = ZigZagOps.LongestZigZag(root);

            Assert.That(len, Is.EqualTo(3));

        }
    }
}
