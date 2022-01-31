using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode
{
    internal class SplittingBST
    {
        internal static void Test()
        {
            var c = new SplittingBST();
            TreeNode t;
            TreeNode r1;
            TreeNode r2;
            int n;

            t = TreeNode.Parse("[4,2,6,1,3,5,7]");
            r1 = TreeNode.Parse("[4,2,6,1,3,5,7]");
            r2 = TreeNode.Parse("[null]");
            n = 99;
            c.TestOne(t, n, r1, r2);

            r1 = TreeNode.Parse("[null]");
            r2 = TreeNode.Parse("[4,2,6,1,3,5,7]");
            n = 0;
            c.TestOne(t, n, r1, r2);

            t = TreeNode.Parse("[4,2,6,1,3,5,7]");
            r1 = TreeNode.Parse("[2,1]");
            r2 = TreeNode.Parse("[4,3,6,null,null,5,7]");
            n = 2;
            c.TestOne(t, n, r1, r2);


            r1 = TreeNode.Parse("[4,2,6,1,3,5,null]");
            r2 = TreeNode.Parse("[7]");
            n = 6;
            c.TestOne(t, n, r1, r2);

            r1 = TreeNode.Parse("[4,2,null,1,3,null,null]");
            r2 = TreeNode.Parse("[6,5,7]");
            n = 4;
            c.TestOne(t, n, r1, r2);


            t = TreeNode.Parse("[10,5,20,3,9,15,25,null,null,8,null,null,null,null,null,6,null,null,7]");
            r1 = TreeNode.Parse("[5,3,6]");
            r2 = TreeNode.Parse("[10,9,20,8,null,15,25,7]");
            n = 6;
            c.TestOne(t, n, r1, r2);

            t = TreeNode.Parse("[1]");
            r1 = TreeNode.Parse("[1]");
            r2 = TreeNode.Parse("[null]");
            n = 1;
            c.TestOne(t, n, r1, r2);
        }
        void TestOne(TreeNode t, int n, TreeNode r1, TreeNode r2)
        {
            t.Draw("t");
            var result = SplitBST(t, n);
            if (false == Dessert.AssertSame(r1, result[0]))
            {
                result[0].Draw("first");
                r1.Draw("r1");
            }
            if (false == Dessert.AssertSame(r2, result[1]))
            {
                result[1].Draw("second");
                r2.Draw("r2");
            }
        }
        TreeNode Insert(TreeNode root, int val)
        {
            /*if (root == null) //empty tree, make new node
            {
                var node = new TreeNode(val);
                this.Root = node;
            }
            else*/ if (val < root.val)
            {
                if (root.left != null)
                    return Insert(root.left, val);
                else
                    return root.left = new TreeNode(val);
            }
            else //if (val > root.val)
            {
                if (root.right != null) 
                    return Insert(root.right, val);
                else
                    return root.right = new TreeNode(val);
            }
        }
        public TreeNode[] SplitBST(TreeNode root, int target)
        {
            var head = root;
            TreeNode first = null;
            TreeNode second = null;
            while (true)
            {
                if (head.val <= target)
                {
                    TreeNode newNode;
                    if (first == null)
                        newNode = first = new TreeNode(head.val);
                    else
                        newNode = Insert(first, head.val);
                    newNode.left = head.left;
                    if (head.val == target)
                    {
                        if (head.right == null)
                            break;
                        head = head.right;
                        if (second == null)
                            newNode = second = new TreeNode(head.val);
                        else
                            newNode = Insert(second, head.val);
                        newNode.right = head.right;
                        newNode.left = head.left;
                        break;
                    }
                    else
                        head = head.right;
                }
                else if (head.val > target)
                {
                    TreeNode newNode;
                    if (second == null)
                        newNode = second = new TreeNode(head.val);
                    else
                        newNode = Insert(second, head.val);
                    newNode.right = head.right;
                    head = head.left;
                }
                else
                    break;

            }
            return new TreeNode[] { first, second};
        }
    }
}