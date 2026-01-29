using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XmlInActions
{
    public class Book
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int? Year { get; set; }
    }

    public class Resource
    {
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public int? Age { get; set; }
    }

    public class XmlParseOps
    {
        public static List<string> GetTitleFromXML(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return [];
            }

            var xmlFile = XElement.Load(filePath);

            var books = xmlFile.Elements("Book")
                .Select(book => book.Element("Title")?.Value ?? string.Empty)
                .ToList();

            return books;
        }

        public static IEnumerable<Book> GetBooksFromXML(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return [];
            }

            var xmlFile = XElement.Load(filePath);

            var books = from book in xmlFile.Descendants("Book")
                        select new Book
                        {
                            Title = book.Element("Title")?.Value ?? string.Empty,
                            Author = book.Element("Author")?.Value ?? string.Empty,
                            Year = int.TryParse(book.Element("Year")?.Value, out var year) ? year : null
                        };

            return books;
        }

        public static List<Resource> GetAllResourcesFromXML(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return [];
            }

            var xmlFile = XElement.Load(filePath);

            //var resources = from r in xmlFile.Descendants("resource")
            //                select new
            //                {
            //                    Name = r.Elements("field")
            //                            .FirstOrDefault(e => (string?)e.Attribute("name") == "name")?.Value ?? string.Empty,
            //                    UserName = r.Elements("field")
            //                                .FirstOrDefault(e => (string?)e.Attribute("name") == "username")?.Value ?? string.Empty,
            //                    Age = r.Elements("field")
            //                           .FirstOrDefault(e => (string?)e.Attribute("name") == "age")?.Value ?? string.Empty
            //                };

            var resources = xmlFile.Descendants("resource")
                            .Select (r => new Resource
                            {
                                Name = r.Elements("field")
                                        .FirstOrDefault(e => (string?)e.Attribute("name") == "name")?.Value ?? string.Empty,
                                UserName = r.Elements("field")
                                            .FirstOrDefault(e => (string?)e.Attribute("name") == "username")?.Value ?? string.Empty,
                                Age = int.Parse(r.Elements("field")
                                       .FirstOrDefault(e => (string?)e.Attribute("name") == "age")?.Value ?? string.Empty)
                            }).ToList();

            foreach (var resource in resources)
            {
                Console.WriteLine($"Name: {resource.Name}, UserName: {resource.UserName}, Age: {resource.Age}");
            }

            return resources;
        }
    }
}
