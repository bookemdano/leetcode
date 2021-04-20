using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    public class TreePreorderTrav
    {
        static public void Test()
        {
            Node node;
            var c = new TreePreorderTrav();
            IList<int> list;
            node = NaryTree.ParseWithParen("1(3(5,6),2,4)");
            list = c.Preorder(node);
            node = NaryTree.ParseWithParen("100(300(5,600),2,4)");
            node = NaryTree.ParseWithParen("1(2,3(6,7(11(14))),4(8(12)),5(9(13),10))");
            list = c.Preorder(node);
            //node = NaryTree.ParseWithNull("1,null,3,2,4,null,5,6");
            
        }
        public IList<int> Preorder(Node root)
        {
            var rv = new List<int>();
            if (root == null)
                return rv;
            var stack = new Stack<Node>();
            stack.Push(root);
            while (stack.Any())
            {
                var head = stack.Pop();
                rv.Add(head.val);
                if (head.children != null)
                {
                    foreach(var child in head.children.Reverse())
                        stack.Push(child);
                }
            }
            return rv;
        }
        public IList<int> PreorderList(Node root)
        {
            var rv = new List<int>();
            if (root == null)
                return rv;
            var stack = new List<Node>();
            stack.Add(root);
            while (stack.Any())
            {
                var head = stack[0];
                stack.RemoveAt(0);
                rv.Add(head.val);
                if (head.children != null)
                    stack.InsertRange(0, head.children);
            }
            return rv;
        }

        public IList<int> PreorderRecursive(Node root)
        {
            var rv = new List<int>();
            if (root == null)
                return rv;
            rv.Add(root.val);
            if (root.children == null)
                return rv;
            foreach (var node in root.children)
            {
                rv.AddRange(Preorder(node));
            }
            return rv;
        }
    }
}
