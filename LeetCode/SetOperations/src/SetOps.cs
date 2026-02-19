using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetInActions
{
    public class SetOps
    {
        public static void RemoveWhere(HashSet<int> numbers, int val)
        {
            numbers.RemoveWhere(x => x < val);
        }
    }
}
