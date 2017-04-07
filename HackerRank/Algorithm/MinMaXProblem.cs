using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.Algorithm
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/mini-max-sum
    /// </summary>
    class MinMaXProblem
    {
        private IEnumerable<int> array;
        public MinMaXProblem Init()
        {
            array = new List<int>() { 1, 2, 3, 4, 5 };
            return this;
        }

        public void Run()
        {
            var s = "1 2 3 4 5";
            array = s.Split(' ').Select(i => Convert.ToInt32(i));
            var min = array.OrderBy(x => x).Take(4).Sum();
            var max = array.OrderByDescending(x => x).Take(4).Sum();
            array.Cast<int>();
            Console.WriteLine($"{min} {max}");
        }
    }
}
