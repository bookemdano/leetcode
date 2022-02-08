using leetcode.Problems;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace leetcode
{
    partial class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var sw = Stopwatch.StartNew();
            WordSearch.Test();
            Console.WriteLine($"{sw.Elapsed}");
        }
    }
}
