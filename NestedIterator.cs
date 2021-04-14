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
    }
}
