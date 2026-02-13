using MenuParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MenuParser.Parser
{
    public class JsonMenuParser : IMenuParser
    {
        public RestaurantGroup Parse (string jsonFile)
        {
            return System.Text.Json.JsonSerializer.Deserialize<RestaurantGroup>(jsonFile);
        }
    }
}
