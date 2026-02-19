using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src.model;

namespace TreeInActions.src
{
    public class TraverseTree
    {
        // Preorder tree trversal using STACK
        //
        // root -> left -> right
        //
        public static IList<TreeNode> PreOrderTraverse_Iterative(TreeNode? root)
        {
            List<TreeNode> result = [];

            if (root == null)
            {
                return result;
            }

            var stack = new Stack<TreeNode>(); ;
            stack.Push(root);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                result.Add(current);

                if (current.right != null)
                    stack.Push(current.right);

                if (current.left != null)
                    stack.Push(current.left);
            }

            return result;
        }

        // Inorder tree trversal using STACK
        //
        // left -> root -> right
        //
        // Time Complexcity: O(N)
        // Space complexity: O(h) <-- O(LogN) for balanced tree, O(N) for skewed
        //
        public static IEnumerable<TreeNode> InOrderTraversal_Iterative(TreeNode? root)
        {
            if (root == null)
            {
                return [];
            }

            var result = new List<TreeNode>();
            var stack = new Stack<TreeNode>();
            TreeNode? current = root;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                current = stack.Pop();
                result.Add(current);

                current = current.right;
            }

            return result;
        }

        //
        // We want to generate postorder:
        //
        //   Left → Right → Root
        //
        // But iteratively and with only one stack.
        //
        // This is the trickiest DFS traversal because you must process a node only after its left and
        // right subtrees are fully processed.
        //
        public static IList<TreeNode> PostOrderTraversal_Iterative(TreeNode? root)
        {
            List<TreeNode> result = [];

            if (root == null)
            {
                return result;
            }

            Stack<TreeNode> stack = [];
            TreeNode? current = root;
            TreeNode? prev = null;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }

                var node = stack.Peek();

                if (node.right == null || node.right == prev)
                {
                    stack.Pop();
                    result.Add(node);
                    prev = node;
                }
                else
                {
                    current = node.right;
                }
            }

            return result;
        }

        //
        // binary tree traversal layer by layer (Queue)
        //
        public static IList<IList<int>> TreeTraversal_ByLayer(TreeNode? root)
        {
            IList<IList<int>> result = [];

            if (root == null)
            {
                return result;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                List<int> currentLevel = [];

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode currentNode = queue.Dequeue();
                    currentLevel.Add(currentNode.val);
                    if (currentNode.left != null)
                    {
                        queue.Enqueue(currentNode.left);
                    }
                    if (currentNode.right != null)
                    {
                        queue.Enqueue(currentNode.right);
                    }
                }
                result.Add(currentLevel);
            }
            return result;
        }

        //
        // binary tree traversal layer by layer (BFS)
        //
        public static IList<int> TreeTraversal_ByLevel(TreeNode? root)
        {
            IList<int> result = [];
            if (root == null)
            {
                return result;
            }

            Queue<TreeNode> queue = [];
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                result.Add(node.val);

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            return result;
        }

        // root -> left -> right
        public static void PreOrderTraversal_Recursive(TreeNode? root, List<int> result)
        {
            if (root == null) return;

            result.Add(root.val);
            PreOrderTraversal_Recursive(root.left, result);
            PreOrderTraversal_Recursive(root.right, result);
        }

        // left -> root -> right
        public static void InOrderTraversal_Recursive(TreeNode? root, List<TreeNode> res)
        {
            if (root == null) return;

            InOrderTraversal_Recursive(root.left, res);
            res.Add(root);
            InOrderTraversal_Recursive(root.right, res);
        }

        // left -> right -> root
        public static void PostOrderTraversal_Recursive(TreeNode? root, List<int> res)
        {
            if (root == null) return;
            
            PostOrderTraversal_Recursive(root.left, res);
            PostOrderTraversal_Recursive(root.right, res);
            res.Add(root.val);
        }
    }
}
