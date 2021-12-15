using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public static class FirstTask
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
                .Where((num, ind) => num + numbers[ind + 1] + numbers[ind + 2]
                                     > numbers[ind] + numbers[ind + 1] + numbers[ind + 2])
                .Count();
        }

        private static List<int> GetFileInts(string filePath) => File.ReadAllLines(filePath)
            .Select(int.Parse)
            .ToList();
    }
}