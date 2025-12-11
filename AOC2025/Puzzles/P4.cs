using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2025.Puzzles
{
    internal class P4
    {
        private static List<List<char>> _grid = new List<List<char>>();
        public static long Solve1()
        {
            _grid = Utils.ConvertFileTo2dListChar(typeof(P4).Name);
            var total = 0;
            for (var y = 0; y < _grid.Count; y++)
            {
                for (var x = 0; x < _grid.Count; x++)
                {
                    var cell = _grid[y][x];
                    if (cell == '.')
                    {
                        continue;
                    }

                    if (cell == '@')
                    {
                        if (HasFewerThanXNeighboursWithCharacter(x, y, '@', 4))
                        {
                            total++;
                        }
                    }
                }
            }
            return total;
        }

        private static bool HasFewerThanXNeighboursWithCharacter(int x, int y, char character, int expectedAmount)
        {
            var possibilities = new int[] { -1, 0, 1 };
            var amount = 0;
            foreach (var xTransformation in possibilities)
            {
                foreach (var yTransformation in possibilities)
                {
                    var newX = x + xTransformation;
                    var newY = y + yTransformation;

                    if (yTransformation == 0 && xTransformation == 0)
                    {
                        continue;
                    }

                    if (newY < 0 || newY >= _grid.Count)
                    {
                        continue;
                    }

                    if (newX < 0 || newX >= _grid[newY].Count)
                    {
                        continue;
                    }

                    if (_grid[newY][newX] != character)
                    {
                        continue;
                    }
                    amount++;
                }
            }

            return amount < expectedAmount;
        }

        public static long Solve2()
        {
            _grid = Utils.ConvertFileTo2dListChar(typeof(P4).Name);
            var removed = 0;
            while (true)
            {
                var toBeRemoved = new List<Tuple<int, int>>();
                for (var y = 0; y < _grid.Count; y++)
                {
                    for (var x = 0; x < _grid.Count; x++)
                    {
                        var cell = _grid[y][x];
                        if (cell == '.')
                        {
                            continue;
                        }

                        if (cell == '@')
                        {
                            if (HasFewerThanXNeighboursWithCharacter(x, y, '@', 4))
                            {
                                toBeRemoved.Add(new Tuple<int, int>(x, y));
                            }
                        }
                    }
                }

                if (toBeRemoved.Count == 0)
                {
                    return removed;
                }

                foreach (var removalCoordinates in toBeRemoved)
                {
                    var (x, y) = removalCoordinates;
                    _grid[y][x] = '.';
                    removed++;
                }
            }
        }
    }
}
