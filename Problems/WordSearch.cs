using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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
            var grid = new Grid(stringGrid);
            //var word = "zinc";
            foreach (var word in words)
            {
                var posList = grid.FindWord(word, 0);
                if (posList != null)
                {
                    Console.WriteLine(word + " found at " + posList[0]);
                    grid.Mark(posList);
                }
                else
                {
                    Console.WriteLine(word + " NOT Found!!!");
                    posList = grid.FindWord(word, 1);

                }

            }
            File.WriteAllText($"wordfound{DateTime.Now.ToString("yyyyMMdd HHmmss")}.txt", grid.ToString());
            Console.WriteLine(grid);
        }
        enum DirEnum
        {
            N,
            NE,
            E,
            SE,
            S,
            SW,
            W,
            NW
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
            GridPos? Next(GridPos pos, DirEnum dir)
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

            public GridPos? FindNext(char c, GridPos pos)
            {
                var i = PosToIndex(pos) + 1;
                if (i >= _rows * _cols)
                    return null;
                for (; i < _rows * _cols; i++)
                {
                    if (Compare(_chars[i], c))
                        return PosFromIndex(i);
                }
                return null;
            }
            int PosToIndex(GridPos pos)
            {
                return pos.Row * _rows + pos.Col;
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
            public void Mark(IEnumerable<GridPos> posList)
            {
                foreach (var pos in posList)
                    _chars[pos.Row * _rows + pos.Col] = char.ToUpper(_chars[pos.Row * _rows + pos.Col]);
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
                var rv = new List<string>();
                for (int iRow = 0; iRow < _rows; iRow++)
                {
                    var line = string.Empty;
                    for (int iCol = 0; iCol < _cols; iCol++)
                    {
                        line += Get(new GridPos(iRow, iCol));
                    }
                    rv.Add(line);
                }
                return string.Join(Environment.NewLine, rv);
            }
            public static bool Compare(char lh, char rh)
            {
                return char.ToLower(lh) == char.ToLower(rh);
            }

            internal List<GridPos> FindWord(string word, int allowedBads)
            {
                var root = word[0];
                var pos = FindNext(root, new GridPos(0, -1));
                while (pos != null)
                {
                    foreach (var dir in Enum.GetValues<DirEnum>())
                    {
                        var posList = SearchWord(word, pos, dir, allowedBads);
                        if (posList != null)
                            return posList;
                    }
                    pos = FindNext(root, pos);
                }
                return null;
            }

            public char[] _chars;
            public int _rows;
            public int _cols;
        }
    }
}
