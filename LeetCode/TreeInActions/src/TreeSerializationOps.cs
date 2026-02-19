using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TreeInActions.src.model;

namespace TreeInActions.src
{
    public class TreeSerializationOps
    {
        //
        // Level-Order (BFS) Serialization of binary tree
        // 
        // Time complexity:  O(N)
        // Space complexity: O(N)
        //
        public static string SerializeTree_ByLevel(TreeNode? root)
        {
            var result = new List<string?>();

            var queue = new Queue<TreeNode?>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == null)
                {
                    result.Add(null);
                    continue;
                }

                result.Add(node.val.ToString());
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }

            return string.Join(",", result);
        }

        //
        // Level-Order (BFS) Deserialization of binary tree
        // 
        // Time complexity:  O(N)
        // Space complexity: O(N)
        //
        public static TreeNode? Deserialize_ByLevel(string data)
        {
            if (string.IsNullOrEmpty(data)) return null;

            string[] values = data.Split(',');
            TreeNode root = new(int.Parse(values[0]));

            Queue<TreeNode> queue = [];
            queue.Enqueue(root);

            int idx = 1; // start from children

            while (queue.Count > 0 && idx < values.Length)
            {
                var current = queue.Dequeue();

                // left child
                if (!string.IsNullOrEmpty(values[idx]))
                {
                    current.left = new TreeNode(int.Parse(values[idx]));
                    queue.Enqueue(current.left);
                }

                idx++;

                if (idx < values.Length && !string.IsNullOrEmpty(values[idx]))
                {
                    current.right = new TreeNode(int.Parse(values[idx]));
                    queue.Enqueue(current.right);
                }
                idx++;
            }

            return root;
        }

        public static string SerializeTree_DFS_Iterative(TreeNode? root)
        {
            if (root == null) return "#";

            var stack = new Stack<TreeNode?>();
            stack.Push(root);

            var result = new List<string>();

            while (stack.Count > 0)
            {
                var node = stack.Pop();

                if (node == null)
                {
                    result.Add("#");
                    continue;
                }

                result.Add(node.val.ToString());

                stack.Push(node.right);
                stack.Push(node.left);
            }

            return string.Join(",", result);
        }

        public static TreeNode? DeserializeTree_DFS_Iterative(string data)
        {
            if (string.IsNullOrEmpty(data) || data == "#") return null;

            string[] tokens = data.Split(",");
            var root = new TreeNode(int.Parse(tokens[0]));

            Stack<(TreeNode node, bool visited)> stack = [];
            stack.Push((root, false));

            int idx = 1;

            while (stack.Count > 0)
            {
                var (node, visited) = stack.Pop();

                if (!visited)
                {
                    if (tokens[idx] == "#")
                    {
                        node.left = null;
                        stack.Push((node, true));
                    }
                    else
                    {
                        TreeNode left = new(int.Parse(tokens[idx]));
                        node.left = left;

                        stack.Push((node, true));
                        stack.Push((left, false));
                    }
                    idx++;
                }
                else
                {
                    // parse right child
                    if (tokens[idx] == "#")
                    {
                        node.right = null;
                    }
                    else
                    {
                        TreeNode right = new(int.Parse(tokens[idx]));
                        node.right = right;

                        stack.Push((right, false));
                    }

                    idx++;
                }
            }

            return root;
        }

        //
        // Pre-Order (DFS) Serialization
        //
        //
        public static string SerializeTree_DFS_Recursive(TreeNode? root)
        {
            var sb = new StringBuilder();

            SerializeTreeHelper(root, sb);

            return sb.ToString();
        }

        private static void SerializeTreeHelper(TreeNode? root, StringBuilder sb)
        {
            if (root == null)
            {
                sb.Append("#,");
                return;
            }

            sb.Append(root.val).Append(",");
            SerializeTreeHelper(root.left, sb);
            SerializeTreeHelper(root.right, sb);
        }

        // 
        public static TreeNode? DeserializeTree_DFS_Recursive(string data)
        {
            Queue<string> queue = new(data.Split(","));

            return DeserializeTreeHelper(queue);
        }

        private static TreeNode? DeserializeTreeHelper(Queue<string> queue)
        {
            string value = queue.Dequeue();

            if (value == "#") return null;

            TreeNode node = new(int.Parse(value));

            node.left = DeserializeTreeHelper(queue);
            node.right = DeserializeTreeHelper(queue);

            return node;
        }
    }
}
