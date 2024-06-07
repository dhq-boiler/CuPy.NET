using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using Cupy.Models;
using Python.Runtime;

namespace Cupy
{
    public static partial class cp
    {
        /// <summary>
        ///     Create an array.
        ///     <param name="data">
        ///         The array to initialize the ndarray with
        ///     </param>
        ///     <returns>
        ///         An array object satisfying the specified requirements.
        ///     </returns>
        public static NDarray<T> array<T>(params T[] data) where T : struct
        {
            var __self__ = self;
            return array(data, null);
        }

        public static NDarray array<T>(params T[][] data) where T : struct
        {
            var arrays = data.Select(x => new NDarray(x)).ToArray();
            return array(arrays);
        }


        public static NDarray array(NDarray @object, Dtype dtype = null, bool? copy = null, string order = null,
            bool? subok = null, int? ndmin = null)
        {
            var __self__ = self;
            using var args = ToTuple(new object[]
            {
                @object
            });
            using var kwargs = new PyDict();
            if (dtype != null) kwargs["dtype"] = ToPython(dtype);
            if (copy != null) kwargs["copy"] = ToPython(copy);
            if (order != null) kwargs["order"] = ToPython(order);
            if (subok != null) kwargs["subok"] = ToPython(subok);
            if (ndmin != null) kwargs["ndmin"] = ToPython(ndmin);
            dynamic py = self.InvokeMethod("array", args, kwargs);
            args.Dispose();
            return ToCsharp<NDarray>(py);
        }

        private static unsafe byte[] ObjectToByteArray(byte obj)
        {
            const int unitsize = 1;
            byte[] ret = new byte[unitsize];
            for (int i = 0; i < unitsize; i++)
            {
                ret[i] = (byte)((obj & (0xF << i)) >> i);
            }
            return ret;
        }

        private static unsafe byte[] ObjectToByteArray(int obj)
        {
            const int unitsize = 4;
            byte[] ret = new byte[unitsize];
            for (int i = 0; i < unitsize; i++)
            {
                ret[i] = (byte)((obj & (0xF << i)) >> i);
            }
            return ret;
        }

        private static unsafe byte[] ObjectToByteArray(long obj)
        {
            int unitsize = 8;
            byte[] ret = new byte[unitsize];
            for (int i = 0; i < unitsize; i++)
            {
                ret[i] = (byte)((obj & (0xF << i)) >> i);
            }
            return ret;
        }

        private static byte[] ObjectToByteArray<T>(T t)
        {
            switch (t)
            {
                case byte b:
                    return ObjectToByteArray(b);
                case int i:
                    return ObjectToByteArray(i);
                case long l:
                    return ObjectToByteArray(l);
                default:
                    throw new NotImplementedException();
            }
        }

        private unsafe static void Copy(byte[] src, NDarray dest)
        {
            int size = src.Length * sizeof(byte);
            IntPtr ptr_dest = (IntPtr)dest.data.Handle;
            byte* p_dest = (byte*)ptr_dest.ToPointer();

            for (int i = 0; i < src.Length; i++)
            {
                dest[i] = new NDarray(src[i]);
            }
        }

        private unsafe static void Copy(char[] src, NDarray dest)
        {
            int size = src.Length * sizeof(char);
            IntPtr ptr_dest = (IntPtr)dest.data.Handle;
            byte* p_dest = (byte*)ptr_dest.ToPointer();

            for (int i = 0; i < src.Length; i++)
            {
                dest[i] = new NDarray(src[i]);
            }
        }

        private unsafe static void Copy(short[] src, NDarray dest)
        {
            int size = src.Length * sizeof(short);
            IntPtr ptr_dest = (IntPtr)dest.data.Handle;
            byte* p_dest = (byte*)ptr_dest.ToPointer();

            for (int i = 0; i < src.Length; i++)
            {
                dest[i] = new NDarray(src[i]);
            }
        }

        private unsafe static void Copy(int[] src, NDarray dest)
        {
            int size = src.Length * sizeof(int);
            IntPtr ptr_dest = (IntPtr)dest.data.Handle;
            byte* p_dest = (byte*)ptr_dest.ToPointer();

            for (int i = 0; i < src.Length; i++)
            {
                dest[i] = new NDarray(src[i]);
            }
        }

        private unsafe static void Copy(long[] src, NDarray dest)
        {
            int size = src.Length * sizeof(long);
            IntPtr ptr_dest = (IntPtr)dest.data.Handle;
            byte* p_dest = (byte*)ptr_dest.ToPointer();

            for (int i = 0; i < src.Length; i++)
            {
                dest[i] = new NDarray(src[i]);
            }
        }

        private unsafe static void Copy(float[] src, NDarray dest)
        {
            int size = src.Length * sizeof(float);
            IntPtr ptr_dest = (IntPtr)dest.data.Handle;
            byte* p_dest = (byte*)ptr_dest.ToPointer();

            for (int i = 0; i < src.Length; i++)
            {
                dest[i] = new NDarray(src[i]);
            }
        }

        private unsafe static void Copy(double[] src, NDarray dest)
        {
            int size = src.Length * sizeof(double);
            IntPtr ptr_dest = (IntPtr)dest.data.Handle;
            byte* p_dest = (byte*)ptr_dest.ToPointer();

            for (int i = 0; i < src.Length; i++)
            {
                dest[i] = new NDarray(src[i]);
            }
        }

        private unsafe static void Copy(bool[] src, NDarray dest)
        {
            int size = src.Length * sizeof(bool);
            IntPtr ptr_dest = (IntPtr)dest.data.Handle;
            byte* p_dest = (byte*)ptr_dest.ToPointer();

            for (int i = 0; i < src.Length; i++)
            {
                dest[i] = new NDarray(src[i]);
            }
        }

        public static NDarray<T> array<T>(T[] @object, Dtype dtype = null, bool? copy = null, string order = null,
            bool? subok = null, int? ndmin = null) where T : struct
        {
            var __self__ = self;
            var type = @object.GetDtype();
            var ndarray = empty(new Shape(@object.Length), type, order);
            if (@object.Length == 0)
                return new NDarray<T>(ndarray);
            switch (@object)
            {
                case char[] a:
                    Copy(a, ndarray);
                    break;
                case byte[] a:
                    Copy(a, ndarray);
                    break;
                case short[] a:
                    Copy(a, ndarray);
                    break;
                case int[] a:
                    Copy(a, ndarray);
                    break;
                case long[] a:
                    Copy(a, ndarray);
                    break;
                case float[] a:
                    Copy(a, ndarray);
                    break;
                case double[] a:
                    Copy(a, ndarray);
                    break;
                case bool[] a:
                    Copy(a, ndarray);
                    break;
                case Complex[] a:
                    var real = new double[@object.Length];
                    var imag = new double[@object.Length];
                    for (var i = 0; i < @object.Length; i++)
                    {
                        real[i] = a[i].Real;
                        imag[i] = a[i].Imaginary;
                    }

                    var ndreal = array(real);
                    var ndimag = array(imag);
                    ndarray.real = ndreal;
                    ndarray.imag = ndimag;
                    break;
            }
            ctypes.Dispose();
            if (dtype != null || subok != null || ndmin != null)
            {
                var converted = cp.array(ndarray, dtype: dtype, copy: false, subok: subok, ndmin: ndmin);
                ndarray.Dispose();
                return new NDarray<T>(converted);
            }

            return new NDarray<T>(ndarray);
        }

        public static NDarray<T> array<T>(T[,] @object, Dtype dtype = null, bool? copy = null, string order = null,
            bool? subok = null, int? ndmin = null) where T : struct
        {
            var __self__ = self;
            var d1_array = @object.Cast<T>().ToArray();
            var shape = new Shape(@object.GetLength(0), @object.GetLength(1));
            var ndarray = array(d1_array, dtype, copy, order, subok, ndmin);
            return new NDarray<T>(ndarray.reshape(shape));
        }

        public static NDarray<T> array<T>(T[,,] data, Dtype dtype = null, bool? copy = null, string order = null,
            bool? subok = null, int? ndmin = null) where T : struct
        {
            var __self__ = self;
            var d1_array = data.Cast<T>().ToArray();
            var shape = new Shape(data.GetLength(0), data.GetLength(1), data.GetLength(2));
            var ndarray = array(d1_array, dtype, copy, order, subok, ndmin);
            return new NDarray<T>(ndarray.reshape(shape));
        }

        public static NDarray<T> array<T>(T[,,,] data, Dtype dtype = null, bool? copy = null, string order = null,
            bool? subok = null, int? ndmin = null) where T : struct
        {
            var __self__ = self;
            var d1_array = data.Cast<T>().ToArray();
            var shape = new Shape(data.GetLength(0), data.GetLength(1), data.GetLength(2), data.GetLength(3));
            var ndarray = array(d1_array, dtype, copy, order, subok, ndmin);
            return new NDarray<T>(ndarray.reshape(shape));
        }

        public static NDarray<T> array<T>(T[,,,,] data, Dtype dtype = null, bool? copy = null, string order = null,
            bool? subok = null, int? ndmin = null) where T : struct
        {
            var __self__ = self;
            var d1_array = data.Cast<T>().ToArray();
            var shape = new Shape(data.GetLength(0), data.GetLength(1), data.GetLength(2), data.GetLength(3),
                data.GetLength(4));
            var ndarray = array(d1_array, dtype, copy, order, subok, ndmin);
            return new NDarray<T>(ndarray.reshape(shape));
        }

        public static NDarray<T> array<T>(T[,,,,,] data, Dtype dtype = null, bool? copy = null, string order = null,
            bool? subok = null, int? ndmin = null) where T : struct
        {
            var __self__ = self;
            var d1_array = data.Cast<T>().ToArray();
            var shape = new Shape(data.GetLength(0), data.GetLength(1), data.GetLength(2), data.GetLength(3),
                data.GetLength(4), data.GetLength(5));
            var ndarray = array(d1_array, dtype, copy, order, subok, ndmin);
            return new NDarray<T>(ndarray.reshape(shape));
        }

        public static NDarray array(string[] strings, int? itemsize = null, bool? copy = null, bool? unicode = null,
            string order = null)
        {
            var __self__ = self;
            var args = new PyTuple(new PyObject[]
                { new PyList(strings.Select(s => new PyString(s) as PyObject).ToArray()) });
            //var args = new PyList(new PyObject[0]);
            //foreach (var s in strings)
            //    args.Append(new PyString(s));
            using var kwargs = new PyDict();
            if (itemsize != null) kwargs["itemsize"] = ToPython(itemsize);
            if (copy != null) kwargs["copy"] = ToPython(copy);
            if (unicode != null) kwargs["unicode"] = ToPython(unicode);
            if (order != null) kwargs["order"] = ToPython(order);
            dynamic py = self.InvokeMethod("array", args, kwargs);
            return ToCsharp<NDarray>(py);
        }

        public static NDarray array<T>(NDarray<T>[] arrays, Dtype dtype = null, bool? copy = null, string order = null,
            bool? subok = null, int? ndmin = null)
        {
            return array(arrays.OfType<NDarray>(), dtype, copy, order, subok, ndmin);
        }

        public static NDarray array<T>(IEnumerable<NDarray<T>> arrays, Dtype dtype = null, bool? copy = null,
            string order = null, bool? subok = null, int? ndmin = null)
        {
            return array(arrays.OfType<NDarray>(), dtype, copy, order, subok, ndmin);
        }

        public static NDarray array(List<NDarray> arrays, Dtype dtype = null, bool? copy = null, string order = null,
            bool? subok = null, int? ndmin = null)
        {
            return array((IEnumerable<NDarray>)arrays, dtype, copy, order, subok, ndmin);
        }

        public static NDarray array(NDarray[] arrays, Dtype dtype = null, bool? copy = null, string order = null,
            bool? subok = null, int? ndmin = null)
        {
            return array((IEnumerable<NDarray>)arrays, dtype, copy, order, subok, ndmin);
        }

        public static NDarray array(IEnumerable<NDarray> arrays, Dtype dtype = null, bool? copy = null,
            string order = null, bool? subok = null, int? ndmin = null)
        {
            var __self__ = self;
            var args = new PyTuple(
                new PyObject[] { new PyList(arrays.Select(nd => nd.PyObject as PyObject).ToArray()) });
            using var kwargs = new PyDict();
            if (dtype != null) kwargs["dtype"] = ToPython(dtype);
            if (copy != null) kwargs["copy"] = ToPython(copy);
            if (order != null) kwargs["order"] = ToPython(order);
            if (subok != true) kwargs["subok"] = ToPython(subok);
            if (ndmin != null) kwargs["ndmin"] = ToPython(ndmin);
            dynamic py = self.InvokeMethod("array", args, kwargs);
            //dynamic py = dynamic_self.array(arrays, dtype, copy, order, subok, ndmin);
            return ToCsharp<NDarray>(py);
        }

        public static NDarray asarray(ValueType scalar, Dtype dtype = null)
        {
            var __self__ = self;
            using var pyargs = ToTuple(new object[]
            {
                scalar
            });
            using var kwargs = new PyDict();
            if (dtype != null) kwargs["dtype"] = ToPython(dtype);
            dynamic py = __self__.InvokeMethod("asarray", pyargs, kwargs);
            return ToCsharp<NDarray>(py);
        }

        /// <summary>
        ///     Convert an array of size 1 to its scalar equivalent.
        /// </summary>
        /// <returns>
        ///     Scalar representation of a. The output data type is the same type
        ///     returned by the input’s item method.
        /// </returns>
        public static T asscalar<T>(NDarray a)
        {
            return new NDarray<T>(a).item();
            //switch (typeof(T).Name)
            //{
            //    case "Int16":   return new NDarray<short>(a).item();
            //    case "Int32":   return new NDarray<int>(a).item();
            //    case "Int64":   return new NDarray<long>(a).item();
            //    case "UInt16":  return new NDarray<ushort>(a).item();
            //    case "UInt32":  return new NDarray<uint>(a).item();
            //    case "UInt64":  return new NDarray<ulong>(a).item();
            //    case "Single":  return new NDarray<float>(a).item();
            //    case "Double":  return new NDarray<double>(a).item();
            //    default:        return new NDarray<T>(a).item();
            //}
            // <--- asscalar has been removed as of Cupy 1.23
        }
    }
}