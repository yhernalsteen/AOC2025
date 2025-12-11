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
        [Benchmark]
        public long SolvePart1()
        {
            return P6.Solve1();
        }

        [Benchmark]
        public long SolvePart2()
        {
            return P6.Solve2();
        }
    }
}
