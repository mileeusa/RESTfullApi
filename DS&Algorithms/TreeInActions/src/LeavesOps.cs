using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src.model;

namespace TreeInActions.src
{
    public class LeavesOps
    {
        public static bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            if (root1 == null || root2 == null) return false;

            var list1 = new List<int>();
            var list2 = new List<int>();

            DFS(root1, list1);
            DFS(root2, list2);

            if (list1.Count != list2.Count) return false;

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i])
                    return false;
            }

            return true;
        }

        private static void DFS(TreeNode? root, List<int> leaves)
        {
            if (root == null) return;

            if (root.left == null && root.right == null)
            {
                leaves.Add(root.val);
                return;
            }

            DFS(root.left, leaves);
            DFS(root.right, leaves);
        }
    }
}
