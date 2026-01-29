using NUnit.Framework;
using NUnit.Framework.Legacy;
using StringInActions.src;

namespace StringInActions.UnitTests
{
    [TestFixture]
    public class StringInActionsTest
    {
        [Test]
        public void LongestCommonPrefix_Test()
        {
            string[] strs = { "flower", "flow", "flight" };
            string result = LongestCommonPrefixOps.LongestCommonPrefix(strs);
            Assert.That(result, Is.EqualTo("fl"));
        }

        [Test]
        public void LongestBuiltWord_Test()
        {
            string[] words = { "a", "ap", "app", "appl", "apple", "apply" };
            string result = LongestWordOps.LongestBuiltWord(words);
            Assert.That(result, Is.EqualTo("apple"));
        }

        [Test]
        public void FindSubstring_Test()
        {
            string s = "barfoothefoobarman";
            string[] words = { "foo", "bar" };
            IList<int> result = SubstringOps.FindSubstring(s, words);
            CollectionAssert.AreEquivalent(new List<int> { 0, 9 }, result);
        }
    }
}
