using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuParserCSS.Model
{
    public class Option
    {
        public int OptionId { get; set; }
        public string OptionName { get; set; } = string.Empty;
        public decimal AdditionalPrice { get; set; }
    }
}
