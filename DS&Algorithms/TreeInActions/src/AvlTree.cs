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
        }

        private AvlNode Delete(AvlNode node, int val)
        {

        }

        private AvlNode RotateRight(AvlNode y)
        {
        }

        private AvlNode RotateLeft(AvlNode x)
        {
        }

        private int Height(AvlNode node)
        {
        }

        private int Balance(AvlNode node)
        {
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
