using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AOC2025
{
    internal static class Utils
    {
        public static List<string> ConvertFileToListString(string fileName)
        {
            fileName = fileName + ".txt";
            var currentPath = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(currentPath, "Data", fileName);
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }
            var text = new List<string>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    text.Add(line);
                }
            }

            return text;

        }

        public static string ConvertFileToString(string fileName)
        {
            fileName = fileName + ".txt";
            var currentPath = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(currentPath, "Data", fileName);
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }

            using (StreamReader sr = new StreamReader(filePath))
            {
                return sr.ReadToEnd();
            }
        }

        public static List<List<char>>ConvertFileTo2dListChar(string fileName)
        {
            fileName = fileName + ".txt";
            var currentPath = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(currentPath, "Data", fileName);
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }
            var text = new List<string>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    text.Add(line);
                }
            }
            var grid = new List<List<char>>();
            for (int y = 0; y < text.Count; y++)
            {
                var line = text[y];
                var yList = new List<char>();
                for(var x = 0; x < line.Length; x++)
                {
                    yList.Add(line[x]);
                }

                grid.Add(yList);
            }

            return grid;
        }
    }
}
