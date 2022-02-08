using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using leetcode.Utils;

namespace leetcode.Problems
{
    internal class WordSearch
    {
        internal static void Test()
        {
            var lines = File.ReadAllLines("assets/wordsearch.txt");
            var stringGrid = new List<string>();
            bool inGrid = true;
            var words = new List<string>();
            foreach (var line in lines)
            {
                if (inGrid)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        inGrid = false;
                    else
                        stringGrid.Add(line.ToLower());
                }
                else
                {
                    words.Add(line.ToLower());
                }
            }
            MakeGridWithRetry(words);

            Solve(new Grid(stringGrid), words);

        }

        private static void MakeGridWithRetry(List<string> words)
        {
            var overTries = 0;
            var best = -1;
            var sw = Stopwatch.StartNew();
            while (best < words.Count())
            {
                ++overTries;
                var grid = CreateGrid(words, 30, 29);
                if (grid.Words.Count() > best || overTries % 1000 == 0)
                {
                    if (grid.Words.Count() > best)
                    {
                        if (grid.Words.Count() > 100)
                        {
                            Console.WriteLine($"New best {grid}");
                            grid.FillRest();
                            File.WriteAllText($"new{grid.Words.Count()}grid{DateTime.Now.ToString("yyyyMMdd HHmmss")}.txt", grid.ToGridString());
                        }
                        best = grid.Words.Count();
                    }
                    Console.WriteLine($"Start Over {overTries} tries, best {best}, time {sw.Elapsed / overTries}");
                }
            }
        }
        private static Grid CreateGrid(List<string> words, int rows, int cols)
        {
            var grid = new Grid(rows, cols);
            var rnd = new Random();
            var myWords = words.OrderByDescending(w => w.Length).ToList();
            foreach(var word in myWords)
            //while(myWords.Count() > 0)
            {
            //    var word = myWords[rnd.Next(myWords.Count())];
                var posList = new GridPos[word.Count()];
                var tries = 0;
                while (true)
                {
                    if (++tries > 500)
                    {
                        var posList1 = grid.TryEverything(word);
                        if (posList1 == null)
                            grid.MissingWords.Add(word);
                        else
                        {
                            grid.Words.Add(word);
                            grid.Mark(posList1, word);
                        }

                        break;  // next word
                        //Console.WriteLine("Stuck on " + word);
                        //return grid;
                    }
                    var dir = Enum.GetValues<DirEnum>()[rnd.Next(8)];

                    GridPos pos = new GridPos(rnd.Next(rows), rnd.Next(cols));
                    // keep moving pos back until it bumps into something
                    while (true)
                    {
                        var leftPos = grid.Next(pos, Opposite(dir));
                        if (leftPos == null || grid.Get(pos) != 0)
                            break;
                        else
                            pos = leftPos;
                    }
                    if (rnd.NextDouble() > .25)
                    {
                        var index = rnd.Next(word.Length);
                        var c = word[index];
                        var newPos = grid.FindNext(c, pos, true);
                        if (newPos != null)
                        {
                            // walk back to start of word
                            newPos = grid.Next(newPos, Opposite(dir), index);
                            if (newPos != null)
                                pos = newPos;
                        }
                    }
                    int i = 0;
                    var found = true;
                    foreach (var c in word)
                    {
                        if (pos == null)
                        {
                            found = false;
                            break;
                        }
                        if (!Grid.Compare(grid.Get(pos), c))
                        {
                            found = false;
                            break;
                        }
                        posList[i++] = pos;
                        pos = grid.Next(pos, dir);
                    }
                    if (found)
                    {
                        grid.Words.Add(word);
                        grid.Mark(posList, word);
                        //myWords.Remove(word);
                        break;
                    }
                }
            }
            //grid.FillRest();
            //File.WriteAllText($"newgrid{DateTime.Now.ToString("yyyyMMdd HHmmss")}.txt", grid.ToGridString());
            //Console.WriteLine(grid.ToGridString());
            return grid;

        }

        static void Solve(Grid grid, List<string> words)
        { 
            //var word = "zinc";
            foreach (var word in words)
            {
                var posList = grid.FindWord(word, 0);
                if (posList != null)
                {
                    Console.WriteLine(word + " found at " + posList[0]);
                    grid.Mark(posList, word);
                }
                else
                {
                    Console.WriteLine(word + " NOT Found!!!");
                    posList = grid.FindWord(word, 1);   // try with one bad letter

                }
            }

            File.WriteAllText($"wordfound{DateTime.Now.ToString("yyyyMMdd HHmmss")}.txt", grid.ToGridString());
            Console.WriteLine(grid.ToGridString());
        }
        static DirEnum Opposite(DirEnum dir)
        {
            return (DirEnum)(((int)dir + 4) % 8);
        }
        enum DirEnum
        {
            E,
            SE,
            S,
            SW,
            W,
            NW,
            N,
            NE,
        }
        class GridPos
        {
            public GridPos(int row, int col)
            {
                Row = row;
                Col = col;
            }

            public int Row { get; }
            public int Col { get; }
            public override string ToString()
            {
                return $"({Row},{Col})";
            }

        }
        class Grid
        {
            public List<string> Words { get; set; } = new List<string>();
            public List<string> MissingWords { get; set; } = new List<string>();
            public Grid(int rows, int cols)
            {
                _rows = rows;
                _cols = cols;
                _chars = new char[_rows * _cols];
            }
            public Grid(List<string> stringGrid)
            {
                _rows = stringGrid.Count();
                _cols = stringGrid.First().Length;
                _chars = new char[_rows * _cols];
                var i = 0;
                foreach (var line in stringGrid)
                {
                    foreach (var c in line)
                        _chars[i++] = c;
                }

            }
            public GridPos? Next(GridPos pos)
            {
                var row = pos.Row;
                var col = pos.Col + 1;
                if (col >= _cols)
                {
                    col = 0;
                    row++;
                }
                if (row >= _rows)
                    return null;
                return new GridPos(row, col);
            }
            public GridPos? Next(GridPos pos, DirEnum dir, int count)
            {
                var rv = pos;
                for (int i = 0; i < count; i++)
                {
                    rv = Next(rv, dir);
                    if (rv == null)
                        return null;
                }
                return rv;
            }
            public GridPos? Next(GridPos pos, DirEnum dir)
            {
                var row = pos.Row;
                var col = pos.Col;
                if (dir == DirEnum.E || dir == DirEnum.NE || dir == DirEnum.SE)
                    col++;
                if (dir == DirEnum.W || dir == DirEnum.NW || dir == DirEnum.SW)
                    col--;

                if (dir == DirEnum.S || dir == DirEnum.SE || dir == DirEnum.SW)
                    row++;
                if (dir == DirEnum.N || dir == DirEnum.NE || dir == DirEnum.NW)
                    row--;

                if (col < 0 || col >= _cols)
                    return null;
                if (row < 0 || row >= _rows)
                    return null;
                return new GridPos(row, col);
            }

            public GridPos? FindNext(char c, GridPos pos, bool strict)
            {
                var i = PosToIndex(pos) + 1;
                if (i >= _rows * _cols)
                    return null;
                for (; i < _rows * _cols; i++)
                {
                    if (Compare(_chars[i], c, strict))
                        return PosFromIndex(i);
                }
                return null;
            }
            public GridPos? FindOneSlowAndFair(char c)
            {
                var indexList = new List<int>(); 
                for (var i = 0; i < _rows * _cols; i++)
                {
                    if (Compare(_chars[i], c, strict: true))
                        indexList.Add(i);
                }
                if (!indexList.Any())
                    return null;
                return PosFromIndex(FakeHelper.PickOne<int>(indexList));
            }
            int PosToIndex(GridPos pos)
            {
                return pos.Row * _cols + pos.Col;
            }
            GridPos PosFromIndex(int index)
            {
                var row = index / _cols;
                var col = index % _cols;
                return new GridPos(row, col) ;
            }
            public char Get(GridPos pos)
            {
                return _chars[PosToIndex(pos)];
            }

            public void Mark(IList<GridPos> posList, string word)
            {
                word = word.ToUpper();
                for (int i = 0; i < posList.Count(); i++)
                    _chars[PosToIndex(posList[i])] = word[i];
            }

            internal List<GridPos> SearchWord(string word, GridPos pos, DirEnum dir, int allowedBads)
            {
                var rv = new List<GridPos>();
                var bads = 0;
                foreach (var c in word)
                {
                    if (pos == null)
                        return null;    // hit edge of grid
                    if (!Compare(c, Get(pos)))
                        bads++;
                    if (bads > allowedBads)
                        return null;
                    rv.Add(pos);
                    pos = Next(pos, dir);
                }
                return rv;
            }

            public override string ToString()
            {
                int unused = 0;
                int used = 0;
                for (int iRow = 0; iRow < _rows; iRow++)
                {
                    for (int iCol = 0; iCol < _cols; iCol++)
                    {
                        var c = Get(new GridPos(iRow, iCol));
                        if (c >= 97 || c == 0 || c == ' ')
                            unused++;
                        else
                            used++;
                    }
                }
                return $"{_rows}x{_cols} {used} used {unused} unused {Words.Count} words {MissingWords.Count} missing";
            }
            public string ToGridString()
            {
                var rv = new List<string>();
                int unused = 0;
                for (int iRow = 0; iRow < _rows; iRow++)
                {
                    var line = string.Empty;
                    for (int iCol = 0; iCol < _cols; iCol++)
                    {
                        var c = Get(new GridPos(iRow, iCol));
                        if (c >= 97 || c == 0 || c == ' ')
                            unused++;
                        line += c;
                    }
                    rv.Add(line);
                }
                rv.Add($"{unused} unused");
                rv.Add($"{Words.Count()} words");
                rv.Add("Missing " + string.Join(',', MissingWords));
                return string.Join(Environment.NewLine, rv);
            }
            public static bool Compare(char lh, char rh, bool strict = false)
            {
                if (strict == false && (lh == 0 || rh == 0))
                    return true;
                return char.ToLower(lh) == char.ToLower(rh);
            }

            internal List<GridPos> FindWord(string word, int allowedBads)
            {
                var root = word[0];
                var pos = FindNext(root, new GridPos(0, -1), false);
                while (pos != null)
                {
                    foreach (var dir in Enum.GetValues<DirEnum>())
                    {
                        var posList = SearchWord(word, pos, dir, allowedBads);
                        if (posList != null)
                            return posList;
                    }
                    pos = FindNext(root, pos, false);
                }
                return null;
            }

            internal void FillRest()
            {
                var rnd = new Random();
                for (int i = 0; i < _chars.Length; i++)
                {
                    if (_chars[i] == 0)
                        _chars[i] = ' '; // rnd.Next(26) + 'a';
                }
            }

            internal List<GridPos> TryEverything(string word)
            {
                var root = word[0];
                var tryList = new List<GridPos>();
                var pos = FindNext(root, new GridPos(0, -1), false);
                while (pos != null)
                {
                    tryList.Add(pos);
                    pos = FindNext(root, pos, false);
                }

                while (tryList.Any())
                {
                    pos = FakeHelper.PickOne<GridPos>(tryList);
                    foreach (var dir in Enum.GetValues<DirEnum>())
                    {
                        var posList = SearchWord(word, pos, dir, 0);
                        if (posList != null)
                            return posList;
                    }
                    tryList.Remove(pos);
                }
                return null;
            }

            public char[] _chars;
            public int _rows;
            public int _cols;
        }
    }
}
