using InterfaceInActions.src;

namespace InterfaceInActions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            INestedKeyValueCollection<string, string, int> scores
                = new NestedKeyValueCollection<string, string, int>();

            scores.Add("Math", "Alice", 95);
            scores.Add("Math", "Bob", 88);
            scores.Add("Science", "Alice", 91);

            if (scores.TryGetValue("Math", "Alice", out var value))
            {
                Console.WriteLine($"Alice's Math score: {value}");
            }

            foreach (var student in scores.GetSubKeys("Math"))
            {
                Console.WriteLine($"Student in Math: {student}");
            }

            scores.Remove("Math", "Bob");
        }
    }
}