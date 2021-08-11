﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace leetcode
{
    partial class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var sw = Stopwatch.StartNew();
            LinkedListCycle.Test();
            //May2021.Test();
            /*
            AssertSame(Fib(0), 0);
            AssertSame(Fib(1), 1);
            AssertSame(Fib(2), 1);
            AssertSame(Fib(3), 2);
            AssertSame(Fib(4), 3);
            AssertSame(Fib(5), 5);
            AssertSame(Fib(6), 8);

            /* 4/14/2021
            var node = ListNode.Parse("2,1");
            var newNode = Partition(node, 2);
            Console.WriteLine($"{ListNode.Parse("2,1")} to {newNode} at 2");
            node = ListNode.Parse("1,4,3,2,5,2");
            newNode = Partition(node, 3);
            Console.WriteLine($"{ListNode.Parse("1,4,3,2,5,2")} to {newNode} at 3");
            //Input: head = [2, 1], x = 2
            //Output:[1,2]

            /*
            var list1 = new List<NestedInteger>() { new NIInt(3), new NIInt(2), new NIInt(1) };
            var list2 = NIList.Parse("[1,1],2,[3,3]").GetList();
            var list3 = NIList.Parse("1,[4,[6]]").GetList();


            Console.WriteLine($"{sw.Elapsed}");
            NestedIterator iter;

            var str = "-64,78,56,10,[-8],26,[-18,[47,[-31,75],[89],13,48],[-19,-69,[36,[-39,55],-5,-4,[-15,-37,-27,-8,-5,35],-51]],83],21,-47,46,33,-91,-21,[-57,0,81,1,-75,-50,-23,-86,39,-98,-29,69,38,32,24,-90,-95,86,-27,-23,-22,44,-88,3,27,9,55,-50,-80,40,5,-61,-82,-14,40,-58,35,93,-68,-26,94,3,-79,9,-88,21,19,-84,7,91,-8,84,12,-19,-13,-83,66,-80,-34,62,59,48,-98,53,-66,18,94,46,11,-73,96,-18,6,-83,91,17,38,10,9,-78,-22,77,83,89,-42,-30,-94,-98,-34,-51,63,-97,96,64,55,-93,-41,27,52,69,53,26,-71,-64,42,-80,52,-43,6,-62,-21,83,-85,-38,49,-50,8,55,-72,74,80,90,53,53,32,-15,36,90,-88,-34,37,41,91,65,76,33,61,5,90,-33,42,-54,-73,34,-16,75,83,91,7,-89,42,-36,77,-5,-83,9,80,53,-23,68,-81,90,10,-90,55,-14,19,-7,91,-14,59,33,31,62,-33,-85,37,-73,83,-78,-86,25,-15,91,97,2,-23,54,-68,53,22,-73,43,-68,-87,-25,18,31,67,-14,94,3,-81,25,-35,-37,17,79,-34,-23,-99,-43,-98,-38,-52,75,63,1,29,71,-68,-71,74,51,-40,86,-73,54,-5,70,-60,-11,-49,-64,90,-8,-25,-16,-52,40,60,-75,96,39,-13,-79,14,-73,22,-79,75,30,-51,49,-19,-15,36,-16,-60,-69,-68,-21,-4,-18,-9,-14,50,65,70,75,-17,30,99,-44,-31,-14,-46,60,-10,52,80,-35,-18,-94,-86,62,-10,49,-53,6,56,-45,62,-48,36,-47,15,-37,-81,-15,-62,-22,91,-85,33,-62,-23,86,97,66,15,54,-69,96,36,-55,36,-97,70,82,9,4,-63,-29,32,49,23,-53,88,18,8,-96,72,-23,-82,6,14,-6,-31,-12,-39,61,-58,-32,57,77,12,-7,56,-40,-48,-35,40,-35,12,-28,90,-87,-4,79,30,80,82,-20,-43,76,62,70,-30,-92,-42,7,68,-24,75,26,-70,-36,[[[95,86,[[0,[-52,-49],[-60],12]],63,-11,-20,75,84,-41,-18,[41,-82,61,98,70,0,45,-83,8,-96,24,-24],-44],-24],-98],-14,39,97,-51,-60,-78,-24,-44,10,-84,44,89,67,5,-75,-73,-53,-81,64,-55,88,-35,89,-94,72,69,29,-52,-97,81,-73,-35,20,-99,13,36,98,65,69,8,81,13,-25,25,95,-1,51,-58,-5,16,-37,-17,57,-71,-35,29,75,70,53,77,51,79,-58,-51,56,31,84,54,-27,30,-37,-46,-56,14,56,-84,89,7,-43,-16,99,19,67,56,24,-68,-38,-1,-97,-84,-24,53,71,-6,-98,28,-98,63,-18,-25,-7,21,5,13,-88,-39,28,-98,68,61,-15,44,-43,-71,1,81,-39,62,-20,-60,54,33,69,26,-96,48,-69,-94,11,-11,-20,80,87,61,-29,98,-77,75,99,67,37,-38,11,93,-10,88,51,27,28,-68,66,-41,41,36,84,44,-16,91,49,71,-19,-94,[[28,-32,44,75,[-57,66],51,[-80],10],-35],-19,97,-65,70,63,86,-2,-9,94,-59,26,35,76,11,-21,-63,-21,-94,84,59,87,13,-96,31,-35,-53,-26,-84,-34,60,-20,23,58,15,-7,21,-22,67,88,-28,-91,14,-93,61,-98,-38,75,-19,-56,59,-83,-91,-51,-79,16,14,-56,90,6,-14,27,63,-91,-15,-22,-22,82,32,-54,47,-96,-69,-61,86,91,-60,-75,43,-3,-31,3,-9,-23,28,11,69,-81,31,59,25,-83,-36,-12,-75,48,42,-21,8,-26,24,-68,-23,31,-30,-60,0,-13,-36,-57,60,32,22,-49,85,-49,38,55,-54,-31,-9,70,-38,54,-65,-37,-20,76,42,64,-73,-57,95,-20,74,-57,19,-49,29,83,-7,-11,-8,-84,40,-45,-57,-45,86,-12,24,-46,-64,62,-91,-30,-74,-35,-76,44,-94,-73,86,77,7,37,-80,-74,87,48,85,-19,-85,-45,-27,31,9,-8,85,-28,79,-14,25,91,-51,10,-61,-49,74,-38,94,56,-12,57,34,71,-5,53,74,-18,-21,59,39,-30,90,-88,-99,-24,3,62,47,-40,-51,-27,-49,-26,82,-11,1,34,27,-5,-10,92,-48,-99,63,23,31,14,-94,-90,-49,44,-44,-59,33,-44,17,-64,-82,-36,-28,-57,13,0,-7,-4,88,70,-93,-7,-35,-4,-15,-6,-26,-75,93,-95,39,98,90,66,20,-54,-93,-47,-22,0,-35,-28,41,14,-8,-46,-86,84,26,-98,55,32,-29,96,-94,32,-33,-21,57,-39,-17,-27,-64,-50,-61,55,-28,-78,84,49,22,-73,-79,-37,40,12,-7,53,-26,-80,31,-94,51,-97,-98,56,34,-54,-88,-32,-17,-29,17,18,20,32,-49,91,54,-65,40,-47,-39,38,-8,-99,-73,84,30,0,-96,-38,5,32,-36,-16,-35,74,29,-23,-80,-88,47,36,29,-32,-54,79,-64,76,91,53,-71,-71,-9,-3,-93,17,-19],36,94,-38,97,-1,70,-62,82,-65,-87,11,11,-68,-1,-41,44,-71,3,89";
            var success = "-64,78,56,10,-8,26,-18,47,-31,75,89,13,48,-19,-69,36,-39,55,-5,-4,-15,-37,-27,-8,-5,35,-51,83,21,-47,46,33,-91,-21,-57,0,81,1,-75,-50,-23,-86,39,-98,-29,69,38,32,24,-90,-95,86,-27,-23,-22,44,-88,3,27,9,55,-50,-80,40,5,-61,-82,-14,40,-58,35,93,-68,-26,94,3,-79,9,-88,21,19,-84,7,91,-8,84,12,-19,-13,-83,66,-80,-34,62,59,48,-98,53,-66,18,94,46,11,-73,96,-18,6,-83,91,17,38,10,9,-78,-22,77,83,89,-42,-30,-94,-98,-34,-51,63,-97,96,64,55,-93,-41,27,52,69,53,26,-71,-64,42,-80,52,-43,6,-62,-21,83,-85,-38,49,-50,8,55,-72,74,80,90,53,53,32,-15,36,90,-88,-34,37,41,91,65,76,33,61,5,90,-33,42,-54,-73,34,-16,75,83,91,7,-89,42,-36,77,-5,-83,9,80,53,-23,68,-81,90,10,-90,55,-14,19,-7,91,-14,59,33,31,62,-33,-85,37,-73,83,-78,-86,25,-15,91,97,2,-23,54,-68,53,22,-73,43,-68,-87,-25,18,31,67,-14,94,3,-81,25,-35,-37,17,79,-34,-23,-99,-43,-98,-38,-52,75,63,1,29,71,-68,-71,74,51,-40,86,-73,54,-5,70,-60,-11,-49,-64,90,-8,-25,-16,-52,40,60,-75,96,39,-13,-79,14,-73,22,-79,75,30,-51,49,-19,-15,36,-16,-60,-69,-68,-21,-4,-18,-9,-14,50,65,70,75,-17,30,99,-44,-31,-14,-46,60,-10,52,80,-35,-18,-94,-86,62,-10,49,-53,6,56,-45,62,-48,36,-47,15,-37,-81,-15,-62,-22,91,-85,33,-62,-23,86,97,66,15,54,-69,96,36,-55,36,-97,70,82,9,4,-63,-29,32,49,23,-53,88,18,8,-96,72,-23,-82,6,14,-6,-31,-12,-39,61,-58,-32,57,77,12,-7,56,-40,-48,-35,40,-35,12,-28,90,-87,-4,79,30,80,82,-20,-43,76,62,70,-30,-92,-42,7,68,-24,75,26,-70,-36,95,86,0,-52,-49,-60,12,63,-11,-20,75,84,-41,-18,41,-82,61,98,70,0,45,-83,8,-96,24,-24,-44,-24,-98,-14,39,97,-51,-60,-78,-24,-44,10,-84,44,89,67,5,-75,-73,-53,-81,64,-55,88,-35,89,-94,72,69,29,-52,-97,81,-73,-35,20,-99,13,36,98,65,69,8,81,13,-25,25,95,-1,51,-58,-5,16,-37,-17,57,-71,-35,29,75,70,53,77,51,79,-58,-51,56,31,84,54,-27,30,-37,-46,-56,14,56,-84,89,7,-43,-16,99,19,67,56,24,-68,-38,-1,-97,-84,-24,53,71,-6,-98,28,-98,63,-18,-25,-7,21,5,13,-88,-39,28,-98,68,61,-15,44,-43,-71,1,81,-39,62,-20,-60,54,33,69,26,-96,48,-69,-94,11,-11,-20,80,87,61,-29,98,-77,75,99,67,37,-38,11,93,-10,88,51,27,28,-68,66,-41,41,36,84,44,-16,91,49,71,-19,-94,28,-32,44,75,-57,66,51,-80,10,-35,-19,97,-65,70,63,86,-2,-9,94,-59,26,35,76,11,-21,-63,-21,-94,84,59,87,13,-96,31,-35,-53,-26,-84,-34,60,-20,23,58,15,-7,21,-22,67,88,-28,-91,14,-93,61,-98,-38,75,-19,-56,59,-83,-91,-51,-79,16,14,-56,90,6,-14,27,63,-91,-15,-22,-22,82,32,-54,47,-96,-69,-61,86,91,-60,-75,43,-3,-31,3,-9,-23,28,11,69,-81,31,59,25,-83,-36,-12,-75,48,42,-21,8,-26,24,-68,-23,31,-30,-60,0,-13,-36,-57,60,32,22,-49,85,-49,38,55,-54,-31,-9,70,-38,54,-65,-37,-20,76,42,64,-73,-57,95,-20,74,-57,19,-49,29,83,-7,-11,-8,-84,40,-45,-57,-45,86,-12,24,-46,-64,62,-91,-30,-74,-35,-76,44,-94,-73,86,77,7,37,-80,-74,87,48,85,-19,-85,-45,-27,31,9,-8,85,-28,79,-14,25,91,-51,10,-61,-49,74,-38,94,56,-12,57,34,71,-5,53,74,-18,-21,59,39,-30,90,-88,-99,-24,3,62,47,-40,-51,-27,-49,-26,82,-11,1,34,27,-5,-10,92,-48,-99,63,23,31,14,-94,-90,-49,44,-44,-59,33,-44,17,-64,-82,-36,-28,-57,13,0,-7,-4,88,70,-93,-7,-35,-4,-15,-6,-26,-75,93,-95,39,98,90,66,20,-54,-93,-47,-22,0,-35,-28,41,14,-8,-46,-86,84,26,-98,55,32,-29,96,-94,32,-33,-21,57,-39,-17,-27,-64,-50,-61,55,-28,-78,84,49,22,-73,-79,-37,40,12,-7,53,-26,-80,31,-94,51,-97,-98,56,34,-54,-88,-32,-17,-29,17,18,20,32,-49,91,54,-65,40,-47,-39,38,-8,-99,-73,84,30,0,-96,-38,5,32,-36,-16,-35,74,29,-23,-80,-88,47,36,29,-32,-54,79,-64,76,91,53,-71,-71,-9,-3,-93,17,-19,36,94,-38,97,-1,70,-62,82,-65,-87,11,11,-68,-1,-41,44,-71,3,89";
            var parts = str.Split(",[]".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var successParts = success.Split(",[]".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var list = NIList.Parse(str).GetList();
            Console.WriteLine("Crazy");
            iter = new NestedIterator(list);
            var i = 0;
            while (iter.HasNext())
            {
                if (i == 33)
                    Console.WriteLine("wait");
                var n = iter.Next();
                AssertSame(n, int.Parse(successParts[i]));
                i++;
                //Console.WriteLine($"{n}");
            }
            AssertSame(i, parts.Count());

            Console.WriteLine("Empty");
            iter = new NestedIterator(NIList.Empty(2).GetList());
            while (iter.HasNext())
                Console.WriteLine($"{iter.Next()}");

            Console.WriteLine("Deep");
            iter = new NestedIterator(NIList.Deep(3).GetList());
            while (iter.HasNext())
                Console.WriteLine($"{iter.Next()}");

            Console.WriteLine("Straight");
            iter = new NestedIterator(new List<NestedInteger>() { new NIInt(3), new NIInt(2), new NIInt(1) });
            while (iter.HasNext())
                Console.WriteLine($"{iter.Next()}");
            Console.WriteLine("Mix");
            iter = new NestedIterator(new List<NestedInteger>() { new NIList(2, 1), new NIInt(2), new NIList(2, 3) });
            while (iter.HasNext())
                Console.WriteLine($"{iter.Next()}");

            /*
             AssertTrue(IsPalindrome("Race, car"), "Race, car");
            AssertTrue(!IsPalindrome("Race: acar"), "Race: acar");
            AssertTrue(IsPalindrome("Rac1e,1 car"), "Rac1e,1 car");
            AssertTrue(IsPalindrome("A man, a plan, a canal: Panama"), "panama");

            /*
            AssertTwoSum(TwoSum(new int[] { 2, 7, 11, 15 }, 9), 0, 1);
            AssertTwoSum(TwoSum(new int[] { 3, 2, 4 }, 6), 1, 2);
            AssertTwoSum(TwoSum(new int[] { 3, 3 }, 6), 0, 1);
            AssertTwoSum(TwoSum(new int[] { 3, 3, (int)4E8, (int)6E8 }, (int) 1E9), 2, 3);
            */


            /*
            var result2 = Ch20210412b("2");
            Debug.Assert(result2[0] == "a");
            Debug.Assert(result2[1] == "b");
            Debug.Assert(result2[2] == "c");
            var result = Ch20210412b("23");
            result = Ch20210412b("678");
            result = Ch20210412b("232");
            */
            Console.WriteLine($"{sw.Elapsed}");

        }

        static public int Fib(int n)
        {
            var rv = 1;
            var last = 0;
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            for (var i = 2; i <= n; i++)
            {
                var oldLast = rv;
                rv = last + rv;
                last = oldLast;
            }
            return rv;
        }

        static public ListNode Partition(ListNode head, int x)
        {
            var before = new ListNode();
            ListNode beforeLast = before;
            var after = new ListNode();
            ListNode afterLast = after;
            while (head != null)
            {
                if (head.val < x)
                {
                    beforeLast.next = head;
                    beforeLast = beforeLast.next;   // increment
                }
                else if (head.val >= x)
                {
                    afterLast.next = head;
                    afterLast = afterLast.next;   // increment
                }
                head = head.next;
            }
            afterLast.next = null;
            beforeLast.next = after.next;
            return before.next;
        }
        static public bool IsPalindrome(string s)
        {
            //var cs = s.ToLower().Where(c => char.IsLetterOrDigit(c)).ToArray();
            var cs = Strip(s);
            var len = cs.Length;
            int half = cs.Length / 2;
            for(int i = 0; i < half; i++)
            {
                if (cs[i] != cs[len - i - 1])
                    return false;
            }
            return true;
        }
        static char[] Strip(string s)
        {
            var rv = new char[s.Length];
            int i = 0;
            foreach (var c in s)
            {
                if ((c >= 48 && c <= 57) || (c >= 97 && c <= 122))
                    rv[i++] = c;
                else if (c >= 65 && c <= 90)
                    rv[i++] = (char) (c + 32);
            }
            System.Array.Resize(ref rv, i);
            return rv;
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
        static bool AssertTrue(bool b, string sz)
        {
            if (!b)
                Console.WriteLine($"FAILED assert {sz}");
            else
                Console.WriteLine($"Assert good {sz}");
            return b;
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
