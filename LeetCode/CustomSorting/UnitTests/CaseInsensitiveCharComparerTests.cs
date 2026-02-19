using CustomSorting.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomSorting.UnitTests
{
    [TestFixture]
    public class CaseInsensitiveCharComparerTests
    {
        [Test]
        public void Compare_Test()
        {
            // arrange
            string[] names = { "John", "Jane", "Jack", "Doe" };
            Console.WriteLine($"Sorted names for \"{string.Join(", ", names)}\" in descending order:");

            // act
            Array.Sort(names, (x, y) => y.CompareTo(x));

            // assert
            Console.WriteLine($"=> {string.Join(", ", names)}\n");

            // arrange
            int[] arr = new int[] { 1, 9, 6, 7, 5, 9 };
            Console.WriteLine($"Sorted integers \"{string.Join(", ", arr)}\" in descending order:");
            
            // act
            Array.Sort(arr, (x, y) => y.CompareTo(x));

            // assert
            Console.WriteLine($"=> {string.Join(", ", arr)}\n");

            // arrange
            string[] strArray = { "apple", "orange", "banana", "grape" };
            Console.WriteLine($"Sorted strings \"{string.Join(", ", strArray)}\" ascending order (case-insensitive):");

            // act
            Array.Sort(strArray, (x, y) => string.Compare(x, y, StringComparison.OrdinalIgnoreCase));

            // assert
            Console.WriteLine($"=> {string.Join(", ", strArray)}\n");
        }

        [Test]
        public void CaseInsensitiveCharComparer_Test()
        {
            char[] chars = { 'a', 'b', 'C', 'd', 'E', 'f' };
            Array.Sort(chars, (x, y) => new CaseInsensitiveCharComparer().Equals(x, y) ? 0 : char.ToUpperInvariant(x).CompareTo(char.ToUpperInvariant(y)));
            Console.WriteLine($"Sorted characters in ascending order (case-insensitive): {string.Join(", ", chars)}");

            // assert
            Assert.That(chars, Is.EqualTo(new char[] { 'a', 'b', 'C', 'd', 'E', 'f' }));
        }
    }
}
