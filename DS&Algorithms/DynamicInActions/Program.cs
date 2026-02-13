using DynamicInActions.src;

namespace DynamicInActions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DynamicTypingOps.ToSubstring();

            DynamicTypingOps.DatabaseAccess("Server");
        }
    }
}