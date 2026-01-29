using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.UnitTests
{
    [TestFixture]
    public class MoveOpsTests
    {
        [Test]
        public void MoveZeroes_Test()
        {
            // arrange
            int[] nums = { 0, 1, 0, 3, 12 };
            Console.WriteLine();
            Console.WriteLine("MoveOps.MoveZeroes [{0}]", string.Join(" ", nums));
            // act
            src.MoveOps.MoveZeroes(nums);
            Console.WriteLine($"=> [{string.Join(" ", nums)}]");
            // assert
            Assert.That(nums, Is.EqualTo(new int[] { 1, 3, 12, 0, 0 }));
        }
    }
}
