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
        private int[][] data;
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
            data = new int[list.Count][];
            int index = 0;
            list.ForEach(line =>
            {
                var item = line.Split(' ').Select(i => Convert.ToInt32(i));
                if (item.Count() % 3 != 0)
                    throw new Exception("not valid input");
                data[index++] = item.ToArray();
            });
            return this;
        }

        public int SumLargestHourGlass()
        {
            var length = GetTotalCubes();
            for (int i = 0; i < length; i++)
            {
                data.GetCube(i);
            }
            return 0;
        }

        private int GetTotalCubes()
        {
            var cubes = data.Count() / 3;
            return cubes * cubes;
        }
    }
    public static class CubeExtenstion
    {
        public static int[][] GetCube(this int[][] Cube, int index)
        {
            int[][] cube = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                }
            }
           
            return cube;
        }
    }
}
