using ArrayInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.UnitTests
{
    [TestFixture]
    public class ConsecutiveOpsTests
    {
        [Test]
        public void LongestConsecutive_Test()
        {
            // arrange
            int[] arr = { 100, 4, 200, 1, 3, 2 };

            // act
            Console.WriteLine("Array: " + string.Join(", ", arr));
            int result = ConsecutiveOps.LongestConsecutive(arr);
            Console.WriteLine("Longest consecutive sequence length: " + result);

            //assert
            Assert.That(result, Is.EqualTo(4));
        }
    }
}
