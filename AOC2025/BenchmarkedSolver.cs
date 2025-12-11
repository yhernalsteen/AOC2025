using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Characteristics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2025
{
    public class BenchmarkedSolver: ISolver
    {
        private readonly Solver _solver = new();

        [Benchmark]
        public long SolvePart1() => _solver.SolvePart1();

        [Benchmark]
        public long SolvePart2() => _solver.SolvePart2();

    }
}
