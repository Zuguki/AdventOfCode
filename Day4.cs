using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public static class Day4
    {
        private const string FileOnePath = "../../../Files/Day4FirstTask.txt";
        private const string FileTwoPath = "../../../Files/Day4SecondTask.txt";
        
        private const string FileTestPath = "../../../Files/Test.txt";
        private const int FieldSize = 5;

        public static int Task1()
        {
            var fields = GetFields(FileOnePath);
            var steps = GetSteps(FileOnePath);
            var counter = 0;
            
            
            var field = GetResultField(fields, steps.Take(FieldSize));
            while (field == null)
                field = GetResultField(fields, steps.Take(FieldSize + ++counter));

            Console.WriteLine(steps[FieldSize + counter - 1]);

            return GetMatrixSum(field, steps.Take(FieldSize + counter)) * steps[FieldSize + counter - 1];
        }

        private static List<int> GetSteps(string filePath = FileTestPath) => File.ReadAllLines(filePath)[0]
            .Split(',')
            .Select(int.Parse)
            .ToList();

        private static List<int[,]> GetFields(string filePath = FileTestPath)
        {
            var fields = new List<int[,]>();
            var field = new int[FieldSize, FieldSize];
            var columnCounter = 0;
            var lines = File.ReadAllLines(filePath)
                .Skip(1)
                .Where(line => line.Length > 1);
            
            foreach (var line in lines)
            {
                var splitLine = line.Split(' ')
                    .Where(s => s != " " && s != "")
                    .ToArray();

                for (var i = 0; i < FieldSize; i++)
                    field[columnCounter, i] = int.Parse(splitLine[i]);

                if (++columnCounter != FieldSize)
                    continue;
                
                columnCounter = 0;
                fields.Add(field);
                field = new int[FieldSize, FieldSize];
            }

            return fields;
        }

        private static int GetMatrixSum(int[,] matrix, IEnumerable<int> steps)
        {
            var sum = 0;
            
            for (var column = 0; column < FieldSize; column++)
            {
                for (var raw = 0; raw < FieldSize; raw++)
                {
                    if (!IsMatched(matrix[column, raw], steps))
                        sum += matrix[column, raw];
                }
            }

            return sum;
        }

        private static bool IsMatched(int number, IEnumerable<int> steps) => 
            steps.Any(step => step == number);

        private static int[,] GetResultField(IEnumerable<int[,]> fields, IEnumerable<int> steps)
        {
            foreach (var field in fields)
            {
                for (var column = 0; column < FieldSize; column++)
                {
                    var columnMatches = 0;
                    var rawMatches = 0;
                    for (var raw = 0; raw < FieldSize; raw++)
                    {
                        if (IsMatched(field[column, raw], steps))
                            rawMatches++;
                        if (IsMatched(field[raw, column], steps))
                            columnMatches++;

                        if (rawMatches == FieldSize || columnMatches == FieldSize)
                            return field;
                    }
                }
            }

            return null;
        }
    }
}