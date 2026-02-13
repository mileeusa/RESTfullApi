using MenuParser.Parser;

namespace MenuParser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IMenuParser parser = MenuParserFactory.GetParser("json");
            var groupOne = parser.Parse(Properties.Resources.JsonData);

            Console.WriteLine($"Restaurant Group: {groupOne.Name}");
            foreach (var r in groupOne.Restaurants)
            {
                Console.WriteLine($"  Restaurant: {r.Name} ({r.Location})");
                foreach (var menu in r.Menus)
                {
                    Console.WriteLine($"    Menu: {menu.Name}");
                    foreach (var category in menu.Categories)
                    {
                        Console.WriteLine($"      Category: {category.Name}");
                        foreach (var item in category.MenuItems)
                        {
                            Console.WriteLine($"        {item.Name} - {item.BasePrice:C}");
                        }
                    }
                }
            }

            var csvMenuParser = MenuParserFactory.GetParser("csv");

            var groupTwo = csvMenuParser.Parse(Properties.Resources.MenuItem_txt);

            Console.WriteLine($"Restaurant Group: {groupTwo.Name}");
            foreach (var r in groupTwo.Restaurants)
            {
                Console.WriteLine($"  Restaurant: {r.Name} ({r.Location})");
                foreach (var menu in r.Menus)
                {
                    Console.WriteLine($"    Menu: {menu.Name}");
                    foreach (var category in menu.Categories)
                    {
                        Console.WriteLine($"      Category: {category.Name}");
                        foreach (var item in category.MenuItems)
                        {
                            Console.WriteLine($"        {item.Name} - {item.BasePrice:C}");
                        }
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
