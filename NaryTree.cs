using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace leetcode
{
    public class Node
    {
        public int val;
        public IList<Node> children;

        internal Node _parent; // only used for parsing
        
        public Node() { }

        public Node(int val, Node parent)
        {
            this.val = val;
            this._parent = parent;
        }

        public Node(int val, IList<Node> children)
        {
            this.val = val;
            this.children = children;
        }

        public override string ToString()
        {
            var rv = $"v{val}";
            if (children != null)
            {
                rv += $":n{children?.Count()}";
                foreach (var child in children)
                {
                    rv += $", ({child})";
                }
            }
            return rv;

        }
    }
    public class NaryTree
    {
        static public Node ParseWithParen(string str)
        {
            //1(3(5,6),2,4)
            var dummy = new Node();
            ParseNode(dummy, str);
            return dummy.children.First();
        }
        static void ParseNode(Node head, string str)
        {
            int i = 0;
            Node lastNode = null;
            while (i < str.Length)
            {
                if (str[i] == ',')
                {
                    i++;
                    continue;
                }    
                var nextblock = NextBlock(str, ref i);
                if (nextblock != null)
                {
                    ParseNode(lastNode, nextblock);
                }
                var n = NextInt(str, ref i);
                if (n != null)
                {
                    if (head.children == null)
                        head.children = new List<Node>();
                    lastNode = new Node(n.Value, head);
                    head.children.Add(lastNode);
                }

            }
        }

        static string NextBlock(string str, ref int start)
        {
            if (str[start] != '(')
                return null;
            int depth = 0;
            for (int i = start; i < str.Length; i++)
            {
                if (str[i] == '(')
                    depth++;
                else if (str[i] == ')')
                {
                    depth--;
                    if (depth == 0)
                    {
                        var size = i - start - 1;
                        int origStart = start;
                        start = i + 1;  // go to next one
                        return str.Substring(origStart + 1, size);
                    }
                }
            }
            return null;
        }
        static int? NextInt(string str, ref int start)
        {
            if (start >= str.Length || !char.IsDigit(str[start]))
                return null;
            int i = start;
            for (i = start; i < str.Length; i++)
            {
                if (!char.IsDigit(str[i]))
                    break;
            }
            var size = i - start;
            var sub = str.Substring(start, size);
            start = i; // return first one not part of int
            return int.Parse(sub);
        }

        static public Node ParseWithNull(string str)
        {
            var parts = str.Split(",");
            Node dummy = new Node();
            Node head = dummy;
            var levels = new Dictionary<int, int>();
            int iLevel = 0;
            levels.Add(iLevel, 0);
            foreach (var part in parts)
            {
                if (int.TryParse(part, out int n))
                {
                    if (head.children == null)
                        head.children = new List<Node>();
                    head.children.Add(new Node(n, head));
                }
                else
                {
                    if (iLevel + 1 < levels.Count())

                    if (head.children == null)
                    {
                        iLevel--;
                        levels[iLevel]++;
                        head = head._parent;
                    }

                    head = head.children[levels[iLevel]];
                    iLevel++;
                    if (levels.Count() < iLevel + 1)
                        levels.Add(iLevel, 0);
                }
            }
            return dummy.children[0];
        }
    }
}
