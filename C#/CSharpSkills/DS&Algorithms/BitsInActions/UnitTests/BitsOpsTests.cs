using BitsInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsInActions.UnitTests
{
    [TestFixture]
    public class BitsOpsTests
    {
        [Test]
        public void BitsOps_Test()
        {
            int number = 29; // Binary: 11101
            int position = 2;
            Console.WriteLine();
            Console.WriteLine($"Original number: {number} (Binary: {Convert.ToString(number, 2)})");
            int bit = BitsOps.GetBit(number, position);
            Console.WriteLine($"GetBit at position {position}: {bit}");
            int setNumber = BitsOps.SetBit(number, position);
            Console.WriteLine($"SetBit at position {position}: {setNumber} (Binary: {Convert.ToString(setNumber, 2)})");
            int clearNumber = BitsOps.ClearBit(number, position);
            Console.WriteLine($"ClearBit at position {position}: {clearNumber} (Binary: {Convert.ToString(clearNumber, 2)})");
            int toggleNumber = BitsOps.ToggleBit(number, position);
            Console.WriteLine($"ToggleBit at position {position}: {toggleNumber} (Binary: {Convert.ToString(toggleNumber, 2)})");
            Console.WriteLine();
        }

        [TestCase(new int[] { 0 }, 1)]
        [TestCase(new int[] { 1, 1, 2 }, 3)]
        [TestCase(new int[] { 1, 2, 4 }, 6)]
        public void SubarrayBitwiseORs_Test(int[] arr, int expected)
        {
            var result = BitsOps.SubarrayBitwiseORs(arr);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase (8, true)]
        [TestCase (64, true)]
        [TestCase (128, true)]
        [TestCase (256, true)]
        [TestCase (250, false)]
        public void IsPowerOfTwo_Test(int num, bool isTrue)
        {
            bool res = BitsOps.IsPowerOfTwo(num);

            // assert
            Assert.That(res, Is.EqualTo(isTrue));
        }
    }
}
