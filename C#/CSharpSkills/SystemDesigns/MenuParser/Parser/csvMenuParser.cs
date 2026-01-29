using MenuParser.Model;
using System.Globalization;
using CsvHelper;

namespace MenuParser.Parser
{
    public class csvMenuParser : IMenuParser
    {
        public RestaurantGroup Parse(string csvFile)
        {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             using var reader = new StringReader(csvFile);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

            var items = csvReader.GetRecords<Dish>().Skip(1).ToList();

            var group = new RestaurantGroup()
            {
                Name = "Imported from CSV",
                Restaurants = new List<Resturant>
                {
                    new Resturant
                    {
                        Name = "Default Restaurant",
                        Location = "Unknown",
                        Menus = new List<Menu>
                        {
                            new Menu
                            {
                                Name = "Imported Menu",
                                Categories = new List<Category>
                                {
                                    new Category
                                    {
                                        Name = "CSV Items",
                                        MenuItems = new List<Dish>
                                        {
                                            new Dish
                                            {
                                                Name = "Waffle",
                                                BasePrice = (decimal)5.99,
                                                Description = "Waffle",
                                                Options = new List<Option>
                                                {
                                                    new Option {
                                                        Name = "Season",
                                                        AdditionalPrice = (decimal)1.99
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            return group;
        }
    }
}
