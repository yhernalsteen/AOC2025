using AOC2025.Puzzles;
using BenchmarkDotNet.Characteristics;
using BenchmarkDotNet.Running;

namespace AOC2025
{
    internal class Program
    {
        static void Main(string[] args)
        {

#if DEBUG
            var solver = new Solver();

            var solution1 = solver.SolvePart1();
            Console.WriteLine(solution1);

            var solution2 = solver.SolvePart2();
            Console.WriteLine(solution2);
#else
            BenchmarkRunner.Run<BenchmarkedSolver>();
#endif
        }
    }
}
