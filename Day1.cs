using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public static class Day1
    {
        private const string FileOnePath = "../../../Files/Day1FirstTask.txt";
        private const string FileTwoPath = "../../../Files/Day1SecondTask.txt";

        public static int Task1()
        {
            var numbers = GetFileInts(FileOnePath);
            return numbers.Skip(1)
                .Where((number, i) => number > numbers[i])
                .Count();
        }

        public static int Task2()
        {
            var numbers = GetFileInts(FileTwoPath);
            return numbers.Skip(3)
                .Where((num, ind) => num > numbers[ind])
                .Count();
        }

        private static List<int> GetFileInts(string filePath) => File.ReadAllLines(filePath)
            .Select(int.Parse)
            .ToList();
    }
}