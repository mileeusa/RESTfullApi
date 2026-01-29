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
    public class CandiesOpsTests
    {
        [Test]
        public void KidsWithCandies_Test()
        {
            int[] candies = new int[] { 2, 3, 5, 1, 3 };
            int extraCandies = 3;

            IList<bool> result = CandiesOps.KidsWithCandies(candies, extraCandies);
            Assert.That(result[3], Is.EqualTo(false));
        }
    }
}
