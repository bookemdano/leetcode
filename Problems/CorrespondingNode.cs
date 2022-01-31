using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode
{
    internal class CorrespondingNode
    {
        internal static void Test()
        {
            var c = new CorrespondingNode();
            TreeNode original;
            TreeNode cloned;
            TreeNode target;
            TreeNode answer;

            original = TreeNode.Parse("[7,4,3,null,null,6,19]");
            cloned = TreeNode.Parse("[7,4,3,null,null,6,19]");
            target = TreeNode.Parse("[3]");
            answer = c.GetTargetCopy(original, cloned, target);
            Dessert.AssertSame(target.val, answer.val);


            original = TreeNode.Parse("[7]");
            cloned = TreeNode.Parse("[7]");
            target = TreeNode.Parse("[7]");
            answer = c.GetTargetCopy(original, cloned, target);
            Dessert.AssertSame(cloned, answer);

        }
        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            return Helper(cloned, target.val);
        }
        public TreeNode Helper(TreeNode node, int val)
        {
            TreeNode rv = null;
            if (node.val == val)
                rv = node;
            if (rv == null && node.right != null)
                rv = Helper(node.right, val);
            if (rv == null && node.left != null)
                rv = Helper(node.left, val);
            return rv;
        }

    }
}