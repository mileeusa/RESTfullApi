using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryInActions.src.model
{
    public class CaseInsensitiveCharComparer : IEqualityComparer<char>
    {
        public bool Equals(char x, char y) => char.ToUpperInvariant(x) == char.ToUpperInvariant(y);

        public int GetHashCode(char c) => char.ToUpperInvariant(c).GetHashCode();
    }
}
