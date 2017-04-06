using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice
{
    class Program
    {

        static decimal MilligramToGrams(MyUnit unit)
        {
            return Math.Round(unit.weight / 1000, 2);
        }

        static void Main(string[] args)
        {
            var myWeight = new MyUnit(1, UnitType.kg);
            var myWeight2Kg = new MyUnit(2, UnitType.mg);

            IEnumerable<MyUnit> list = new List<MyUnit>() { myWeight, myWeight2Kg };

            var result = list.OrderBy(x=> x);
            result.All(unit =>
                 {
                     Console.WriteLine(unit.ToString());
                     return true;
                 });


            //var myWeight2 = new MyUnit(1000, UnitType.gm);
            //var myWeight3 = new MyUnit(1000000, UnitType.mg, MilligramToGrams);

            //Console.WriteLine(myWeight.ToString());
            //Console.WriteLine(myWeight2.ToString());

            //Console.WriteLine($"using equals: {myWeight.Equals(myWeight2)}");
            //Console.WriteLine($"using equal: {myWeight == myWeight2}");
            //Console.WriteLine($"using equal: {myWeight == myWeight3}");

            //Console.WriteLine($"{myWeight.GetHashCode()} == {myWeight2.GetHashCode()}");

        }
    }
}
