using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode
{
    public class IceCream
    {
        static public void Test()
        {
            var c = new IceCream();
            //[1,3,2,4,1], coins = 7
            Dessert.AssertSame(4, c.MaxIceCream(new int[] { 1, 3, 2, 4, 1 }, 7));
            Dessert.AssertSame(0, c.MaxIceCream(new int[] { 10, 6, 8, 7, 7, 8 }, 5));
            Dessert.AssertSame(6, c.MaxIceCream(new int[] { 1, 6, 3, 1, 2, 5 }, 20));

        }
        public int MaxIceCream(int[] costs, int coins)
        {
            var map = new Dictionary<int, int>();
            foreach(var cost in costs)
            {
                if (cost > coins)
                    continue;
                if (!map.ContainsKey(cost))
                    map.Add(cost, 1);
                else
                    map[cost]++;
            }
            int rv = 0;
            if (map.Count() == 0)
                return rv;
            for (int cost = 1; cost <= coins; cost++)
            {
                if (cost > coins)
                    break;
                if (!map.ContainsKey(cost))
                    continue;
                var ics = map[cost];
                for (int j = 1; j <= ics; j++)
                {
                    if (cost <= coins)
                    {
                        coins -= cost;
                        rv++;
                    }    
                }
            }
            return rv;
        }
    }
}
