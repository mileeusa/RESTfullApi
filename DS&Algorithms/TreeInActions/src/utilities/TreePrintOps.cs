using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src.model;

namespace TreeInActions.src.utilities
{
    public class TreePrintOps
    {
        public static void PrintTreeByLevel(TreeNode? root)
        {
            if (root == null)
            {
                return;
            }

            Queue<TreeNode> queue = [];
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var node = queue.Dequeue();
                    Console.Write(node.val + " ");

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }

                Console.WriteLine();                
            }
        }
    }
}
