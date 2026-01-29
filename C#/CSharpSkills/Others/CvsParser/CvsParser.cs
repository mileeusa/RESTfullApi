using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Skills_CvsParser
{
    public class Payment
    {
        public int LocationId { get; set; }
        public string PaymentStatus { get; set; }
        public double Price { get; set; }
    }

    //public class Revenue
    //{
    //    public int LocationId { get; set; }
    //    public double Amount { get; set; }
    //}

    public class CvsParser
    {
        private string _fileName;

        public CvsParser()
        {
            _fileName = "Files\\CvsSamples.txt";

            AllPayments = File.ReadAllLines(FileName)
                .Skip(1)
                .Select(line =>
                {
                    var parts = line.Split(",");
                    return new Payment
                    {
                        LocationId = int.Parse(parts[0]),
                        PaymentStatus = parts[1],
                        Price = double.Parse(parts[2])
                    };
                }).ToList();
        }

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public List<Payment> AllPayments { get; }

        public double AveragePayment()
        {
            return AllPayments
                   .Where(e => e.PaymentStatus == "Completed")
                   .Average(e => e.Price);
        }

        public double TotalPayments()
        {
            return AllPayments.Sum(e => e.Price);
        }
        public double TotalPayment(int location)
        {
            double a = AllPayments
                .Where(r => r.PaymentStatus == "Completed")
                .Where(r => r.LocationId == location)
                .Select(r => r.Price)
                .ToList()
                .Sum();

            return a;
        }

        public void TotalPayment()
        {
            // Group and calculate total revenue for Paid transactions
            var revenuePerLocation = AllPayments
                .Where(r => r.PaymentStatus.Equals("Completed", StringComparison.OrdinalIgnoreCase))
                .GroupBy(r => r.LocationId)
                .Select(g => new
                {
                    LocationId = g.Key,
                    TotalRevenue = g.Sum(s => s.Price)
                })
                .ToList();

            // Print results
            foreach (var item in revenuePerLocation)
            {
                Console.WriteLine($"Location: {item.LocationId}, Revenue: {item.TotalRevenue:C}");
            }
        }
    }
}
