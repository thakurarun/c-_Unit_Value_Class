using HackerRank.Algorithm;
using HackerRank.DataStructure;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            HourGlassProblem problem = new HourGlassProblem();

            var result = problem
                            .Init()
                            .SumLargestHourGlass();
            //System.Console.WriteLine(result);
        }
    }
}
