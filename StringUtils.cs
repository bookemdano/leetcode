using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    public class StringUtils
    {
        public static void Test2()
        {
            var c = new StringUtils();
            Dessert.AssertSame("a", c.LongestPalindrome("a"));
            Dessert.AssertSame("a", c.LongestPalindrome("ac"));
            Dessert.AssertSame("aa", c.LongestPalindrome("aa"));
            Dessert.AssertSame("bab", c.LongestPalindrome("babad"));
            Dessert.AssertSame("bb", c.LongestPalindrome("cbbd"));
            Dessert.AssertSame("ddd", c.LongestPalindrome("aabbccdddeeff"));
            Dessert.AssertSame("ddd", c.LongestPalindrome("aabbccddd"));
        }
        public string LongestPalindrome(string s)
        {
            for (int nPan = s.Length; nPan > 1; nPan--)
            {
                var end = s.Length - nPan;
                for(int firstChar = 0; firstChar <= end; firstChar++)
                {
                    if (IsPalindrome(s, firstChar, nPan))
                        return s.Substring(firstChar, nPan);
                }
            }
            return s.Substring(0, 1);
        }
        bool IsPalindrome(string str, int start, int len)
        {
            for (int i = 0; i < len / 2; i++)
            {
                if (str[i + start] != str[start + len - i - 1])
                    return false;
            }
            return true;
        }
        bool IsPalindrome(string str)
        {
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                    return false;
            }
            return true;
        }
        public static void Test()
        {
            var c = new StringUtils();

            Dessert.IsTrue(c.IsValid("()"), "String ()");
            Dessert.IsTrue(!c.IsValid(")"), "String )");
            Dessert.IsTrue(!c.IsValid("("), "String (");
            Dessert.IsTrue(c.IsValid("()[]{}"), "String ()[]{}");
            Dessert.IsTrue(!c.IsValid("(]"), "String (]");
            Dessert.IsTrue(!c.IsValid("([)]"), "String ([)]");
            Dessert.IsTrue(c.IsValid("{[]}"), "String {[]}");

            char[] chars;

            chars = "the sky is blue".ToCharArray();
            c.ReverseWordsChar(chars);
            Dessert.AssertSame("blue is sky the", new string(chars));
            chars = "the sky is blue".ToCharArray();
            c.ReverseWordsCharArray(chars);
            Dessert.AssertSame("blue is sky the", new string(chars));

            chars = "a".ToCharArray();
            c.ReverseWordsChar(chars);
            Dessert.AssertSame("a", new string(chars));

            Dessert.AssertSame("blue is sky the", c.ReverseWords("the sky is blue"));
            Dessert.AssertSame("world hello", c.ReverseWords("  hello world  "));
            Dessert.AssertSame("example good a", c.ReverseWords("a good   example"));
            Dessert.AssertSame("Alice Loves Bob", c.ReverseWords("  Bob    Loves  Alice   "));
            Dessert.AssertSame("bob like even not does Alice", c.ReverseWords("Alice does not even like bob"));
        }
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            var pairs = new Dictionary<char, char>() { {'(', ')' }, { '[', ']' }, { '{', '}' } };
            foreach (var c in s)
            {
                if (c == '(' || c == '[' || c == '{')
                    stack.Push(c);
                else
                {
                    if (!stack.Any())
                        return false;
                    if (pairs[stack.Pop()] != c)
                        return false;
                }
            }
            return !stack.Any();
        }
        public string ReverseWords(string s)
        {
            var parts = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return string.Join(" ", parts.Reverse());
        }

        public void ReverseWordsCharArray(char[] s)
        {
            var words = new List<string>() { string.Empty };
            for (var i = 0; i < s.Length; i++)
            {

                if (s[i] == ' ')
                    words.Add(string.Empty);
                else
                    words[words.Count() - 1] = words[words.Count() - 1] + s[i];
            }
            words.Reverse();
            var result = string.Join(' ', words);
            for (var i = 0; i < s.Length; i++)
                s[i] = result[i];
        }
        public void ReverseWordsChar(char[] s)
        {
            var result = string.Empty;
            var word = string.Empty;
            for (var i = 0; i < s.Length; i++)
            {

                if (s[i] == ' ')
                {
                    result = word + " " + result;
                    word = string.Empty;
                }
                else
                    word = word + s[i];
            }
            result = word + " " + result;
            for (var i = 0; i < s.Length; i++)
                s[i] = result[i];
        }

        public static string NextBlock(string str, ref int start, char cStart, char cEnd)
        {
            if (start >= str.Length || str[start] != cStart)
                return null;
            int depth = 0;
            for (int i = start; i < str.Length; i++)
            {
                if (str[i] == cStart)
                    depth++;
                else if (str[i] == cEnd)
                {
                    depth--;
                    if (depth == 0)
                    {
                        var size = i - start - 1;
                        int origStart = start;
                        start = i + 1;  // go to next one
                        return str.Substring(origStart + 1, size);
                    }
                }
            }
            return null;
        }
    }
}
