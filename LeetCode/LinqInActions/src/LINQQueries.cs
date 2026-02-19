using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LinqInActions
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Country { get; set; }
    }

    public class Order
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public double Cost { get; set; }
    }


    public class LINQQueries
    {
        public static void SubQueries()
        {
            string[] names = { "David Gilmour", "David Gilmour", "Foger Waters", "Rick Wright", "Nick Mason" };

            var query = names.Distinct().OrderBy(x => x.Split().Last()); // order by the last name

            Console.WriteLine();

            foreach (var name in query)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            query = names.Distinct().OrderBy(x => x.Split().First());  // order by the first name

            foreach (var name in query)
            {
                Console.WriteLine(name);
            }
        }

        public static void LINQJoinWithMethodSyntax()
        {
            Console.WriteLine("LINQJoinWithMethodSyntax:");

            var customers = new List<Customer>
            {
                new Customer { CustomerId = 1, CustomerName = "Alice Johnson", Country = "USA" },
                new Customer { CustomerId = 2, CustomerName = "Bob Smith", Country = "Canada" },
                new Customer { CustomerId = 3, CustomerName = "Charlie Brown", Country = "UK" },
                new Customer { CustomerId = 4, CustomerName = "Diana Prince", Country = "Australia" }
            };

            // Sample orders
            var orders = new List<Order>
            {
                new Order { CustomerId = 1, OrderDate = new DateTime(2025, 8, 1), Cost = 250.50 },
                new Order { CustomerId = 1, OrderDate = new DateTime(2025, 8, 5), Cost = 100.00 },
                new Order { CustomerId = 2, OrderDate = new DateTime(2025, 8, 3), Cost = 300.75 },
                new Order { CustomerId = 3, OrderDate = new DateTime(2025, 8, 4), Cost = 150.20 },
                new Order { CustomerId = 4, OrderDate = new DateTime(2025, 8, 2), Cost = 500.00 },
                new Order { CustomerId = 4, OrderDate = new DateTime(2025, 8, 7), Cost = 250.00 }
            };

            var custOrders = customers.Join(orders, 
                c => c.CustomerId, o => o.CustomerId,
                (c, o) => new
                {
                    c.CustomerName,
                    o.OrderDate,
                    o.Cost
                });

            foreach (var c in custOrders)
            {
                Console.WriteLine($"Customer Name: {c.CustomerName}, Date: {c.OrderDate}, Total: {c.Cost}");
            }
            Console.WriteLine();

            var custTotalOrders = customers.GroupJoin(orders, 
                c => c.CustomerId, o => o.CustomerId,
                (c, o) => new
                {
                    c.CustomerName,
                    TotalOrders = o.Sum(o => o.Cost)
                });

            foreach (var c in custTotalOrders)
            {
                Console.WriteLine($"Customer Name: {c.CustomerName}, Total: {c.TotalOrders}");
            }
            Console.WriteLine();

            var customerCountries = customers
                .Select(c => c.Country).Distinct().ToList();

            foreach (var c in customerCountries)
            {
                Console.WriteLine($"Country: {c}");
            }
            Console.WriteLine();
        }

        public static void LINQJoinWithQuerySyntax()
        {

            Console.WriteLine("LINQJoinWithQuerySyntax:");

            var customers = new List<Customer>
            {
                new Customer { CustomerId = 1, CustomerName = "Alice Johnson", Country = "USA" },
                new Customer { CustomerId = 2, CustomerName = "Bob Smith", Country = "Canada" },
                new Customer { CustomerId = 3, CustomerName = "Charlie Brown", Country = "UK" },
                new Customer { CustomerId = 4, CustomerName = "Diana Prince", Country = "Australia" }
            };

            // Sample orders
            var orders = new List<Order>
            {
                new Order { CustomerId = 1, OrderDate = new DateTime(2025, 8, 1), Cost = 250.50 },
                new Order { CustomerId = 1, OrderDate = new DateTime(2025, 8, 5), Cost = 100.00 },
                new Order { CustomerId = 2, OrderDate = new DateTime(2025, 8, 3), Cost = 300.75 },
                new Order { CustomerId = 3, OrderDate = new DateTime(2025, 8, 4), Cost = 150.20 },
                new Order { CustomerId = 4, OrderDate = new DateTime(2025, 8, 2), Cost = 500.00 },
                new Order { CustomerId = 4, OrderDate = new DateTime(2025, 8, 7), Cost = 250.00 }
            };

            var custOrders = from customer in customers
                             join order in orders on customer.CustomerId equals order.CustomerId
                             select new
                             {
                                 customer.CustomerName,
                                 order.OrderDate,
                                 order.Cost
                             };

            foreach (var c in custOrders)
            {
                Console.WriteLine($"Customer Name: {c.CustomerName}, Date: {c.OrderDate}, Total: {c.Cost}");
            }
            Console.WriteLine();

            var custTotalOrders = from c in customers
                                  join o in orders on c.CustomerId equals o.CustomerId into custOrderGroup
                                  select new
                                  {
                                      c.CustomerName,
                                      TotalOrders = custOrderGroup.Sum(o => o.Cost)
                                  };

            foreach (var c in custTotalOrders)
            {
                Console.WriteLine($"Customer Name: {c.CustomerName}, Total: {c.TotalOrders}");
            }
            Console.WriteLine();

            var customerCountries = customers
                .Select(c => c.Country).Distinct().ToList();

            foreach (var c in customerCountries)
            {
                Console.WriteLine($"Country: {c}");
            }
            Console.WriteLine();
        }

        public static void test()
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            IEnumerable<string> names2 = names
                .Select(n => Regex.Replace(n, "[aeiou]", ""));

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();
            foreach (var name in names2)
            {
                Console.WriteLine(name);
            }

            // method syntax or fluent syntax
            var query1 = names
                .Select(x => x.Replace("a", "")
                .Replace("e", "")
                .Replace("i", "")
                .Replace("o", "")
                .Replace("u", ""))
                .Where(noVowel => noVowel.Length > 2)
                .OrderBy(noVowel => noVowel);

            foreach (var name in query1)
            {
                Console.WriteLine($"Name: {name}");
            }

            Console.WriteLine();

            // query syntax =
            var query2 = from q in names
                         let c = q.Replace("a", "")
                                  .Replace("e", "")
                                  .Replace("i", "")
                                  .Replace("o", "")
                                  .Replace("u", "")
                         where c.Length > 2
                         orderby c
                         select c;

            foreach (var name in query2)
            {
                Console.WriteLine($"Name: {name}");
            }

            LINQJoinWithMethodSyntax();
            LINQJoinWithQuerySyntax();
        }
    }
}
