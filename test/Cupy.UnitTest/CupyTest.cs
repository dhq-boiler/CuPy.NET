using Cupy.Models;
using NUnit.Framework;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Cupy.UnitTest
{
    [TestFixture]
    public class CupyTest : BaseTestCase
    {

        [Test]
        public void empty()
        {
            // initialize an array with random integers
            var a = cp.empty(new Shape(2, 3), cp.int32);
            Console.WriteLine(a.repr);
            Assert.That(a.ToString(), Is.Not.Null);
            // this should print out the exact integers of the array
            foreach (var x in a.GetData<int[,]>())
                Console.WriteLine(x);
        }

        [Test]
        public unsafe void create_from_pointer_without_copying()
        {
            var pointer = IntPtr.Zero;
            try
            {
                var dtype = cp.int32;
                const int length = 1024;
                pointer = Marshal.AllocHGlobal(length);
                var ptr = (int*)pointer;
                // fill the buffer with index numbers
                for (var i = 0; i < length / sizeof(int); i++)
                    ptr[i] = i;
                var a = new NDarray(pointer, length, dtype);
                Console.WriteLine(a.ToString());
                var b = cp.arange(length / sizeof(int));
                Console.WriteLine(b);
                var truth1 = b.Equals(a);
                var truth2 = a.Equals(b);
                Assert.That(b, Is.EqualTo(a));
            }
            finally
            {
                if (pointer != IntPtr.Zero)
                    Marshal.FreeHGlobal(pointer);
            }
        }

#if NOT_IMPLEMENTED
        [Test]
        public void efficient_array_copy()
        {
            var a = cp.empty(new Shape(2, 3), cp.int32);
            Console.WriteLine(a.repr);
            Assert.IsNotNull(a.ToString());
            long ptr = a.PyObject.ctypes.data;
            Console.WriteLine("ptr: " + ptr);
            var array = new[] { 1, 2, 3, 4, 5, 6 };
            Marshal.Copy(array, 0, new IntPtr(ptr), array.Length);
            Console.WriteLine(a.ToString());
        }
#endif

        [Test]
        public void array()
        {
            var array = new[] { 1, 2, 3, 4, 5, 6 };
            var a = cp.array(array);
            Console.WriteLine(a.repr);
            Assert.That(array, Is.EqualTo(a.GetData<int[]>()));
        }

        [Test]
        public void ndarray_shape()
        {
            var array = new[] { 1, 2, 3, 4, 5, 6 };
            var a = cp.array(array);
            Assert.That(new Shape(6), Is.EqualTo(a.shape));
            Assert.That(new Shape(100), Is.EqualTo(cp.arange(100).shape));
        }

        [Test]
        public void ndarray_strides()
        {
            Assert.That(new[] { 4 }, Is.EqualTo(cp.array(1, 2, 3, 4, 5, 6).strides));
            Assert.That(new[] { 8 }, Is.EqualTo(cp.arange(10, dtype: cp.longlong).strides));
        }

        [Test]
        public void ndarray_ndim()
        {
            Assert.That(1, Is.EqualTo(cp.array(1, 2, 3, 4, 5, 6).ndim));
            Assert.That(1, Is.EqualTo(cp.arange(10, dtype: cp.longlong).ndim));
        }

        [Test]
        public void ndarray_size()
        {
            Assert.That(6, Is.EqualTo(cp.array(1, 2, 3, 4, 5, 6).size));
            Assert.That(10, Is.EqualTo(cp.arange(10, dtype: cp.longlong).size));
        }

        [Test]
        public void ndarray_len()
        {
            Assert.That(6, Is.EqualTo(cp.array(1, 2, 3, 4, 5, 6).len));
            Assert.That(10, Is.EqualTo(cp.arange(10, dtype: cp.longlong).len));
        }

        [Test]
        public void ndarray_itemsize()
        {
            Assert.That(4, Is.EqualTo(cp.array(1, 2, 3, 4, 5, 6).itemsize));
            Assert.That(8, Is.EqualTo(cp.arange(10, dtype: cp.longlong).itemsize));
        }

        [Test]
        public void ndarray_nbytes()
        {
            Assert.That(24, Is.EqualTo(cp.array(1, 2, 3, 4, 5, 6).nbytes));
            Assert.That(80, Is.EqualTo(cp.arange(10, dtype: cp.longlong).nbytes));
        }

        [Test]
        public void ndarray_base()
        {
            var a = cp.array(1, 2, 3, 4, 5, 6);
            var b = a.reshape(new Shape(2, 3));
            Assert.That(null, Is.EqualTo(a.@base));
            Assert.That(a, Is.EqualTo(b.@base));
        }

        [Test]
        public void ndarray_dtype()
        {
            Assert.That(cp.int32, Is.EqualTo(cp.array(new[] { 1, 2, 3, 4, 5, 6 }, cp.int32).dtype));
            Assert.That(cp.longlong, Is.EqualTo(cp.arange(10, dtype: cp.longlong).dtype));
            Assert.That(cp.float32, Is.EqualTo(cp.arange(10, dtype: cp.float32).dtype));
            Assert.That(cp.@double, Is.EqualTo(cp.arange(10, dtype: cp.float64).dtype));
        }

        [Test]
        public void ndarray_multidim_source_array()
        {
            var a = cp.array(new[,] { { 1f, 2f }, { 3f, 4f }, { 3f, 4f } });
            Console.WriteLine(a.repr);
            Assert.That(new Shape(3, 2), Is.EqualTo(a.shape));
            Assert.That(cp.float32, Is.EqualTo(a.dtype));
        }

        [Test]
        public void ndarray_T()
        {
            var x = cp.array(new[,] { { 1f, 2f }, { 3f, 4f } });
            Assert.That("array([[1.0, 2.0],\n       [3.0, 4.0]], dtype=float32)", Is.EqualTo(x.ToString()));
            var t = x.T;
            Console.WriteLine(t.repr);
            Assert.That("[[1., 3.],\n       [2., 4.]]", Is.EqualTo(t.ToString()));
            // getting data of transposed array returns transposed array!
            Assert.That(new[,] { { 1f, 3f}, { 2f, 4f} }, Is.EqualTo(t.GetData<float[,]>()));
        }

        [Test]
        public void ndarray_flatten()
        {
            var x = cp.array(new[,] { { 1f, 2f }, { 3f, 4f } });
            Assert.That("[1., 2., 3., 4.]", Is.EqualTo(x.flatten().ToString()));
            var t = x.T;
            Assert.That("[1., 3., 2., 4.]", Is.EqualTo(t.flatten().ToString()));
            Assert.That(new[] { 1f, 3f, 2f, 4f }, Is.EqualTo(t.flatten().GetData<float[]>()));
        }

        [Test]
        public void ndarray_reshape()
        {
            var a = cp.array(1, 2, 3, 4, 5, 6);
            var b = a.reshape(new Shape(2, 3));
            Assert.That("[[1 2 3]\n [4 5 6]]", Is.EqualTo(b.str));
            Assert.That(new Shape(2, 3), Is.EqualTo(b.shape));
            Assert.That(null, Is.EqualTo(a.@base));
            Assert.That(a, Is.EqualTo(b.@base));
        }

        [Test]
        public void ndarray_indexing()
        {
            // using string indices
            var x = cp.arange(10);
            Assert.That("2", Is.EqualTo(x["2"].str));
            Assert.That("8", Is.EqualTo(x["-2"].str));
            Assert.That("[2 3 4 5 6 7]", Is.EqualTo(x["2:-2"].str));
            var y = x.reshape(new Shape(2, 5));
            Assert.That("8", Is.EqualTo(y["1,3"].str));
            Assert.That("9", Is.EqualTo(y["1,-1"].str));
            Assert.That("array([0, 1, 2, 3, 4])", Is.EqualTo(y["0"].repr));
            Assert.That("2", Is.EqualTo(y["0"]["2"].str));
        }

        [Test]
        public void ndarray_indexing1()
        {
            // using int indices
            var x = cp.arange(10);
            Assert.That("2", Is.EqualTo(x[2].str));
            Assert.That("8", Is.EqualTo(x[-2].str));
            var y = x.reshape(new Shape(2, 5));
            Assert.That("8", Is.EqualTo(y[1, 3].str));
            Assert.That("9", Is.EqualTo(y[1, -1].str));
            Assert.That("array([0, 1, 2, 3, 4])", Is.EqualTo(y[0].repr));
            Assert.That("2", Is.EqualTo(y[0][2].str));
        }

        [Test]
        public void ndarray_indexing2()
        {
            var x = cp.arange(10, 1, -1);
            Assert.That("array([10,  9,  8,  7,  6,  5,  4,  3,  2])", Is.EqualTo(x.repr));
            Assert.That("array([7, 7, 9, 2])", Is.EqualTo(x[cp.array(3, 3, 1, 8)].repr));
            Assert.That("array([7, 7, 4, 2])", Is.EqualTo(x[cp.array(3, 3, -3, 8)].repr));
            Assert.That("array([[9, 9],\n       [8, 7]])", Is.EqualTo(x[cp.array(new[,] { { 1, 1 }, { 2, 3 } })].repr));
        }

        [Test]
        public void ndarray_indexing3()
        {
            var y = cp.arange(35).reshape(5, 7);
            Assert.That("array([ 0, 15, 30])", Is.EqualTo(y[cp.array(0, 2, 4), cp.array(0, 1, 2)].repr));
            Assert.That("array([ 1, 15, 29])", Is.EqualTo(y[cp.array(0, 2, 4), 1].repr));
            Assert.That(
                "array([[ 0,  1,  2,  3,  4,  5,  6],\n       [14, 15, 16, 17, 18, 19, 20],\n       [28, 29, 30, 31, 32, 33, 34]])",
                Is.EqualTo(y[cp.array(0, 2, 4)].repr));
        }

        [Test]
        public void ndarray_indexing_setter1()
        {
            // using int indices
            var x = cp.arange(10);
            Assert.That("2", Is.EqualTo(x[2].str));
            x[2] = (NDarray)22;
            Assert.That("22", Is.EqualTo(x[2].str));
            Assert.That("8", Is.EqualTo(x[-2].str));
            x[-2] = (NDarray)88;
            Assert.That("88", Is.EqualTo(x[-2].str));
            var y = x.reshape(new Shape(2, 5));
            Assert.That("88", Is.EqualTo(y[1, 3].str));
            y[1, 3] = (NDarray)888;
            Assert.That("888", Is.EqualTo(y[1, 3].str));
            Assert.That("array([ 0,  1, 22,  3,  4])", Is.EqualTo(y[0].repr));
            Assert.That("22", Is.EqualTo(y[0][2].str));
            y[0][2] = (NDarray)222;
            Assert.That("222", Is.EqualTo(y[0][2].str));
        }

        [Test]
        public void ndarray_indexing_setter2()
        {
            // using string indices
            var x = cp.arange(10);
            Assert.That("2", Is.EqualTo(x[2].str));
            x["2"] = (NDarray)22;
            Assert.That("22", Is.EqualTo(x[2].str));
            Assert.That("8", Is.EqualTo(x[-2].str));
            x["-2"] = (NDarray)88;
            Assert.That("88", Is.EqualTo(x[-2].str));
            var y = x.reshape(new Shape(2, 5));
            Assert.That("88", Is.EqualTo(y[1, 3].str));
            y["1, 3"] = (NDarray)888;
            Assert.That("888", Is.EqualTo(y[1, 3].str));
            Assert.That("array([ 0,  1, 22,  3,  4])", Is.EqualTo(y[0].repr));
            Assert.That("22", Is.EqualTo(y[0][2].str));
            y["0"]["2"] = (NDarray)222;
            Assert.That("222", Is.EqualTo(y[0][2].str));
        }

        [Test]
        public void ndarray_indexing_setter3()
        {
            var a = cp.array(1, 2, 3, 4, 5, 6).reshape(new Shape(2, 3));
            Assert.That("[[1 2 3]\n [4 5 6]]", Is.EqualTo(a.str));
            a[":", 1] = a[":", 1] * 2;
            Assert.That("[[ 1  4  3]\n [ 4 10  6]]", Is.EqualTo(a.str));
        }

        [Test]
        public void ndarray_indexing_setter4()
        {
            var x = cp.arange(10, 1, -1);
            Assert.That("array([10,  9,  8,  7,  6,  5,  4,  3,  2])", Is.EqualTo(x.repr));
            Assert.That("array([7, 7, 9, 2])", Is.EqualTo(x[cp.array(3, 3, 1, 8)].repr));
            var ZeroToThree = cp.arange(4);
            x[cp.array(3, 3, 1, 8)] = ZeroToThree;
            Assert.That("array([10,  2,  8,  1,  6,  5,  4,  3,  3])", Is.EqualTo(x.repr));
        }

        [Test]
        public void ndarray_slice()
        {
            var x = cp.arange(10);
            Assert.That("array([2, 3, 4])", Is.EqualTo(x["2:5"].repr));
            Assert.That("array([0, 1, 2])", Is.EqualTo(x[":-7"].repr));
            Assert.That("array([1, 3, 5])", Is.EqualTo(x["1:7:2"].repr));
            var y = cp.arange(35).reshape(new Shape(5, 7));
            Assert.That("array([[ 7, 10, 13],\n       [21, 24, 27]])", Is.EqualTo(y["1:5:2,::3"].repr));
        }

        [Test]
        public void ndarray_slice1()
        {
            var y = cp.arange(35).reshape(5, 7);
            var b = y > 20;
            Assert.That(
                "array([[ 1,  2],\n" +
                "       [15, 16],\n" +
                "       [29, 30]])",
                Is.EqualTo(y[cp.array(0, 2, 4), "1:3"].repr));
            Assert.That("array([[22, 23],\n       [29, 30]])", Is.EqualTo(y[b[":", 5], "1:3"].repr));
        }

        [Test]
        public void ndarray_masking()
        {
            var y = cp.arange(35).reshape(5, 7);
            var b = y > 20;
            Assert.That("array([21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34])", Is.EqualTo(y[b].repr));
            // use a 1-D boolean whose first dim agrees with the first dim of y
            Assert.That("array([False, False, False,  True,  True])", Is.EqualTo(b[":", 5].repr));
            Assert.That("array([[21, 22, 23, 24, 25, 26, 27],\n       [28, 29, 30, 31, 32, 33, 34]])",
                Is.EqualTo(y[b[":", 5]].repr));
        }

        [Test]
        public void ndarray_masking1()
        {
            var x = cp.arange(30).reshape(2, 3, 5);
            var expected =
                "array([[[ 0,  1,  2,  3,  4],\n" +
                "        [ 5,  6,  7,  8,  9],\n" +
                "        [10, 11, 12, 13, 14]],\n\n" +
                "       [[15, 16, 17, 18, 19],\n" +
                "        [20, 21, 22, 23, 24],\n" +
                "        [25, 26, 27, 28, 29]]])";
            Assert.That(
                expected,
                Is.EqualTo(x.repr));
            var b = cp.array(new[,] { { true, true, false }, { false, true, true } });
            expected =
                "array([[ 0,  1,  2,  3,  4],\n" +
                "       [ 5,  6,  7,  8,  9],\n" +
                "       [20, 21, 22, 23, 24],\n" +
                "       [25, 26, 27, 28, 29]])";
            Assert.That(
                expected,
                Is.EqualTo(x[b].repr));
        }

        [Test]
        public void ndarray_comparison_operators()
        {
            var a = cp.array(1, 2, 3);
            // comparison with a scalar
            Assert.That(new[] { true, false, false }, Is.EqualTo((a < 2).GetData<bool[]>()));
            Assert.That(new[] { true, true, false }, Is.EqualTo((a <= 2).GetData<bool[]>()));
            Assert.That(new[] { false, false, true }, Is.EqualTo((a > 2).GetData<bool[]>()));
            Assert.That(new[] { false, true, true }, Is.EqualTo((a >= 2).GetData<bool[]>()));
            Assert.That(new[] { false, true, false }, Is.EqualTo(a.equals(2).GetData<bool[]>()));
            Assert.That(new[] { true, false, true }, Is.EqualTo(a.not_equals(2).GetData<bool[]>()));
            // comparison with an array
            var b = cp.ones(new Shape(3), cp.int32) * 2;
            Assert.That(new[] { true, false, false }, Is.EqualTo((a < b).GetData<bool[]>()));
            Assert.That(new[] { true, true, false }, Is.EqualTo((a <= b).GetData<bool[]>()));
            Assert.That(new[] { false, false, true }, Is.EqualTo((a > b).GetData<bool[]>()));
            Assert.That(new[] { false, true, true }, Is.EqualTo((a >= b).GetData<bool[]>()));
            Assert.That(new[] { false, true, false }, Is.EqualTo(a.equals(b).GetData<bool[]>()));
            Assert.That(new[] { true, false, true }, Is.EqualTo(a.not_equals(b).GetData<bool[]>()));
        }

        [Test]
        public void ndarray_unary_operators()
        {
            // unary operations
            var a = cp.array(1, 2, 3);
            Assert.That(new[] { -1, -2, -3 }, Is.EqualTo((-a).GetData<int[]>()));
            Assert.That(new[] { 1, 2, 3 }, Is.EqualTo((+a).GetData<int[]>()));
            // todo: test operator ~
        }

        [Test]
        public void ndarray_arithmetic_operators()
        {
            // arithmetic operators
            var a = cp.array(1, 2, 3);
            var b = cp.ones(new Shape(3), cp.int32) * 2;
            Assert.That(new[] { 11, 12, 13 }, Is.EqualTo((a + 10).GetData<int[]>()));
            Assert.That(new[] { 3, 4, 5 }, Is.EqualTo((a + b).GetData<int[]>()));
            Assert.That(new[] { -9, -8, -7 }, Is.EqualTo((a - 10).GetData<int[]>()));
            Assert.That(new[] { -1, 0, 1 }, Is.EqualTo((a - b).GetData<int[]>()));
            Assert.That(new[] { 10, 20, 30 }, Is.EqualTo((a * 10).GetData<int[]>()));
            Assert.That(new[] { 2, 4, 6 }, Is.EqualTo((a * b).GetData<int[]>()));
            a = cp.array(2, 4, 16);
            Assert.That(new[] { 1d, 2d, 8d }, Is.EqualTo((a / 2).GetData<double[]>()));
            Assert.That(new[] { 1d, 2d, 8d }, Is.EqualTo((a / b).GetData<double[]>()));
            Assert.That(new[] { 4, 2, .5 }, Is.EqualTo((8 / a).GetData<double[]>()));
            Assert.That(new[] { 4, 2, -10 }, Is.EqualTo((6 - a).GetData<int[]>()));
        }

        [Test]
        public void ndarray_arithmetic_inplace_operators()
        {
            var a = cp.array(1, 2, 3);
            var b = cp.ones(new Shape(3), cp.int32) * 2;
            a.iadd(10);
            Assert.That(new[] { 11, 12, 13 }, Is.EqualTo(a.GetData<int[]>()));
            a.isub(10);
            Assert.That(new[] { 1, 2, 3 }, Is.EqualTo(a.GetData<int[]>()));
            a.iadd(b);
            Assert.That(new[] { 3, 4, 5 }, Is.EqualTo(a.GetData<int[]>()));
            a.isub(b);
            Assert.That(new[] { 1, 2, 3 }, Is.EqualTo(a.GetData<int[]>()));
        }

        [Test]
        public void ndarray_value_div_ndarray()
        {
            // division operator
            var a = cp.array(1.0, 2.0, 3.0);
            Assert.That(new[] { 0.5, 1.0, 1.5 }, Is.EqualTo((a / 2.0).GetData<double[]>()));
            Assert.That(new[] { 6.0, 3.0, 2.0 }, Is.EqualTo((6.0 / a).GetData<double[]>()));
            // minus operator
            Assert.That(new[] { -1.0, 0.0, 1.0 }, Is.EqualTo((a - 2.0).GetData<double[]>()));
            Assert.That(new[] { 1.0, 0.0, -1.0 }, Is.EqualTo((2.0 - a).GetData<double[]>()));
        }

        [Test]
        public void np_where()
        {
            //>>> import Cupy as np
            //>>> a = [1, 2, 3, 4, 0, 0, 1, 2]
            //>>> a = cp.array(a)
            //>>> b = cp.where(a == 0)
            //>>> b[0]
            //array([4, 5], dtype = int64)
            var a = cp.array(1, 2, 3, 4, 0, 0, 1, 2);
            var b = a.equals(0).where();
            Assert.That("array([4, 5], dtype=int64)", Is.EqualTo(b[0].repr));
        }

        [Test]
        public void GetData_noncontiguous()
        {
            var X = new int[3, 3];
            X[0, 0] = -1;

            NDarray npX = cp.array(X, cp.int32); // control
            NDarray npY = cp.array(X, cp.int32); // test

            Console.WriteLine("Control:");
            Console.WriteLine(npX);

            Console.WriteLine("Test:");
            Console.WriteLine(npY);

            // flip on the row axis
            npY = npY.flip(new[] { 0 });
            Console.WriteLine("Test flipped on axis 0:");
            Console.WriteLine(npY);

            // get their data
            var cX = npX.GetData<int[][]>();
            var cY = npY.GetData<int[][]>();

            Console.WriteLine("Control extracted back to C#:\n" + string.Join(" ", cX.SelectMany(x => x)));
            Assert.That("-1 0 0 0 0 0 0 0 0", Is.EqualTo(string.Join(" ", cX.SelectMany(x => x))));
            Console.WriteLine("Test extracted back to C#:\n" + string.Join(" ", cY.SelectMany(x => x)));
            Assert.That("0 0 0 0 0 0 -1 0 0", Is.EqualTo(string.Join(" ", cY.SelectMany(x => x))));
        }

        [Test]
        public void CopyDataInAndOutExample()
        {
            var a = cp.array(2, 4, 9, 25);
            Console.WriteLine("a: " + a.repr);
            // a: array([ 2,  4,  9, 25])
            var roots = a.sqrt();
            Console.WriteLine(roots.repr);
            // array([1.41421356, 2.        , 3.        , 5.        ])
            Assert.That("array([1.41421356, 2.        , 3.        , 5.        ], dtype=float64)", Is.EqualTo(roots.repr));
#if TODO
            Console.WriteLine(string.Join(", ", roots.GetData<int[]>()));
#endif
            // 1719614413, 1073127582, 0, 1073741824
            Console.WriteLine("roots.dtype: " + roots.dtype);
            // roots.dtype: float64
            Console.WriteLine(string.Join(", ", roots.GetData<double[]>()));
            // 1.4142135623731, 2, 3, 5
            Assert.That(new[] { 1.41, 2, 3, 5 }, Is.EqualTo(roots.GetData<double[]>().Select(x => Math.Round(x, 2)).ToArray()));
        }

        [Test]
        public void QuestionByPiyushspss()
        {
            // cp.column_stack(cp.where(mat > 0))

            //>>> a = cp.array([1, 0, 0, 1, 2, 3, 0, 1]).reshape(2, 4)
            //         >>> a
            //array([[1, 0, 0, 1],
            //       [2, 3, 0, 1]])
            //>>> cp.column_stack(a)
            //array([[1, 2],
            //       [0, 3],
            //       [0, 0],
            //       [1, 1]])
            //>>> cp.where(a > 0)
            //(array([0, 0, 1, 1, 1], dtype = int64), array([0, 3, 0, 1, 3], dtype = int64))
            //>>> cp.column_stack(cp.where(a > 0))
            //array([[0, 0],
            //       [0, 3],
            //       [1, 0],
            //       [1, 1],
            //       [1, 3]], dtype = int64)
            //>>>
            var a = cp.array(1, 0, 0, 1, 2, 3, 0, 1).reshape(2, 4);
            var expected =
                "array([[1, 2],\n" +
                "       [0, 3],\n" +
                "       [0, 0],\n" +
                "       [1, 1]])";
            Assert.That(expected, Is.EqualTo(cp.column_stack(a).repr));
            // note: this was a bug, now you don't get a python tuple back, but an array of NDarrays instead so the following line just doesn't compile any more
            //Assert.That("(array([0, 0, 1, 1, 1], dtype=int64), array([0, 3, 0, 1, 3], dtype=int64))", cp.where(a > 0).repr);
            expected =
                "array([[0, 0],\n" +
                "       [0, 3],\n" +
                "       [1, 0],\n" +
                "       [1, 1],\n" +
                "       [1, 3]], dtype=int64)";
            Assert.That(expected, Is.EqualTo(cp.column_stack((a > 0).where()).repr));
        }

        [Test]
        public void QuestionByGurelsoycaner()
        {
            //>>> import Cupy as np
            //>>> P1 = cp.array([1, 2, 3, 4])
            //>>> P2 = cp.array([4, 3, 2, 1])
            //>>> ex = (P2 - P1) / (cp.linalg.norm(P2 - P1))
            //>>> ex
            //array([0.67082039, 0.2236068, -0.2236068, -0.67082039])
            var P1 = cp.array(1, 2, 3, 4);
            var P2 = cp.array(4, 3, 2, 1);
            var ex = (P2 - P1) / cp.linalg.norm(P2 - P1);
            Assert.That("array([ 0.67082039,  0.2236068 , -0.2236068 , -0.67082039], dtype=float64)", Is.EqualTo(ex.repr));
        }

        [Test]
        public void QuestionBySimonBuehler()
        {
            //import Cupy as np
            //bboxes = cp.empty([999, 4])
            //keep_idx = cp.array([2, 6, 7, 8, 9, 13])
            //bboxes = bboxes[keep_idx]
            //>>> bboxes.shape
            //(6, 4)
            var bboxes = cp.empty(new Shape(999, 4));
            var keep_idx = cp.array(2, 6, 7, 8, 9, 13);
            bboxes = bboxes[keep_idx];
            Assert.That("(6, 4)", Is.EqualTo(bboxes.shape.ToString()));

            //>>> cp.where(keep_idx > 4)[0]
            //array([1, 2, 3, 4, 5], dtype = int64)
            var x = (keep_idx > 4).where()[0];
            Assert.That("array([1, 2, 3, 4, 5], dtype=int64)", Is.EqualTo(x.repr));
        }

#if NOT_SUPPORTED
        [Test]
        public void StringArray()
        {
            //>>> a = Cupy.array(['apples', 'foobar', 'cowboy'])
            //>>> a[2] = 'bananas'
            //>>> a
            //array(['apples', 'foobar', 'banana'], 
            //      dtype = '|S6')
            var a = cp.array(new[] { "apples", "foobar", "cowboy" });
            Assert.That("array(['apples', 'foobar', 'cowboy'], dtype='<U6')", a.repr);
            // todo: a[2]="banana";
            a.self.SetItem(new PyInt(2), new PyString("banana"));
            Assert.That("array(['apples', 'foobar', 'banana'], dtype='<U6')", a.repr);

            //>>> a = Cupy.array(['apples', 'foobar', 'cowboy'], dtype = object)
            //>>> a
            //array([apples, foobar, cowboy], dtype = object)
            //>>> a[2] = 'bananas'
            //>>> a
            //array([apples, foobar, bananas], dtype = object)
            a = cp.array(new[] { "apples", "foobar", "cowboy" }, cp.object_);
            Assert.That("array(['apples', 'foobar', 'cowboy'], dtype=object)", a.repr);
            // todo: a[2]="banana";
            a.self.SetItem(new PyInt(2), new PyString("banana"));
            Assert.That("array(['apples', 'foobar', 'banana'], dtype=object)", a.repr);
        }
#endif

        [Test]
        public void ComplexNumbers()
        {
            //>>> a = cp.array([1+2j, 3+4j, 5+6j])
            //>>> a.imag
            //array([2.,  4.,  6.])
            var a = cp.array(new Complex(1, 2), new Complex(3, 4), new Complex(5, 6));
            Assert.That("array([1., 3., 5.], dtype=float64)", Is.EqualTo(a.real.repr));
            Assert.That("array([2., 4., 6.], dtype=float64)", Is.EqualTo(a.imag.repr));
            //>>> cp.imag(a)
            //array([2., 4., 6.])
            //>>> cp.real(a)
            //array([1., 3., 5.])
            Assert.That("array([1., 3., 5.], dtype=float64)", Is.EqualTo(a.real().repr));
            Assert.That("array([2., 4., 6.], dtype=float64)", Is.EqualTo(a.imag().repr));
            //>>> a.imag = cp.array([8, 10, 12])
            //>>> a
            //array([1. +8.j,  3.+10.j,  5.+12.j])
            a.imag = cp.array(8, 10, 12);
            Assert.That("array([1. +8.j, 3.+10.j, 5.+12.j], dtype=complex128)", Is.EqualTo(a.repr));
            //>>> cp.imag(1 + 1j)
            //1.0
            Assert.That(1.0, Is.EqualTo(cp.imag(new Complex(1, 1)).asscalar<double>()));

            // getting the complex numbers out again
            var c = a.GetData<Complex[]>();
            Assert.That(new[] { new Complex(1, 8), new Complex(3, 10), new Complex(5, 12) }.SequenceEqual(c));

            // accessing scalar values
            var b = new NDarray<Complex>(a);
            Assert.That(new Complex(1, 8), Is.EqualTo(b[0].asscalar<Complex>()));
        }

        [Test]
        public void IssueByXlient()
        {
            var points = new[] { new Point(0, 0), new Point(17, 4), new Point(2, 22), new Point(10, 7) };
            int[,] Pts =
            {
                { points[0].X, points[0].Y },
                { points[1].X, points[1].Y },
                { points[2].X, points[2].Y },
                { points[3].X, points[3].Y }
            };

            // exception here / deadlock
            var dtype = Pts.GetDtype();

            NDarray pts = cp.array(Pts);
            var rectangle = cp.zeros(new Shape(4, 2), dtype);

            var sum = pts.sum(1);
            var differnce = pts.diff(axis: 1);

            rectangle[0] = pts[sum.argmin()];
            rectangle[2] = pts[sum.argmax()];
            rectangle[1] = pts[differnce.argmin()];
            rectangle[3] = pts[differnce.argmax()];
        }

        [Test]
        public void IssueByVolgaone()
        {
            var n = cp.array(new float[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            var row0 = n[0]; //extract 1st row
            Assert.That("array([1., 2., 3.], dtype=float32)", Is.EqualTo(row0.repr));
            var row0Data = row0.GetData<float[]>(); //this is correct - {1,2,3} 
            Assert.That("1,2,3", Is.EqualTo(string.Join(",", row0Data)));
            var col1 = n[":,1"]; //extract 1st column - NDarray is [2 5 8] as expected
            Assert.That("array([2., 5., 8.], dtype=float32)", Is.EqualTo(col1.repr));
            var col1Data = col1.GetData<float[]>(); //this is wrong - {2,3,4}
            Assert.That("2,5,8", Is.EqualTo(string.Join(",", col1Data)));
        }

        [Test]
        public void IssueByNbustins()
        {
            var iarr = new int[3, 25, 25, 3];
            NDarray nd = cp.array(iarr);
            Assert.That(new Shape(3, 25, 25, 3), Is.EqualTo(nd.shape));
        }

        [Test]
        public void IssueByBanyc1()
        {
            //a = cp.array([[1, 2, 3], [4, 5, 6]])
            //b = cp.array([1, 2])
            //cp.savez('/tmp/123.npz', a = a, b = b)
            //data = cp.load('/tmp/123.npz')
            //data['a']
            //array([[1, 2, 3],
            //[4, 5, 6]])
            //data['b']
            //array([1, 2])
            //data.close()
            var a = cp.array(new[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            var b = cp.array(1, 2);
            var tempFile = Path.GetTempFileName() + ".npz";
            Console.WriteLine(tempFile);
            cp.savez(tempFile, kwds: new Dictionary<string, NDarray> { ["a"] = a, ["b"] = b });
            var data = cp.load(tempFile, allow_pickle: true);
            var a1 = new NDarray(data.self["a"]);
            Console.WriteLine(a1.repr);
            var b1 = new NDarray(data.self["b"]);
            Console.WriteLine(b1.repr);
            Assert.That("array([[1, 2, 3],\n       [4, 5, 6]])", Is.EqualTo(a1.repr));
            Assert.That(@"array([1, 2])", Is.EqualTo(b1.repr));
        }

        [Test]
        public void IssueByBanyc2()
        {
            var a = cp.array(new[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            var b = cp.array(1, 2);
            var tempFile = Path.GetTempFileName() + ".npz";
            Console.WriteLine(tempFile);
            cp.savez(tempFile, new[] { a, b });
            var data = cp.load(tempFile, allow_pickle: true);
            var a1 = new NDarray(data.self["arr_0"]);
            Console.WriteLine(a1.repr);
            var b1 = new NDarray(data.self["arr_1"]);
            Console.WriteLine(b1.repr);
            Assert.That("array([[1, 2, 3],\n       [4, 5, 6]])", Is.EqualTo(a1.repr));
            Assert.That(@"array([1, 2])", Is.EqualTo(b1.repr));
        }

#if NOT_IMPLEMENTED
        [Test]
        public void IssueByBanyc3()
        {
            //>>> a = cp.ones((1, 2, 3, 4))
            //>>> a
            //array([[[[1., 1., 1., 1.],
            //         [1., 1., 1., 1.],
            //         [1., 1., 1., 1.]],

            //        [[1., 1., 1., 1.],
            //         [1., 1., 1., 1.],
            //         [1., 1., 1., 1.]]]])
            //>>> c = cp.transpose(a, (0, 2, 3, 1))
            //>>> c
            //array([[[[1., 1.],
            //         [1., 1.],
            //         [1., 1.],
            //         [1., 1.]],

            //        [[1., 1.],
            //         [1., 1.],
            //         [1., 1.],
            //         [1., 1.]],

            //        [[1., 1.],
            //         [1., 1.],
            //         [1., 1.],
            //         [1., 1.]]]])
            //>>> b = a.transpose((0, 2, 3, 1))
            //>>> b
            //array([[[[1., 1.],
            //         [1., 1.],
            //         [1., 1.],
            //         [1., 1.]],

            //        [[1., 1.],
            //         [1., 1.],
            //         [1., 1.],
            //         [1., 1.]],

            //        [[1., 1.],
            //         [1., 1.],
            //         [1., 1.],
            //         [1., 1.]]]])
            //>>>
            var a = cp.ones(1, 2, 3, 4);
            var c = cp.transpose(a, new[] { 0, 2, 3, 1 });

            var s =
                "array([[[[1., 1.],\n         [1., 1.],\n         [1., 1.],\n         [1., 1.]],\n\n        [[1., 1.],\n         [1., 1.],\n         [1., 1.],\n         [1., 1.]],\n\n        [[1., 1.],\n         [1., 1.],\n         [1., 1.],\n         [1., 1.]]]])";
            Assert.That(s, c.repr);
            var b = a.transpose(0, 2, 3, 1);
            Assert.That(s, b.repr);
        }
#endif

        [Test]
        public void IssueBybeanels01()
        {
            //sample = [cp.array([[1., 2., 3.]]),cp.array([[4., 5., 6.]]),cp.array([[7., 8., 9.]])]
            //for test in sample:
            //    n = cp.argmax(test[0])
            //    print(n)
            //# expected: 
            //# 2
            //# 2
            //# 2
            var result = new List<int>();
            var nc = cp.array(new[] { cp.array(1, 2, 3), cp.array(4, 5, 6), cp.array(7, 8, 9) });
            for (var i = 0; i < nc.len; i++)
            {
                var n = nc[i].argmax().asscalar<int>();
                result.Add(n);
            }

            Assert.That("2, 2, 2", Is.EqualTo(string.Join(", ", result)));
        }

        [Test]
        public void IssueBybeanels01a()
        {
            //sample = [cp.array([[1., 2., 3.]]),cp.array([[4., 5., 6.]]),cp.array([[7., 8., 9.]])]
            //for test in sample:
            //    n = cp.argmax(test[0])
            //    print(n)
            //# expected: 
            //# 2
            //# 2
            //# 2
            var result = new List<int>();
            var nc = cp.array(new[] { cp.array(1, 2, 3), cp.array(4, 5, 6), cp.array(7, 8, 9) });
            for (var i = 0; i < nc.len; i++)
            {
                var n = nc[i].argmax().asscalar<int>();
                result.Add(n);
            }

            Assert.That("2, 2, 2", Is.EqualTo(string.Join(", ", result)));
        }

        [Test]
        public void IssueByMatteo_0()
        {
            //>>> x = cp.array([0, 1, 2, 3])
            //>>> y = cp.array([-1, 0.2, 0.9, 2.1])
            //>>> A = cp.vstack([x, cp.ones(len(x))]).T
            //>>> A
            //array([[0., 1.],
            //       [1., 1.],
            //       [2., 1.],
            //       [3., 1.]])
            //>>> cp.linalg.lstsq(A, y, rcond = None)
            //(array([1.  , -0.95]), array([0.05]), 2, array([4.10003045, 1.09075677]))
            var x = cp.array(0, 1, 2, 3);
            var y = cp.array(-1, 0.2, 0.9, 2.1);
            var A = cp.vstack(x, cp.ones(x.len)).T;
            Assert.That("array([[0., 1.],\n       [1., 1.],\n       [2., 1.],\n       [3., 1.]], dtype=float64)", Is.EqualTo(A.repr));
            var tuple = cp.linalg.lstsq(A, y);
            Assert.That("array([ 1.  , -0.95], dtype=float64)", Is.EqualTo(tuple.Item1.repr));
            Assert.That("array([0.05], dtype=float64)", Is.EqualTo(tuple.Item2.repr));
            Assert.That(2, Is.EqualTo(tuple.Item3));
            Assert.That("array([4.10003045, 1.09075677], dtype=float64)", Is.EqualTo(tuple.Item4.repr));
        }

#if NOT_SUPPORTED
        [Test]
        public void IssueByDecemberDream()
        {
            //a = cp.array([1, 2, -2, -4, 0])
            //cp.roots(a)
            //# returns array([ 1.41421356, -2., -1.41421356, 0.])            
            var a = cp.array(1, 2, -2, -4, 0);
            var b = a.roots();
            Assert.That("array([ 1.41421356, -2.        , -1.41421356,  0.        ])", b.repr);
        }
#endif

        [Test]
        public void IssueByDecemberDream2()
        {
            NDarray test = cp.array(new[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 9, 10, 11 } });
            NDarray rows = cp.array(new[,] { { 0, 0 }, { 3, 3 } });
            NDarray cols = cp.array(new[,] { { 0, 2 }, { 0, 2 } });

            var b = test[rows, cols];
            // should return
            // [[0, 2],
            //  [9, 11]]
            Assert.That("array([[ 0,  2],\n       [ 9, 11]])", Is.EqualTo(b.repr));
        }

#if NOT_IMPLEMENTED
        [Test]
        public void IssueByAmpangboy()
        {
            var arr = cp.array(1.0);
            var result = cp.insert(arr, 0, 1.0);
            Assert.That("array([1., 1.])", result.repr);
        }
#endif

        [Test]
        public void IssueByBigpo()
        {
            var a = cp.random.randn(3, 3);
            var tmp = cp.linalg.qr(a);
        }

        [Test]
        public void IssueByAllenP()
        {
            //>>> dx = 4.0
            //>>> dy = 5.0
            //>>> zX =[[1, 2, 3],[4,5,6],[8,9,0]]
            //>>> cp.gradient(zX, dx, dy)
            //[array([[0.75, 0.75, 0.75],
            //       [0.875, 0.875, -0.375],
            //       [1.   , 1.   , -1.5]]), array([[0.2, 0.2, 0.2],
            //       [ 0.2,  0.2,  0.2],
            //       [ 0.2, -0.8, -1.8]])]
            var zX = new NDarray(new[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 8, 9, 0 } });
            var result = cp.gradient(zX, new List<double> { 4.0, 5.0 });
            var expected = 
@"array([[[ 0.75 ,  0.75 ,  0.75 ],
        [ 0.875,  0.875, -0.375],
        [ 1.   ,  1.   , -1.5  ]],

       [[ 0.2  ,  0.2  ,  0.2  ],
        [ 0.2  ,  0.2  ,  0.2  ],
        [ 0.2  , -0.8  , -1.8  ]]], dtype=float64)".Replace("\r", "");
            Assert.That(expected, Is.EqualTo(result.repr));
        }

        [Test]
        public void PrimitiveConversion()
        {
            var np = cp.dynamic_self;
            Assert.That(3, Is.EqualTo(new PyInt(3).As<int>()));
            Assert.That(1_000_000_000_000_000, Is.EqualTo(new PyInt(1_000_000_000_000_000).As<long>()));
            Console.WriteLine(((dynamic)new PyInt(1_000_000_000_000_000)).__class__); // => <class 'int'>
            Console.WriteLine(cp.Int64(1_000_000_000_000_000).__class__); // => <class 'Cupy.int64'>
            Assert.That(3, Is.EqualTo((cp.Int32(3) as PyObject).As<int>()));
            Assert.That(1_000_000_000_000_000, Is.EqualTo((cp.Int64(1_000_000_000_000_000) as PyObject).As<long>()));
        }

        [Test]
        public void IssueByMegawattFs()
        {
            var arr = cp.array(1, 2, 3, 4, 5);
            var slice0 = new Slice(2, 4);
            var arr4 = arr[slice0];
            Assert.That("array([3, 4])", Is.EqualTo(arr4.repr));
            var slice1 = new Slice(2, -1);
            var arr5 = arr[slice1];
            Assert.That("array([3, 4])", Is.EqualTo(arr5.repr));
            var arr1 = arr["2:4"];
            Assert.That("array([3, 4])", Is.EqualTo(arr1.repr));
            var arr2 = arr[":4"];
            Assert.That("array([1, 2, 3, 4])", Is.EqualTo(arr2.repr));
            var arr3 = arr[":-1"];
            Assert.That("array([1, 2, 3, 4])", Is.EqualTo(arr3.repr));
        }

        [Test]
        public async Task IssueByMrCOrrupted()
        {
            var arrays = new Dictionary<string, NDarray>();
            arrays["a"] = cp.arange(6).reshape(2, 3);
            arrays["b"] = cp.arange(3);

            var filename = Path.Combine(Path.GetTempPath(), "test.npz");
            cp.savez_compressed(filename, null, arrays);
            var archive = cp.load(filename);
            Console.WriteLine(archive.repr);
            var a = new NDarray(archive.PyObject["a"]);
            var b = new NDarray(archive.PyObject["b"]);
            Console.WriteLine(a.repr);
            Console.WriteLine(b.repr);
            Assert.That("array([[0, 1, 2],\n       [3, 4, 5]])", Is.EqualTo(a.repr));
            Assert.That(@"array([0, 1, 2])", Is.EqualTo(b.repr));
        }

        [Test]
        public async Task AsscalarRemovedInCupyV1_23()
        {
            Assert.That(143, Is.EqualTo(new NDarray<int>(new[] { 143 }).asscalar<int>()));
            Assert.That(143d, Is.EqualTo(new NDarray<double>(new[] { 143d }).asscalar<double>()));
            Assert.That(143d, Is.EqualTo(new NDarray<double>(new[] { 143d }).item()));
        }

#if NOT_SUPPORTED
        [Test]
        public async Task IssueByMaLichtenegger()
        {
            // byte array als uint32 array
            var bytes = new byte[] { 1, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0, 0 };
            var uints = cp.zeros(new Shape(3), cp.uint32);
            Console.WriteLine(uints.repr);
            var ctypes = uints.PyObject.ctypes;
            long ptr = ctypes.data;
            Marshal.Copy(bytes, 0, new IntPtr(ptr), bytes.Length);
            Console.WriteLine(uints.repr);
            Assert.That("array([1, 2, 3], dtype=uint32)", uints.repr);
            // byte array als float64 array
            bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 0, 0, 0, 0, 0, 0, 0, 0 };
            var doubles = cp.zeros(new Shape(2), cp.float64);
            Console.WriteLine(doubles.repr);
            ctypes = doubles.PyObject.ctypes;
            ptr = ctypes.data;
            Marshal.Copy(bytes, 0, new IntPtr(ptr), bytes.Length);
            Console.WriteLine(doubles.repr);
            Assert.That(doubles[0].asscalar<double>() != 0);
            Assert.That(doubles[1].asscalar<double>() == 0);
        }
#endif

        [Test]
        public async Task IssueByMartinDevans()
        {
            //>>> x = cp.arange(9)
            //>>> cp.split(x, 3)
            //[array([0, 1, 2]), array([3, 4, 5]), array([6, 7, 8])]
            var x = cp.arange(9);
            var b = x.split(3).repr();
            var a = "(array([0, 1, 2]), array([3, 4, 5]), array([6, 7, 8]))";
            Assert.That(a, Is.EqualTo(b));
            Assert.That(a, Is.EqualTo(x.split(3, -1).repr()));
            //>>> x = cp.arange(8.0)
            //>>> cp.split(x, [3, 5, 6, 10])
            //[array([0., 1., 2.]),
            //array([3., 4.]),
            //array([5.]),
            //array([6., 7.]),
            //array([], dtype = float64)]
            x = cp.arange(8);
            b = x.split(new[] { 3, 5, 6, 10 }).repr();
            a = "(array([0, 1, 2]), array([3, 4]), array([5]), array([6, 7]), array([]))";
            Assert.That(a, Is.EqualTo(b));
            Assert.That(a, Is.EqualTo(x.split(new[] { 3, 5, 6, 10 }).repr()));
        }

        // TODO:  https://docs.scipy.org/doc/Cupy/user/basics.indexing.html?highlight=slice#structural-indexing-tools
        // TODO:  https://docs.scipy.org/doc/Cupy/user/basics.indexing.html?highlight=slice#assigning-values-to-indexed-arrays
        // TODO:  https://docs.scipy.org/doc/Cupy/user/basics.indexing.html?highlight=slice#dealing-with-variable-numbers-of-indices-within-programs

        [Test]
        public async Task DisposeTest()
        {
            var x = cp.array([1, 2, 3]);
            x.Dispose();
        }

        [Test]
        public void array_FromByteArrayTest()
        {
            var bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var a = cp.array(bytes);
            Assert.That("array([1, 2, 3, 4, 5, 6, 7, 8], dtype=int8)", Is.EqualTo(a.repr));
        }

        [Test]
        public void frombufferTest()
        {
            var bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var a = cp.frombuffer(bytes, cp.@byte);
            Assert.That("array([1, 2, 3, 4, 5, 6, 7, 8], dtype=int8)", Is.EqualTo(a.repr));
        }

        [Test]
        public void Convert_int16_array_Test()
        {
            var a = cp.array(new[] { 1, 2, 3 }, dtype: cp.int16);
            var b = a.GetData<short[]>();
            Assert.That(b, Is.EqualTo(new short[] { 1, 2, 3 }));
        }

        [Test]
        public void Covert_int32_array_Test()
        {
            var a = cp.array(new[] { 1, 2, 3 }, dtype: cp.int32);
            var b = a.GetData<int[]>();
            Assert.That(b, Is.EqualTo(new[] { 1, 2, 3 }));
        }

        [Test]
        public void Convert_int64_array_Test()
        {
            var a = cp.array(new[] { 1, 2, 3 }, dtype: cp.int64);
            var b = a.GetData<long[]>();
            Assert.That(b, Is.EqualTo(new[] { 1L, 2L, 3L }));
        }

        [Test]
        public void Convert_float_array_Test()
        {
            var a = cp.array(new[] { 1.0, 2.0, 3.0 }, dtype: cp.float32);
            var b = a.GetData<float[]>();
            Assert.That(b, Is.EqualTo(new[] { 1.0f, 2.0f, 3.0f }));
        }

        [Test]
        public void Convert_double_array_Test()
        {
            var a = cp.array(new[] { 1.0, 2.0, 3.0 }, dtype: cp.float64);
            var b = a.GetData<double[]>();
            Assert.That(b, Is.EqualTo(new[] { 1.0, 2.0, 3.0 }));
        }
    }
}