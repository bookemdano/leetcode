using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace leetcode
{
    public class MSInt
    {
        static public void Test()
        {
            var c = new MSInt();
            
            Dessert.IsTrue(c.IsValidBST(TreeNode.Parse("[2147483647]")));
            Dessert.IsTrue(!c.IsValidBST(TreeNode.Parse("[5,4,6,null,null,3,7]")));
            Dessert.IsTrue(c.IsValidBST(TreeNode.Parse("[2,1,3]")));
            
            Dessert.IsTrue(!c.IsValidBST(TreeNode.Parse("[2,2,2]")));
            Dessert.IsTrue(!c.IsValidBST(TreeNode.Parse("[2,null,2]")));

            var str = File.ReadAllText("assets//input20210630.txt");
            var tree = TreeNode.Parse(str);
            Dessert.IsTrue(c.IsValidBST(tree));
            Dessert.IsTrue(!c.IsValidBST(TreeNode.Parse("[3,null,30,10,null,null,15,null,45]")));
            Dessert.IsTrue(!c.IsValidBST(TreeNode.Parse("[32,26,47,19,null,null,56,null,27]")));
            Dessert.IsTrue(c.IsValidBST(TreeNode.Parse("[0]")));
            Dessert.IsTrue(c.IsValidBST(TreeNode.Parse("[0,-1]")));
            Dessert.IsTrue(!c.IsValidBST(TreeNode.Parse("[32,26,47,19,null,null,56,null,27]")));
            Dessert.IsTrue(!c.IsValidBST(TreeNode.Parse("[5,1,4,null,null,3,6]")));
        }
        public bool IsValidBST(TreeNode root)
        {
            if (root == null)
                return false;
            return Valid(root, long.MinValue, long.MaxValue);
        }

        bool Valid(TreeNode node, long upperMin, long upperMax)
        {
            if (node.val <= upperMin || node.val >= upperMax || upperMax < upperMin)
                return false;

            if (node.left != null && !Valid(node.left, upperMin, Math.Min(upperMax, node.val)))
                return false;

            if (node.right != null && !Valid(node.right, Math.Max(upperMin, node.val), upperMax))
                return false;
            return true;
        }
        public bool IsValidBST2(TreeNode root)
        {
            if (root == null)
                return false;
            if (root.left == null && root.right == null)
                return true;
            if (root.left != null && root.val <= Max(root.left))
                return false;
            //if (root.right != null && root.val >= Min(root.right))
            //    return false;
            if (root.left != null && !IsValidBST(root.left))
                return false;
            if (root.right != null && !IsValidBST(root.right))
                return false;
            return true;
        }

        int Max(TreeNode node)
        {
            var max = int.MinValue;
            if (node.left != null)
                max = Math.Max(max, Max(node.left));
            if (node.right != null)
                max = Math.Max(max, Max(node.right));
            if (max >= node.val)
                max = int.MaxValue;
            return max;
        }
    }
}
