using GraphInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingInActions.UnitTests
{
    [TestFixture]
    public class WordsMessinessOpsTests
    {
        [Test]
        public void MinimizeMessinessLastLineNoPenalty_Test()
        {
            var words = new string[] { "aaa", "bbb", "c", "d", "ee", "ff", "ggggggg" };
            int maxWidth = 11;

            var result = WordsMessinessOps.MinimizeMessinessLastLineNoPenalty(words, maxWidth);

            Console.WriteLine(result);
        }

        [TestCase("aaa bbb c d ee ff ggggggg", 11)]
        [TestCase("This is an example of text justification", 16)]
        public void MinimizeMessiness_Test(string text, int maxWidth)
        {
            var result = WordsMessinessOps.MinimizeMessiness(text, maxWidth);

            foreach (var line in result)
            {
                Console.WriteLine(line);
            }
        }
    }
}
