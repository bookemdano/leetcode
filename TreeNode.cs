using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
        // [2,1,3]
        // [5,1,4,null,null,3,6]
        public static TreeNode Parse(string str)
        {
            var parts = str.Trim("[]".ToCharArray()).Split(",");
            if (parts[0] == "null")
                return null;

            var root = new TreeNode(int.Parse(parts[0]));
            var lastLevel = new List<TreeNode>();
            lastLevel.Add(root);
            var i = 1;
            while (true)
            {
                var newLevel = new List<TreeNode>();
                foreach (var n in lastLevel)
                {
                    if (i >= parts.Length)
                        return root;
                    var val = parts[i++];
                    if (val != "null")
                    {
                        n.left = new TreeNode(int.Parse(val));
                        newLevel.Add(n.left);
                    }
                    if (i >= parts.Length)
                        return root;
                    val = parts[i++];
                    if (val != "null")
                    {
                        n.right = new TreeNode(int.Parse(val));
                        newLevel.Add(n.right);
                    }
                }
                lastLevel = newLevel;
            }
        }
        public override string ToString()
        {
            return $"{val}({left},{right})";
        }
        TreeNode(string[] values, int i, int add)
        {
            val = int.Parse(values[i]);
            int leftI = i + 1 + add;
            if (leftI < values.Length && values[leftI] != "null")
                left = new TreeNode(values, leftI, 1);
            int rightI = i + 2 + add;
            if (rightI < values.Length && values[rightI] != "null")
                right = new TreeNode(values, rightI, 0);
        }
    }
}
