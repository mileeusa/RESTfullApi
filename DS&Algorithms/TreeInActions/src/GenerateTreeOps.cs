using System.Text;
using ListInActions.model;
using TreeInActions.src.model;

namespace TreeInActions.src
{
    public class GenerateTreeOps
    {
        public static TreeNode? GenerateTreeFromArray(int?[] arr)
        {
            if (arr == null || arr.Length == 0 || arr[0] == null)
            {
                return null;
            }

            // arr[0] is guaranteed not null here
            TreeNode root = new TreeNode(arr[0]!.Value);
            Queue<TreeNode> queue = [];
            queue.Enqueue(root);

            int i = 1;
            while (i < arr.Length)
            {
                TreeNode current = queue.Dequeue();

                // Left child
                if (arr[i] != null)
                {
                    current.left = new TreeNode(arr[i]!.Value);
                    queue.Enqueue(current.left);
                }
                i++;

                // Right child
                if (i < arr.Length && arr[i] != null)
                {
                    current.right = new TreeNode(arr[i]!.Value);
                    queue.Enqueue(current.right);
                }
                i++;
            }

            return root;
        }

        public static TreeNode? GenerateTreeFromSortedArray(int?[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return null;
            }

            // here we can have extra step to skil nulls entirely if needed
            var values = arr.Where(x => x.HasValue).Select(x => x.Value).ToArray();

            return BuildBSTFromSortedArray(values, 0, values.Length - 1);
        }

        public static TreeNode? BuildBSTFromSortedArray(int[] arr, int left, int right)
        {
            // Base case
            if (left > right)
            {
                return null;
            }

            // Find the middle element
            int mid = left + (right - left) / 2;

            TreeNode node = new TreeNode(arr[mid]);
            node.left = BuildBSTFromSortedArray(arr, left, mid - 1);
            node.right = BuildBSTFromSortedArray(arr, mid + 1, right);

            return node;
        }

        public static TreeNode? BuildBSTFromSortedList(ListNode? head)
        {
            if (head == null) return null;

            var mid = FindMiddleElement(head);
            TreeNode node = new TreeNode(mid.val);

            if (head == mid)
                return node;

            node.left = BuildBSTFromSortedList(head);
            node.right = BuildBSTFromSortedList(mid.next);

            return node;
        }

        public static TreeNode? BuildBSTFromSortedList_II(ListNode? head)
        {
            var list = SortedLinkedListToArray(head);

            return ConvertListToTree(list, 0, list.Count - 1);
        }

        private static TreeNode? ConvertListToTree(List<int> list, int left, int right)
        {
            if (left > right)
                return null;

            int mid = left + (right - left ) / 2;
            TreeNode node = new TreeNode(list[mid]);

            if (left == right)
                return node;

            node.left = ConvertListToTree(list, left, mid - 1);
            node.right = ConvertListToTree(list, mid + 1, right);

            return node;
        }

        public static List<int> SortedLinkedListToArray(ListNode? head)
        {
            var result = new List<int>();
            while (head != null)
            {
                result.Add(head.val);
                head = head.next;
            }

            return result;
        }

        public static ListNode? FindMiddleElement(ListNode? head)
        {
            ListNode? prev = null;
            var slow = head;
            var fast = head;

            while (fast != null && fast.next != null)
            {
                prev = slow;
                slow = slow?.next;
                fast = fast.next.next;
            }

            if (prev != null)
                prev.next = null;

            return slow;
        }

        //
        // You need to construct a binary tree from a string consisting of parenthesis and integers.
        //
        // The whole input represents a binary tree.It contains an integer followed by zero,
        // one or two pairs of parenthesis.The integer represents the root's value and
        // a pair of parenthesis contains a child binary tree with the same structure.
        //
        // You always start to construct the left child node of the parent first if it exists.
        //
        // Example:
        //
        //            4  
        //          /   \
        //        2      6
        //       / \    /
        //     3    1  5  
        //
        //   Input: s = "4(2(3)(1))(6(5))"
        //   Output: [4, 2, 6, 3, 1, 5]
        //    
        // LeetCode 536. Construct Binary Tree from String
        //
        // Time complexity:  O(N)
        //
        // Difficulty: Medium
        //
        public static TreeNode? Str2tree(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 0)
                return null;

            var stack = new Stack<TreeNode>();
            TreeNode? root = null;

            for (int i = 0; i < s.Length;)
            {
                if (s[i] == ')')
                {
                    stack.Pop();
                    i++;
                }
                else if (s[i] == '(')
                {
                    i++;
                }
                else
                {
                    // number parsing
                    int sign = 1;
                    if (s[i] == '-')
                    {
                        sign = -1;
                        i++;
                    }

                    int num = 0;
                    while (i < s.Length && char.IsDigit(s[i]))
                    {
                        num = num * 10 + (s[i] - '0');
                        i++;
                    }

                    var node = new TreeNode(sign * num);

                    if (stack.Count > 0)
                    {
                        var parent = stack.Peek();
                        if (parent.left == null)
                        {
                            parent.left = node;
                        }
                        else
                        {
                            parent.right = node;
                        }
                    }
                    else
                    {
                        root = node;
                    }

                    stack.Push(node);
                }

            }

            return root;
        }

        public static string Tree2Str(TreeNode root)
        {
            if (root == null) return "";
            var sb = new StringBuilder();
            DFS(root, sb);

            return sb.ToString();
        }

        private static void DFS(TreeNode root, StringBuilder sb)
        {
            if (root == null) return;
            sb.Append(root.val.ToString());

            if (root.left == null && root.right == null)
                return;

            sb.Append("(");
            DFS(root.left, sb);
            sb.Append(")");

            if (root.right != null)
            {
                sb.Append("(");
                DFS(root.right, sb);
                sb.Append(")");
            }
        }

        public static string Tree2Str_Iterative(TreeNode root)
        {
            if (root == null) return "";

            var stack = new Stack<TreeNode>();
            var visited = new HashSet<TreeNode>();

            var sb = new StringBuilder();

            stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Peek();

                if (visited.Contains(node))
                {
                    stack.Pop();
                    sb.Append(")");
                }
                else
                {
                    visited.Add(node);
                    sb.Append("(" + node.val);
                    if (node.left == null && node.right != null)
                    {
                        sb.Append("()");
                    }

                    if (node.right != null)
                    {
                        stack.Push(node.right);
                    }

                    if (node.left != null)
                    {
                        stack.Push(node.left);
                    }
                }
            }

            return sb.ToString(1, sb.Length - 1);
        }
    }
}
