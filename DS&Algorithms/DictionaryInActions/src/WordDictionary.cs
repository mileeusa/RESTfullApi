using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryInActions.src
{
    class TrieNode
    {
        public TrieNode[] Children = new TrieNode[26];
        public bool IsWord;
    }

    // 
    // Leet 211. Design Add and Search Words Data Structure
    //
    // // TBD
    //
    public class WordDictionary
    {
        private readonly TrieNode root;

        public WordDictionary()
        {
            root = new TrieNode();
        }

        public void AddWord(string word)
        {
            TrieNode node = root;
            foreach (char c in word)
            {
                int idx = c - 'a';
                if (node.Children[idx] == null)
                    node.Children[idx] = new TrieNode();

                node = node.Children[idx];
            }
            node.IsWord = true;
        }

        public bool Search(string word)
        {
            return Dfs(word, 0, root);
        }

        private bool Dfs(string word, int index, TrieNode node)
        {
            if (node == null) return false;
            if (index == word.Length)
                return node.IsWord;

            char c = word[index];

            if (c == '.')
            {
                foreach (var child in node.Children)
                {
                    if (child != null && Dfs(word, index + 1, child))
                        return true;
                }
                return false;
            }
            else
            {
                int idx = c - 'a';
                return Dfs(word, index + 1, node.Children[idx]);
            }
        }
    }
}
