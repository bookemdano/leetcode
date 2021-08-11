using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace leetcode
{
    public class LinkedLists
    {
        static public string Printout { get; set; }
        static public void Test()
        {
            var c = new LinkedLists();
            Printout = string.Empty;
            c.PrintLinkedListInReverse(new ImmutableListNode(ListNode.Parse("1,2,3,4,5")));
            Dessert.AssertSame("[5,4,3,2,1]", Printout);
            Printout = string.Empty;
            c.PrintLinkedListInReverse(new ImmutableListNode(ListNode.Parse("0,-4,-1,3,-5")));
            Dessert.AssertSame("[-5,3,-1,-4,0]", Printout);

            Printout = string.Empty;
            c.PrintLinkedListInReverse(new ImmutableListNode(ListNode.Parse("-2,0,6,4,4,-6")));
            Dessert.AssertSame("[-6,4,4,6,0,-2]", Printout);
            Printout = string.Empty;
            c.PrintLinkedListInReverse(null);
            Dessert.AssertSame("[]", Printout);

            Dessert.AssertSame(ListNode.Parse("5,4,3,2,1"), c.ReverseList(ListNode.Parse("1,2,3,4,5")));
            Dessert.AssertSame(ListNode.Parse("2,1"), c.ReverseList(ListNode.Parse("1,2")));
            Dessert.AssertSame(ListNode.Parse("1,2,1,1"), c.ReverseList(ListNode.Parse("1,1,2,1")));
            Dessert.AssertSame(ListNode.Parse(""), c.ReverseList(ListNode.Parse("")));
        }
        public void PrintLinkedListInReverse(ImmutableListNode head)
        {
            if (head == null)
            {
                Write("[]");
                return;
            }
            var node = head;
            var stack = new Stack<ImmutableListNode>();
            while (node != null)
            {
                stack.Push(node);
                node = node.GetNext();
            }
            node = stack.Pop();
            Write("[");
            while (node != null)
            {
                node.PrintValue();
                if (stack.Count() == 0)
                    break;
                node = stack.Pop();
                Write(",");
            }
            Write("]");
        }
        public static void Write(string str)
        {
            Printout += str;
        }
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
                return null;
            var n = 0;
            var first = true;
            var i = 0;
            while (first || n > 0)
            {
                i++;
                var node = head;
                var j = 0;
                while (node != null && node.next != null && (first || j++ < n))
                {
                    var oldNodeVal = node.val;
                    node.val = node.next.val;
                    node.next.val = oldNodeVal;
                    node = node.next;
                    if (first)
                        n++;
                }
                n--;
                first = false;
            }
            return head;
        }
    }
    public class ImmutableListNode
    {
        ListNode _node;
        public ImmutableListNode(ListNode next)
        {
            _node = next;
        }

        public void PrintValue()
        {
            LinkedLists.Write(_node.val.ToString());
        }
        public ImmutableListNode GetNext()
        {
            if (_node.next == null)
                return null;
            return new ImmutableListNode(_node.next);
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
        public int Length
        {
            get
            {
                if (_stackLimit == 20)
                    return int.MaxValue;
                _stackLimit++;

                var rv = 1 + next.Length;
                _stackLimit--;
                return rv;
            }
        }
        public static ListNode Parse(string str, int pos)
        {
            var rv = Parse(str);
            if (pos == -1)
                return rv;
            var cur = rv;
            int i = 0;
            ListNode target = null;
            while(true)
            {
                if (i++ == pos)
                    target = cur;
                if (cur.next == null)
                {
                    cur.next = target;
                    break;
                }
                cur = cur.next;
            }
            return rv;
        }
        public static ListNode Parse(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return null;
            var parts = str.Replace("[", "").Replace("]", "").Split(",");
            ListNode rv = null;
            ListNode lastNode = null;
            foreach (var part in parts)
            {
                var newNode = new ListNode(int.Parse(part));
                if (rv == null)
                    rv = newNode;
                if (lastNode != null)
                    lastNode.next = newNode;

                lastNode = newNode;
            }
            return rv;
        }

        static int _stackLimit = 0;
        public override string ToString()
        {
            if (_stackLimit == 20)
                return "...";
            _stackLimit++;
            var rv = $"{val}";
            if (next != null)
                rv += $", n{next.ToString()}";
            _stackLimit--;
            return rv;
        }
    }
}
