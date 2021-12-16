using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public static class Day6
    {
        private const string FileOnePath = "../../../Files/Day6FirstTask.txt";
        private const string FileTestPath = "../../../Files/Test.txt";
        private const int Days = 80;

        public static int Task1()
        {
            var numbers = GetFileInput(FileOnePath);
            
            for (var day = 0; day < Days; day++)
            {
                var numbersCount = numbers.Count;
                for (var index = 0; index < numbersCount; index++)
                {
                    if (numbers[index] == 0)
                    {
                        numbers[index] = 6;
                        numbers.Add(8);
                    }
                    else
                        numbers[index]--;
                }
            }

            return numbers.Count;
        }

        private static List<int> GetFileInput(string filePath = FileTestPath) => File.ReadAllLines(filePath)[0]
            .Where(c => c != ',')
            .Select(c => int.Parse(c.ToString()))
            .ToList();
    }
}