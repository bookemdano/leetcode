using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode
{
    public class RemoveNthNode
    {
        static public void Test()
        {
            var c = new RemoveNthNode();
            Dessert.AssertSame(ListNode.Parse("1,2,3,5"), c.RemoveNthFromEnd(ListNode.Parse("1,2,3,4,5"), 2));
            Dessert.AssertSame(ListNode.Parse("1,2"), c.RemoveNthFromEnd(ListNode.Parse("1,2,3"), 1));
            Dessert.AssertSame(ListNode.Parse("1"), c.RemoveNthFromEnd(ListNode.Parse("1,2"), 1));
            Dessert.AssertSame(ListNode.Parse(""), c.RemoveNthFromEnd(ListNode.Parse("1"), 1));
            Dessert.AssertSame(ListNode.Parse("2"), c.RemoveNthFromEnd(ListNode.Parse("1,2"), 2));
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head.next == null)
                return null;
            var start = head;
            var next = head;
            var i = 0;
            while(next != null)
            {
                if (i > n)
                    start = start.next;
                next = next.next;
                i++;
            }
            if (n == i)
                head = head.next;
            else if (start.next != null)
                start.next = start.next.next;
            return head;
        }
        public ListNode RemoveNthFromEndTerrible(ListNode head, int n)
        {
            var next = head;
            var nodes = new List<ListNode>();
            while (next != null)
            {
                nodes.Add(next);
                next = next.next;
            }
            if (nodes.Count() == 1)
                return null;
            var target = nodes.Count() - n;
            if (target == 0)
                head = nodes[1];
            else if (target + 1 < nodes.Count)
                nodes[target - 1].next = nodes[target + 1];
            else
                nodes[target - 1].next = null;

            return head;
        }


    }
}
