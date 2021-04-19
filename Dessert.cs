using System;
namespace leetcode
{
    static public class Dessert
    {
        static public bool AssertSame(double x, double y, string str = null)
        {
            if (x != y)
                Console.WriteLine($"FAILED same {str} {x} != {y}");
            else
                Console.WriteLine($"pass same {str} {x} == {y}");
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
    }
}
