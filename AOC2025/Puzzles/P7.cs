using System.Collections;

namespace AOC2025.Puzzles;

public static class P7
{
    public static long Solve1()
    {
        var grid = Utils.ConvertFileTo2dListChar(nameof(P7));
        var split = 0;
        var beams = new Queue<(int, int)>();

        for (var x = 0; x < grid[0].Count; x++)
        {
            var c = grid[0][x];
            if (c == 'S')
            {
                beams.Enqueue((x, 1));
                break;
            }
        }
        
        var width = grid[0].Count;
        var height = grid.Count;
        var visited = new HashSet<(int, int)>();

        while (beams.Count > 0)
        {
            var (x, y) = beams.Dequeue();
            if (y >= height)
            {
                continue;
            }

            if (!visited.Add((x, y)))
            {
                continue;
            }

            switch (grid[y][x])
            {
                case '.':
                    beams.Enqueue((x, y + 1));
                    break;
                case '^':
                {
                    split++;
                    if (x - 1 >= 0)
                    {
                        beams.Enqueue((x - 1, y + 1));
                    }

                    if (x + 1 < width)
                    {
                        beams.Enqueue((x + 1, y + 1));
                    }

                    break;
                }
            }
        }
        
        return split;
    }

    public static long RecursiveDfs(List<List<char>> grid, (int, int) coordinates, Dictionary<(int, int), long> memo)
    {
        if (memo.TryGetValue(coordinates, out var memoizedCount))
        {
            return memoizedCount;
        }

        var count = 0L;
        
        var height = grid.Count;
        var width = grid[0].Count;
        
        var (x,y) = coordinates;

        if (y >= height)
        {
            return 0;
        }

        if (x >= width)
        {
            return 0;
        }

        if (x < 0)
        {
            return 0;
        }

        switch (grid[y][x])
        {
            case '.':
                count += RecursiveDfs(grid, (x, y + 1), memo);
                break;
            case '^':
            {
                count ++;
                if (x - 1 >= 0)
                {
                    count += RecursiveDfs(grid, (x - 1, y + 1), memo);
                }

                if (x + 1 < width)
                {
                    count += RecursiveDfs(grid, (x + 1, y + 1), memo);
                }

                break;
            }
        }

        memo[coordinates] = count;

        return count;
    }

    public static long Solve2()
    {
        var grid = Utils.ConvertFileTo2dListChar(nameof(P7));
        //var visited = new HashSet<(int, int)>();
        var y = 1;
        var x = 0;

        for (var i = 0; i < grid[0].Count; i++)
        {
            var c = grid[0][i];
            if (c == 'S')
            {
                x = i;
                break;
            }
        }
        
        var memo = new Dictionary<(int, int), long>();
        return RecursiveDfs(grid, (x, y), memo) + 1;
    }
}