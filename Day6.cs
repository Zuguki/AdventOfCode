using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace AdventOfCode
{
    public static class Day6
    {
        private const string FileOnePath = "../../../Files/Day6FirstTask.txt";
        private const string FileTestPath = "../../../Files/Test.txt";
        private const int Days = 256;

        public static int Task1()
        {
            var numbers = GetFileInput(FileTestPath);
            
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

        public static BigInteger Task2()
        {
            var numbers = GetFileInput(FileOnePath);
            var fishArr = new long[9];

            foreach (var number in numbers)
                fishArr[number]++;

            for (var day = 0; day < Days; day++)
            {
                var newFish = fishArr[0];
                for (var index = 1; index < fishArr.Length; index++)
                    fishArr[index - 1] = fishArr[index];
                
                fishArr[8] = newFish;
                fishArr[6] += newFish;
            }

            return fishArr.Sum();
        }

        private static List<int> GetFileInput(string filePath = FileTestPath) => File.ReadAllLines(filePath)[0]
            .Where(c => c != ',')
            .Select(c => int.Parse(c.ToString()))
            .ToList();
    }
}