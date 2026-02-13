namespace XmlInActions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var titles = XmlParseOps.GetTitleFromXML("files\\books.txt");
            foreach (var book in titles)
            {
                Console.WriteLine(book);
            }

            var books = XmlParseOps.GetBooksFromXML("files\\books.txt");
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Year: {book.Year}");
            }

            XmlParseOps.GetAllResourcesFromXML("files\\resources.xml");
        }
    }
}