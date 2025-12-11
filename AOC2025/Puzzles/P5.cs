using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2025.Puzzles
{
    public static class P5
    {
        public static long Solve1()
        {
            var lines = Utils.ConvertFileToListString(typeof(P5).Name);
            var encounteredEmptyLine = false;
            var intervals = new List<Tuple<long, long>>();
            var numbers = new List<long>();
            var total = 0;
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    encounteredEmptyLine = true;
                    continue;
                }
                if (!encounteredEmptyLine)
                {
                    var parts = line.Split('-');
                    long.TryParse(parts[0], out long begin);
                    long.TryParse(parts[1], out long end);
                    intervals.Add(new Tuple<long, long>(begin, end));
                }
                else
                {
                    long.TryParse(line, out long number);
                    numbers.Add(number);
                }
            }

            foreach (var number in numbers)
            {
                foreach (var interval in intervals)
                {
                    var (begin, end) = interval;
                    if (number >= begin && number <= end)
                    {
                        total++;
                        break;
                    }
                }
            }

            return total;
        }

        public static long Solve2()
        {
            var lines = Utils.ConvertFileToListString(typeof(P5).Name);
            var intervals = new List<Tuple<long, long>>();
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }
                var parts = line.Split('-');
                long.TryParse(parts[0], out long begin);
                long.TryParse(parts[1], out long end);
                intervals.Add(new Tuple<long, long>(begin, end));
            }

            var SortedIntervals = intervals.OrderBy(i => i.Item1).ThenBy(i => i.Item2);

            var islands = new List<Tuple<long, long>>();

            foreach (var interval in SortedIntervals)
            {
                var (begin, end) = interval;

                if (islands.Count == 0)
                {
                    // first island we create
                    islands.Add(Tuple.Create(begin, end));
                }

                var lastIsland = islands[islands.Count - 1];
                var (lastBegin, lastEnd) = lastIsland;
                if (begin > lastEnd)
                {
                    // no overlap with existing island
                    islands.Add(Tuple.Create(begin, end));
                }
                else if (end > lastEnd && begin <= lastEnd)
                {
                    islands[islands.Count - 1] = Tuple.Create(lastBegin, end);
                }
            }

            var sum = 0L;
            foreach (var island in islands)
            {
                var (begin, end) = island;
                sum += (end - begin) + 1;
            }

            return sum;
        }
    }
}
