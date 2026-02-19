using GraphInActions.src.model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GraphInActions.src
{
    // 
    public class AnountOfTimeToBeInfected
    {
        // 
        // You are given the root of a binary tree with unique values, and an
        // integer start. At minute 0, an infection starts from the node
        // with value start.
        //
        // Each minute, a node becomes infected if:
        //   The node is currently uninfected.
        //   The node is adjacent to an infected node.
        //
        // Return the number of minutes needed for the entire tree to be infected.
        //
        // LeetCode 2385. Amount of Time for Binary Tree to Be Infected
        //
        public static int AmountOfTime(TreeNode root, int start)
        {
            var graph = new Dictionary<int, List<int>>();
            BuildGraph(root, null, graph);

            Queue<int> queue = [];

            var visited = new HashSet<int>();
            visited.Add(start);
            queue.Enqueue(start);

            int minutes = -1;

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    int curNode = queue.Dequeue();

                    if (!graph.ContainsKey(curNode)) continue;

                    foreach (var neighbor in graph[curNode])
                    {
                        // Remove Contains check, just call Add and check return value
                        if (visited.Add(neighbor))
                        {
                            queue.Enqueue(neighbor);
                        }
                    }
                }

                minutes++;
            }

            return minutes;
        }

        public static void BuildGraph(TreeNode? node, TreeNode? parent, Dictionary<int, List<int>> graph)
        {
            if (node == null) return;

            if (!graph.ContainsKey(node.val))
            {
                graph[node.val] = []; // new List<int>();
            }

            if (parent != null)
            {
                graph[node.val].Add(parent.val);
                graph[parent.val].Add(node.val);
            }

            BuildGraph(node.left, node, graph);
            BuildGraph(node.right, node, graph);
        }

        public static void AmountOfTime_Test()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(5);
            root.left.right = new TreeNode(4);
            root.left.right.left = new TreeNode(9);
            root.left.right.right = new TreeNode(24);
            root.right = new TreeNode(3);
            root.right.left = new TreeNode(10);
            root.right.right = new TreeNode(6);
            int start = 3;
            Console.WriteLine();
            Console.WriteLine("AnountOfTimeToBeInfected.AmountOfTime()");
            int result = AmountOfTime(root, start);
            Console.WriteLine(result); // Expected output: 4
        }
    }
}
