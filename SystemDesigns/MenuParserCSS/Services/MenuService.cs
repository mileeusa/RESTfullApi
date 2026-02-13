using MenuParserCSS.Model;

namespace MenuParserCSS.Services
{
    public class MenuService : IMenuService
    {
        private readonly RestaurantMenu _menu = new RestaurantMenu();

        public void AddDish(int dishId, string dishName, decimal basePrice)
        {
            if (_menu.Categories
                .SelectMany(x => x.Dishes)
                .Where(d => d.DishId == dishId)
                .Any())
            {
                return;
            }

            var dish = new Dish
            {
                DishId = dishId,
                DishName = dishName,
                BasePrice = basePrice
            };

            // TBD
        }

        public void AddCategory(int categoryId, string categoryName)
        {
            if (!_menu.Categories.Any(x => x.CategoryId == categoryId))
            {
                var category = new Category
                {
                    CategoryId = categoryId,
                    CategoryName = categoryName,
                };
                _menu.Categories.Add(category);
            }
        }

        public void AddDishToCategory(int dishId, int categoryId)
        {
            var category = _menu.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (category == null)
            {
                return;
            }

            var dish = _menu.Categories
                .SelectMany(x => x.Dishes)
                .Where(x => x.DishId == dishId)
                .FirstOrDefault();

            if ( dish != null)
            {
                if (!category.Dishes.Any(d => d.DishId == dishId))
                {
                    category.Dishes.Add(dish);
                }
            }


        }
        public void AddOption(int dishId, int optionId, decimal price)
        {
            var dish = _menu.Categories
                .SelectMany(c => c.Dishes)
                .FirstOrDefault(d => d.DishId == dishId);

            if (dish == null || dish.Options.Any(o => o.OptionId == optionId))
            {
                return;
            }

            dish.Options.Add(new Option
            {
                OptionId = optionId,
                AdditionalPrice = price
            });
        }


        public RestaurantMenu GetRestaurantMenu()
        {
            return _menu;
        }
    }
}
