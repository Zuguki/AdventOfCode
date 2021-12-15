using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public static class Day5
    {
        private const string FileOnePath = "../../../Files/Day5FirstTask.txt";
        private const string FileTestPath = "../../../Files/Test.txt";
        private static int maxValue;

        public static int Task1()
        {
            var numbersCollection = GetFileInput(FileOnePath);
            SetMaxValues(numbersCollection);
            var matrix = new int[maxValue + 1, maxValue + 1];

            foreach (var numbers in numbersCollection)
            {
                if (numbers[0] == numbers[2])
                    matrix = SetValueToMatrix(matrix, numbers, true);
                if (numbers[1] == numbers[3])
                    matrix = SetValueToMatrix(matrix, numbers, false);
            }

            var sum = 0;
            for (var column = 0; column < maxValue; column++)
            {
                for (var row = 0; row < maxValue; row++)
                {
                    if (matrix[column, row] > 1)
                        sum++;
                }
            }

            return sum;
        }

        public static int Task2()
        {
            return 1;
        }

        private static int[,] SetValueToMatrix(int[,] matrix, IReadOnlyList<int> numbers, bool isVertical)
        {
            var min = isVertical ? Math.Min(numbers[1], numbers[3]) : Math.Min(numbers[0], numbers[2]);
            var max = isVertical ? Math.Max(numbers[1], numbers[3]) : Math.Max(numbers[0], numbers[2]);
            
            while (min <= max)
            {
                if (isVertical)
                    while(min <= max)
                        matrix[min++, numbers[0]]++;
                else
                    while(min <= max)
                        matrix[numbers[1], min++]++;
            }

            return matrix;
        }

        private static IEnumerable<int[]> GetFileInput(string filePath = FileTestPath)
        {
            var fileLines = File.ReadAllLines(filePath)
                .Select(s => s.Split(','));

            var resultLines = new List<int[]>();
            foreach (var line in fileLines)
            {
                var middleLine = line[1].Split(" -> ");
                var middleIntLine = middleLine.Select(int.Parse).ToArray();
                resultLines.Add(new[] {int.Parse(line[0]),
                    middleIntLine[0], middleIntLine[1],
                    int.Parse(line[2])});
            }

            return resultLines;
        }

        private static void SetMaxValues(IEnumerable<int[]> numbersCollection)
        {
            foreach (var numbers in numbersCollection)
            {
                maxValue = Math.Max(numbers[0], numbers[2]) > maxValue ? Math.Max(numbers[0], numbers[2]) : maxValue;
                maxValue = Math.Max(numbers[1], numbers[3]) > maxValue ? Math.Max(numbers[1], numbers[3]) : maxValue;
            }
        }
    }
}