using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src.model;

namespace TreeInActions.src
{
    public class BalanceOps
    {
        public static bool IsBalanced(TreeNode root)
        {
            //return GetTreeHeight(root) != -1;
            //return GetTreeHeight_IterativeOne(root) != -1;
            return GetTreeHeight_IterativeTwo(root) != -1;
        }

        public static int GetTreeHeight(TreeNode? node)
        {
            if (node == null) return 0;

            int left = GetTreeHeight(node.left);
            int right = GetTreeHeight(node.right);
            
            if (left == -1 || right == -1 || Math.Abs(left - right) > 1)
            {
                return -1; // Current node is not balanced
            }

            return Math.Max(left, right) + 1;
        }

        // Iterative approach to determine if a binary tree is height-balanced
        //
        // Time complexity: O(n)
        // Space complexity: O(n)
        //
        // the height of a node depends on its children, the iterative version must still do a postorder traversal!!!
        //
        public static int GetTreeHeight_IterativeOne(TreeNode? root)
        {
            if (root == null) return 0;

            var stack = new Stack<(TreeNode, bool)>();
            var heightMap = new Dictionary<TreeNode, int>();

            stack.Push((root, false));

            while (stack.Count > 0)
            {
                var (node, visited) = stack.Pop();

                if (!visited)
                {
                    stack.Push((node, true));

                    if (node.right != null)
                    {
                        stack.Push((node.right, false));
                    }

                    if (node.left != null)
                    {
                        stack.Push((node.left, false));
                    }
                }
                else
                {
                    int leftHeight = node.left != null && heightMap.ContainsKey(node.left) ? heightMap[node.left] : 0;
                    int rightHeight = node.right != null && heightMap.ContainsKey(node.right) ? heightMap[node.right] : 0;

                    if (leftHeight == -1 || rightHeight == -1 || Math.Abs(leftHeight - rightHeight) > 1)
                    {
                        return -1; // Tree is not balanced
                    }

                    heightMap[node] = Math.Max(leftHeight, rightHeight) + 1;
                }
            }

            return heightMap[root];
        }

        public static int GetTreeHeight_IterativeTwo(TreeNode? root)
        {
            if (root == null) return 0;
            
            var s1 = new Stack<TreeNode>();
            var s2 = new Stack<TreeNode>();
            var heightMap = new Dictionary<TreeNode, int>();

            s1.Push(root);
            while (s1.Count > 0)
            {
                var node = s1.Pop();
                s2.Push(node);

                if (node.left != null)
                {
                    s1.Push(node.left);
                }
                if (node.right != null)
                {
                    s1.Push(node.right);
                }
            }

            while (s2.Count > 0)
            {
                var node = s2.Pop();

                int leftHeight = node.left != null && heightMap.ContainsKey(node.left) ? heightMap[node.left] : 0;
                int rightHeight = node.right != null && heightMap.ContainsKey(node.right) ? heightMap[node.right] : 0;

                if (leftHeight == -1 || rightHeight == -1 || Math.Abs(leftHeight - rightHeight) > 1)
                {
                    return -1; // Tree is not balanced
                }

                heightMap[node] = Math.Max(leftHeight, rightHeight) + 1;
            }

            return heightMap[root];
        }
    }
}
