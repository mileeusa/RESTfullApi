using HashSetInAction.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSetInAction.UnitTests
{
    [TestFixture]
    public class UniqueOpsTests
    {
        [Test]
        public void UniqueOccurrences_Test()
        {
            // arrange
            Console.WriteLine();
            Console.WriteLine("UniqueOps.UniqueOccurrences_Test:");
            int[] arr = new int[] { 1, 2, 2, 1, 1, 3 };

            // act
            bool result = UniqueOps.UniqueOccurrences(arr);

            // assert
            Console.WriteLine("Are occurrences unique? {0}", result);
            Assert.That(result, Is.EqualTo(true));
        }
    }
}
