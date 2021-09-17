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

        internal void Draw(string name)
        {
            int h = Height();
            var max = Math.Pow(2, h) - 1;
            var width = Math.Pow(2, h - 1);
            var head = this;
            Console.WriteLine(name);

            var q = new Queue<TreeNode>();
            q.Enqueue(this);
            var list = new List<int>();
            while (q.Any())
            {
                var node = q.Dequeue();
                if (node == null)
                    node = new TreeNode(0);

                list.Add(node?.val ?? 0);
                if (list.Count() >= max)
                    break;
                q.Enqueue(node.left);
                q.Enqueue(node.right);
            }
            var idx = 0;
            var dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < h; i++)
            {
                var items = Math.Pow(2, i);
                dict.Add(i, new List<int>());
                for (int j = 0; j < items; j++)
                    dict[i].Add(list[idx++]);
            }
            var dictRev = dict.OrderByDescending(d => d.Key);
            var extra = "";
            var last_layer = new List<int>();
            var lines = new List<string>();
            foreach (var kvp in dictRev)
            {
                var curr_layer = new List<int>();
                var len = 0;
                var i = 0;
                var line = string.Empty;
                foreach (var val in kvp.Value)
                {
                    var str = $"{extra}{Center(val, 3)} ";
                    var offset = 0;
                    if (last_layer.Any())
                    {
                        var left = last_layer[i * 2];
                        var right = last_layer[i * 2 + 1];
                        offset = (int) ((right - left) / 2.0) + left - 1 - line.Length;
                        for (int s = 0; s < offset; s++)
                            str = " " + str;
                    }
                    line += str;
                    len += str.Length;
                    curr_layer.Add(len - 2 - 1);
                    i++;
                }
                lines.Add(line);
                last_layer = curr_layer;
            }
            lines.Reverse();
            foreach (var line in lines)
                Console.WriteLine(line);
        }
        string Center(int i, int width)
        {
            var str = i.ToString();
            if (i == 0)
                str = ".";
            var len = str.Length;
            var delta = width - len;
            if (delta <= 0)
                return str;

            if (delta == 1)
                return " " + str;
            else// if (delta == 2)
                return " " + str + " ";
        }
        void Layers(Dictionary<int, List<int>> dict, int layer)
        {
            if (!dict.ContainsKey(layer))
                dict.Add(layer, new List<int>());
            if (!dict.ContainsKey(layer + 1))
                dict.Add(layer + 1, new List<int>());
            dict[layer].Add(val);
            if (right != null)
                right.Layers(dict, layer + 1);
            else
                dict[layer + 1].Add(-1);

            if (left != null)
                left.Layers(dict, layer + 1);
            else
                dict[layer + 1].Add(-1);

        }

        public virtual void PrintCurrentLevel(TreeNode root, int level)
        {
            if (root == null)
            {
                return;
            }
            if (level == 1)
            {
                Console.Write(root.val + " ");
            }
            else if (level > 1)
            {
                PrintCurrentLevel(root.left, level - 1);
                PrintCurrentLevel(root.right, level - 1);
            }
        }
        int Height()
        {
            /* compute height of each subtree */
            int lheight = left?.Height() ?? 0;
            int rheight = right?.Height() ?? 0;

            /* use the larger one */
            if (lheight > rheight)
            {
                return (lheight + 1);
            }
            else
            {
                return (rheight + 1);
            }
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
