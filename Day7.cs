using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public static class Day7
    {
        private const string FileOnePath = "../../../Files/Day7FirstTask.txt";
        private const string FileTestPath = "../../../Files/Test.txt";

        public static int Task1()
        {
            var minFuel = int.MaxValue;
            
            var crabPositions = GetFileInput(FileOnePath);
            crabPositions.Sort();

            for (var position = 0; position <= crabPositions[^1]; position++)
            {
                var fuel = crabPositions.Sum(crabPosition => GetSwapFuel(crabPosition, position));
                minFuel = minFuel < fuel ? minFuel : fuel;
            }

            return minFuel;
        }

        private static int GetSwapFuel(int crabPosition, int position)
        {
            if (crabPosition == position)
                return 0;

            var fuel = 0;
            var coast = 1;
            var dx = crabPosition - position > 0 ? 1 : -1;
            while (crabPosition != position)
            {
                position += dx;
                fuel += coast++;
            }
                
            return fuel;
        }

        private static List<int> GetFileInput(string filePath = FileTestPath)
        {
            var file = File.ReadAllLines(filePath)
                .Select(s => s.Split(','))
                .Take(1);

            return (from strings in file from value in strings select int.Parse(value)).ToList();
        }
    }
}