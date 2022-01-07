using System.Collections.Generic;
using System.Linq;

namespace leetcode
{
    internal class BSTIterator
    {
        private Stack<TreeNode> _stack = new Stack<TreeNode>();
        internal static void Test()
        {
            var node = TreeNode.Parse("[4,2,6,1,3,5,7]");
            var c = new BSTIterator(node);

            var result = new List<int>();
            while (c.HasNext())
                result.Add(c.Next());
            Dessert.AssertSame(new int[] { 1, 2, 3, 4, 5, 6, 7 }, result.ToArray());
        }
        public BSTIterator(TreeNode node)
        {
            StackLeft(node);
        }
        void StackLeft(TreeNode node)
        {
            while(node != null)
            {
                _stack.Push(node);
                node = node.left;
            }
        }
        public int Next()
        {
            var node = _stack.Pop();
            if (node.right != null)
                StackLeft(node.right);

            return node.val;
        }
        public bool HasNext()
        {
            return _stack.Any();
        }
    }
}