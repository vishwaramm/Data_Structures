using System;
using System.Collections.Generic;
using System.Text;

namespace Vish.DataStructures.Models
{
    /// <summary>
    /// Trie data structure to efficiently get prefixes of strings. 
    /// Got its name from the 'trie' in the word retrieval
    /// </summary>
    public class Trie
    {
        private TrieNode m_root;
        private int m_count;

        public Trie()
        {
            m_root = new TrieNode('^', 0, null);
            m_count = 0;
        }

        public int EntryCount
        {
            get
            {
                return m_count;
            }
        }

        /// <summary>
        /// Get prefix of the specified string. Runtime O (m) m = number of characters in s
        /// </summary>
        /// <returns>The prefix.</returns>
        /// <param name="s">S.</param>
        public TrieNode Prefix(string s)
        {
            var current = m_root;
            var result = current;

            foreach (char c in s)
            {
                current = current.FindChild(c);

                if (current == null)
                    break;

                result = current;
            }

            return result;
        }

        /// <summary>
        /// Search the specified s. Runtime O(m)
        /// </summary>
        /// <returns>The search.</returns>
        /// <param name="s">S.</param>
        public bool Search(string s)
        {
            var prefix = Prefix(s);
            return prefix.Depth == s.Length && prefix.FindChild('$') != null;
        }

        public List<string> StartsWith(string s)
        {
            List<string> results = new List<string>();

            var prefix = Prefix(s);

            if (prefix.Value == '^') //equals root
            {
                //no match
                return results;
            }

            Traverse(prefix, s.Substring(0, s.Length-1), "", results);

            return results;
        }

        protected void Traverse(TrieNode node, string prefix, string word, List<string> result)
        {
            if (node.Value == '$' || node == null)
            {
                result.Add(prefix + word);
                return;
            }

            word += node.Value;

            foreach (var kvp in node.Children)
            {
                Traverse(kvp.Value, prefix, word, result);
            }
        }



        /// <summary>
        /// Insert the specified string. Runtime O(m) m = number of characters in s
        /// </summary>
        /// <param name="s">S.</param>
        public void Insert(string s)
        {
            var prefix = Prefix(s);
            var current = prefix;

            for (int i = prefix.Depth; i < s.Length; i++)
            {
                var node = new TrieNode(s[i], current.Depth + 1, current);
                current.Children.Add(s[i], node);
                current = node;
            }

            if (!current.Children.ContainsKey('$'))
            {
                //End of string
                current.Children.Add('$', new TrieNode('$', current.Depth + 1, current));
                m_count++;
            }
        }

        /// <summary>
        /// Delete the specified string. Runtime O(m)
        /// </summary>
        /// <param name="s">S.</param>
        public void Delete(string s)
        {
            var prefix = Prefix(s);

            if (prefix.Depth == s.Length)
            {
                var current = prefix;
                current.DeleteChild('$');

                for (int i = s.Length - 1; i >= 0; i--)
                {
                    if (current.IsLeaf())
                    {
                        if (current.Parent != null)
                        {
                            current.Parent.DeleteChild(s[i]);
                            current = current.Parent;
                        }
                    }
                }

                m_count--;
            }
        }
    }

    public class TrieNode
    {
        public char Value { get; set; }

        public int Depth { get; set; }

        public TrieNode Parent { get; set; }

        public Dictionary<char, TrieNode> Children { get; set; }

        public TrieNode(char value, int depth, TrieNode parent)
        {
            Value = value;
            Depth = depth;
            Parent = parent;
            Children = new Dictionary<char, TrieNode>();
        }

        public bool IsLeaf()
        {
            return Children.Count == 0;
        }

        /// <summary>
        /// Finds the child. Runtime O(1)
        /// </summary>
        /// <returns>The child.</returns>
        /// <param name="c">C.</param>
        public TrieNode FindChild(char c)
        {
            if (Children.ContainsKey(c))
                return Children[c];

            return null;
        }

        /// <summary>
        /// Deletes the child. Runtime O(1)
        /// </summary>
        /// <param name="c">C.</param>
        public void DeleteChild(char c)
        {
            Children.Remove(c);
        }
    }
}
