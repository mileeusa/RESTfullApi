namespace SetInActions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HashSet<int> numbers = new HashSet<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            SetOps.RemoveWhere(numbers, 5);

            var result = string.Join(",", numbers.ToArray());
            Console.WriteLine(result);
            Console.WriteLine();
        }
    }
}