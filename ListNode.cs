﻿namespace leetcode
{
    partial class Program
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
            public static ListNode Parse(string str)
            {
                var parts = str.Split(",");
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

            public override string ToString()
            {
                var rv = $"{val}";
                if (next != null)
                    rv += $", n{next.ToString()}";
                return rv;

            }
        }
    }
}