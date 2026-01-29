using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuParserCSS.Model
{
    public class Dish
    {
        public int DishId { get; set; }
        public required string DishName { get; set; } = string.Empty;
        public decimal BasePrice { get; set; }
        public List<Option> Options { get; set; } = new List<Option>();
    }
}
