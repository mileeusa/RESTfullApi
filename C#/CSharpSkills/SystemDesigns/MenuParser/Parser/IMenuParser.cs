using MenuParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuParser.Parser
{
    public interface IMenuParser
    {
        public RestaurantGroup Parse(string data);
    }
}
