using AOC2025.Puzzles;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2025
{
    internal class Solver : ISolver
    {
        public long SolvePart1()
        {
            return P7.Solve1();
        }
        
        public long SolvePart2()
        {
            return P7.Solve2();
        }
    }
}
