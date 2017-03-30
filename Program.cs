using System;

namespace Practice
{
    class Program
    {

        static decimal MilligramToGrams(MyUnit unit)
        {
            return Math.Round(unit.weight / 1000,2);
        }


        static void Main(string[] args)
        {
            var myWeight = new MyUnit(1, UnitType.kg);
            var myWeight2 = new MyUnit(1000, UnitType.gm);
            var myWeight3 = new MyUnit(1000000, UnitType.mg, MilligramToGrams);

            Console.WriteLine(myWeight.ToString());
            Console.WriteLine(myWeight2.ToString());

            Console.WriteLine($"using equals: {myWeight.Equals(myWeight2)}");
            Console.WriteLine($"using equal: {myWeight == myWeight2}");
            Console.WriteLine($"using equal: {myWeight == myWeight3}");

            Console.WriteLine($"{myWeight.GetHashCode()} == {myWeight2.GetHashCode()}");



        }
    }
}
