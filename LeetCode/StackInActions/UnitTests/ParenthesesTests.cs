using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackInActions.UnitTests
{
    [TestFixture]
    public class ParenthesesTests
    {
        [Test]
        public void IsValid_Test()
        {
            // arrange
            var testCases = new Dictionary<string, bool>
            {
                { "()", true },
                { "()[]{}", true },
                { "(]", false },
                { "([)]", false },
                { "{[]}", true },
                { "", true },
                { "((()))", true },
                { "((())", false },
                { "())", false }
            };
            // act & assert
            foreach (var testCase in testCases)
            {
                string input = testCase.Key;
                bool expected = testCase.Value;
                bool result = Parentheses.IsValid(input);
                Assert.That(result, Is.EqualTo(expected), $"{input} should be {(expected ? "valid" : "invalid")}");
            }
        }

        [Test]
        public void LongestValidParentheses_Test()
        {
            Console.WriteLine();
            string s = "(()";
            int length = Parentheses.LongestValidParentheses(s);
            Console.WriteLine($"Longest valid parentheses in \"{s}\": {length}"); // Output: 2

            s = ")()())";
            length = Parentheses.LongestValidParentheses(s);
            Console.WriteLine($"Longest valid parentheses in \"{s}\": {length}"); // Output: 4

            s = "";
            length = Parentheses.LongestValidParentheses(s);
            Console.WriteLine($"Longest valid parentheses in \"{s}\": {length}"); // Output: 0

            s = "()(())";
            length = Parentheses.LongestValidParentheses(s);
            Console.WriteLine($"Longest valid parentheses in \"{s}\": {length}"); // Output: 6
        }
    }
}
