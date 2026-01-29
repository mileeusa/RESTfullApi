using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src.model;

namespace TreeInActions.src
{
    public class BinaryTreeAncestorOps
    {
        //
        // Given a binary tree, find the lowest common ancestor (LCA) of two given
        // nodes in the tree.
        //
        // According to the definition of LCA on Wikipedia: “The lowest common
        // ancestor is defined between two nodes p and q as the lowest node
        // in T that has both p and q as descendants(where we allow a node
        // to be a descendant of itself).”
        //
        // LeetCode 236. Lowest Common Ancestor of a Binary Tree
        //
        // Time:  O(N)
        // Space: O(1)
        //
        // Note: No ordering property for binary tree, so you need search both trees
        // 
        // Recursive idea
        // If root == null, return null
        // If root == p or root == q, return root
        // Recurse left & right
        //   -- If both return non-null → root is LCA
        //   -- Else return the non-null one
        //
        public static TreeNode? LowestCommonAncestor(TreeNode? root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q) return root;

            var left = LowestCommonAncestor(root.left, p, q);
            var right = LowestCommonAncestor(root.right, p, q);

            if (left != null && right != null)
                return root;

            return left == null ? right : left;
        }

        //
        // Core idea
        //   1. Do a DFS/BFS to record parent[node]
        //   2. Stop once both p and q are found
        //   3. Store all ancestors of p in a set
        //   4. Walk q upward until it hits an ancestor of p
        //
        public static TreeNode? LowestCommonAncestor_Iterative(TreeNode? root, TreeNode? p, TreeNode? q)
        {
            if (root == null) return null;

            var parent = new Dictionary<TreeNode, TreeNode?>();
            var stack = new Stack<TreeNode>();

            parent[root] = null;
            stack.Push(root);

            while (!parent.ContainsKey(p) || !parent.ContainsKey(q))
            {
                var node = stack.Pop();

                if (node.left != null)
                {
                    parent[node.left] = node;
                    stack.Push(node.left);
                }

                if (node.right != null)
                {
                    parent[node.right] = node;
                    stack.Push(node.right);
                }
            }

            var ancestor = new HashSet<TreeNode>();
            while (p != null)
            {
                ancestor.Add(p);
                p = parent.TryGetValue(p, out var parentNode) ? parentNode : null;
            }

            while (!ancestor.Contains(q))
            {
                ancestor.Add(q);
                q = parent.TryGetValue(q, out var parentNode) ? parentNode : null;
            }

            return q;
        }
    }
}
