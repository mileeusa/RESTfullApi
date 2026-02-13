using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeInActions.UnitTests
{
    [TestFixture]
    public class TreeSideViewOpsTests
    {
        [Test]
        public void RightSideView_Test()
        {
            // arrange
            var root = new src.model.TreeNode(1)
            {
                left = new src.model.TreeNode(2)
                {
                    right = new src.model.TreeNode(5)
                },
                right = new src.model.TreeNode(3)
                {
                    right = new src.model.TreeNode(4)
                }
            };
            // act
            IList<int> result = src.TreeSideViewOps.RightSideView(root);

            // assert
            Assert.That(result, Is.EqualTo(new List<int> { 1, 3, 4 }));
        }
    }
}
