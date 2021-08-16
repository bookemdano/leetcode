using System;
using System.Collections.Generic;
using System.IO;
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
            Dessert.AssertSame(2, c.LengthOfLongestSubstring("abba"));
            Dessert.AssertSame(3, c.LengthOfLongestSubstring("abcabcbb"));
            Dessert.AssertSame(3, c.LengthOfLongestSubstring("abcb"));
            Dessert.AssertSame(9, c.LengthOfLongestSubstring("danielefrancis"));
            Dessert.AssertSame(1, c.LengthOfLongestSubstring("bbbbb"));
            Dessert.AssertSame(6, c.LengthOfLongestSubstring("abadefg"));
            Dessert.AssertSame(2, c.LengthOfLongestSubstring("au"));
            Dessert.AssertSame(3, c.LengthOfLongestSubstring("pwwkew"));
            Dessert.AssertSame(3, c.LengthOfLongestSubstring("dvdf"));
            var txt = File.ReadAllText("assets//input20210815.txt");
            Dessert.AssertSame(86, c.LengthOfLongestSubstring(txt.Substring(0, 1000)));
        }
        public int LengthOfLongestSubstring(string s)
        {
            var chars = new Dictionary<char, List<int>>();
            var length = s.Length;
            for (int i = 0; i < length; i++)
            {
                var c = s[i];
                if (!chars.ContainsKey(c))
                    chars.Add(c, new List<int>());
                chars[c].Add(i);
            }
            return RLOLS(chars, s, 0);
            /*
            var minGap = length;
            foreach (var kvp in chars)
            {
                var c = kvp.Key;
                int maxGap = 0;
                if (kvp.Value.Count() == 1)
                    maxGap = length;
                else
                {
                    maxGap = chars[c][1];
                    var last = chars[c][chars[c].Count() - 2];
                    var gap = length - (last + 1);
                    if (gap > maxGap)
                        maxGap = gap;

                }
                if (maxGap < minGap)
                    minGap = maxGap;
            }
            return minGap;
            */
        }
        int RLOLS(Dictionary<char, List<int>> chars, string s, int gCur)
        {
            var length = s.Length;
            for (int iCur = 0; iCur < length; iCur++)
            {
                var c = s[iCur];
                var ints = chars[c];
                var gNextDup = ints.FirstOrDefault(i => i > gCur + iCur && i < gCur + length);
                if (gNextDup != 0)
                {
                    var iNextDup = gNextDup - gCur;
                    //var left = iNextDup;
                    var left = RLOLS(chars, s.Substring(0, iNextDup), gCur);

                    //var gNextDupEnd = ints.FirstOrDefault(i => i > gNextDup);
                    //if (gNextDupEnd == 0)
                    //    gNextDupEnd = length;
                    var maxRight = length - (iCur + 1);
                    if (left >= maxRight)
                        return left;
                    var right = RLOLS(chars, s.Substring(iCur + 1, maxRight), gCur + iCur + 1);
                    if (right > left)
                        return right;
                    else
                        return left;
                }
            }
            return length;       
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
