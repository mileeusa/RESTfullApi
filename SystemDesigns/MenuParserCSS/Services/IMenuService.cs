using MenuParserCSS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuParserCSS.Services
{
    public interface IMenuService
    {
        void AddDish(int dishId, string dishName, decimal basePrice);
        void AddCategory(int categoryId, string categoryName);
        void AddDishToCategory(int dishId, int categoryId);
        void AddOption(int dishId, int optionId, decimal price);

        RestaurantMenu GetRestaurantMenu();
    }
}
