using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode
{
    internal class InOrderTraversal
    {
        internal static void Test()
        {
            var c = new InOrderTraversal();
            Dessert.AssertSame(new int[] { 1, 3, 2 }, c.InorderTraversal(TreeNode.Parse("[1,null,2,3]")).ToArray());
            Dessert.AssertSame(new int[] { 2, 1 }, c.InorderTraversal(TreeNode.Parse("[1,2]")).ToArray());
            Dessert.AssertSame(new int[] { 1, 2 }, c.InorderTraversal(TreeNode.Parse("[1,null,2]")).ToArray());
            Dessert.AssertSame(new int[] { 1 }, c.InorderTraversal(TreeNode.Parse("[1]")).ToArray());
        }
        public IList<int> InorderTraversal(TreeNode root)
        {
            var rv = new int[100];
            var i = Helper(rv, root, 0);
            Array.Resize(ref rv, i);
            return rv;
        }
        public int Helper(int[] outs, TreeNode node, int i)
        {
            if (node == null)
                return i;
            if (node.left != null)
                i = Helper(outs, node.left, i);
            outs[i++] = node.val;
            if (node.right != null)
                i = Helper(outs, node.right, i);
            return i;
        }
    }

}