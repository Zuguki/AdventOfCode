using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public static class Day8
    {
        private const string FileOnePath = "../../../Files/Day8FirstTask.txt";
        private const string FileTestPath = "../../../Files/Test.txt";

        private static readonly Dictionary<int, string> Dict = new()
        {
            {0, "abcefg"},
            {1, "cf"},
            {2, "acdeg"},
            {3, "acdfg"},
            {4, "bcdf"},
            {5, "abdfg"},
            {6, "abdefg"},
            {7, "acf"},
            {8, "abcdefg"},
            {9, "abcdfg"}
        };

        public static int Task1()
        {
            var segments = GetFileInput(FileOnePath);
            var correct = 0;
            foreach (var segment in segments)
            {
                correct += segment
                    .Count(segmentVal => 
                        segmentVal.Length == Dict[1].Length 
                        || segmentVal.Length == Dict[4].Length 
                        || segmentVal.Length == Dict[7].Length 
                        || segmentVal.Length == Dict[8].Length);
            }
            
            return correct;
        }

        public static int Task2()
        {
            return 1;
        }

        private static List<string[]> GetFileInput(string fileName = FileTestPath) => File.ReadAllLines(fileName)
                .Select(s => s.Split('|'))
                .Select(segmentArr => segmentArr[1]
                    .Trim()
                    .Split(' ')
                    .ToArray())
                .ToList();
    }
}