using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicInActions.src
{
    public class Book
    {
        public string Title { get; set; }
    }

    public class Database : DynamicObject
    {
        private string _connectionString;

        public Database(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Pretend each table is dynamically accessible (database.Books, database.Users, etc.)
        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            switch (binder.Name)
            {
                case "Books":
                    result = new BooksTable(_connectionString);
                    return true;
            }

            result = null;

            return false;
        }
    }
    public class BooksTable(string connectionString)
    {
        private string _connectionString = connectionString;

        private static readonly List<Book> _books = 
        [
            new Book { Title = "Holly Webb Adventures – Book 1" },
            new Book { Title = "The Secret Garden" },
            new Book { Title = "Holly Webb Christmas Special" },
            new Book { Title = "C# in Depth" }
        ];

        public List<dynamic> SearchByTitle(string title)
        {
            // Simulate database search
            return _books
                .Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                .Select(b => (dynamic)b)
                .ToList();
        }
    }

    public class DynamicTypingOps
    {
        public static void ToSubstring()
        {
            dynamic text = "Hello, World!";
            string world = text.Substring(6);

            Console.WriteLine();
            Console.WriteLine("ToSubstring");
            Console.WriteLine($"From {text} to {world}");
        }

        public static void DatabaseAccess(string connectionString)
        {
            // Simulate a database record as a dynamic object
            dynamic database = new Database(connectionString);
            var books = database.Books.SearchByTitle("Holly Webb");
            Console.WriteLine();
            foreach (var book in books)
            {
                Console.WriteLine($"Book Title: {book.Title}");
            }
        }
    }
}
