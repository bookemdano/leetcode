using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    public class CodeTest
    {
        static public void Test()
        {
            var c = new CodeTest();

            Dessert.IsTrue(!c.solution4(4, new int[] { 1, 2, 1, 3 }, new int[] { 2, 4, 3, 4 }));
            Dessert.IsTrue(c.solution4(4, new int[] { 1, 2, 4, 4, 3 }, new int[] { 2, 3, 1, 3, 1 }));
            Dessert.IsTrue(c.solution4(3, new int[] { 1, 3 }, new int[] { 2, 2 }));
            Dessert.IsTrue(c.solution4(1, new int[] { 1, 3 }, new int[] { 2, 2 }));
            Dessert.IsTrue(c.solution4(2, new int[] { 1, 3 }, new int[] { 2, 2 }));
            Dessert.IsTrue(c.solution4(2, new int[] { 1 }, new int[] { 2 }));
            Dessert.IsTrue(!c.solution4(6, new int[] { 2, 4, 5, 3 }, new int[] { 3, 5, 6, 4 }));

            Dessert.AssertSame(7, c.solution3(2014, "April", "May", "Wednesday"));

            Dessert.AssertSame("123-45", c.solution2("  1  23---4- 5 "));
            Dessert.AssertSame("004-448-555-583-61", c.solution2("00-44  48 5555 8361"));
            Dessert.AssertSame("022-198-53-24", c.solution2("0 - 22 1985--324"));
            Dessert.AssertSame("555-372-654", c.solution2("555372654"));
            Dessert.AssertSame("10", c.solution2("  1  0----"));
            Dessert.AssertSame("123", c.solution2("  1  23----"));
            Dessert.AssertSame("12-34", c.solution2("  1  23---4-"));
            

            Dessert.AssertSame("pom", c.solution1(new string[] { "pim", "pom" }, new string[] { "999999999", "777888999" }, "88999"));
            Dessert.AssertSame("ann", c.solution1(new string[] { "sander", "amy", "ann", "mike" }, new string[] { "123456789", "234567890", "789123456", "123123123" }, "1"));
            Dessert.AssertSame("ann", c.solution1(new string[] { "sander", "amy", "ann", "ann", "mike", "mike" }, new string[] { "123456789", "234567890", "789123456", "123123123", "789123456", "123123123" }, "1"));
            Dessert.AssertSame("NO CONTACT", c.solution1(new string[] { "adam", "eva", "leo" }, new string[] { "121212121", "111111111", "444555666" }, "112"));
        }

        // only 50% right
        public bool solution4(int N, int[] A, int[] B)
        {
            var nodeLines = new List<int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == B[i] - 1)
                    nodeLines.Add(A[i]);
                else if (B[i] == A[i] - 1)
                    nodeLines.Add(B[i]);
            }
            var ordered = nodeLines.OrderBy(n => n).ToArray();
            var node = 1;
            foreach (var o in ordered)
            {
                if (node == N)
                    return true;
                else if (o != node)
                    return false;
                node++;
            }
            return (ordered.Last() == N - 1);
        }

        public bool solution4a(int N, int[] A, int[] B)
        {
            var nodeLines = new List<int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == B[i] - 1)
                    nodeLines.Add(A[i]);
                else if (B[i] == A[i] - 1)
                    nodeLines.Add(B[i]);
            }
            var ordered = nodeLines.OrderBy(n => n).ToArray();
            var node = 1;
            foreach (var o in ordered)
            {
                if (node == N)
                    return true;
                else if (o != node)
                    return false;
                node++;
            }
            return (ordered.Last() == N - 1);
        }

        public int solution3(int Y, string A, string B, string W)
        {
            var months = new string[] { "AddZeroMonth", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            //var days = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

            var startMonth = Array.IndexOf(months, A);
            var endMonth = Array.IndexOf(months, B);

            var start = new DateTime(Y, startMonth, 1);
            while (start.DayOfWeek != DayOfWeek.Monday)
                start = start.AddDays(1);
            var lastDay = DateTime.DaysInMonth(Y, endMonth);
            var end = new DateTime(Y, endMonth, lastDay);
            while (end.DayOfWeek != DayOfWeek.Sunday)
                end = end.AddDays(-1);
            var rv = ((end - start).TotalDays + 1) / 7.0;
            return (int) rv;
        }

        public string solution2(string S)
        {
            var s = S.Replace("-", "").Replace(" ", "");
            var parts = new List<string>();
            while (true)
            {
                if (s.Length == 4)
                {
                    parts.Add($"{s[0]}{s[1]}");
                    parts.Add($"{s[2]}{s[3]}");
                    break;
                }
                else if (s.Length == 3)
                {
                    parts.Add($"{s[0]}{s[1]}{s[2]}");
                    break;
                }
                else if (s.Length == 2)
                {
                    parts.Add($"{s[0]}{s[1]}");
                    break;
                }
                else // greater than 3
                {
                    parts.Add($"{s[0]}{s[1]}{s[2]}");
                    s = s.Substring(3, s.Length - 3);
                }
            }
            return string.Join("-", parts);
            // write your code in C# 6.0 with .NET 4.5 (Mono)
        }
        public string solution1(string[] A, string[] B, string P)
        {
            var rv = new List<string>();
            for (int i = 0; i < B.Length; i++)
            {
                if (B[i].Contains(P))
                    rv.Add(A[i]);
            }
            if (!rv.Any())
                return "NO CONTACT";

            return rv.OrderBy(a => a).First();
        }

        void SmallestTest()
        { 
            Dessert.AssertSame(5, solutionSmallest(new int[] { 1, 3, 6, 4, 1, 2 }));
            Dessert.AssertSame(4, solutionSmallest(new int[] { 1, 2, 3 }));
            Dessert.AssertSame(1, solutionSmallest(new int[] { -1, -2, -3 }));
        }

        public int solutionSmallest(int[] A)
        {
            var sorted = A.OrderBy(a => a).ToArray();
            var rv = 1;
            var i = 0;
            while(true)
            {
                if (i >= sorted.Length || sorted[i] != rv)
                    return rv;
                i++;
                while (i < sorted.Length && sorted[i] == rv)
                    i++;
                rv++;
            }

        }
    }
}
