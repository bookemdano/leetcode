using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode
{
    public class AdjDup2
    {
        static public void Test()
        {
            var c = new AdjDup2();
            AssertSame("aa", c.RemoveDuplicates("deeedbbcccbdaa", 3));
            AssertSame("abcd", c.RemoveDuplicates("abcd", 2));
            AssertSame("vcnasu", c.RemoveDuplicates("viittttttiiiillllkkkkkkllllllkkkkkkllkkkkkkcnoooossssssooasu", 6));
            AssertSame("ps", c.RemoveDuplicates("pbbcggttciiippooaais", 2));
        }
        static bool AssertSame(string x, string y)
        {
            if (x != y)
                Console.WriteLine($"FAILED assert {x} != {y}");
            if (x == y)
                Console.WriteLine($"Assert good {x} == {y}");
            return (x != y);
        }
        // stack
        public string RemoveDuplicates(string s, int k)
        {
            var stack = new Stack<int>();
            for(var i = 0; i < s.Length; i++)
            {
                if (i == 0 || s[i] != s[i - 1])
                    stack.Push(1);
                else
                {
                    var top = stack.Pop() + 1;
                    if (top == k)
                    {
                        s = s.Remove(i - k + 1, k);
                        i -= k;
                    }
                    else
                        stack.Push(top);
                }
            }
            return s;
        }
        public string RemoveDuplicatesBrute(string s, int k)
        {
            while(true)
            {
                var count = 0;
                var i = 0;
                var found = false;
                for (i = 0; i < s.Length; i++)
                {
                    if (i > 0 && s[i] == s[i-1])
                    {
                        count++;
                        if (count == k)
                        {
                            s = s.Remove(i - k + 1, k);
                            found = true;
                            break;
                        }
                    }
                    else
                    {
                        count = 1;
                    }
                }
                if (!found)
                    break;
            }
            return s;
        }
    }
}
