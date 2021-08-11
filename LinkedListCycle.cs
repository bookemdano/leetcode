using System;
using System.Collections.Generic;

namespace leetcode
{
    internal class LinkedListCycle
    {
        internal static void Test()
        {
            var c = new LinkedListCycle();
            Dessert.IsTrue(c.HasCycle(ListNode.Parse("[3,2,0,-4]", 1)));
            Dessert.IsTrue(c.HasCycle(ListNode.Parse("[-1,-7,7,-4,19,6,-9,-5,-2,-5]", 6)));
            Dessert.IsTrue(c.HasCycle(ListNode.Parse("[1]", 0)));
            Dessert.IsTrue(c.HasCycle(ListNode.Parse("[1,2]", 0)));
            Dessert.IsFalse(c.HasCycle(ListNode.Parse("[3,2,0,-4]", -1)));
        }
        public bool HasCycle(ListNode head)
        {
            var fast = head;
            var slow = head;
            while (slow != null)
            {
                fast = fast.next?.next;
                slow = slow.next;
                if (fast == null)
                    return false;
                if (fast == slow || fast.next == head)
                    return true;
            }
            return false;
        }
    }
}