using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    class NonRepeatingSubstring
    {
        internal static void Test()
        {
            var c = new NonRepeatingSubstring();
            Dessert.AssertSame(3, c.LengthOfLongestSubstring("dvdf"));
            Dessert.AssertSame(3, c.LengthOfLongestSubstring("pwwkew"));
            Dessert.AssertSame(3, c.LengthOfLongestSubstring("abcabcbb"));
            Dessert.AssertSame(1, c.LengthOfLongestSubstring("bbbbb"));
        }
        public int LengthOfLongestSubstring(string s)
        {
            var edges = new HashSet<Tuple<int, int>>();
            var length = s.Length;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (i == j)
                        continue;
                    if (s[i] == s[j])
                    {
                        edges.Add(new Tuple<int, int>(i, j));
                    }
                }
            }
            var last = 0;
            var maxGap = 0;
            foreach (var edge in edges)
            {
                if (edge.Item1 - last > maxGap)
                    maxGap = edge.Item1 - last;
                last = edge.Item1;
            }
            if (length - last > maxGap)
                maxGap = length - last;

            return maxGap;
        }
    }
    public class Edge
    {
        public Edge(int n1, int n2)
        {
            N1 = n1;
            N2 = n2;
        }

        public int N1 { get; set; }  
        public int N2 { get; set; }
        public override string ToString()
        {
            return $"{N1} to {N2}";
        }
    }
    public class NewTreeNode
    {
        public NewTreeNode(char c)
        {
            _val = c;
        }
        public NewTreeNode Find(char val)
        {
            if (_val == val)
                return this;
            foreach (var child in _children)
            {
                var found = child.Find(val);
                if (found != null)
                    return found;
            }
            return null;
        }
        public override int GetHashCode()
        {
            return _val;
        }

        internal void Add(NewTreeNode newTreeNode)
        {
            if (!_children.Contains(newTreeNode))
                _children.Add(newTreeNode);
        }

        int _depth = 0;
        public override string ToString()
        {
            if (_depth > 20)
                return "...";
            _depth++;
            var rv= $"{_val} ({string.Join("|", _children.Select(c => c.ToString()))})";
            _depth--;
            return rv;
        }
        public char _val { get; set; }
        HashSet<NewTreeNode> _children = new HashSet<NewTreeNode>();
    }
}
