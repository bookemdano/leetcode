using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace leetcode
{
    class NonRepeatingSubstring
    {
        internal static void Test()
        {
            var c = new NonRepeatingSubstring();
            var sw = Stopwatch.StartNew();
            Dessert.AssertSame(0, c.LengthOfLongestSubstring(""));
            Dessert.AssertSame(3, c.LengthOfLongestSubstring("abcabcbb"));
            Dessert.AssertSame(17, c.LengthOfLongestSubstring("yzcrkylidvgqxebwmubplzxihjlvataasdsfdfngavyyabuowyfhzcpglcdoxeoqjivmnkuofsohti"), $"{sw.Elapsed}");
            
            Dessert.AssertSame(3, c.LengthOfLongestSubstring("abcb"));
            Dessert.AssertSame(9, c.LengthOfLongestSubstring("danielefrancis"));
            Dessert.AssertSame(1, c.LengthOfLongestSubstring("bbbbb"));
            Dessert.AssertSame(6, c.LengthOfLongestSubstring("abadefg"));
            Dessert.AssertSame(2, c.LengthOfLongestSubstring("au"));
            Dessert.AssertSame(3, c.LengthOfLongestSubstring("pwwkew"));
            Dessert.AssertSame(3, c.LengthOfLongestSubstring("dvdf"));
            Dessert.AssertSame(2, c.LengthOfLongestSubstring("abba"));
            var txt = File.ReadAllText("assets//input20210815.txt");
            Dessert.AssertSame(86, c.LengthOfLongestSubstring(txt.Substring(0, 1000)));
        }
        public int LengthOfLongestSubstring(string s)
        {
            if (s == "")
                return 0;
            var chars = new Dictionary<char, List<int>>();
            var length = s.Length;
            for (int i = 0; i < length; i++)
            {
                var c = s[i];
                if (!chars.ContainsKey(c))
                    chars.Add(c, new List<int>());
                chars[c].Add(i);
            }


            var start = 0;
            var end = 1;
            var max = 1;
            while(end < length)
            {
                var sub = s.Substring(start, end - start + 1);
                bool b = IsUnique(s, start, end, chars);
                if (b)
                {
                    var len = end - start + 1;
                    if (len > max)
                        max = len;
                    end++;
                }
                else
                    start++;
            }
            return max;
        }

        private bool IsUnique(string s, int start, int end, Dictionary<char, List<int>> chars)
        {
            for (int i = start; i <= end; i++)
            {
                var c = s[i];
                var subInts = chars[c].Where(i => i >= start && i <= end).ToArray();
                if (subInts.Length > 1)
                    return false;
            }
            return true;

        }

        public int LengthOfLongestSubstring2(string s)
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
            var looper = new Dictionary<string, int>();
            return RLOLS(chars, Sub.Create(0, length - 1, s), 1, looper);
        }
        int RLOLS(Dictionary<char, List<int>> chars, Sub sub, int max, Dictionary<string, int> looper)
        {
            if (looper.ContainsKey(sub.Sz))
                return looper[sub.Sz];
            var length = sub.Length;
            var allSplits = new List<Sub>();
            foreach(var kvp in chars)
            {
                var c = kvp.Key;
                var ints = kvp.Value;
                var splits = GetSplits(ints, sub, max);
                if (splits == null)
                    continue;
                allSplits.AddRange(splits);
            }
            if (!allSplits.Any())
            {
                looper[sub.Sz] = length;
                return looper[sub.Sz];
            }
            foreach (var split in allSplits)
            {
                if (split.Length <= max)
                    continue;
                var val = RLOLS(chars, split, max, looper);
                if (val > max)
                    max = val;
            }
            looper[sub.Sz] = max;
            return looper[sub.Sz];
        }

        private List<Sub> GetSplits(List<int> ints, Sub sub, int max)
        {
            var rv = new List<Sub>();
            var subInts = ints.Where(i => i >= sub.Start && i <= sub.End).ToArray();
            var len = subInts.Count();
            var last = sub.End;
            if (len == 1)
            {
                return null;
                //rv.Add(Sub.Create(0, last, s));
            }

            for (int i = 0; i < len; i++)
            {
                int prev = 0;
                if (i >= 1)
                    prev = subInts[i - 1] + 1;
                int next = last;
                if (i + 1 < len)
                    next = subInts[i + 1] - 1;
                //if (next - prev + 1 <= max)
                //    continue;
                rv.Add(Sub.Create(prev, next, sub.Original));
            }
            //if (prev < s.Length - 1)
            //    rv.Add(Sub.Create(prev, s.Length - 1, s));

            return rv;
        }
    }
    public class Sub
    {
        static public Sub Create(int start, int end, string original)
        {
            var rv = new Sub();
            rv.Start = start;
            rv.End = end;
            rv.Original = original;
            return rv;
        }
        public override string ToString()
        {
            return $"{Sz} {Start},{End}";
        }
        public int Start { get; set; }
        public int End { get; set; }
        public string Original { get; set; }
        public string Sz
        {
            get
            {
                return Original.Substring(Start, Length);
            }
        }
        public int Length
        {
            get
            {
                return End - Start + 1;
            }
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
