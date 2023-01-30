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

        public static int Task2()
        {
            var lines = GetFileStrings(FileTwoPath);
            var frequentlyNumber = GetFilterWord(lines);
            var rareNumber = GetFilterWord(lines, false);
            
            return Convert.ToInt32(frequentlyNumber, 2)
                   * Convert.ToInt32(rareNumber, 2);
        }

        private static string GetFilterWord(IReadOnlyList<string> lines, bool frequently = true)
        {
            var result = new StringBuilder();
            for (var index = 0; index < lines[0].Length; index++)
            {
                var counter = new[] {0, 0};
                var correctLines = lines.Where(s => s.StartsWith(result.ToString())).ToArray();
                
                if (correctLines.Length == 1)
                    return correctLines[0];
                
                foreach (var line in correctLines)
                {
                    if (lines.Count(s => s.StartsWith(result.ToString())) == 1)
                        return line;
                    
                    if (line[index] == '0')
                        counter[0]++;
                    else
                        counter[1]++;
                }
                
                if (frequently)
                    result.Append(counter[0] > counter[1] ? "0" : "1");
                else
                    result.Append(counter[0] <= counter[1] ? "0" : "1");
            }

            return result.ToString();
        }

        private static List<string> GetFileStrings(string filePath = FileTestPath) => File.ReadAllLines(filePath)
            .ToList();
    }
}