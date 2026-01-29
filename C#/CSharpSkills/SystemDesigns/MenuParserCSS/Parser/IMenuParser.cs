using MenuParserCSS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuParserCSS.Parser
{
    public interface IMenuParser
    {
        void Parse(IEnumerable<string> lines);
    }
}
