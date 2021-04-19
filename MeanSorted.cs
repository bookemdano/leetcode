using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode
{
    public class MeanSorted
    {
        public static void Test()
        {
            var sorted = new MeanSorted();
            Dessert.AssertSame(2, sorted.FindMedianSortedArrays(new int[] { 1, 3 }, new int[] { 2 }));
            Dessert.AssertSame(2.5, sorted.FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3, 4 }));
            Dessert.AssertSame(1, sorted.FindMedianSortedArrays(new int[0], new int[] { 1 }));
            Dessert.AssertSame(2, sorted.FindMedianSortedArrays(new int[] { 2 }, new int[0]));

        }
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var nums = new List<int>();
            nums.AddRange(nums1);
            nums.AddRange(nums2);
            var na = nums.OrderBy(n => n).ToArray();
            var len = na.Count();
            var half = (len / 2);
            if (len % 2 == 1)
                return na[half];
            else
                return (na[half - 1] + na[half])/2.0;
        }
    }
}
