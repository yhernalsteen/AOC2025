using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2025.Puzzles
{
    public static class P3
    {
        public static long Solve1()
        {
            var lines = Utils.ConvertFileToListString(typeof(P3).Name);
            var result = 0L;
            foreach (var line in lines)
            {
                var numbers = line.Select(x => (int)char.GetNumericValue(x)).ToList();

                var biggest = GetBiggestNumbers(numbers, 2);

                var localResult = ListToLong(biggest);
                Console.WriteLine($"{ListToLong(numbers)} - {localResult}");
                result += localResult;
            }

            return result;
        }

        private static long ListToLong(List<int> numbers)
        {
            var result = 0L;
            for (var i = 0; i < numbers.Count; i++)
            {
                result += numbers[i] * (long)Math.Pow(10, numbers.Count - 1 - i);
            }
            return result;
        }

        public static List<int> GetBiggestNumbers(List<int> numbers, int amount)
        {
            var currIndex = 0;
            var currentAmount = 0;
            var list = new List<int>();
            for (var i = 0; i < amount; i++)
            {
                var biggest = 0;
                for (var j = currIndex; j < numbers.Count - (amount - currentAmount - 1); j++)
                {
                    if (numbers[j] > biggest)
                    {
                        biggest = numbers[j];
                        currIndex = j + 1;
                    }
                }
                list.Add(biggest);
                currentAmount += 1;
            }
            return list;
        }

        public static long Solve2()
        {
            var lines = Utils.ConvertFileToListString(typeof(P3).Name);
            var result = 0L;
            foreach (var line in lines)
            {
                var numbers = line.Select(x => (int)char.GetNumericValue(x)).ToList();

                var biggest = GetBiggestNumbers(numbers, 12);

                var localResult = ListToLong(biggest);
                Console.WriteLine($"{ListToLong(numbers)} - {localResult}");
                result += localResult;
            }

            return result;
        }
    }
}
