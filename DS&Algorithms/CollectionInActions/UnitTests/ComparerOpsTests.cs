using CollectionInActions.src;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionInActions.UnitTests
{
    [TestFixture]
    public class ComparerOpsTests
    {
        [Test]
        public void SortStringIgnoreCase_Test()
        {
            // arrange
            var list = new string[] { "apple", "Banana", "cherry", "Apricot" };

            // acr
            ComparerOps.SortStringIgnoreCase(list);

            // assert
            Assert.That(list[1], Is.EqualTo("Apricot"));
            Assert.That(list[0], Is.EqualTo("apple"));
        }

        [Test]
        public void CustomComparerOne_Test()
        {
            var people = new List<Person>
            {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 25 },
                new Person { Name = "Andrew", Age = 25 }
            };

            ComparerOps.CustomComparerOne(people);

            // assert
            Assert.That(people[0].Name, Is.EqualTo("Andrew"));
        }

        [Test]
        public void CustomSortingMultiKey_Test()
        {
            //   [ [1,3], [2,4], [1,2], [2,2], [1,5] ]
            //
            //  Expected sorted result:
            //   [ [1,5], [1,3], [1,2], [2,4], [2,2] ]

            var intervals = new int[][]
            {
                [ 1, 3 ],
                [ 2, 4 ],
                [ 1, 2 ],
                [ 2, 2 ],
                [ 1, 5 ],
            };

            // act
            ComparerOps.CustomSortingMultiKey(intervals);

            // assert
            Assert.That(intervals[0][0], Is.EqualTo(1));
            Assert.That(intervals[0][1], Is.EqualTo(2));
            Assert.That(intervals[4][0], Is.EqualTo(2));
            Assert.That(intervals[4][1], Is.EqualTo(4));
        }
    }
}
