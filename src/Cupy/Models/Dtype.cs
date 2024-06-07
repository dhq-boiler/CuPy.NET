using System;
using System.Numerics;
using Python.Runtime;

namespace Cupy
{
    public class Dtype : PythonObject
    {
        public Dtype(PyObject pyobj) : base(pyobj)
        {
        }

        public Dtype(Dtype t) : base((PyObject)t.PyObject)
        {
        }

        ~Dtype()
        {
            GC.SuppressFinalize(this);
            Dispose();
        }
    }


    public static class DtypeExtensions
    {
        public static Dtype GetDtype(this object obj)
        {
            switch (obj)
            {
                case bool o: return cp.bool8;
                case sbyte o: return cp.int8;
                case byte o: return cp.uint8;
                case short o: return cp.int16;
                case ushort o: return cp.uint16;
                case int o: return cp.int32;
                case uint o: return cp.uint32;
                case long o: return cp.int64;
                case ulong o: return cp.uint64;
                case float o: return cp.float32;
                case double o: return cp.float64;
                case string o: return cp.unicode_;
                case char o: return cp.unicode_;
                case Complex o: return cp.complex_;
                case bool[] o: return cp.bool8;
                case byte[] o: return cp.@byte;
                case short[] o: return cp.int16;
                case int[] o: return cp.int32;
                case long[] o: return cp.int64;
                case float[] o: return cp.float32;
                case double[] o: return cp.float64;
                case string[] o: return cp.unicode_;
                case char[] o: return cp.unicode_;
                case Complex[] o: return cp.complex_;
                case bool[,] o: return cp.bool8;
                case byte[,] o: return cp.uint8;
                case short[,] o: return cp.int16;
                case int[,] o: return cp.int32;
                case long[,] o: return cp.int64;
                case float[,] o: return cp.float32;
                case double[,] o: return cp.float64;
                case string[,] o: return cp.unicode_;
                case char[,] o: return cp.unicode_;
                case Complex[,] o: return cp.complex_;
                case bool[,,] o: return cp.bool8;
                case byte[,,] o: return cp.uint8;
                case short[,,] o: return cp.int16;
                case int[,,] o: return cp.int32;
                case long[,,] o: return cp.int64;
                case float[,,] o: return cp.float32;
                case double[,,] o: return cp.float64;
                case string[,,] o: return cp.unicode_;
                case char[,,] o: return cp.unicode_;
                case Complex[,,] o: return cp.complex_;
                case bool[,,,] o: return cp.bool8;
                case byte[,,,] o: return cp.uint8;
                case short[,,,] o: return cp.int16;
                case int[,,,] o: return cp.int32;
                case long[,,,] o: return cp.int64;
                case float[,,,] o: return cp.float32;
                case double[,,,] o: return cp.float64;
                case string[,,,] o: return cp.unicode_;
                case char[,,,] o: return cp.unicode_;
                case Complex[,,,] o: return cp.complex_;
                case bool[,,,,] o: return cp.bool8;
                case byte[,,,,] o: return cp.uint8;
                case short[,,,,] o: return cp.int16;
                case int[,,,,] o: return cp.int32;
                case long[,,,,] o: return cp.int64;
                case float[,,,,] o: return cp.float32;
                case double[,,,,] o: return cp.float64;
                case string[,,,,] o: return cp.unicode_;
                case char[,,,,] o: return cp.unicode_;
                case Complex[,,,,] o: return cp.complex_;
                case bool[,,,,,] o: return cp.bool8;
                case byte[,,,,,] o: return cp.uint8;
                case short[,,,,,] o: return cp.int16;
                case int[,,,,,] o: return cp.int32;
                case long[,,,,,] o: return cp.int64;
                case float[,,,,,] o: return cp.float32;
                case double[,,,,,] o: return cp.float64;
                case string[,,,,,] o: return cp.unicode_;
                case char[,,,,,] o: return cp.unicode_;
                case Complex[,,,,,] o: return cp.complex_;
                default: throw new ArgumentException("Can not convert type of given object to dtype: " + obj.GetType());
            }
        }

        //public static dtype ToDtype(this Type t)
        //{
        //    if (t == typeof(byte)) return dtype.UInt8;
        //    if (t == typeof(short)) return dtype.Int16;
        //    if (t == typeof(int)) return dtype.Int32;
        //    if (t == typeof(long)) return dtype.Int64;
        //    if (t == typeof(float)) return dtype.Float32;
        //    if (t == typeof(double)) return dtype.Float64;
        //    throw new ArgumentException("Can not convert given type to dtype: " + t);
        //}
    }
}