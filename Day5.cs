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
        private static int _maxValue;

        public static int Task1()
        {
            var numbersCollection = GetFileInput();
            SetMaxValues(numbersCollection);
            var matrix = new int[_maxValue + 1, _maxValue + 1];

            foreach (var numbers in numbersCollection)
            {
                if (numbers[0] == numbers[2])
                    matrix = SetValueToMatrix(matrix, numbers);
                if (numbers[1] == numbers[3])
                    matrix = SetValueToMatrix(matrix, numbers);
            }

            var sum = 0;
            for (var column = 0; column < _maxValue + 1; column++)
            {
                for (var row = 0; row < _maxValue + 1; row++)
                {
                    if (matrix[column, row] > 1)
                        sum++;
                }
            }

            return sum;
        }

        public static int Task2()
        {
            var numbersCollection = GetFileInput();
            SetMaxValues(numbersCollection);
            var matrix = new int[_maxValue + 1, _maxValue + 1];

            matrix = numbersCollection
                .Aggregate(matrix, SetValueToMatrix);

            var sum = 0;
            for (var column = 0; column < _maxValue + 1; column++)
            {
                for (var row = 0; row < _maxValue + 1; row++)
                {
                    if (matrix[column, row] > 1)
                        sum++;
                }
            }

            return sum;
        }

        private static int[,] SetValueToMatrix(int[,] matrix, IReadOnlyList<int> numbers)
        {
            var dx = (numbers[2] - numbers[0]) switch
            {
                > 0 => 1,
                < 0 => -1,
                _ => 0
            };
            
            var dy = (numbers[3] - numbers[1]) switch
            {
                > 0 => 1,
                < 0 => -1,
                _ => 0
            };
            
            var x = numbers[0];
            var y = numbers[1];

            while (numbers[2] != x || numbers[3] != y)
            {
                matrix[y, x]++;
                x += dx;
                y += dy;
            }
            matrix[y, x]++;

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
                _maxValue = Math.Max(numbers[0], numbers[2]) > _maxValue ? Math.Max(numbers[0], numbers[2]) : _maxValue;
                _maxValue = Math.Max(numbers[1], numbers[3]) > _maxValue ? Math.Max(numbers[1], numbers[3]) : _maxValue;
            }
        }
    }
}