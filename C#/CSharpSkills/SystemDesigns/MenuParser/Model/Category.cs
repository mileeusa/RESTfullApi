using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuParser.Model
{
    public class Category
    {
        public string Name { get; set; }
        public List<Dish> MenuItems { get; set; } = new List<Dish>();
    }
}
