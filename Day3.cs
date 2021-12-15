using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day3
    {
        private const string FileOnePath = "../../../Files/Day3FirstTask.txt";
        private const string FileTwoPath = "../../../Files/Day3SecondTask.txt";
        
        private const string FileTestPath = "../../../Files/Test.txt";

        public static int Task1()
        {
            var lines = GetFileStrings(FileOnePath);
            var oneValues = new int[lines[0].Length];

            foreach (var line in lines)
            {
                for (var index = 0; index < line.Length; index++)
                {
                    oneValues[index] += line[index] == '1' ? 1 : -1;
                }
            }

            var sBinaryMain = new StringBuilder();
            var sBinaryAddition = new StringBuilder();
            foreach (var value in oneValues)
            {
                sBinaryMain.Append(value > 0 ? 1 : 0);
                sBinaryAddition.Append(value < 0 ? 1 : 0);
            }
            
            return Convert.ToInt32(sBinaryMain.ToString(), 2)
                   * Convert.ToInt32(sBinaryAddition.ToString(), 2);
        }

        private static List<string> GetFileStrings(string filePath = FileTestPath) => File.ReadAllLines(filePath)
            .ToList();
    }
}