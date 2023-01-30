using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public static class Day2
    {
        private const string FileOnePath = "../../../Files/Day2FirstTask.txt";
        private const string FileTwoPath = "../../../Files/Day2SecondTask.txt";
        
        private const string FileTestPath = "../../../Files/Test.txt";

        public static int Task1()
        {
            var result = new Dictionary<string, int>();
            var input = GetFileInput(FileOnePath);
            
            foreach (var item in input)
            {
                if (result.ContainsKey(item[0]))
                    result[item[0]] += int.Parse(item[1]);
                else
                    result.Add(item[0], int.Parse(item[1]));
            }
            
            return result["forward"] * (result["down"] - result["up"]);
        }

        public static int Task2()
        {
            var result = new Dictionary<string, int>
            {
                {"aim", 0},
                {"depth", 0}
            };
            var input = GetFileInput(FileTwoPath);
            
            foreach (var item in input)
            {
                var num = int.Parse(item[1]);
                if (result.ContainsKey(item[0]))
                    result[item[0]] += num;
                else
                    result.Add(item[0], num);

                result["aim"] = GetAim(item[0], num, result["aim"]);
                if (item[0] == "forward")
                    result["depth"] += GetDepth(result["aim"], num);
            }
            
            return result["depth"] * result["forward"];
        }

        private static IEnumerable<string[]> GetFileInput(string filePath) => File.ReadAllLines(filePath)
            .Select(s => s.Split(' '));

        private static int GetAim(string direction, int value, int aim)
        {
            var result = aim;

            switch (direction)
            {
                case "down":
                    result += value;
                    break;
                case "up":
                    result -= value;
                    break;
            }

            return result;
        }

        private static int GetDepth(int aim, int value) => value * aim;
        
    }
}