using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2025.Puzzles
{
    public static class P1
    {
        private static (int, int) GetNextPositionAndZerosEncountered(int number, char direction, int offset)
        {
            var leftBoundary = 0;
            var rightBoundary = 99;

            int isZero = 0;

            while (offset > 0)
            {
                if (direction == 'l' || direction == 'L') 
                {
                    if (number == leftBoundary)
                    {
                        number = rightBoundary;
                    } else
                    {
                        number--;
                    }
                } else if (direction == 'r' || direction == 'R')
                {
                    if (number == rightBoundary) {
                        number = leftBoundary;
                    } else
                    {
                        number++;
                    }
                }
                offset--;

                if (number == 0)
                {
                    isZero++;
                }
            }

            return (number, isZero);
        }

        private static (char, int) GetArguments(string text)
        {
            char c = text[0];
            text = text.Substring(1);
            if (!int.TryParse(text, out int i))
            {
                throw new ArgumentException("String does not contain a valid number!");
            }

            return(c, i);
        }

        public static int Solve()
        {
            var filename = typeof(P1).Name;
            var text = Utils.ConvertFileToListString(filename);

            var position = 50;
            var isZero = 0;    
            foreach(var command in text)
            {
                var (direction, offset)= GetArguments(command);
                int zerosEncounteredInLoop = 0;

                (position, zerosEncounteredInLoop) = GetNextPositionAndZerosEncountered(position, direction, offset);

                isZero += zerosEncounteredInLoop;
            }

            return isZero;
        }
    }
}
