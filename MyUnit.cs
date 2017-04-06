using System;
using System.Collections.Generic;

namespace Practice
{
    public enum UnitType
    {
        kg = 1,
        gm = 2,
        pound = 3,
        mg = 4
    }

    public class MyUnitComparer : IComparer<MyUnit>
    {
        public int Compare(MyUnit x, MyUnit y)
        {
            var first = x.ConvertToGram();
            var second = y.ConvertToGram();
            if (first == second)
                return -1;
            else
            {
                var s = first.CompareTo(second);
                return s;
            }
        }
    }

    public class MyUnit : IEquatable<MyUnit>// ,  IComparable<MyUnit>
    {
        Func<MyUnit, decimal> converter;
        const decimal GramsPerKiloGram = 1000M;
        const decimal GramsPerPound = 453.592M;
        public UnitType unitType { get; }
        public decimal weight { get; }
        public MyUnit(decimal weight, UnitType unitType)
        {
            this.weight = weight;
            this.unitType = unitType;
        }
        public MyUnit(decimal weight, UnitType unitType, Func<MyUnit, decimal> converterToGrams)
        {
            this.weight = weight;
            this.unitType = unitType;
            this.converter = converterToGrams;
        }

        public override string ToString()
        {
            return $"{this.weight} {this.unitType}";
        }

        public bool Equals(MyUnit other)
        {
            return ConvertToGram() == other.ConvertToGram();
        }

        public static bool operator ==(MyUnit first, MyUnit second)
        {
            return first.ConvertToGram() == second.ConvertToGram();
        }
        public static bool operator !=(MyUnit first, MyUnit second)
        {
            return first.ConvertToGram() != second.ConvertToGram();
        }
        public override int GetHashCode()
        {
            // Hash would be different for same value of object
            return this.ConvertToGram().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            // Not required but (see https://blogs.msdn.microsoft.com/jaredpar/2009/01/15/if-you-implement-iequatablet-you-still-must-override-objects-equals-and-gethashcode/)
            return Equals(obj as MyUnit);
        }

        internal decimal ConvertToGram()
        {
            if (this.converter != null)
            {
                return this.converter(this);
            }
            decimal value = 0.0M;
            switch (this.unitType)
            {
                case UnitType.kg:
                    {
                        value = weight * GramsPerKiloGram;
                        break;
                    }
                case UnitType.pound:
                    {
                        value = weight * GramsPerPound;
                        break;
                    }
                default:
                    {
                        value = weight;
                        break;
                    }
            }
            return Math.Round(value, 2);
        }

        //public int CompareTo(MyUnit other)
        //{
        //    var first = this.ConvertToGram();
        //    var second = other.ConvertToGram();
        //    if (first > second)
        //        return 1;
        //    else if (first < second)
        //        return 0;
        //    else
        //        return -1;
        //}
    }
}
