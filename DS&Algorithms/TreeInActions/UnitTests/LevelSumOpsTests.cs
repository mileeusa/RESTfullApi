using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src;

namespace TreeInActions.UnitTests
{
    [TestFixture]
    public class LevelSumOpsTests
    {
        [Test]
        public void MaxLevelSum_Test()
        {
            // arrange
            /*
                    1
                   / \
                  7   0
                 / \
                7  -8
            */
            var root = new src.model.TreeNode(1)
            {
                left = new src.model.TreeNode(7)
                {
                    left = new src.model.TreeNode(7),
                    right = new src.model.TreeNode(-8)
                },
                right = new src.model.TreeNode(0)
            };
            Console.WriteLine();
            Console.WriteLine("LevelSumOps.MaxLevelSum_Test:");

            // act
            var (level, maxSum) = LevelSumOps.MaxLevelSum(root);

            // assert
            Console.WriteLine($"Max Level Sum: {maxSum}, level: {level}");
            Assert.That(level, Is.EqualTo(2));
        }
    }
}
