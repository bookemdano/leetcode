using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode
{
    partial class Program
    {
        public class NestedIterator
        {
            private IList<NestedInteger> _nestedList;

            public NestedIterator(IList<NestedInteger> nestedList)
            {
                _nestedList = nestedList;
            }
            private int _i = 0;
            private NestedIterator _inner = null;
            public bool HasNext()
            {
                //if (_nestedList.Count() > 500 || _nestedList.Count() < 1)
                //    return false;
                
                while(_i < _nestedList.Count())
                {
                    var current = _nestedList.ElementAt(_i);
                    if (current.IsInteger())
                        return (_i < _nestedList.Count());
                    else
                    {
                        if (_inner == null)
                            _inner = new NestedIterator(current.GetList());
                        if (_inner.HasNext())
                            return true;
                        
                        if (_inner?.HasNext() == false)
                        {
                            _i++;
                            _inner = null;
                        }

                    }
                }

                return (_i < _nestedList.Count());
            }

            public int Next()
            {
                var current = _nestedList.ElementAt(_i);
                if (current.IsInteger())
                {
                    _i++;
                    return current.GetInteger();
                }

                return _inner.Next();
            }
        }
        public interface NestedInteger
        {

            // @return true if this NestedInteger holds a single integer, rather than a nested list.
            bool IsInteger();

            // @return the single integer that this NestedInteger holds, if it holds a single integer
            // Return null if this NestedInteger holds a nested list
            int GetInteger();

            // @return the nested list that this NestedInteger holds, if it holds a nested list
            // Return null if this NestedInteger holds a single integer
            IList<NestedInteger> GetList();
        }
        public class NIInt : NestedInteger
        {
            private int _i;

            public NIInt(int i)
            {
                _i = i;
            }
            public int GetInteger()
            {
                return _i;
            }

            public IList<NestedInteger> GetList()
            {
                throw new NotImplementedException();
            }

            public bool IsInteger()
            {
                return true;
            }

            static public List<NestedInteger> ParseList(string str)
            {
                var rv = new List<NestedInteger>();
                var parts = str.Split(",");
                foreach (var part in parts)
                    rv.Add(new NIInt(int.Parse(part)));
                return rv;
            }

            public override string ToString()
            {
                return $"{GetInteger()}";
            }
        }
        public class NIList : NestedInteger
        {
            private List<NestedInteger> _list;
            private NIList()
            {

            }
            public NIList(int n, int i)
            {
                _list = new List<NestedInteger>();
                for (int j = 0; j < n; j++)
                    _list.Add(new NIInt(i));

            }

            internal static NIList Deep(int levels)
            {
                var rv = new NIList();
                rv._list = new List<NestedInteger>();
                rv._list.Add(new NIInt((int)Math.Pow(levels, 2)));
                if (levels > 1)
                    rv._list.Add(NIList.Deep(levels - 1));
                return rv;
            }

            internal static NIList Empty(int levels)
            {
                var rv = new NIList();
                rv._list = new List<NestedInteger>();
                if (levels > 1)
                    rv._list.Add(NIList.Empty(levels - 1));
                return rv;
            }

            internal static NIList Parse(string str)
            {
                //[[1,1],2,[1,1]]
                //[3,2,1]
                var rv = new NIList();
                rv._list = new List<NestedInteger>();
                var count = 0;
                int iStart = 0;
                while (str.Contains('['))
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        var c = str[i];
                        if (c == '[')
                        {
                            if (count == 0 && i > 0)
                            {
                                rv._list.AddRange(NIInt.ParseList(str.Substring(0, i - 1)));
                                str = str.Remove(0, i - 1).Trim(',');
                                break;
                            }
                            if (count == 0)
                                iStart = i + 1;
                            count++;
                        }
                        if (c == ']')
                        {
                            count--;
                            if (count == 0)
                            {
                                rv._list.Add(Parse(str.Substring(iStart, i - iStart)));
                                str = str.Remove(iStart - 1, i - iStart + 2).Trim(',');
                                break;
                            }
                        }
                    }
                }
                if (!string.IsNullOrWhiteSpace(str))
                    rv._list.AddRange(NIInt.ParseList(str));

                return rv;
            }
            public int GetInteger()
            {
                throw new NotImplementedException();
            }

            public IList<NestedInteger> GetList()
            {
                return _list.Cast<NestedInteger>().ToList();
            }

            public bool IsInteger()
            {
                return false;
            }
            public override string ToString()
            {
                var parts = new List<string>();
                foreach (var i in GetList())
                    parts.Add(i.ToString());
                return $"[{string.Join(",", parts)}]";
            }


        }

    }
}
