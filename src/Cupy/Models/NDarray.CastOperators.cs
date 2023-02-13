using System;

namespace Cupy
{
    public partial class NDarray
    {
        public static implicit operator NDarray(Array array)
        {
            if (array == null)
                return null;
            switch (array)
            {
                case byte[] a: return cp.array(a);
                case bool[] a: return cp.array(a);
                case short[] a: return cp.array(a);
                case int[] a: return cp.array(a);
                case long[] a: return cp.array(a);
                case float[] a: return cp.array(a);
                case double[] a: return cp.array(a);
                case string[] a: return cp.array(a);
                case byte[,] a: return cp.array(a);
                case bool[,] a: return cp.array(a);
                case short[,] a: return cp.array(a);
                case int[,] a: return cp.array(a);
                case long[,] a: return cp.array(a);
                case float[,] a: return cp.array(a);
                case double[,] a: return cp.array(a);
                case string[,] a: return cp.array(a);
                case byte[,,] a: return cp.array(a);
                case bool[,,] a: return cp.array(a);
                case short[,,] a: return cp.array(a);
                case int[,,] a: return cp.array(a);
                case long[,,] a: return cp.array(a);
                case float[,,] a: return cp.array(a);
                case double[,,] a: return cp.array(a);
                case string[,,] a: return cp.array(a);
            }

            throw new InvalidOperationException($"Unable to cast {array.GetType()} to NDarray");
        }

        // these must be explicit or we have bad side effects
        public static explicit operator NDarray(bool d)
        {
            return cp.asarray(d);
        }

        public static explicit operator NDarray(byte d)
        {
            return cp.asarray(d);
        }

        public static explicit operator NDarray(short d)
        {
            return cp.asarray(d);
        }

        public static explicit operator NDarray(int d)
        {
            return cp.asarray(d);
        }

        public static explicit operator NDarray(long d)
        {
            return cp.asarray(d);
        }

        public static explicit operator NDarray(float d)
        {
            return cp.asarray(d);
        }

        public static explicit operator NDarray(double d)
        {
            return cp.asarray(d);
        }

        // these must be explicit or we have bad side effects
        public static explicit operator bool(NDarray a)
        {
            return cp.asscalar<bool>(a);
        }

        public static explicit operator byte(NDarray a)
        {
            return cp.asscalar<byte>(a);
        }

        public static explicit operator short(NDarray a)
        {
            return cp.asscalar<short>(a);
        }

        public static explicit operator int(NDarray a)
        {
            return cp.asscalar<int>(a);
        }

        public static explicit operator long(NDarray a)
        {
            return cp.asscalar<long>(a);
        }

        public static explicit operator float(NDarray a)
        {
            return cp.asscalar<float>(a);
        }

        public static explicit operator double(NDarray a)
        {
            return cp.asscalar<double>(a);
        }
    }
}