using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    class CAddTwoNumbers
    {
        internal static void Test()
        {
            var c = new CAddTwoNumbers();
            Dessert.AssertSame(ListNode.Parse("[7,3]"), c.AddTwoNumbers(ListNode.Parse("[0]"), ListNode.Parse("[7,3]")));
            Dessert.AssertSame(ListNode.Parse("[7,0,8]"), c.AddTwoNumbers(ListNode.Parse("[2,4,3]"), ListNode.Parse("[5,6,4]")));
            Dessert.AssertSame(ListNode.Parse("[8,9,9,9,0,0,0,1]"), c.AddTwoNumbers(ListNode.Parse("[9,9,9,9]"), ListNode.Parse("[9,9,9,9,9,9,9]")));
            Dessert.AssertSame(ListNode.Parse("[0]"), c.AddTwoNumbers(ListNode.Parse("[0]"), ListNode.Parse("[0]")));
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode rv = l1;
            while (l1 != null || l2 != null)
            {
                if (l2 != null)
                {
                    l1.val += l2.val;
                    l2 = l2.next;
                }
                if (l1.val > 9)
                {
                    l1.val -= 10;
                    if (l1.next == null)
                        l1.next = new ListNode(0, null);
                    l1.next.val += 1;
                }
                if (l1.next == null && l2 != null)
                {
                    l1.next = new ListNode(0, null);
                }
                l1 = l1.next;
            }
            return rv;
        }
        public ListNode AddTwoNumbers1(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode();
            ListNode cur = head;
            while(!(l1 == null && l2 == null))
            {
                if (l1 != null)
                {
                    cur.val += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    cur.val += l2.val;
                    l2 = l2.next;
                }
                if (l1 == null && l2 == null && cur.val < 10)
                    break;
                cur.next = new ListNode();
                if (cur.val > 9)
                {
                    cur.val -= 10;
                    cur.next.val = 1;
                }
                cur = cur.next;
            }

            return head;
        }
    }
}
