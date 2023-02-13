using System;
using System.Linq;

namespace Cupy.Models
{
    /// <summary>
    ///     Special type for axis parameters that can be automatically cast implicitly from int or int[]
    /// </summary>
    public class Axis
    {
        public readonly int[] Axes;

        /// <summary>
        ///     Default axis, corresponds to axis=null in Cupy
        /// </summary>
        public Axis()
        {
        }

        /// <summary>
        ///     Single axis, corresponds to axis=x in Cupy
        /// </summary>
        /// <param name="axis"></param>
        public Axis(int axis)
        {
            Axes = new[] { axis };
        }

        /// <summary>
        ///     Multiple axes, corresponds to axis=(x,y, ...) in Cupy
        /// </summary>
        /// <param name="axes"></param>
        public Axis(params int[] axes)
        {
            Axes = axes;
        }

        public static implicit operator Axis(int axis)
        {
            return new Axis(axis);
        }

        public static implicit operator Axis(int[] axes)
        {
            return new Axis(axes);
        }

        public static implicit operator Axis(ValueTuple<int> tuple)
        {
            return new Axis(tuple.Item1);
        }

        public static implicit operator Axis(ValueTuple<int, int> tuple)
        {
            return new Axis(tuple.Item1, tuple.Item2);
        }

        public static implicit operator Axis(ValueTuple<int, int, int> tuple)
        {
            return new Axis(tuple.Item1, tuple.Item2, tuple.Item3);
        }

        public static implicit operator Axis(ValueTuple<int, int, int, int> tuple)
        {
            return new Axis(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
        }

        public static implicit operator Axis(ValueTuple<int, int, int, int, int> tuple)
        {
            return new Axis(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5);
        }

        #region Equality

        public override bool Equals(object obj)
        {
            var b = obj as Axis;
            if (b == null)
            {
                if (Axes == null)
                    return true;
                if (Axes.Length == 0)
                    return true;
                return false;
            }

            return Axes.SequenceEqual(b.Axes);
        }

        public static bool operator ==(Axis a, Axis b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;
            if (ReferenceEquals(a, null))
                return b.Equals(a);
            return a.Equals(b);
        }

        public static bool operator !=(Axis a, Axis b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            if (Axes == null)
                return 0;
            return Axes.GetHashCode();
        }

        #endregion
    }
}