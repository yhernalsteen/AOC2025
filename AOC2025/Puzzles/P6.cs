using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2025.Puzzles
{
    public static class P6
    {
        public static long Solve1()
        {
            var lines = Utils.ConvertFileToListString(typeof(P6).Name);
            var numbersGrid = new List<List<long>>();
            var operators = new List<char>();
            for (var i = 0; i < lines.Count; i++)
            {
                var numbers = new List<long>();
                var sb = new StringBuilder();
                var currentNumber = 0L;
                var hasStreak = false;
                foreach (var c in lines[i].Trim())
                {
                    if (c == ' ' && hasStreak)
                    {
                        numbers.Add(currentNumber);
                        currentNumber = 0;
                        hasStreak = false;
                        continue;
                    }
                    else if (c == ' ')
                    {
                        continue;
                    }


                    if (i == lines.Count - 1)
                    {
                        operators.Add(c);
                    }
                    else
                    {
                        currentNumber = (currentNumber * 10) + (int)char.GetNumericValue(c);
                        hasStreak = true;
                    }
                }

                if (hasStreak)
                {
                    numbers.Add(currentNumber);
                    hasStreak = false;
                }

                if (numbers.Count > 0)
                {
                    numbersGrid.Add(numbers);
                }
            }
            var total = 0L;
            for (var x = 0; x < numbersGrid[0].Count; x++)
            {
                var operatorString = operators[x];
                var result = 0L;
                for (var y = 0; y < numbersGrid.Count; y++)
                {
                    if (operatorString == '+')
                    {
                        result += numbersGrid[y][x];
                    }
                    else if (operatorString == '*')
                    {
                        if (result == 0)
                        {
                            result = 1;
                        }
                        result *= numbersGrid[y][x];
                    }
                }

                total += result;
            }
            return total;
        }

        public static long Solve2()
        {
            return 0;
        }
    }
}
