using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TreeInActions.src.model;

namespace TreeInActions.src
{
    public class BinarySearchTreeAncestorOps
    {
        // Calculate the lowest common ancestor in binary search tree (BST)
        // 
        // A Binary Search Tree (BST) is a type of binary tree data structure in which each node contains a unique
        // key and satisfies a specific ordering property:
        //
        //   -- All nodes in the left subtree of a node contain values strictly less than the node’s value.
        //   -- All nodes in the right subtree of a node contain values strictly greater than the node’s value.
        // 
        // Time: O(h), where h is the height of the tree, i.e.
        //                  O(log n) for balanced BST and O(n) for skewed BST.
        //
        // Space: space comes from recursive stack depth, O(log n) for balanced BST and O(n) for skewed BST
        // 
        public static TreeNode? LowestCommonAncestor_BST(TreeNode? root, TreeNode p, TreeNode q)
        {
            if (root == null) return null;

            if (root.val > p.val && root.val > q.val)
            {
                return LowestCommonAncestor_BST(root.left, p, q);
            }
            else if (root.val < p.val && root.val < q.val)
            {
                return LowestCommonAncestor_BST(root.right, p, q);
            }
            else
            {
                return root;
            }
        }

        // 
        // Time:  O(h), where h is the height of the tree, i.e. O(log n) for balanced BST and O(n) for skewed BST.
        //
        // Space: iterative approach uses constant space, no recursive stack, just a few pointers (root, p, q).
        //                   i.e. O(1)
        //
        public static TreeNode? LowestCommonAncestor_BST_Iterative(TreeNode? root, TreeNode p, TreeNode q)
        {
            while (root != null)
            {
                if (root.val > p.val && root.val > q.val)
                {
                    root = root.left;
                }
                else if (root.val < p.val && root.val < q.val)
                {
                    root = root.right;
                }
                else
                {
                    return root;
                }
            }

            return null;
        }
    }
}
