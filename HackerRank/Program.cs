using HackerRank.Algorithm;
using HackerRank.DataStructure;
using System;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            HourGlassProblem problem = new HourGlassProblem();
            Console.WriteLine("Given Input\n");
            problem
                .Init()
                .Data[0]
                .Print();
            
            var result = problem
                            .SumLargestHourGlass();
            Console.WriteLine($"\nSum of larget Hour glass: {result}\n");
        }
    }
}
