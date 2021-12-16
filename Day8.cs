using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public static class Day8
    {
        private const string FileOnePath = "../../../Files/Day8FirstTask.txt";
        private const string FileTestPath = "../../../Files/Test.txt";

        private static readonly Dictionary<int, string> Dict = new();

        public static int Task1()
        {
            var output = GetFileInput(FileOnePath, 1);
            return output.Sum(segments => segments.Count(segment => segment.Length is 2 or 4 or 3 or 7));
        }

        public static int Task2()
        {
            var patterns = GetFileInput(FileOnePath, 0);
            var output = GetFileInput(FileOnePath, 1);
            var resultValues = new List<int>();
            
            for (var index = 0; index < patterns.Count; index++)
            {
                Dict[1] = patterns[index].First(s => s.Length == 2);
                Dict[4] = patterns[index].First(s => s.Length == 4);
                Dict[7] = patterns[index].First(s => s.Length == 3);
                Dict[8] = patterns[index].First(s => s.Length == 7);

                var candidatesForSix = patterns[index].Where(s => s.Length == 6).ToArray();
                Dict[6] = candidatesForSix.First(candidate => !ContainString(candidate, Dict[1]));
                Dict[9] = candidatesForSix.First(candidate => ContainString(candidate, Dict[4]));
                Dict[0] = candidatesForSix.First(candidate => !ContainString(candidate, Dict[4]));
                
                var candidatesForFive = patterns[index].Where(s => s.Length == 5).ToArray();
                Dict[3] = candidatesForFive.First(candidate => ContainString(candidate, Dict[1]));
                Dict[5] = candidatesForFive.First(candidate => ContainString(Dict[6], candidate));
                Dict[2] = candidatesForFive.First(candidate 
                    => !Dict[3].Contains(candidate) && !Dict[5].Contains(candidate));

                SortStringsInDict();

                var segmentString = new StringBuilder();
                foreach (var pattern in output[index])
                {
                    var sortPattern = string.Concat(pattern.OrderBy(c => c));
                    segmentString.Append(Dict.FirstOrDefault(x => x.Value == sortPattern).Key);
                }
                
                resultValues.Add(int.Parse(segmentString.ToString()));
            }

            return resultValues.Sum();
        }

        private static void SortStringsInDict()
        {
            foreach (var (key, value) in Dict)
                Dict[key] = string.Concat(value.OrderBy(c => c));
        }

        private static bool ContainString(string str1, string str2) 
            => str2.Count(str1.Contains) == str2.Length;

        private static List<string[]> GetFileInput(string fileName, int choice) => File.ReadAllLines(fileName)
                .Select(s => s.Split('|'))
                .Select(segmentArr => segmentArr[choice]
                    .Trim()
                    .Split(' ')
                    .ToArray())
                .ToList();
    }
}