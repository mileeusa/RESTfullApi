using MenuParserCSS.Model;
using MenuParserCSS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuParserCSS.Parser
{
    public class MenuParser : IMenuParser
    {
        private readonly IMenuService _menuService;

        public MenuParser(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public void Parse(IEnumerable<string> lines)
        {
            var enumerator = lines.GetEnumerator();

            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (string.IsNullOrWhiteSpace(current))
                {
                    continue;
                }

                if (int.TryParse(current, out var id))
                {
                    // look up the current block
                    if (!enumerator.MoveNext())
                    {
                        break;
                    }

                    var type = enumerator.Current?.Trim().ToUpper();

                    switch (type)
                    {
                        case "DISH":
                            ParseDish(id, enumerator);
                            break;

                        case "CaTEGORY":
                            ParseCategory(id, enumerator);
                            break;

                        case "OPTION":
                            ParseOption(id, enumerator);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void ParseDish(int dishId, IEnumerator<string> enumerator)
        {
            if (!enumerator.MoveNext())
            {
                return;                
            }

            var name = enumerator.Current.Trim();

            if (!enumerator.MoveNext() || name.Length == 0)
            {
                return;
            }

            decimal price = decimal.Parse(enumerator.Current ?? "0");

            _menuService.AddDish(dishId, name, price);

            while (enumerator.MoveNext())
            { 
                var current = enumerator.Current?.Trim();
                if (string.IsNullOrWhiteSpace(current))
                {
                    break;
                }

                if (int.TryParse(current, out var optionId))
                {
                    _menuService.AddOption(dishId, optionId, (decimal)0.0);
                }
            }
        }

        private void ParseCategory(int categoryId, IEnumerator<string> enumerator)
        {
            if (!enumerator.MoveNext())
            {
                return;
            }

            var name = enumerator.Current.Trim();
            if (string.IsNullOrWhiteSpace(name) && !enumerator.MoveNext())
            {
                return;
            }

            if (int.TryParse(enumerator.Current.Trim(), out var dishId))
            {
                var dish = _menuService.GetRestaurantMenu().Categories
                    .Where(x => x.CategoryId == categoryId)
                    .SelectMany(d => d.Dishes)
                    .Where(c => c.DishId == dishId)
                    .FirstOrDefault();

                if (dish == null)
                {
                    var category = new Category
                    {
                        CategoryName = name,
                        CategoryId = categoryId,
                    };

                    _menuService.AddDishToCategory(dishId, categoryId);
                }
            }
        }

        private void ParseOption(int optionId, IEnumerator<string> enumerator)
        {
            if (!enumerator.MoveNext())
            {
                return;
            }

            var optionName = enumerator.Current.Trim();

            if (!string.IsNullOrWhiteSpace(optionName) && !enumerator.MoveNext())
            {
                if (decimal.TryParse(enumerator.Current.Trim(), out var additionalPrice))
                {
                    foreach (var dish in _menuService.GetRestaurantMenu().Categories.SelectMany(x => x.Dishes))
                    {
                        var option = dish
                            .Options
                            .Where(x => x.OptionId == optionId)
                            .FirstOrDefault();

                        if (option != null)
                        {
                            dish.Options.Clear();
                            dish.Options.Add(new Option
                            {
                                OptionId = optionId,
                                OptionName = optionName,
                                AdditionalPrice = additionalPrice
                            });
                        }
                    }
                }
            }
        }
    }
}
