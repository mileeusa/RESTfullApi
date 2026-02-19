using System;
using TreeInActions.src.model;

namespace TreeInActions.src
{
    public class RemoveNodeOps
    {
        // 
        // Given a root node reference of a BST and a key, delete the node with
        // the given key in the BST. Return the root node
        // reference (possibly updated) of the BST.
        //
        // Basically, the deletion can be divided into two stages:
        //   Search for a node to remove.
        //   If the node is found, delete the node.
        //
        // LeetCode: 450 Delete Node in a BST
        //
        // Time complexity:  O(logN)
        // Space complexity: O(H) to keep the recursion stack, where H is a tree height.
        //        H=logN for the balanced tree.
        //
        public static TreeNode? DeleteNode(TreeNode root, int key)
        {
            if (root == null) return null;

            TreeNode? parent = null;
            TreeNode? curr = root;

            // search the target
            while (curr != null && curr.val != key) {
                parent = curr;
                curr = (curr.val > key) ? curr.left : curr.right;
            }

            if (curr == null) return root;

            //
            // handle both left and right node are not NULL
            //
            if (curr.left != null && curr.right != null) {
                // find the smallest node in the right subtree
                var succParent = curr;
                var succ = curr.right;

                while (succ.left != null) {
                    succParent = succ;
                    succ = succ.left;
                }

                curr.val = succ.val;

                // now delete succ (which is guranteed to have <= 1 child!!!)
                curr = succ;
                parent = succParent;
            }

            // handle 0 or 1 child
            TreeNode? child = (curr.left != null) ? curr.left : curr.right;

            if (parent == null)
                return child;

            if (parent.left == curr) {
                parent.left = child;
            }
            else {
                parent.right = child;
            }

            return root;
        }
    }
}
