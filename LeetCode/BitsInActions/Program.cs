using BitsInActions.src;

namespace BitsInActions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int index = -1;
            int rIndex = ~index; // ~x = -(x + 1)

            Console.WriteLine($"Index: {index}, ~Index: {rIndex}");
        }
    }
}