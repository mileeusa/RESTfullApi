using NUnit.Framework;
using CollectionInActions.src;

namespace CollectionInActions.UnitTests
{
    [TestFixture]
    public class MyCollectionTests
    {
        [TestCase]
        public void Add_IncreasesCount()
        {
            var c = new MyCollection<int>();

            Assert.That(c.Count == 0);

            c.Add(1);
            Assert.That(c.Count, Is.EqualTo(1));
            Assert.That(c.Contains(1), Is.EqualTo(true));
        }

        [TestCase]
        public void Remove_DecreasesCount_WhenItemExists()
        {
            var c = new MyCollection<string>();
            c.Add("a");
            c.Add("b");

            Assert.That(c.Remove("a"), Is.EqualTo(true));
            Assert.That(c.Count, Is.EqualTo(1));
            Assert.That(c.Contains("a"), Is.EqualTo(false));
        }

        [TestCase]
        public void Remove_ReturnsFalse_WhenItemNotExists()
        {
            var c = new MyCollection<int>();
            Assert.That(!c.Remove(42));
            Assert.That(c.Count == 0);
        }

        [TestCase]
        public void Contains_ReturnsTrue_WhenItemExists()
        {
            var c = new MyCollection<int>();
            c.Add(7);
            Assert.That(c.Contains(7));
        }

        [TestCase]
        public void CopyTo_CopiesItemsToArray()
        {
            var c = new MyCollection<int>();
            c.Add(1);
            c.Add(2);
            c.Add(3);

            var arr = new int[5];
            c.CopyTo(arr, 1);

            Assert.That(arr[0] == 0);
            Assert.That(arr[1] == 1);
            Assert.That(arr[2] == 2);
            Assert.That(arr[3] == 3);
        }

        [TestCase]
        public void Clear_EmptiesCollection()
        {
            var c = new MyCollection<int>();
            c.Add(1);
            c.Add(2);

            c.Clear();
            Assert.That(c.Count == 0);
            Assert.That(!c.Contains(1));
        }

        [TestCase]
        public void Enumerator_EnumeratesItemsInOrder()
        {
            var c = new MyCollection<int>();
            c.Add(5);
            c.Add(6);

            Console.WriteLine("Items in collection:");
            foreach (var item in c)
            {
                Console.WriteLine(item);
            }

            var list = c.ToList();
            Assert.That(c, Is.EqualTo(list));
        }

        [TestCase]
        public void IsReadOnly_IsFalse()
        {
            var c = new MyCollection<int>();
            Assert.That(c.IsReadOnly, Is.EqualTo(false));
        }
    }
}