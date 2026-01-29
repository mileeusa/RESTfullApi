
using EfficientSerializer.src;

namespace EfficientSerializer
{
    class Person
    {
        public string Name { get; set; }
        public int Age;
        public List<string> Hobbies { get; set; }
    }

    public class Program
    {
        private static void Main(string[] args)
        {
            var p = new Person
            {
                Name = "Alice",
                Age = 30,
                Hobbies = new List<string> { "Reading", "Hiking" }
            };

            string serialized = SimpleSerializer.Serialize(p);
            Console.WriteLine(serialized);

            Person deserialized = SimpleSerializer.Deserialize<Person>(serialized);
            Console.WriteLine(deserialized.Name);      // Alice
            Console.WriteLine(deserialized.Age);       // 30
            Console.WriteLine(string.Join(",", deserialized.Hobbies)); // Reading,Hiking
        }
    }
}