using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Utils
{
    internal class FakeHelper
    {
        static Random _rnd = new Random();
        static public T PickOne<T>(IList<T> list)
        {
            return list[_rnd.Next(list.Count())];
        }
    }
}
