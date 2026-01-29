namespace CSharp_Skills_LINQ
{
    public class LINQ_IEnumerable_Tutorial
    {
        public static void RetrieveItemsFromLINQ()
        {
            string[] names = { "Tom", "Harry", "Dick", "Mary" };

            // Implement using fluent syntax
            Console.WriteLine("// Implement using fluent syntax");
            var filterNames_01 = Enumerable.Where(names, x => x.Length >= 4);
            var filterNames_02 = names.Where(n => n.Length >= 4);

            foreach (var name in filterNames_01)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            foreach (var name in filterNames_02)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            var filterName_04 = names.Where(x => x.Contains("a"))
                .OrderBy(x => x.Length)
                .Select(x => x.ToUpper());

            foreach (var name in filterName_04)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            // Implement using query expression
            Console.WriteLine("// Implement using query expression");
            var filterNames_03 = from n in names where n.Contains("a") select n;

            foreach (var name in filterNames_03)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            var query_01 =
                from n in names
                where n.Contains("a")
                orderby n.Length
                select n.ToUpper();

            foreach (var name in query_01)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();


            // mixed syntax queries
            Console.WriteLine("// mixed syntax queries");
            int matches = (from n in names where n.Contains("a") select n).Count();
            Console.WriteLine("matches: " + matches);

            string first = (from n in names where n.Contains("a") select n).First();
            Console.WriteLine("first matched name that contains \"a\": " + first);

            //deferred execution/revaluation
            var numbers = new List<int>() { 1, 2, 3, 4, 5, 6 };
            List<int> timesTen = numbers.Select(x => x * 10).ToList(); // executes immediately into a List<int>

            numbers.Clear();
            Console.WriteLine(timesTen.Count);

            string[] musos =
            {
                "David Cilmour",
                "Roger Waters",
                "Rick Wright",
                "Nick Mason"
            };

            // LINQ query using subqueries
            Console.WriteLine("// LINQ query using subqueries");
            var query_02 = musos.OrderBy(x => x.Split().Last()).ToList();

            foreach (var name in query_02)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            // using keyword "into"
            Console.WriteLine("// using keyword \"into\"");
            var query_03 = from n in names
                           select n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", "")
                           into noVowel
                           where noVowel.Length > 2
                           orderby noVowel
                           select noVowel;

            foreach (var name in query_03)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            // wrapping queries
            Console.WriteLine("// wrapping queries");
            var query_04 = from n1 in (
                from n2 in names
                select n2.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", "")
                )
                           where n1.Length > 2
                           orderby n1
                           select n1;

            foreach (var name in query_04)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            Console.WriteLine("// using anonymous types");
            var intermediate = from n in names
                               select new
                               {
                                   Original = n,
                                   Vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("e", "")
                               };

            var query_05 = from n in intermediate
                           where n.Vowelless.Length > 2
                           select n.Original;

            foreach (var name in query_05)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            Console.WriteLine("// using let Keyword");
            var query_06 = from n in names
                           let Vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("e", "")
                           where Vowelless.Length > 2
                           orderby Vowelless
                           select n;

            foreach (var name in query_06)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            // Microsoft Entity Framework (EF) / interpreted queris

        }

        public static void StringFromLINQ()
        {
            char[] chars = "HelloWorld".Distinct().ToArray();

            Console.WriteLine("// LINQ manipulation");
            foreach (var name in chars)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// List all the files int the temparory path
        /// </summary>
        public static void ReportFiles()
        {
            string tmpPath = Path.GetTempPath();
            DirectoryInfo[] dirs = new DirectoryInfo(tmpPath).GetDirectories();

            var query =
                from d in dirs
                where (d.Attributes & FileAttributes.System) == 0
                select new
                {
                    DirectoryName = d.FullName,
                    Created = d.CreationTime,
                    Files = from f in d.GetFiles()
                            where (f.Attributes & FileAttributes.Hidden) == 0
                            select new
                            {
                                FileName = f.Name,
                                f.Length,
                            }
                };

            foreach (var dirFiles in query)
            {
                Console.WriteLine("Directory: " + dirFiles.DirectoryName);
                foreach (var file in dirFiles.Files)
                {
                    Console.WriteLine("  " + file.FileName + " Length: " + file.Length);
                }
            }
        }

        //public static void SQL_Style_Joins()
        //{
        //    var query =
        //        from c in dbContext.Customers
        //        select new
        //        {
        //            c.Name,
        //            Purchases = (from p in dbContext.Purchases
        //                         where p.CustomerId == c.IS && p.Price > 1000
        //                         select new
        //                         {
        //                             p.Description,
        //                             p.Price
        //                         }
        //            ).ToList()
        //        };

        //    foreach (var namePurchases in query)
        //    {
        //        Console.WriteLine("Customer: " + namePurchases.Name);
        //        foreach (var purchaseDetail in namePurchases)
        //        {
        //            Console.WriteLine("Description: " + purchaseDetail.Description + ", price: " +purchaseDetail.Price);
        //        }
        //    }
        //}
    }
}
