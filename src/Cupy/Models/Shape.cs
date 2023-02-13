using System;
using System.Linq;

namespace Cupy.Models
{
    public class Shape
    {
        public Shape(params int[] shape)
        {
            Dimensions = shape;
        }

        public int[] Dimensions { get; }

        public int this[int n] => Dimensions[n];

        public static implicit operator Shape(ValueTuple<int> tuple)
        {
            return new Shape(tuple.Item1);
        }

        public static implicit operator Shape(ValueTuple<int, int> tuple)
        {
            return new Shape(tuple.Item1, tuple.Item2);
        }

        public static implicit operator Shape(ValueTuple<int, int, int> tuple)
        {
            return new Shape(tuple.Item1, tuple.Item2, tuple.Item3);
        }

        public static implicit operator Shape(ValueTuple<int, int, int, int> tuple)
        {
            return new Shape(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
        }

        public static implicit operator Shape(ValueTuple<int, int, int, int, int> tuple)
        {
            return new Shape(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5);
        }

        #region Equality

        public static bool operator ==(Shape a, Shape b)
        {
            if (b is null) return false;
            return a.Dimensions.SequenceEqual(b?.Dimensions);
        }

        public static bool operator !=(Shape a, Shape b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Shape))
                return false;
            return Dimensions.SequenceEqual(((Shape)obj).Dimensions);
        }

        public override int GetHashCode()
        {
            return (Dimensions ?? new int[0]).GetHashCode();
        }

        public override string ToString()
        {
            return $"({string.Join(", ", Dimensions ?? new int[0])})";
        }

        #endregion
    }
}