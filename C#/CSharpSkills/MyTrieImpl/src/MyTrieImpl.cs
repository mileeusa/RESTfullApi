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
    }
}
