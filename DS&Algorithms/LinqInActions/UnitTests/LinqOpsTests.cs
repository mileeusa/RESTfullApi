using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqInActions.UnitTests
{
    [TestFixture]
    public class LinqOpsTests
    {
        [Test]
        public void SampleLinqQuery_Test()
        {
            // arrange
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine();
            Console.WriteLine("LinqOps.SampleLinqQuery on [{0}]", string.Join(" ", numbers));
            // act
            var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
            // assert
            Console.WriteLine("Even Numbers: [{0}]", string.Join(" ", evenNumbers));
            Assert.That(evenNumbers, Is.EqualTo(new List<int> { 2, 4, 6 }));
        }
    }
}
