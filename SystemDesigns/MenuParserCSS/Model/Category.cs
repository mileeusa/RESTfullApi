using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuParserCSS.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; } = string.Empty;
        public List<Dish> Dishes { get; set; } = new List<Dish>();
    }
}
