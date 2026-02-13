// See https://aka.ms/new-console-template for more information
using CSharp_Skills_CvsParser;

namespace CSharp_Skills_CvsParser
{
    public class Program
    {
        private static void Main(string[] args)
        {
            CvsParser cvsParser = new CvsParser();
            var payments = cvsParser.AllPayments;

            foreach (var payment in payments)
            {
                Console.WriteLine(payment);
            }

            var average = payments.Average(e => e.Price);
            var topEarner = payments.OrderByDescending(e => e.Price).First();

            double totalPayment = cvsParser.TotalPayment(1);

            Console.WriteLine($"Average payment: {cvsParser.AveragePayment()}");
            Console.WriteLine("Total payment for location 1: {0}", totalPayment);

            cvsParser.TotalPayment();

            Console.WriteLine("Hello, World!");
        }
    }
}