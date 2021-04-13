using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var sw = Stopwatch.StartNew();

            AssertTwoSum(TwoSum(new int[] { 2, 7, 11, 15 }, 9), 0, 1);
            AssertTwoSum(TwoSum(new int[] { 3, 2, 4 }, 6), 1, 2);
            AssertTwoSum(TwoSum(new int[] { 3, 3 }, 6), 0, 1);
            AssertTwoSum(TwoSum(new int[] { 3, 3, (int)4E8, (int)6E8 }, (int) 1E9), 2, 3);
            Console.WriteLine($"{sw.Elapsed}");

            /*
            var result2 = Ch20210412b("2");
            Debug.Assert(result2[0] == "a");
            Debug.Assert(result2[1] == "b");
            Debug.Assert(result2[2] == "c");
            var result = Ch20210412b("23");
            result = Ch20210412b("678");
            result = Ch20210412b("232");
            */

        }
        static public int[] TwoSum(int[] nums, int target)
        {
            var len = nums.Length;
            if (len > 1000)
                return new int[0];
            int i, j;
            for (i = 0; i < len - 1; i++)
            {
                var val = target - nums[i];
                for (j = i + 1; j < len; j++)
                {
                    if (nums[j] == val)
                        return new int[] { i, j };
                }
            }
            return new int[0];
        }
        static public void AssertTwoSum(int[] results, int i1, int i2)
        {
            AssertSame(results[0], i1);
            AssertSame(results[1], i2);


        }
        static bool AssertSame(int x, int y)
        {
            if (x != y)
                Console.WriteLine($"FAILED assert {x} != {y}");
            if (x == y)
                Console.WriteLine($"Assert good {x} == {y}");
            return (x != y);
        }

        static IList<string> Ch20210412b(string digits)
        {
            string[] _map = new string[] { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            var rv = new List<string>();
            if (digits.Length == 0)
                return rv;
            if (digits.Length > 4)
                digits = digits.Substring(0, 4);
            rv.Add(string.Empty);
            foreach (var digit in digits)
            {
                var set = _map[digit - '0'];
                var newRv = new List<string>();
                foreach (var r in rv)
                {
                    foreach (var c in set)
                    {
                        newRv.Add(r + c.ToString());
                    }
                }
                rv = newRv;
            }

            return rv;
        }
        static IList<string> Ch20210412a(string digits)
        {
            Dictionary<char, string> _dict = new Dictionary<char, string> { { '2', "abc" }, { '3', "def" }, { '4', "ghi" }, { '5', "jkl" }, { '6', "mno" }, { '7', "pqrs" }, { '8', "tuv" }, { '9', "wxyz" }, };
            var rv = new List<string>();
            if (digits.Length == 0)
                return rv;
            if (digits.Length > 4)
                digits = digits.Substring(0, 4);
            rv.Add(string.Empty);
            foreach (var digit in digits)
            {
                var set = _dict[digit];
                var newRv = new List<string>();
                foreach (var r in rv)
                {
                    foreach (var c in set)
                    {
                        newRv.Add(r + c.ToString());
                    }
                }
                rv = newRv;
            }

            return rv;
        }
    }
}
