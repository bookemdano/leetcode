using System;
using System.Collections.Generic;

namespace leetcode
{
    public class AtoI
    {
        static public void Test()
        {
            var c = new AtoI();

            Dessert.AssertSame(42, c.MyAtoi("42"));
            Dessert.AssertSame(-42, c.MyAtoi("-42"));
            Dessert.AssertSame(0, c.MyAtoi("words and 987"));
            Dessert.AssertSame(4193, c.MyAtoi("4193 with words"));
            Dessert.AssertSame(-2147483648, c.MyAtoi("-91283472332"));
            Dessert.AssertSame(2147483647, c.MyAtoi("91283472332"));
            Dessert.AssertSame(0, c.MyAtoi("+-12"));
            Dessert.AssertSame(-12, c.MyAtoi(" -0012a42"));
            Dessert.AssertSame(2147483647, c.MyAtoi("2147483648"));
            Dessert.AssertSame(-2147483648, c.MyAtoi("-2147483648"));
            Dessert.AssertSame(-2147483647, c.MyAtoi("-2147483647"));

        }
        public int MyAtoi(string s)
        {
            var first = true;
            var neg = false;
            var rv = 0L;
            foreach(var c in s)
            {
                if (first && c == ' ')
                    continue;
                if (c < '0' || c > '9')
                {
                    if (first && c == '-')
                        neg = true;
                    else if (first && c == '+')
                        neg = false;
                    else
                        break;
                    first = false;
                    continue;
                } 
                first = false;
                rv = rv * 10L + (c - '0');
                if (neg && (0 - rv) <= int.MinValue)
                    return int.MinValue;
                else if (!neg && rv >= int.MaxValue)
                    return int.MaxValue;
            }
            if (neg)
                rv = 0 - rv;
            return (int) rv;
        }
    }
}
