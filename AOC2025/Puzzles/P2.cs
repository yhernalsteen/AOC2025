using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2025.Puzzles
{
    public static class P2
    {
        private static Dictionary<long, long> LengthDict = new Dictionary<long, long>(); 
        public static long Solve1()
        {
            var filename = typeof(P2).Name;
            var text = Utils.ConvertFileToString(filename);
            var ranges = text.Split(",");
            var invalid = new List<long>();
            foreach ( var range in ranges)
            {
                var intervals = range.Split("-");
                _ = long.TryParse(intervals[0], out long start);
                _ = long.TryParse(intervals[1], out long end);
               var i = start;
               while (i <= end)
                {
                    if (!IsValidInt(i))
                    {
                        invalid.Add(i);
                    }
                    i++;
                }
            }
            return invalid.Sum();
        }

        private static bool IsIntEvenLenght(long v)
        {

            return LenghtOfInt(v) % 2 == 0;
        }

        private static long LenghtOfInt(long v)
        {
            if (LengthDict.ContainsKey(v))
            {
                return LengthDict[v];
            }

            long lenght = 1;
            while (v >= 10)
            {
                v = v / 10;
                lenght++;
            }
            LengthDict[v] = lenght;
            return lenght;
        }

        private static (long, long) DivideEvenInt(long v)
        {
            var length = LenghtOfInt(v);
            var sizeOfHalf = length / 2;

            var halfOne = v / (long)Math.Pow(10, sizeOfHalf);
            var halfTwo = v - (halfOne * (long)Math.Pow(10, sizeOfHalf));

            return (halfOne, halfTwo);
        }

        private static bool IsValidInt(long v)
        {
            if (!IsIntEvenLenght(v))
            {
                return true;
            }

            var (halfone, halftwo) = DivideEvenInt(v);

            if (halfone == halftwo)
            {
                return false;
            }


            return true;
        }
    }
}
