using CustomSearchInActions.src;
using NUnit.Framework;

namespace CustomSearchInActions.UnitTests
{
    [TestFixture]
    public class CustomSearchFromHackerRankTests
    {
        [TestCase(@"Files\CustomerData_01.txt")]
        [TestCase(@"Files\CustomerData_02.txt")]
        [TestCase(@"Files\CustomerData_03.txt")]
        public static void ExecuteSearch_Test(string fileName)
        {
            Console.WriteLine();
            Console.WriteLine($"Execute search for {fileName}");
            Stream? stream = new StreamReader(fileName).BaseStream;
            CustomeSearchFromHackerRank.Execute(stream);
        }
    }
}
