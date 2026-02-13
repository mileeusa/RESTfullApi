using MenuParserCSS.Parser;
using MenuParserCSS.Services;
using System.ComponentModel;

namespace MenuParserCSS
{
    public class Program
    {
        public static void Main(string[] args)
        {            

            MenuService menuService = new MenuService();
            MenuParser menuParser = new MenuParser(menuService);

            IEnumerable<string> lines = File.ReadAllLines("Files\\Menu.txt");

            menuParser.Parse(lines);
        }
    }
}
