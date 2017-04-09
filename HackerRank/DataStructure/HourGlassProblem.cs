using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.DataStructure
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/2d-array
    /// </summary>
    class HourGlassProblem
    {
        public List<int[][]> Data { get; private set; }
        public HourGlassProblem Init()
        {
            List<string> list = new List<string>{
                "1 1 1 0 0 0",
                "0 1 0 0 0 0",
                "1 1 1 0 0 0",
                "0 0 2 4 4 0",
                "0 0 0 2 0 0",
                "0 0 1 2 4 0"
            };
            Data = new List<int[][]>();
            int[][] Cube = new int[list.Count][];
            var index = 0;
            list.ForEach(line =>
            {
                var item = line.Split(' ').Select(i => Convert.ToInt32(i));
                if (item.Count() % 3 != 0)
                    throw new Exception("not valid input");
                Cube[index++] = item.ToArray();
            });
            Data.Add(Cube);
            return this;
        }

        public int SumLargestHourGlass()
        {
            return Data.Select(cube
                => cube
                    .GetCubes()
                    .GetCubeSums()
                    .GetLargestCubeSum())
                    .Max();
        }
    }
    public static class CubeExtenstion
    {
        public static List<int[][]> GetCubes(this int[][] Cube)
        {
            List<int[][]> cubes = new List<int[][]>();
            var totalCubes = Cube.GetTotalCubes();
            var sequence = GetSequence(totalCubes);
            Console.WriteLine($"\nTotal cubes: {totalCubes}");
            sequence
                .ForEach(position =>
                {
                    var cube = new int[3][];
                    var xPos = position.Item1 * 3;
                    var yPos = position.Item2 * 3;
                    for (int i = xPos, p = 0; i < xPos + 3; i++, p++)
                    {
                        cube[p] = new int[3];
                        for (int j = yPos, q = 0; j < yPos + 3; j++, q++)
                        {
                            cube[p][q] = Cube[i][j];
                        }
                    }
                    cube.Print();
                    Console.WriteLine();
                    cubes.Add(cube);
                });
            return cubes;
        }

        public static IEnumerable<int> GetCubeSums(this List<int[][]> Cubes)
        {
            return Cubes.Select(cube =>
            {
                int sum = 0;
                for (int i = 0; i < cube.Length; i++)
                {
                    for (int j = 0; j < cube.Length; j++)
                    {
                        sum += cube[i][j];
                    }
                }
                return sum;
            });
        }
        public static int GetLargestCubeSum(this IEnumerable<int> sums)
        {
            return sums.Max();
        }

        public static void Print(this int[][] Cube)
        {
            Cube.All(x =>
            {
                x.All(y =>
                {
                    Console.Write(y);
                    return true;
                });
                Console.WriteLine();
                return true;
            });
        }

        private static int GetTotalCubes(this int[][] Cube)
        {
            var hCubes = Cube.Length / 3;
            return hCubes * hCubes;
        }
        private static List<Tuple<int, int>> GetSequence(int totalCubes)
        {
            var sequence = new List<Tuple<int, int>>();
            for (int i = 0; i < Math.Sqrt(totalCubes); i++)
            {
                for (int j = 0; j < Math.Sqrt(totalCubes); j++)
                {
                    sequence.Add(new Tuple<int, int>(i, j));
                }
            }
            return sequence;
        }
    }
}
