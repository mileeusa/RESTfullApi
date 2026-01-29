using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuParser.Model
{
    public class Resturant
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Menu> Menus { get; set; }
    }
}
