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
    public class RotateOpsTests
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1)]
        [TestCase(new int[] { 5, 1, 2, 3, 4 }, 1)]
        [TestCase(new int[] { 4, 5, 1, 2, 3 }, 1)]
        [TestCase(new int[] { 3, 4, 5, 1, 2 }, 1)]
        [TestCase(new int[] { 2, 3, 4, 5, 1 }, 1)]
        public void FindMinInRotatedArray_Test(int[] nums, int expected)
        {
            // arrange

            // act 
            var result = RotateOps.FindMinInRotatedArray(nums);

            // assert
            Assert.That(result, Is.EqualTo(expected));

        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] { 5, 6, 7, 1, 2, 3 })]
        public void Rotate_Cyclic_Test(int[] nums, int k, int[] expected)
        {
            Console.WriteLine($"Rotate_Cyclic. \n{string.Join(", ", nums)}");
            RotateOps.Rotate_Cyclic(nums, k);
            Console.WriteLine($"=> {string.Join(", ", nums)}");
        }
    }
}
