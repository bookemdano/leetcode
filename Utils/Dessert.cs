using System;
using System.Linq;

namespace leetcode
{
    static public class Dessert
    {
        static public bool AssertSame(double x, double y, string str = null)
        {
            if (x != y)
                Error($"same {str} '{x}' != '{y}'");
            else
                Pass($"same {str} '{x}' == '{y}'");
            return (x == y);
        }

        static public bool IsTrue(bool b, string str = null)
        {
            if (b)
                Pass($"is_true {str} '{b}'");
            else
                Error($"is_true {str} '{b}'");
            return b;
        }

        static public bool IsFalse(bool b, string str = null)
        {
            if (!b)
                Pass($"is_false {str} '{b}'");
            else
                Error($"is_false {str} '{b}'");
            return b;
        }

        internal static bool AssertSameUnordered(int[] lh, int[] rh)
        {
            return AssertSame(lh.OrderBy(v => v).ToArray(), rh.OrderBy(v => v).ToArray());
        }
        internal static bool AssertSame(int[] lh, int[] rh)
        {
            if (lh.Length != rh.Length)
            {
                Error("length diff");
                return false;
            }
            for (int i = 0; i < lh.Length; i++)
            {
                if (lh[i] != rh[i])
                {
                    Error("array diff " + i);
                    return false;
                }
            }
            Pass("array diff");
            return true;
        }

        static void Error(string str)
        {
            Console.WriteLine($"{DateTime.Now} ***FAILED*** {str}");
        }
        static void Pass(string str)
        {
            Console.WriteLine($"{DateTime.Now} pass {str}");
        }
        static public bool AssertSame(string x, string y, string str = null)
        {
            if (x != y)
                Error($"same {str} '{x}' != '{y}'");
            else
                Pass($"same {str} '{x}' == '{y}'");
            return (x == y);
        }

        internal static bool NotNull(object o, string str)
        {
            if (o == null)
                Console.WriteLine($"FAILED notnull {str}");
            else
                Console.WriteLine($"pass notnull {str}");
            return (o != null);
        }
        internal static bool AssertSame(ListNode listNode1, ListNode listNode2)
        {
            var li1 = listNode1;
            var li2 = listNode2;
            while (true)
            {
                if (li1 == null && li2 == null)
                    break;
                if (!NotNull(li1, "li1") || !NotNull(li2, "li2"))
                    return false;
                if (!AssertSame(li1.val, li2.val, "node val"))
                    return false;
                li1 = li1.next;
                li2 = li2.next;
            }
            return true;
        }
        internal static bool AssertSame(TreeNode treeNode1, TreeNode treeNode2, string str = "")
        {
            var i1 = treeNode1;
            var i2 = treeNode2;
            if (i1 == null && i2 == null)
                return true;
            if (string.IsNullOrWhiteSpace(str))
                str = $"{treeNode1} vs {treeNode2}";

            if (!NotNull(i1, "li1") || !NotNull(i2, "li2"))
                return false;
            if (!AssertSame(i1.val, i2.val, str))
                return false;
            if (!AssertSame(i1.left, i2.left, str))
                return false;
            if (!AssertSame(i1.right, i2.right, str))
                return false;

            return true;
        }
    }
}
