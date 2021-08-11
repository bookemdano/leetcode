using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    class TreeMisc
    {
        static long Solution(long[] prices)
        {
            var dict = new List<Tuple<long, int>>();
            for (int i = 0; i < prices.Length; i++)
                dict.Add(new Tuple<long, int>(prices[i], i));
            var up = dict.OrderBy(d => d.Item1);
            var down = dict.OrderByDescending(d => d.Item1);
            var best = long.MinValue;
            foreach (var i in up)
            {
                foreach (var j in down)
                {
                    if (j.Item2 >= i.Item2)
                    {
                        var diff = j.Item1 - i.Item1;
                        if (diff > best)
                            best = diff;
                        break;
                    }
                }
            }
            return best;
        }
        static long solution(long n)
        {
            if (n == 0)
                return 0;
            long rv = 1;
            if (n > 2)
                rv += solution(n - 3);
            if (n > 1)
                rv += solution(n - 2);
            if (n > 0)
                rv += solution(n - 1);
            return rv;
        }
        static Dictionary<int, long> _founds = new Dictionary<int, long>();
        static long Steps(int n)
        {
            if (_founds.ContainsKey(n))
                return _founds[n];
            long rv = 0;
            for (int i = 3; i > 0; i--)
            {
                if (n >= i)
                {
                    if (n == i)
                        rv++;
                    else
                        rv += Steps(n - i);
                }
            }
            _founds[n] = rv;

            return rv;
        }

        static Dictionary<int, List<List<int>>> _statics = new Dictionary<int, List<List<int>>>();
        static List<List<int>> Steps(int n, List<int> steps)
        {
            if (_statics.ContainsKey(n))
                return _statics[n];
            var rv = new List<List<int>>();
            for (int i = 3; i > 0; i--)
            {
                if (n >= i)
                {
                    var newSteps = new List<int>(steps);
                    newSteps.Add(i);
                    if (n == i)
                        rv.Add(newSteps);
                    else
                        rv.AddRange(Steps(n - i, newSteps));
                }
            }
            _statics[n] = rv;

            return rv;
        }
    }
}
