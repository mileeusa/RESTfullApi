using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuParser.Model
{
    public class RestaurantGroup
    {
        public string Name { get; set; }
        public List<Resturant> Restaurants { get; set; }
    }
}
