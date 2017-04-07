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

    public interface IUnit : IEquatable<IUnit>, IComparable<IUnit>
    {
        decimal ConvertToGram();
    }

    public sealed class VoidMyUnit : IUnit
    {
        private VoidMyUnit()
        { }
        private static volatile VoidMyUnit instance;
        public static VoidMyUnit Instance { get { return instance ?? (instance = new VoidMyUnit()); } }

        public int CompareTo(IUnit other)
        {
            return 0;
        }

        public decimal ConvertToGram()
        {
            return 0;
        }

        public bool Equals(IUnit other)
        {
            return false;
        }


        public override string ToString()
        {
            return "n/a";
        }
    }

    public class MyUnit : IUnit
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

        public static bool operator ==(MyUnit first, IUnit second)
        {
            return first.ConvertToGram() == second.ConvertToGram();
        }
        public static bool operator !=(MyUnit first, IUnit second)
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

        public decimal ConvertToGram()
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

        public int CompareTo(IUnit other)
        {
            var first = this.ConvertToGram();
            var second = other.ConvertToGram();
            return first.CompareTo(second);
        }

        public bool Equals(IUnit other)
        {
            return Equals(other as MyUnit);
        }
    }
}
