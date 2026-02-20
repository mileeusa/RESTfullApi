using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src.model;

namespace TreeInActions.src
{
    public interface IAvlTree
    {
        public void Insert(int val);
        public void Delete(int val);
        
    }

    // TBD
    public class AvlTree : IAvlTree
    {
        public void Insert(int val)
        {

        }

        public void Delete(int val)
        {

        }

        private AvlNode Insert(AvlNode node, int val)
        {
            return node;
        }

        private AvlNode Delete(AvlNode node, int val)
        {
            return node;
        }

        private AvlNode RotateRight(AvlNode y)
        {
            return y;
        }

        private AvlNode RotateLeft(AvlNode x)
        {
            return x;
        }

        private int Height(AvlNode node)
        {
            return node.Height;
        }

        private int Balance(AvlNode node)
        {
            return 1;
        }

        private AvlNode MinValueNode(AvlNode node)
        {

            var current = node;
            while (current.Left != null)
                current = current.Left;

            return current;
        }
    }
}
