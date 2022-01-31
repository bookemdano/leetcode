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
            output = Test("[WordDictionary, addWord, addWord, addWord, addWord, search, search, addWord, search, search, search, search, search, search][[],[at],[and],[an],[add],[a],[.at],[bat],[.at],[an.],[a.d.],[b.],[a.d],[.]]");
            Dessert.AssertSame("[null, null, null, null, null, false, false, null, true, true, false, false, true, false]", output);

            output = Test("[WordDictionary, addWord, addWord, addWord, search, search, search, search,[[],[bad],[dad],[mad],[pad],[bad],[.ad],[b..]]");
            Dessert.AssertSame("[null, null, null, null, false, true, true, true]", output);
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
   
    public class WordDictionary
    {
        List<string> _words = new List<string>();    
        public WordDictionary()
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
