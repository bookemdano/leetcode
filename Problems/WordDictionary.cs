using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Problems
{
    // 2022-01-28
    internal class WordDictionaryTest
    {
        internal static void Test()
        {
            string output;
            output = Test("[WordDictionary, addWord, addWord, addWord, search, search, search, search,[[],[bad],[dad],[mad],[pad],[bad],[.ad],[b..]]");
            Dessert.AssertSame("[null, null, null, null, false, true, true, true]", output);

            output = Test("[WordDictionary, addWord, addWord, addWord, addWord, search, search, addWord, search, search, search, search, search, search][[],[at],[and],[an],[add],[a],[.at],[bat],[.at],[an.],[a.d.],[b.],[a.d],[.]]");
            Dessert.AssertSame("[null, null, null, null, null, false, false, null, true, true, false, false, true, false]", output);

        }
        static string Test(string str)
        {
            var wa = Parse(str);
            var outs = new List<string>();
            var wd = new WordDictionary();
            int i = 0;
            foreach (var word in wa.Actions)
            {
                if (word == "WordDictionary")
                    outs.Add("null");
                else if (word == "addWord")
                {
                    wd.AddWord(wa.Words[i++]);
                    outs.Add("null");
                }
                else if (word == "search")
                {
                    if (wd.Search(wa.Words[i++]))
                        outs.Add("true");
                    else
                        outs.Add("false");
                }
            }
            //for (; i < wa.Words.Count(); i++)
                //outs.Add(wd.Search(wa.Words[i]));
            return "[" + string.Join(", ", outs) + "]";

        }
        static WordAction Parse(string str)
        {
            str = str.Replace("[", "").Replace("]", "").Replace("\"", "").Replace(" ", "");
            var parts = str.Split(",", StringSplitOptions.RemoveEmptyEntries);
            var rv = new WordAction();
            foreach (var part in parts)
            {
                if (part == "WordDictionary" || part == "addWord" || part == "search")
                    rv.Actions.Add(part);
                else
                    rv.Words.Add(part);
            }
            return rv;
        }
        class WordAction
        {
            public List<string> Actions { get; set; } = new List<string>();
            public List<string> Words { get; set; } = new List<string>();
        }
    }
    // binary implementation- never go it working out.
    public class WordDictionaryBinary
    {
        public static readonly char WILD_CHAR = '.';
        public static readonly char END_CHAR = '|';

        int[] _values = new int[500];
        List<string> _words = new List<string>();
        public WordDictionaryBinary()
        {
            
        }

        public void AddWord(string word)
        {
            word += END_CHAR;
            var key = WordToKey(word);
            for (int i = 0; i < key.Length; i++)
                _values[i] = _values[i] | key[i];
            _words.Add(word);
        }

        public bool Search(string word)
        {
            word += END_CHAR;
            var key = WordToKey(word);
            var mask = WordToMask(word);
            var possibleHashes = new List<int>();
            for (int i = 0; i < key.Length; i++)
            {
                if (mask[i] == 1)
                {
                    var ored = _values[i] & key[i];
                    if (ored != key[i])
                        return false;
                }
            }
            return SearchWord(word);
        }

        bool SearchWord(string word)
        {
            if (!word.Contains("."))
                return _words.Contains(word);

            var regex = new System.Text.RegularExpressions.Regex(word);
            foreach (var iWord in _words)
            {
                if (word.Length != iWord.Length)
                    continue;
                if (regex.IsMatch(iWord))
                    return true;
            }
            return false;
        }

        private int[] WordToKey(string word)
        {
            var rv = new int[word.Length];
            for (int i = 0; i < word.Length; i++)
                rv[i] = (int)Math.Pow(2, word[i] - 'a');
            return rv;
        }
        private int KeyToHash(int[] ints)
        {
            var rv = 0;
            foreach(var i in ints)
            {
                rv = rv ^ i;
            }
            return rv;
        }
        private int[] WordToMask(string word)
        {
            var rv = new int[word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == WILD_CHAR)
                    rv[i] = 0;
                else
                    rv[i] = 1;
            }
            return rv;
        }
    }
    // Tree implementation
    public class WordDictionary
    {
        WordNode _head = new WordNode(WordNode.ROOT_CHAR);
        public WordDictionary()
        {

        }

        public void AddWord(string word)
        {
            var node = _head;
            word += WordNode.END_CHAR;
            foreach(var c in word)
            {
                var newNode = node.Children.FirstOrDefault(x => x.Value == c);
                if (newNode == null)
                {
                    newNode = new WordNode(c);
                    node.Children.Add(newNode);
                }
                node = newNode;
            }
        }

        public bool Search(string word)
        {
            var node = _head;
            word += WordNode.END_CHAR;
            return node.Search(word, 0);
        }

        public override string ToString()
        {
            return _head.ToString();
        }
        class WordNode
        {
            public static readonly char WILD_CHAR = '.';
            public static readonly char ROOT_CHAR = '0';
            public static readonly char END_CHAR = '1';
            public WordNode(char c)
            {
                Value = c;
            }

            public char Value { get; }
            public List<WordNode> Children { get; } = new List<WordNode>();
            public override string ToString()
            {
                return $"{Value} ({string.Join("|", Children)})";
            }

            internal bool Search(string word, int i)
            {
                var c = word[i];
                if (c == WordNode.WILD_CHAR)
                {
                    foreach (var node in Children)
                        if (node.Search(word, i + 1))
                            return true;
                }
                var newNode = Children.FirstOrDefault(x => x.Value == c);
                if (newNode == null)
                    return false;
                if (newNode.Value == END_CHAR && c == END_CHAR)
                    return true;
                return newNode.Search(word, i + 1);
            }
        }
    }

    public class WordDictionaryList
    {
        List<string> _words = new List<string>();    
        public WordDictionaryList()
        {

        }

        public void AddWord(string word)
        {
            _words.Add(word);
        }

        public bool Search(string word)
        {
            if (!word.Contains("."))
                return _words.Contains(word);

            var regex = new System.Text.RegularExpressions.Regex(word);
            foreach (var iWord in _words)
            {
                if (word.Length != iWord.Length)
                    continue;
                if (regex.IsMatch(iWord))
                    return true;
            }
            return false;
        }
        bool DotCompareWord(string iWord, string word)
        {
            if (word.Length != iWord.Length)
                return false;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != '.' && iWord[i] != word[i])
                    return false;
            }
            return true;
        }
    }

}
