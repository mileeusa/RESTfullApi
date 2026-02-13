using ArrayInActions.src;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.UnitTests
{
    [TestFixture]
    public class NumberAddOpsTests
    {
        [Test]
        public void PlusOne_TestOne()
        {
            // arrange
            List<int> digits = new List<int> { 9, 9, 9 };

            // act
            Console.WriteLine();
            Console.WriteLine("NumberAddOps.PlusOne");
            Console.WriteLine("Original digits: " + string.Join(", ", digits));
            List<int> result = NumberAddOps.PlusOne(digits);
            Console.WriteLine("After Plus One: " + string.Join(", ", result));

            // assert
            CollectionAssert.AreEquivalent(new List<int> { 1, 0, 0, 0 }, result);
        }

        [Test]
        public void PlusOne_TestTwo()
        {
            // arrange
            List<int> digits = new List<int> { 9, 9, 8 };

            // act
            Console.WriteLine();
            Console.WriteLine("NumberAddOps.PlusOne");
            Console.WriteLine("Original digits: " + string.Join(", ", digits));
            List<int> result = NumberAddOps.PlusOne(digits);
            Console.WriteLine("After Plus One: " + string.Join(", ", result));

            // assert
            CollectionAssert.AreEquivalent(new List<int> { 9, 9, 9 }, result);
        }
    }
}
