using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuParser.Parser
{
    public static class MenuParserFactory
    {
        public static IMenuParser GetParser(string format)
        {
            return format.ToLower() switch
            {
                "json" => new JsonMenuParser(),
                "csv" => new csvMenuParser(),
                _ => throw new ArgumentException()
            };
        }
    }
}
