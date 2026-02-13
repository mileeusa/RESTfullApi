using NUnit.Framework;

namespace StringInActions
{
    public class SplitOps
    {
        public static void StringSplit()
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
