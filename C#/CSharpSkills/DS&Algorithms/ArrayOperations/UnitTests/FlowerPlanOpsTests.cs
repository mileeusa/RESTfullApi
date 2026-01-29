using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.UnitTests
{
    [TestFixture]
    public class FlowerPlanOpsTests
    {
        [Test]
        public void CanPlaceFlowers_Test_One()
        {
            int[] flowerbed = new int[] { 1, 0, 0, 0, 1 };
            int n = 1;
            bool result = ArrayInActions.src.FlowerPlanOps.CanPlaceFlowers(flowerbed, n);
            Assert.That(result, Is.EqualTo(true));
        }


        [Test]
        public void CanPlaceFlowers_Test_Two()
        {
            int[] flowerbed = new int[] { 1, 0, 0, 0, 1 };
            int n = 2;
            bool result = ArrayInActions.src.FlowerPlanOps.CanPlaceFlowers(flowerbed, n);
            Assert.That(result, Is.EqualTo(false));
        }
    }
}
