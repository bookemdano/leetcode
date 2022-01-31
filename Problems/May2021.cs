using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    public class May2021
    {
        static public void Test()
        {
            TestLeastSum();
        }

        private static void TestLeastSum()
        {
            var c = new May2021();
            Dessert.AssertSame(40, c.MinProductSum(StringUtils.ParseArray("[5,3,4,2]"), StringUtils.ParseArray("[4, 2, 2, 5]")));
            Dessert.AssertSame(65, c.MinProductSum(StringUtils.ParseArray("[2,1,4,5,7]"), StringUtils.ParseArray("[3, 2, 4, 8, 6]")));
        }

        public int MinProductSum(int[] nums1, int[] nums2)
        {
            var n = nums1.Length;
            nums1 = nums1.OrderBy(n => n).ToArray();
            nums2 = nums2.OrderByDescending(n => n).ToArray();
            var rv = 0;
            for (int i = 0; i < n; i++)
                rv += nums1[i] * nums2[i];
            return rv;
        }
    }
}
