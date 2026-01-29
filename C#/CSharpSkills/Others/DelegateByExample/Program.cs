using Delegates;

namespace DelegateByExample
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.Run(new DelegateWithButtonClicked());

            Console.ReadLine();
        }
    }
}
