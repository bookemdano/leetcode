using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode
{
    internal class GreaterSearchTree
    {
        internal static void Test()
        {
            var c = new GreaterSearchTree();
            TreeNode original;
            TreeNode target;
            TreeNode answer;

            original = TreeNode.Parse("[1,2,3]");
            target = TreeNode.Parse("[6,5,3]");
            answer = c.BstToGst(original);
            Dessert.AssertSame(target, answer);
            original = TreeNode.Parse("[1,2,3,4]");
            target = TreeNode.Parse("[10,9,7,4]");
            answer = c.BstToGst(original);
            Dessert.AssertSame(target, answer);

            original = TreeNode.Parse("[4,1,6,0,2,5,7,null,null,null,3,null,null,null,8]");
            target = TreeNode.Parse("[30,36,21,36,35,26,15,null,null,null,33,null,null,null,8]");
            answer = c.BstToGst(original);
            Dessert.AssertSame(target, answer);
            original = TreeNode.Parse("[0,null,1]");
            target = TreeNode.Parse("[1,null,1]");
            answer = c.BstToGst(original);
            Dessert.AssertSame(target, answer);

        }
        public TreeNode BstToGst(TreeNode root)
        {
            TreeNode rv = new TreeNode(root.val);
            if (root.left != null)
            {
                rv.left = BstToGst(root.left);
                rv.val += rv.left.val;
            }
            if (root.right != null)
            {
                rv.right = BstToGst(root.right);
                rv.val += rv.right.val;
            }
            return rv;
        }
        static void BSTToMinHeap(TreeNode root, List<int> arr)
        {
            if (root == null)
                return;

            // first copy data at index 'i' of 'arr' to
            // the node
            //root.val = arr[++i];

            // then recur on left subtree
            BSTToMinHeap(root.left, arr);

            // now recur on right subtree
            BSTToMinHeap(root.right, arr);
        }
        public TreeNode OldBstToGst(TreeNode root)
        {
            TreeNode rv = new TreeNode(root.val);
            if (root.left != null)
            {
                rv.left = BstToGst(root.left);
                rv.val += rv.left.val;
            }
            if (root.right != null)
            {
                rv.right = BstToGst(root.right);
                rv.val += rv.right.val;
            }
            return rv;
        }
    }
}