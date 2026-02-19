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
    public class ProductOpsTests
    {
        [Test]
        public void ProductExceptSelf_Test()
        {
            var nums = new int[] { 1, 2, 3, 4 };

            Console.WriteLine("ProductExceptSelf");
            Console.WriteLine($"{string.Join(", ", nums)}");
            Console.WriteLine("==>");

            // act
            var result = ProductOps.ProductExceptSelf(nums);

            // assert
            Console.WriteLine($"{string.Join(", ", result)}");

            Assert.That( result, Is.Not.Null );
            Assert.That(result[0], Is.EqualTo(24));
        }
    }
}
