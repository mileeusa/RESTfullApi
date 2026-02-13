using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions
{
    public class AssertOps
    {
        public static void Assertions()
        {
            string s = "1,2,,3,,,4,,5 ";

            var splits = s.Split(',', StringSplitOptions.None);
            Assert.That(splits.Length == 9);

            splits = s.Split(',', StringSplitOptions.TrimEntries);
            Assert.That(splits.Length == 9);

            splits = s.Split(',', StringSplitOptions.RemoveEmptyEntries);
            Assert.That(splits.Length == 5);
        }
    }
}
