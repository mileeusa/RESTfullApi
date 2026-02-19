using System;
using System.Collections.Generic;
using System.Text;

namespace MyTrieInActions.src
{
    public class TrieNode
    {
        public TrieNode[] Children = new TrieNode[26];
        public bool IsEndOfWord;
    }

    //
    // LeetCode 208. Implement Trie (Prefix Tree)
    //
    public class Trie
    {
        private readonly TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
        {
            TrieNode node = root;

            foreach (char c in word)
            {
                int index = c - 'a';
                if (node.Children[index] == null)
                {
                    node.Children[index] = new TrieNode();
                }
                node = node.Children[index];
            }

            node.IsEndOfWord = true;
        }

        public bool Search(string word)
        {
            TrieNode node = FindNode(word);
            return node != null && node.IsEndOfWord;
        }

        public bool StartsWith(string prefix)
        {
            return FindNode(prefix) != null;
        }

        private TrieNode FindNode(string str)
        {
            TrieNode node = root;

            foreach (char c in str)
            {
                int index = c - 'a';
                if (node.Children[index] == null)
                {
                    return null;
                }
                node = node.Children[index];
            }

            return node;
        }

        // ==========================
        // DELETE
        // ==========================
        public void Delete(string word)
        {
            Delete(root, word, 0);
        }

        private bool Delete(TrieNode node, string word, int index)
        {
            if (node == null) return false;

            if (index == word.Length)
            {
                if (!node.IsEndOfWord)
                    return false;

                node.IsEndOfWord = false;

                return IsEmpty(node);
            }

            int idx = word[index] - 'a';
            var child = node.Children[idx];

            if (child == null)
                return false;

            bool shouldDeleteChild = Delete(child, word, index + 1);

            if (shouldDeleteChild)
            {
                // Only delete this node if it’s not the end of another word
                // and it has no children
                //
                node.Children[idx] = null;
                return !node.IsEndOfWord && IsEmpty(node);
            }

            return false;
        }

        private bool IsEmpty(TrieNode node)
        {
            for (int i = 0; i < 26; i++)
            {
                if (node.Children[i] != null)
                    return false;
            }

            return true;
        }
    }
}
