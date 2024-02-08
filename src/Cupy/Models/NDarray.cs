using Cupy.Models;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Cupy
{
    public partial class NDarray : PythonObject
    {
        // this is needed for constructors in  NDarray<T>
        protected NDarray()
        {
        }

        // these are manual overrides of functions or properties that can not be automatically generated

        public NDarray(PyObject pyobj) : base(pyobj)
        {
        }

        public NDarray(byte obj) : this(new PyInt(obj))
        {
        }

        public NDarray(int obj) : this(new PyInt(obj))
        {
        }

        public NDarray(long obj) : this(new PyInt(obj))
        {
        }

        public NDarray(float obj) : this(new PyFloat(obj))
        {
        }

        public NDarray(double obj) : this(new PyFloat(obj))
        {
        }

        public NDarray(bool obj) : this(obj.ToPython())
        {
        }

        public NDarray(NDarray t) : base((PyObject)t.PyObject)
        {
        }

        /// <summary>
        ///     Creates an array from an unmanaged (or fixed) memory pointer without copying.
        /// </summary>
        /// <param name="dataPtr">Pointer to a block of unmanaged memory or to a block of pinned managed memory</param>
        /// <param name="dataLength">The length of the block of memory in bytes</param>
        /// <param name="dtype">The data type of the resulting NDarray</param>
        public NDarray(IntPtr dataPtr, long dataLength, Dtype dtype)
        {
            // adapted from https://pastebin.com/4hANmBNy
            // thanks to Eli Belash
            var g = (Cupy.ctypes.dynamic_self.c_uint8 * dataLength).from_address(dataPtr.ToInt64());
            self = cp.dynamic_self.frombuffer(g, dtype.PyObject, -1);
        }

        /// <summary>
        ///     Information about the memory layout of the array.
        /// </summary>
        public Flags flags => new Flags(self.GetAttr("flags")); // TODO: implement Flags

        /// <summary>
        ///     Tuple of array dimensions.
        /// </summary>
        public Shape shape => new Shape(self.GetAttr("shape").As<int[]>());

        /// <summary>
        ///     Tuple of bytes to step in each dimension when traversing an array.
        /// </summary>
        public int[] strides => self.GetAttr("strides").As<int[]>();

        /// <summary>
        ///     Number of array dimensions.
        /// </summary>
        public int ndim => self.GetAttr("ndim").As<int>();

        /// <summary>
        ///     Python buffer object pointing to the start of the array’s data.
        /// </summary>
        public PyObject data => self.GetAttr("data");

        /// <summary>
        ///     Number of elements in the array.
        /// </summary>
        public int size => self.GetAttr("size").As<int>();

        /// <summary>
        ///     Length of one array element in bytes.
        /// </summary>
        public int itemsize => self.GetAttr("itemsize").As<int>();

        /// <summary>
        ///     Total bytes consumed by the elements of the array.
        /// </summary>
        public int nbytes => self.GetAttr("nbytes").As<int>();

        /// <summary>
        ///     Base object if memory is from some other object.
        /// </summary>
        public NDarray @base
        {
            get
            {
                var base_obj = self.GetAttr("base");
                if (base_obj.IsNone())
                    return null;
                return new NDarray(base_obj);
            }
        }

        /// <summary>
        ///     Data-type of the array’s elements.
        /// </summary>
        public Dtype dtype => new Dtype(self.GetAttr("dtype"));

        /// <summary>
        ///     Same as self.transpose(), except that self is returned if self.ndim &lt; 2.
        /// </summary>
        public NDarray T => new NDarray(self.GetAttr("T"));

        ///// <summary>
        ///// The real part of the array.
        ///// </summary>
        //public NDarray real => new NDarray(self.GetAttr("real"));

        ///// <summary>
        ///// The imaginary part of the array.
        ///// </summary>
        //public NDarray imag => new NDarray(self.GetAttr("imag"));

        /// <summary>
        ///     A 1-D iterator over the array.
        /// </summary>
        public PyObject flat => self.GetAttr("flat"); // todo: wrap and support usecases

#if NOT_SUPPORTED
        /// <summary>
        ///     An object to simplify the interaction of the array with the ctypes module.
        /// </summary>
        //public PyObject ctypes => self.GetAttr("ctypes"); // TODO: wrap ctypes
        public PyObject ctypes => Cupy.ctypes.self;//.GetAttr("ctypes");
#endif

        /// <summary>
        ///     Length of the array (same as size)
        /// </summary>
        public int len => self.InvokeMethod("__len__").As<int>();

        /// <summary>
        ///     returns the 'array([ .... ])'-representation known from the console
        /// </summary>
        public string repr => ToString(1);

        /// <summary>
        ///     returns the '[ .... ]'-representation
        /// </summary>
        public string str => self.InvokeMethod("__str__").As<string>();

        public NDarray this[string slicing_notation]
        {
            get
            {
                var tuple = new PyTuple(Slice.ParseSlices(slicing_notation).Select(s =>
                {
                    if (s.IsIndex)
                        return new PyInt(s.Start.Value);
                    return s.ToPython();
                }).ToArray());
                return new NDarray(PyObject[tuple]);
            }
            set
            {
                var tuple = new PyTuple(Slice.ParseSlices(slicing_notation).Select(s =>
                {
                    if (s.IsIndex)
                        return new PyInt(s.Start.Value);
                    return s.ToPython();
                }).ToArray());
                self.SetItem(tuple, ToPython(value));
            }
        }

        public NDarray this[params int[] coords]
        {
            get
            {
                if (coords.Length == 1)
                {
                    var pyint = new PyInt(coords[0]);
                    using (Py.GIL())
                    {
                        return new NDarray(self.GetItem(pyint));
                    }
                }
                else
                {
                    var tuple = ToTuple(coords);
                    return new NDarray(PyObject[tuple]);
                }
            }
            set
            {
                var tuple = ToTuple(coords);
                self.SetItem(tuple, ToPython(value));
            }
        }

        public NDarray this[params NDarray[] indices]
        {
            get
            {
                var tuple = new PyTuple(indices.Select(a => (PyObject)a.PyObject).ToArray());
                return new NDarray(PyObject[tuple]);
            }
            set
            {
                var tuple = new PyTuple(indices.Select(a => (PyObject)a.PyObject).ToArray());
                self.SetItem(tuple, ToPython(value));
            }
        }

        public NDarray this[params object[] arrays_slices_or_indices]
        {
            get
            {
                var pyobjs = arrays_slices_or_indices.Select<object, PyObject>(x =>
                {
                    switch (x)
                    {
                        case int i: return new PyInt(i);
                        case NDarray a: return a.PyObject;
                        case string s: return new Slice(s).ToPython();
                        default: return ToPython(x);
                    }
                }).ToArray();
                var tuple = new PyTuple(pyobjs);
                return new NDarray(PyObject[tuple]);
            }
            set
            {
                var pyobjs = arrays_slices_or_indices.Select<object, PyObject>(x =>
                {
                    switch (x)
                    {
                        case int i: return new PyInt(i);
                        case NDarray a: return a.PyObject;
                        case string s: return new Slice(s).ToPython();
                        default: return ToPython(x);
                    }
                }).ToArray();
                var tuple = new PyTuple(pyobjs);
                self.SetItem(tuple, ToPython(value));
            }
        }

        public NDarray real
        {
            get
            {
                dynamic py = self.GetAttr("real");
                return ToCsharp<NDarray>(py);
            }
            set => self.SetAttr("real", value.PyObject);
        }

        public NDarray imag
        {
            get
            {
                dynamic py = self.GetAttr("imag");
                return ToCsharp<NDarray>(py);
            }
            set => self.SetAttr("imag", value.PyObject);
        }

        //unsafe void PinVoidPointer(object voidPtr, int length)
        //{
        //    fixed (void* ptr = (void*)&voidPtr)
        //    {
        //        // ここで、ptrがピンされます。
        //        // ポインターを介して扱うメモリーブロックは、GCによって移動されなくなります。
        //        // したがって、ポインターを介してアクセスするメモリー領域のアドレスを計算することができます。
        //        byte* bytePtr = (byte*)ptr;
        //        for (int i = 0; i < length; i++)
        //        {
        //            bytePtr[i] = 0;
        //        }
        //    }
        //}

        //[DllImport("numpy.core._multiarray_umath", CallingConvention = CallingConvention.Cdecl)]
        //private static extern IntPtr PyArray_DATA(IntPtr arr);

        public unsafe static byte[] SerializeObject(dynamic obj)
        {
            int size = (int)obj.nbytes;
            byte[] ret = new byte[size];
            IntPtr ptr = (IntPtr)obj.data.Handle;
            byte* p = (byte*)ptr.ToPointer();
            for (int i = 0; i < size; i++)
            {
                ret[i] = *(p + i);
            }
            return ret;
            //BinaryFormatter formatter = new BinaryFormatter();
            //using (MemoryStream stream = new MemoryStream())
            //{
            //    formatter.Serialize(stream, obj);
            //    return stream.ToArray();
            //}
        }

        /// <summary>
        ///     Returns a copy of the array data
        /// </summary>
        public unsafe T GetData<T>()
        {
            return (T)GetDataInternal<T>();
        }

        private object GetDataInternal<T>()
        {
            return ToCsharp<T>(this);
        }

        /// <summary>
        ///     Insert scalar into an array (scalar is cast to array’s dtype, if possible)
        ///     There must be at least 1 argument, and define the last argument
        ///     as item.  Then, a.itemset(*args) is equivalent to but faster
        ///     than a[args] = item.  The item should be a scalar value and args
        ///     must select a single item in the array a.
        ///     Notes
        ///     Compared to indexing syntax, itemset provides some speed increase
        ///     for placing a scalar into a particular location in an ndarray,
        ///     if you must do this.  However, generally this is discouraged:
        ///     among other problems, it complicates the appearance of the code.
        ///     Also, when using itemset (and item) inside a loop, be sure
        ///     to assign the methods to a local variable to avoid the attribute
        ///     look-up at each loop iteration.
        /// </summary>
        /// <param name="args">
        ///     If one argument: a scalar, only used in case a is of size 1.
        ///     If two arguments: the last argument is the value to be set
        ///     and must be a scalar, the first argument specifies a single array
        ///     element location. It is either an int or a tuple.
        /// </param>
        public void itemset(params object[] args)
        {
            var pyargs = ToTuple(args);
            var kwargs = new PyDict();
            dynamic py = self.InvokeMethod("itemset", pyargs, kwargs);
        }

        /// <summary>
        ///     Construct Python bytes containing the raw data bytes in the array.
        ///     Constructs Python bytes showing a copy of the raw contents of
        ///     data memory. The bytes object can be produced in either ‘C’ or ‘Fortran’,
        ///     or ‘Any’ order (the default is ‘C’-order). ‘Any’ order means C-order
        ///     unless the F_CONTIGUOUS flag in the array is set, in which case it
        ///     means ‘Fortran’ order.
        ///     This function is a compatibility alias for tobytes. Despite its name it returns bytes not strings.
        /// </summary>
        /// <param name="order">
        ///     Order of the data for multidimensional arrays:
        ///     C, Fortran, or the same as for the original array.
        /// </param>
        /// <returns>
        ///     Python bytes exhibiting a copy of a’s raw data.
        /// </returns>
        public byte[] tostring(string order = null)
        {
            return tobytes();
        }

        /// <summary>
        ///     Construct Python bytes containing the raw data bytes in the array.
        ///     Constructs Python bytes showing a copy of the raw contents of
        ///     data memory. The bytes object can be produced in either ‘C’ or ‘Fortran’,
        ///     or ‘Any’ order (the default is ‘C’-order). ‘Any’ order means C-order
        ///     unless the F_CONTIGUOUS flag in the array is set, in which case it
        ///     means ‘Fortran’ order.
        /// </summary>
        /// <param name="order">
        ///     Order of the data for multidimensional arrays:
        ///     C, Fortran, or the same as for the original array.
        /// </param>
        /// <returns>
        ///     Python bytes exhibiting a copy of a’s raw data.
        /// </returns>
        public byte[] tobytes(string order = null)
        {
            throw new NotImplementedException("TODO: this needs to be implemented with Marshal.Copy");
            var pyargs = ToTuple(new object[]
            {
            });
            var kwargs = new PyDict();
            if (order != null) kwargs["order"] = ToPython(order);
            dynamic py = self.InvokeMethod("tobytes", pyargs, kwargs);
            return ToCsharp<byte[]>(py);
        }

        /// <summary>
        ///     New view of array with the same data.
        ///     Notes
        ///     a.view() is used two different ways:
        ///     a.view(some_dtype) or a.view(dtype=some_dtype) constructs a view
        ///     of the array’s memory with a different data-type.  This can cause a
        ///     reinterpretation of the bytes of memory.
        ///     a.view(ndarray_subclass) or a.view(type=ndarray_subclass) just
        ///     returns an instance of ndarray_subclass that looks at the same array
        ///     (same shape, dtype, etc.)  This does not cause a reinterpretation of the
        ///     memory.
        ///     For a.view(some_dtype), if some_dtype has a different number of
        ///     bytes per entry than the previous dtype (for example, converting a
        ///     regular array to a structured array), then the behavior of the view
        ///     cannot be predicted just from the superficial appearance of a (shown
        ///     by print(a)). It also depends on exactly how a is stored in
        ///     memory. Therefore if a is C-ordered versus fortran-ordered, versus
        ///     defined as a slice or transpose, etc., the view may give different
        ///     results.
        /// </summary>
        /// <param name="dtype">
        ///     Data-type descriptor of the returned view, e.g., float32 or int16. The
        ///     default, None, results in the view having the same data-type as a.
        ///     This argument can also be specified as an ndarray sub-class, which
        ///     then specifies the type of the returned object (this is equivalent to
        ///     setting the type parameter).
        /// </param>
        /// <param name="type">
        ///     Type of the returned view, e.g., ndarray or matrix.  Again, the
        ///     default None results in type preservation.
        /// </param>
        public void view(Dtype dtype = null, Type type = null)
        {
            throw new NotImplementedException(
                "Get python type 'ndarray' and 'matrix' and substitute them for the given .NET type");
            var pyargs = ToTuple(new object[]
            {
            });
            var kwargs = new PyDict();
            if (dtype != null) kwargs["dtype"] = ToPython(dtype);
            if (type != null) kwargs["type"] = ToPython(type);
            dynamic py = self.InvokeMethod("view", pyargs, kwargs);
        }

        /// <summary>
        ///     Change shape and size of array in-place.
        ///     Notes
        ///     This reallocates space for the data area if necessary.
        ///     Only contiguous arrays (data elements consecutive in memory) can be
        ///     resized.
        ///     The purpose of the reference count check is to make sure you
        ///     do not use this array as a buffer for another Python object and then
        ///     reallocate the memory. However, reference counts can increase in
        ///     other ways so if you are sure that you have not shared the memory
        ///     for this array with another Python object, then you may safely set
        ///     refcheck to False.
        /// </summary>
        /// <param name="new_shape">
        ///     Shape of resized array.
        /// </param>
        /// <param name="refcheck">
        ///     If False, reference count will not be checked. Default is True.
        /// </param>
        public void resize(Shape new_shape, bool? refcheck = null)
        {
            var pyargs = ToTuple(new object[]
            {
                new_shape
            });
            var kwargs = new PyDict();
            if (refcheck != null) kwargs["refcheck"] = ToPython(refcheck);
            dynamic py = self.InvokeMethod("resize", pyargs, kwargs);
        }

        /// <summary>
        ///     Gives a new shape to an array without changing its data.
        ///     Notes
        ///     It is not always possible to change the shape of an array without
        ///     copying the data. If you want an error to be raised when the data is copied,
        ///     you should assign the new shape to the shape attribute of the array:
        ///     The order keyword gives the index ordering both for fetching the values
        ///     from a, and then placing the values into the output array.
        ///     For example, let’s say you have an array:
        ///     You can think of reshaping as first raveling the array (using the given
        ///     index order), then inserting the elements from the raveled array into the
        ///     new array using the same kind of index ordering as was used for the
        ///     raveling.
        /// </summary>
        /// <param name="newshape">
        ///     The new shape should be compatible with the original shape. If
        ///     an integer, then the result will be a 1-D array of that length.
        ///     One shape dimension can be -1. In this case, the value is
        ///     inferred from the length of the array and remaining dimensions.
        /// </param>
        /// <returns>
        ///     This will be a new view object if possible; otherwise, it will
        ///     be a copy.  Note there is no guarantee of the memory layout (C- or
        ///     Fortran- contiguous) of the returned array.
        /// </returns>
        public NDarray reshape(params int[] newshape)
        {
            //auto-generated code, do not change
            var @this = this;
            return @this.reshape(new Shape(newshape));
        }

        /// <summary>
        ///     Convert an array of size 1 to its scalar equivalent.
        /// </summary>
        /// <returns>
        ///     Scalar representation of a. The output data type is the same type
        ///     returned by the input’s item method.
        /// </returns>
        public T asscalar<T>()
        {
            return cp.asscalar<T>(this);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var array = obj as NDarray;
            if (!ReferenceEquals(array, null))
                return this.array_equal(array);
            return base.Equals(obj);
        }

        /// <summary>
        ///     Returns a view of the array with axes transposed.<br></br>
        ///     For a 1-D array, this has no effect.<br></br>
        ///     (To change between column and
        ///     row vectors, first cast the 1-D array into a matrix object.)
        ///     For a 2-D array, this is the usual matrix transpose.<br></br>
        ///     For an n-D array, if axes are given, their order indicates how the
        ///     axes are permuted (see Examples).<br></br>
        ///     If axes are not provided and
        ///     a.shape = (i[0], i[1], ... i[n-2], i[n-1]), then
        ///     a.transpose().shape = (i[n-1], i[n-2], ... i[1], i[0]).
        /// </summary>
        /// <returns>
        ///     View of a, with axes suitably permuted.
        /// </returns>
        public NDarray transpose(params int[] axes)
        {
            return cp.transpose(this, axes);
        }

        public string ToStringAsPythonObject()
        {
            return base.ToString();
        }

        public override string ToString()
        {
            if (self.HasAttr("ndim"))
            {
                return Dig(ndim - 1, ndim, this);
            }
            else if (!base.ToString().Contains("[[") && !base.ToString().Contains("]]"))
            {
                return base.ToString();
            }
            else
            {
                return ToStringAsList();
            }
        }

        private string ToStringAsList()
        {
            var this_0 = this[0];
            var col = this_0.len;
            var row = this.len;
            var i = 0;
            var str = string.Empty;
            str += "[";
            while (i < row)
            {
                var j = 0;
                str += "[";
                while (j < col)
                {
                    var obj = ToCsharp(this_0.GetType(), this[i][j]);
                    str += obj.ToString();
                    if (j < col - 1)
                    {
                        str += ", ";
                    }
                    j += 1;
                }
                str += "]";
                if (i < row - 1)
                {
                    str += ", ";
                }
                i += 1;
            }
            str += "]";
            return str;
        }

        public string ToString(int depth)
        {
            if (self.HasAttr("ndim"))
            {
                var str = string.Empty;
                var isArray = this.ToString().Substring(0, 1).IndexOf("[") > -1 || this.ToString().IndexOf("array") > -1;
                if (isArray && depth == 1)
                {
                    str += "array(";
                }
                str += Dig(ndim - 1, ndim, this);
                if (isArray && ndim > 0 && !dtype.ToString().Equals("int32") && !dtype.ToString().Equals("bool"))
                {
                    str += $", dtype={dtype}";
                }
                if (isArray && depth == 1)
                {
                    str += ")";
                }
                return Arrange(str);
            }
            else if (depth == 1)
            {
                var str = string.Empty;
                if (depth == 1)
                {
                    str += "array(";
                }
                str += this.ToString();
                if (!Leaf(this).ToString().Contains("NpzFile"))
                {
                    if (!Leaf(this).dtype.ToString().Equals("int32") && !Leaf(this).dtype.ToString().Equals("bool"))
                    {
                        str += $", dtype={Leaf(this).dtype.ToString()}";
                    }
                }
                if (depth == 1)
                {
                    str += ")";
                }
                return Arrange($"{str}".Replace("], [", "],\n       ["));
            }
            else if (this.len == 1)
            {
                var str = this[0].ToString(depth + 1);
                return Arrange(str);
            }
            else
            {
                var str = "[";
                for (int i = 0; i < this.len; i++)
                {
                    str += this[i].ToString(depth + 1);
                    if (i < this.len - 1)
                    {
                        str += ", ";
                    }
                }
                str += "]";
                return Arrange(str);
            }
        }

        private string Arrange(string input)
        {
            var builder = new StringBuilder();

            // 数値（整数、小数、複素数）、bool値にマッチする正規表現
            string numberPattern = @"([-+]?\d+\.?\d*([eE][-+]?\d+)?)|(True|False)|(nan)|(\.\.\.)|([-+]?\d*\.?\d*([eE][-+]?\d+)?[+-]\d*\.?\d*j)";
            var dtypePattern = new Regex(@"dtype=(?<dtype>.+?)\)");
            var dtypeMatched = dtypePattern.IsMatch(input);

            // 単一の数値の場合の処理
            if (!input.Trim().StartsWith("array("))
            {
                var match = Regex.Match(input, numberPattern);
                if (match.Success)
                {
                    return match.Value; // 単一の数値をそのまま返す
                }
            }

            // 行を分割し、空行を除外
            var lines = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (lines.Any(l => l.Contains("...")))
            {
                lines = FormatArray(lines.ToList());
            }

            // 数値を抽出し、多次元リストに格納
            var arrays = new List<List<List<string>>>();

            // 整数部と小数部、複素数部の最大桁数を計算
            int maxIntegerDigits = 0;
            int maxDecimalDigits = 0;
            int maxComplexDigits = 0;
            int ndim = 1;
            var currentMatrix = new List<List<string>>();

            ndim = lines.First().Count(x => x.Equals('[')) & lines.Last().Count(x => x.Equals(']'));

            foreach (var line in lines)
            {
                var trimmedLine = line.Trim();
                if (trimmedLine == "") continue;  // 空行をスキップ

                // '[' と ']' の間の内容を抽出
                var innerContentMatches = Regex.Matches(trimmedLine, @"\[([^]]+)\]");
                foreach (Match innerContentMatch in innerContentMatches)
                {
                    var innerContent = innerContentMatch.Groups[1].Value;

                    // 内容から数字を抽出し、リストに追加
                    var values = innerContent.Split(',', '[', ']').Select(x => x.Trim()).Where(x => x.Any()).ToList();
                    if (values.Count > 0)
                    {
                        currentMatrix.Add(values);
                    }

                    // 整数部と小数部の桁数を更新
                    foreach (var value in values)
                    {
                        var complexMatch = Regex.Match(value, @"([-+]?\d*\.?\d*([eE][-+]?\d+)?)[+-]\d*\.?\d*j");
                        if (complexMatch.Success)
                        {
                            // 複素数の場合
                            var complexParts = complexMatch.Groups[1].Value.Split('.');
                            maxIntegerDigits = Math.Max(maxIntegerDigits, complexParts[0].TrimStart('-').Length);
                            if (complexParts.Length > 1)
                            {
                                maxDecimalDigits = Math.Max(maxDecimalDigits, complexParts[1].Length);
                            }
                            maxComplexDigits = Math.Max(maxComplexDigits, value.Length - complexMatch.Groups[1].Value.Length);
                        }
                        else if (double.TryParse(value, out double num))
                        {
                            var parts = value.Split('.');
                            if (!value.Equals("nan"))
                            {
                                maxIntegerDigits = Math.Max(maxIntegerDigits, parts[0].Length);
                            }

                            if (parts.Length > 1)
                            {
                                maxDecimalDigits = Math.Max(maxDecimalDigits, parts[1].Length);
                            }
                        }
                        else if (value == "nan")
                        {
                            // 'nan' の場合は整数部の最大桁数に影響を与えない
                            continue;
                        }
                    }
                }

                // Check if it's the end of a 2D array
                if (trimmedLine.Contains("]]"))
                {
                    arrays.Add(currentMatrix);
                    currentMatrix = new List<List<string>>();
                }
            }

            if (currentMatrix.Any())
            {
                arrays.Add(currentMatrix);
            }

            // 各列の最大幅を計算
            int overallMaxLength = 0;
            foreach (var array in arrays)
            {
                foreach (var matrix in array)
                {
                    foreach (var value in matrix)
                    {
                        if (value.Contains("nan"))
                            continue;
                        overallMaxLength = Math.Max(overallMaxLength, value.Trim().Length);
                    }
                }
            }

            // 整形された文字列の出力
            builder.Append("array(");
            builder.Append(Repeat(ndim, "["));

            for (int matrixIndex = 0; matrixIndex < arrays.Count; matrixIndex++)
            {
                var matrix = arrays[matrixIndex];
                for (int i = 0; i < matrix.Count; i++)
                {
                    var formattedRow = matrix[i]
                    .Select((element, index) => {
                        // True の場合は右詰めにする
                        if (element.Contains("."))
                        {
                            var complexMatch = Regex.Match(element, @"([-+]?\d*\.?\d*\s*([eE][-+]?\d+)?)[+-]\d*\.?\d*j");
                            if (complexMatch.Success)
                            {
                                // 複素数の場合、整数部と小数部の桁数に合わせてパディングし、複素数部はそのまま
                                var complexParts = complexMatch.Groups[1].Value.Split('.');
                                var integerPart = complexParts[0].PadLeft(maxIntegerDigits);
                                var decimalPart = complexParts.Length > 1 ? complexParts[1].PadRight(maxDecimalDigits, ' ') : new string(' ', maxDecimalDigits);
                                return $"{integerPart}.{decimalPart}" + element.Substring(complexMatch.Groups[1].Value.Length);
                            }
                            else if (element == "nan")
                            {
                                // 'nan' の場合、適切なスペースを追加
                                return element.PadLeft(maxIntegerDigits + maxDecimalDigits + 1);
                            }
                            else if (double.TryParse(element, out double num))
                            {
                                // 数値の場合、整数部と小数部の桁数に合わせてパディング
                                var parts = element.Split('.');
                                var integerPart = parts[0].PadLeft(maxIntegerDigits);
                                var decimalPart = parts.Length > 1 ? parts[1].PadRight(maxDecimalDigits, ' ') : "";
                                return $"{integerPart}.{decimalPart}";
                            }
                            return element.PadRight(overallMaxLength);
                        }
                        else if (element == "True" || element.Length < overallMaxLength)
                            return element.PadLeft(overallMaxLength);
                        else
                            return element.PadRight(overallMaxLength);
                    })
                    .Aggregate((acc, next) => acc + ", " + next);

                    if (i == 0)
                    {
                        builder.Append(matrixIndex > 0 ? "       " : "");
                    }
                    else
                    {
                        builder.Append("       ");
                    }

                    if ((arrays.Count == 1 && matrix.Count == 1))
                    {
                        if (ndim > 1)
                        {
                            builder.Append(formattedRow);
                        }
                        else
                        {
                            builder.Append(formattedRow);
                        }
                    }
                    else
                    {
                        if (i == 0)
                        {
                            if (ndim == 3 && matrixIndex > 0)
                            {
                                builder.Append("[[" + formattedRow + "]");
                            }
                            else
                            {
                                builder.Append(formattedRow + "]");
                            }
                        }
                        else if (i == matrix.Count - 1)
                        {
                            if (ndim == 3)
                            {
                                if (matrixIndex == arrays.Count - 1)
                                {
                                    builder.Append(Repeat(ndim - 2, " ") + "[" + formattedRow);
                                }
                                else
                                {
                                    builder.Append(Repeat(ndim - 2, " ") + "[" + formattedRow + "]]");
                                }
                            }
                            else
                            {
                                builder.Append("[" + formattedRow);
                            }
                        }
                        else
                        {
                            if (ndim == 3)
                            {
                                builder.Append(Repeat(ndim - 2, " ") + "[" + formattedRow + "]");
                            }
                            else
                            {
                                builder.Append("[" + formattedRow + "]");
                            }
                        }
                    }

                    if (ndim == 3 && i == matrix.Count - 1 && matrixIndex < arrays.Count - 1)
                    {
                        builder.Append(",\n\n");
                    }
                    else if (i < matrix.Count - 1)
                    {
                        builder.Append(",\n");
                    }

                    var r = builder.ToString();
                }
            }
            builder.Append(Repeat(ndim, "]"));

            if (dtypeMatched)
            {
                var m = dtypePattern.Match(input);
                var dtypeVal = m.Groups["dtype"].Value;
                builder.Append($", dtype={dtypeVal}");
            }
            builder.Append(")"); // array の閉じ括弧（外側）

            return builder.ToString();
        }

        private List<string> FormatArray(List<string> lines)
        {
            var result = new List<string>();

            // 先頭行の処理
            var firstLine = lines[0].Trim();
            if (firstLine.StartsWith("array(["))
            {
                // 先頭行から "array([" を除去し、整形を開始
                firstLine = firstLine.Substring("array([".Length).Trim('[', ']').Trim();
                result.Add("array([[" + firstLine);
            }
            else
            {
                result.Add("[" + firstLine);
            }

            // 残りの行の処理
            for (int i = 1; i < lines.Count; i++)
            {
                var line = lines[i].Trim();
                var innerContent = line.Trim('[', ']').Trim();

                if (!line.Contains("[") && line.Contains("]"))
                {
                    if (lines.Count - 1 != i)
                    {
                        result[result.Count - 1] += innerContent + "],\n";
                    }
                    else
                    {
                        result[result.Count - 1] += innerContent;
                    }
                }
                else
                {
                    if (lines.Count - 1 != i)
                    {
                        result.Add("[" + innerContent);
                    }
                    else
                    {
                        result.Add("[" + innerContent + "]])");
                    }
                }
            }

            return result;
        }


        private string Repeat(int ndim, string v)
        {
            var builder = new StringBuilder();
            for (var i = 0; i < ndim; i++)
            {
                builder.Append(v);
            }
            return builder.ToString();
        }

        private NDarray Leaf(NDarray ndArray)
        {
            var target = ndArray;
            var str = target.str;
            while (str.Contains("["))
            {
                target = target[0];
                str = target.str;
            }
            return target;
        }

        private string Dig(int dim, int depth, NDarray arr)
        {
            if (dim > 1)
            {
                var str = "[";
                for (int i = 0; i < arr.len; i++)
                {
                    var ndarray = arr[i];
                    str += Dig(dim - 1, depth, ndarray);
                    if (i < arr.len - 1)
                    {
                        str += ",";
                        if (dim > 0)
                        {
                            str += "\n\n       ";
                        }
                        else
                        {
                            str += " ";
                        }
                    }
                }
                str += "]";
                return str;
            }
            else
            {
                var str = arr.ToStringAsBase();

                var str2 = string.Empty;

                Regex regex = new Regex("(?<arr>\\[[-\\d\\.\\s]+\\])");
                Regex regex2 = new Regex("^\\[\\[[\\s\\S]+?\\]\\]$");
                Regex regex3 = new Regex("\\[(?<elms>[\\s\\S]+?)\\]");
                Regex regex4 = new Regex("\\[(?<contents>\\[[\\s\\S]+?\\])\\]");

                if (regex2.IsMatch(str))
                {
                    var str3 = str.Replace("]\n [", "],\n       [");
                    str3 = str3.Substring(1, str3.Length - 2);
                    if (regex4.IsMatch(str3))
                    {
                        var mcs = regex4.Matches(str3);
                        int strlen = 0;
                        int integerPartMaxLen = 0;
                        int decimalPartMaxLen = 0;
                        foreach (Match mc in mcs)
                        {
                            var str5 = mc.Groups["contents"].Value;
                            if (regex.IsMatch(str5))
                            {
                                var mcs2 = regex.Matches(str5);
                                foreach (Match mc2 in mcs2)
                                {
                                    var op = OnePass(mc2.Groups["arr"].ToString());
                                    strlen = Math.Max(strlen, op.Item2);
                                    integerPartMaxLen = Math.Max(integerPartMaxLen, op.Item3);
                                    decimalPartMaxLen = Math.Max(decimalPartMaxLen, op.Item4);
                                }
                            }
                        }

                        foreach (Match mc in mcs)
                        {
                            var str5 = mc.Groups["contents"].Value.Replace("]\n  [", "],\n       [");

                            if (regex.IsMatch(str5))
                            {
                                str2 += "[";
                                var mcs2 = regex.Matches(str5);
                                //Two pass
                                foreach (Match mc2 in mcs2)
                                {
                                    str2 += TwoPass(mc2.Groups["arr"].ToString(), strlen, integerPartMaxLen, decimalPartMaxLen);
                                    if (!Object.ReferenceEquals(mc2, mcs2.Last()))
                                    {
                                        str2 += ", ";
                                    }
                                }
                                str2 += "]";
                                if (!Object.ReferenceEquals(mc, mcs.Last()))
                                {
                                    str2 += ", ";
                                }
                            }
                        }
                        str2 = str2.Substring(1, str2.Length - 2);
                    }
                    else if (regex.IsMatch(str3))
                    {
                        var mcs = regex.Matches(str3);
                        int strlen = 0;
                        int integerPartMaxLen = 0;
                        int decimalPartMaxLen = 0;
                        //One pass
                        foreach (Match mc in mcs)
                        {
                            var op = OnePass(mc.Groups["arr"].ToString());
                            strlen = Math.Max(strlen, op.Item2);
                            integerPartMaxLen = Math.Max(integerPartMaxLen, op.Item3);
                            decimalPartMaxLen = Math.Max(decimalPartMaxLen, op.Item4);
                        }
                        //Two pass
                        foreach (Match mc in mcs)
                        {
                            str2 += TwoPass(mc.Groups["arr"].ToString(), strlen, integerPartMaxLen, decimalPartMaxLen);
                            if (!Object.ReferenceEquals(mc, mcs.Last()))
                            {
                                str2 += ", ";
                            }
                        }
                    }
                    else if (regex3.IsMatch(str3))
                    {
                        var mcs = regex3.Matches(str3);
                        int strlen = 0;
                        int integerPartMaxLen = 0;
                        int decimalPartMaxLen = 0;
                        //One pass
                        foreach (Match mc in mcs)
                        {
                            var op = OnePass(mc.Groups["elms"].ToString());
                            strlen = Math.Max(strlen, op.Item2);
                            integerPartMaxLen = Math.Max(integerPartMaxLen, op.Item3);
                            decimalPartMaxLen = Math.Max(decimalPartMaxLen, op.Item4);
                        }
                        //Two pass
                        foreach (Match mc in mcs)
                        {
                            str2 += TwoPass(mc.Groups["elms"].ToString(), strlen, integerPartMaxLen, decimalPartMaxLen);
                            if (!Object.ReferenceEquals(mc, mcs.Last()))
                            {
                                str2 += ", ";
                            }
                        }
                    }
                    str2 = $"[{str2}]";
                    str2 = str2.Replace("]], [[", $"]],\n{Spaces("array(".Length + depth - 1)}[[");
                    str2 = str2.Replace("], [", $"],\n{Spaces("array(".Length + depth - 1)}[");
                    return str2;
                }
                else if (regex.IsMatch(str))
                {
                    var mcs = regex.Matches(str);
                    int strlen = 0;
                    int integerPartMaxLen = 0;
                    int decimalPartMaxLen = 0;
                    //One pass
                    foreach (Match mc in mcs)
                    {
                        var op = OnePass(mc.Groups["arr"].ToString());
                        strlen = Math.Max(strlen, op.Item2);
                        integerPartMaxLen = Math.Max(integerPartMaxLen, op.Item3);
                        decimalPartMaxLen = Math.Max(decimalPartMaxLen, op.Item4);
                    }
                    //Two pass
                    foreach (Match mc in mcs)
                    {
                        str2 += TwoPass(mc.Groups["arr"].ToString(), strlen, integerPartMaxLen, decimalPartMaxLen);
                        if (!Object.ReferenceEquals(mc, mcs.Last()))
                        {
                            str2 += ", ";
                        }
                    }
                    if (mcs.Count() > 1)
                    {
                        str2 = $"[{str2}]";
                        str2 = str2.Replace("]], [[", $"]],\n{Spaces("array(".Length + depth - 1)}[[");
                        str2 = str2.Replace("], [", $"],\n{Spaces("array(".Length + depth - 1)}[");
                        return str2;
                    }
                    else
                    {
                        //return $"{str2}".Replace("], [", "],\n       [");
                        str2 = str2.Replace("]], [[", $"]],\n{Spaces("array(".Length + depth - 1)}[[");
                        str2 = str2.Replace("], [", $"],\n{Spaces("array(".Length + depth - 1)}[");
                        return str2;
                    }
                }
                else
                {
                    if (str.Equals("[]"))
                    {
                        return str;
                    }
                    int strlen = 0;
                    int integerPartMaxLen = 0;
                    int decimalPartMaxLen = 0;
                    var op = OnePass(str);
                    strlen = Math.Max(strlen, op.Item2);
                    integerPartMaxLen = Math.Max(integerPartMaxLen, op.Item3);
                    decimalPartMaxLen = Math.Max(decimalPartMaxLen, op.Item4);
                    str2 += TwoPass(str, strlen, integerPartMaxLen, decimalPartMaxLen);
                    return $"{str2}".Replace("], [", "],\n       [");
                }
            }
        }

        private string ToStringAsBase()
        {
            return base.ToString();
        }

        private string TwoPass(string input, int strlen, int integerPartMaxLen, int decimalPartMaxLen)
        {
            if (!input.Contains(',') && !input.Contains(' '))
            {
                return input;
            }
            var elements = input.Split('[', ',', ' ', ']');
            elements = elements.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            elements = JoinComplex(elements);
            int maxlen = strlen;
            var str = string.Empty;
            var regex = new Regex("(?<integerPart>-?\\d+?)\\.(?<decimalPart>\\d+?)?");
            var regexComplex = new Regex("(?<real>\\d+?)\\.\\+(?<imag>\\d+?)\\.j");
            foreach (var element in elements)
            {
                //複素数の時
                if (regexComplex.IsMatch(element))
                {
                    int count = 0;
                    str += element.Insert(element.IndexOf("+"), Spaces(maxlen-element.Length));
                    count = maxlen - element.Length;
                    for (int i = 0; i < maxlen - count - element.Length; i++)
                    {
                        str += " ";
                    }
                }
                else //整数、小数の時
                {
                    //小数点があるときは左詰め
                    if (element.Contains("."))
                    {
                        int count = 0;
                        if (regex.IsMatch(element))
                        {
                            var mc = regex.Match(element);
                            var integerPartStr = mc.Groups["integerPart"].Value;
                            var decimalPartStr = mc.Groups["decimalPart"].Value;
                            for (int i = 0; i < integerPartMaxLen - integerPartStr.Length; i++)
                            {
                                str += " ";
                                count++;
                            }
                        }
                        str += element;
                        if (regex.IsMatch(element))
                        {
                            var mc = regex.Match(element);
                            var integerPartStr = mc.Groups["integerPart"].Value;
                            var decimalPartStr = mc.Groups["decimalPart"].Value;
                            for (int i = 0; i < decimalPartMaxLen - decimalPartStr.Length; i++)
                            {
                                str += " ";
                                count++;
                            }
                        }
                        for (int i = 0; i < maxlen - count - element.Length; i++)
                        {
                            str += " ";
                        }
                    }
                    else //小数点がないときは右詰め
                    {
                        for (int i = 0; i < maxlen - element.Length; i++)
                        {
                            str += " ";
                        }
                        str += element;
                    }
                }

                if (!Object.ReferenceEquals(element, elements.Last()))
                {
                    str += ", ";
                }
            }
            if (str.Contains(','))
            {
                str = $"[{str}]";
            }
            str = str.Replace("\n, ", ",\n       ");
            return str;
        }

        private string Spaces(int count)
        {
            string ret = string.Empty;
            for (int i = 0;i < count;i++)
            {
                ret += " ";
            }
            return ret;
        }

        private string[] JoinComplex(string[] elements)
        {
            var ret = new List<string>();
            foreach (var element in elements)
            {
                if (element.StartsWith("+"))
                {
                    ret[ret.Count() - 1] = ret[ret.Count() - 1] + element;
                }
                else
                {
                    ret.Add(element);
                }
            }
            return ret.ToArray();
        }

        private (string, int, int, int) OnePass(string str)
        {
            var elements = str.Split('[', ',', ' ', ']');
            elements = elements.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            int maxlen = elements.Max(x => x.Length);
            int integerPartMaxLen = 0;
            int decimalPartMaxLen = 0;
            str = string.Empty;
            var regex = new Regex("(?<integerPart>-?\\d+?)\\.(?<decimalPart>\\d+?)");
            foreach (var element in elements)
            {
                if (regex.IsMatch(element))
                {
                    var mc = regex.Match(element);
                    var integerPartStr = mc.Groups["integerPart"].Value;
                    integerPartMaxLen = Math.Max(integerPartMaxLen, integerPartStr.Length);
                    var decimalPartStr = mc.Groups["decimalPart"].Value;
                    decimalPartMaxLen = Math.Max(decimalPartMaxLen, decimalPartStr.Length);
                }

                str += element;
                for (int i = 0; i < maxlen - element.Length; i++)
                {
                    str += " ";
                }
                if (!Object.ReferenceEquals(element, elements.Last()))
                {
                    str += ", ";
                }
            }
            if (str.Contains(','))
            {
                str = $"[{str}]";
            }
            str = str.Replace("\n, ", ",\n       ");
            return (str, elements.Max(x => x.Length), integerPartMaxLen, decimalPartMaxLen);
        }
    }

    public class NDarray<T> : NDarray
    {
        public NDarray(NDarray t) : base(t)
        {
        }

        public NDarray(PyObject pyobject) : base(pyobject)
        {
        }

        public NDarray(T[] array)
        {
            var nd = cp.array(array);
            self = nd.self;
        }

        public new NDarray<T> this[string slicing_notation]
        {
            get
            {
                var tuple = new PyTuple(Slice.ParseSlices(slicing_notation).Select(s =>
                {
                    if (s.IsIndex)
                        return new PyInt(s.Start.Value);
                    return s.ToPython();
                }).ToArray());
                return new NDarray<T>(PyObject[tuple]);
            }
            set
            {
                var tuple = new PyTuple(Slice.ParseSlices(slicing_notation).Select(s =>
                {
                    if (s.IsIndex)
                        return new PyInt(s.Start.Value);
                    return s.ToPython();
                }).ToArray());
                self.SetItem(tuple, ToPython(value));
            }
        }

        public new NDarray this[params int[] coords]
        {
            get
            {
                if (coords.Length == 1)
                {
                    var pyint = new PyInt(coords[0]);
                    return new NDarray<T>(PyObject[pyint]);
                }
                else
                {
                    var tuple = ToTuple(coords);
                    return new NDarray<T>(PyObject[tuple]);
                }
            }
            set
            {
                var tuple = ToTuple(coords);
                self.SetItem(tuple, ToPython(value));
            }
        }

        public new NDarray this[params NDarray[] indices]
        {
            get
            {
                var tuple = new PyTuple(indices.Select(a => (PyObject)a.PyObject).ToArray());
                return new NDarray<T>(PyObject[tuple]);
            }
            set
            {
                var tuple = new PyTuple(indices.Select(a => (PyObject)a.PyObject).ToArray());
                self.SetItem(tuple, ToPython(value));
            }
        }

        public new NDarray this[params object[] arrays_slices_or_indices]
        {
            get
            {
                var pyobjs = arrays_slices_or_indices.Select<object, PyObject>(x =>
                {
                    switch (x)
                    {
                        case int i: return new PyInt(i);
                        case NDarray a: return a.PyObject;
                        case string s: return new Slice(s).ToPython();
                        default: return ToPython(x);
                    }
                }).ToArray();
                var tuple = new PyTuple(pyobjs);
                return new NDarray(PyObject[tuple]);
            }
            set
            {
                var pyobjs = arrays_slices_or_indices.Select<object, PyObject>(x =>
                {
                    switch (x)
                    {
                        case int i: return new PyInt(i);
                        case NDarray a: return a.PyObject;
                        case string s: return new Slice(s).ToPython();
                        default: return ToPython(x);
                    }
                }).ToArray();
                var tuple = new PyTuple(pyobjs);
                self.SetItem(tuple, ToPython(value));
            }
        }

        /// <summary>
        ///     Returns a copy of the array data
        /// </summary>
        public T GetData()
        {
            return base.GetData<T>();
        }

        public T item()
        {
            if (typeof(T) == typeof(Complex))
                return (T)(object)new Complex(real.asscalar<double>(), imag.asscalar<double>());
            return self.InvokeMethod("item").As<T>();
        }

        public override string ToString()
        {
            string str = string.Empty;
            var dig = Dig(ndim - 1, this);
            if (dig.IndexOf("[") > -1)
            {
                str = $"array({dig}";
                if (!dtype.ToString().Equals("int32"))
                {
                    str += $", dtype={dtype}";
                }
                str += ")";
            }
            else
            {
                str += dig;
            }
            return str;
        }

        private string Dig(int dim, NDarray arr)
        {
            if (dim == -1)
            {
                var isComplex = arr.dtype.ToString().StartsWith("complex");
                if (isComplex)
                {
                    return $"{arr.real.ToString()}+{arr.imag.ToString()}j";
                }
                return arr.ToStringAsPythonObject();
            }
            else
            {
                var str = "[";
                for (int i = 0; i < arr.len; i++)
                {
                    str += Dig(dim - 1, arr[i]);
                    if (i < arr.len - 1)
                    {
                        str += ",";
                        if (dim > 0)
                        {
                            str += "\n       ";
                        }
                        else
                        {
                            str += " ";
                        }
                    }
                }
                str += "]";
                return str;
            }
        }
    }
}