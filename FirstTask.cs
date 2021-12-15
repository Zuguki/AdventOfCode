using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public static class FirstTask
    {
        private const string FilePath = "../../../Files/Day1FirstTask.txt";

        public static int Task1()
        {
            var numbers = GetFileInts();
            return numbers.Skip(1)
                .Where((number, i) => number > numbers[i])
                .Count();
        }

        private static List<int> GetFileInts() => File.ReadAllLines(FilePath)
            .Select(int.Parse)
            .ToList();
    }
}