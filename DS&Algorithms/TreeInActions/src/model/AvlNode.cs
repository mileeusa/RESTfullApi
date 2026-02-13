using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeInActions.src.model
{
    public class AvlNode
    {
        public int Val;
        public AvlNode? Left;
        public AvlNode? Right;
        public int Height;

        public AvlNode(int val)
        {
            Val = val;
            Height = 1;
            Left = null;
            Right = null;
        }
    }
}
