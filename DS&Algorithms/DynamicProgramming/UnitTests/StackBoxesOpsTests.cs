using DynamicProgrammingInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingInActions.UnitTests
{
    [TestFixture]
    public class StackBoxesOpsTests
    {
        [Test]
        public void MaxStackHeight_Test()
        {
            var boxes = new Box[]
            {
                new Box() { W = 1, D = 1, H = 1 },
                new Box() { W = 2, D = 2, H = 2 },
                new Box() { W = 3, D = 3, H = 3 }
            };

            var result = StackBoxesOps.MaxStackHeight(boxes);

            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void GetMaxHeightStack_Test()
        {
            var boxes = new Box[]
            {
                new Box() { W = 1, D = 1, H = 1 },
                new Box() { W = 2, D = 2, H = 2 },
                new Box() { W = 3, D = 3, H = 3 }
            };

            var result = StackBoxesOps.GetMaxHeightStack(boxes);

            foreach(var box in result)
                Console.WriteLine(box.ToString());

            Assert.That(result.Count, Is.EqualTo(3));
        }
    }
}
