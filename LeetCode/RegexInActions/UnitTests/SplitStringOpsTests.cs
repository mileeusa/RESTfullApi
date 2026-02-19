using NUnit.Framework;
using RegexInActions.src;

namespace RegexInActions.UnitTests
{
    [TestFixture]
    public class SplitStringOpsTests
    {
        [TestCase("a,b,c,d", "a")]
        [TestCase("\"John, Smith\",25,Developer", "\"John, Smith\"")]
        [TestCase("123,\"Alice, Bob\",Engineer,\"R&D, Robotics\",Yes", "123")]
        [TestCase("\"Bob \"\"The Man\"\" Jones\",45,Manager", "\"Bob \"\"The Man\"\" Jones\"")]
        [TestCase("a,,,\"Hello, world\"", "a")]
        [TestCase("name,   \"Bob, Jr\",   age, 30", "name")]
        [TestCase("\"John, Doe\",28,\"Engineer, Software\",\"San Jose, CA\",\"He said, \"\"Hello!\"\"\"", "\"John, Doe\"")]
        [TestCase("\"Seattle, WA\", \"San Francisco, CA\", \"Austin, TX\"", "\"Seattle, WA\"")]
        public void SplitByCommaAndSpace_Test(string str, string expected)
        {
            var result = SplitStringOps.SplitByComma(str);
            Console.WriteLine(string.Join(" ", result));

            Assert.That(result[0], Is.EqualTo(expected));
        }
    }
}
