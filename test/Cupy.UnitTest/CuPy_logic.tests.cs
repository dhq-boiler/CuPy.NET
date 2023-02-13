// Copyright (c) 2019 by the SciSharp Team
// Code generated by CodeMinion: https://github.com/SciSharp/CodeMinion

using Cupy.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cupy.UnitTest
{
    [TestClass]
    public class Cupy_logicTest : BaseTestCase
    {
        [TestMethod]
        public void allTest()
        {
            // >>> cp.all([[True,False],[True,True]])
            // False

            var givenb = cp.all(new[,] { { true, false }, { true, true } });
            Assert.AreEqual(false, givenb);

            // >>> cp.all([[True,False],[True,True]], axis=0)
            // array([ True, False])

            var given = cp.all(new[,] { { true, false }, { true, true } }, new[] { 0 });
            var expected =
                "array([ True, False])";
            Assert.AreEqual(expected, given.repr);

            // >>> cp.all([-1, 4, 5])
            // True
            // 

            givenb = cp.all(new[] { -1, 4, 5 });
            Assert.AreEqual(true, givenb);

            // >>> cp.all([1.0, cp.nan])
            // True
            // 

            Assert.IsTrue(cp.all(new[] { 1.0, cp.nan }));

            // >>> o=cp.array([False])
            // >>> z=cp.all([-1, 4, 5], out=o)
            // >>> id(z), id(o), z                             
            // (28293632, 28293632, array([ True]))
            // 

            var o = cp.array(false).reshape(new Shape());
            var z = cp.array(-1, 4, 5).all(null, o);
            given = z;
            expected = "array(True)";
            Assert.AreEqual(expected, given.repr);
            Assert.AreEqual(o.Handle, z.Handle);
        }

        [TestMethod]
        public void anyTest()
        {
            // >>> cp.any([[True, False], [True, True]])
            // True
            // 

#if TODO
            var given = cp.any({{True, False}, {True, True}});
            var expected =
                "True";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> cp.any([[True, False], [False, False]], axis=0)
            // array([ True, False])
            // 

#if TODO
             given = cp.any({{True, False}, {False, False}}, axis = 0);
             expected =
                "array([ True, False])";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> cp.any([-1, 0, 5])
            // True
            // 

#if TODO
             given = cp.any({-1, 0, 5});
             expected =
                "True";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> cp.any(cp.nan)
            // True
            // 

#if TODO
             given = cp.any(cp.nan);
             expected =
                "True";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> o=cp.array([False])
            // >>> z=cp.any([-1, 4, 5], out=o)
            // >>> z, o
            // (array([ True]), array([ True]))
            // >>> # Check now that z is a reference to o
            // >>> z is o
            // True
            // >>> id(z), id(o) # identity of z and o              
            // (191614240, 191614240)
            // 

#if TODO
             given = o = cp.array({False});
             given = z = cp.any({-1, 4, 5}, out = o);
             given = z, o;
             expected =
                "(array([ True]), array([ True]))";
            Assert.AreEqual(expected, given.repr);
             given = # Check now that z is a reference to o;
             given = z is o;
             expected =
                "True";
            Assert.AreEqual(expected, given.repr);
             given = id(z), id(o) # identity of z and o              ;
             expected =
                "(191614240, 191614240)";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void isfiniteTest()
        {
            // >>> cp.isfinite(1)
            // True
            // >>> cp.isfinite(0)
            // True
            // >>> cp.isfinite(cp.nan)
            // False
            // >>> cp.isfinite(cp.inf)
            // False
            // >>> cp.isfinite(cp.NINF)
            // False
            // >>> cp.isfinite([cp.log(-1.),1.,cp.log(0)])
            // array([False,  True, False])
            // 

#if TODO
            var given = cp.isfinite(1);
            var expected =
                "True";
            Assert.AreEqual(expected, given.repr);
             given = cp.isfinite(0);
             expected =
                "True";
            Assert.AreEqual(expected, given.repr);
             given = cp.isfinite(cp.nan);
             expected =
                "False";
            Assert.AreEqual(expected, given.repr);
             given = cp.isfinite(cp.inf);
             expected =
                "False";
            Assert.AreEqual(expected, given.repr);
             given = cp.isfinite(cp.NINF);
             expected =
                "False";
            Assert.AreEqual(expected, given.repr);
             given = cp.isfinite({cp.log(-1.),1.,cp.log(0)});
             expected =
                "array([False,  True, False])";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> x = cp.array([-cp.inf, 0., cp.inf])
            // >>> y = cp.array([2, 2, 2])
            // >>> cp.isfinite(x, y)
            // array([0, 1, 0])
            // >>> y
            // array([0, 1, 0])
            // 

#if TODO
             given = x = cp.array({-cp.inf, 0., cp.inf});
             given = y = cp.array({2, 2, 2});
             given = cp.isfinite(x, y);
             expected =
                "array([0, 1, 0])";
            Assert.AreEqual(expected, given.repr);
             given = y;
             expected =
                "array([0, 1, 0])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void isinfTest()
        {
            // >>> cp.isinf(cp.inf)
            // True
            // >>> cp.isinf(cp.nan)
            // False
            // >>> cp.isinf(cp.NINF)
            // True
            // >>> cp.isinf([cp.inf, -cp.inf, 1.0, cp.nan])
            // array([ True,  True, False, False])
            // 

#if TODO
            var given = cp.isinf(cp.inf);
            var expected =
                "True";
            Assert.AreEqual(expected, given.repr);
             given = cp.isinf(cp.nan);
             expected =
                "False";
            Assert.AreEqual(expected, given.repr);
             given = cp.isinf(cp.NINF);
             expected =
                "True";
            Assert.AreEqual(expected, given.repr);
             given = cp.isinf({cp.inf, -cp.inf, 1.0, cp.nan});
             expected =
                "array([ True,  True, False, False])";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> x = cp.array([-cp.inf, 0., cp.inf])
            // >>> y = cp.array([2, 2, 2])
            // >>> cp.isinf(x, y)
            // array([1, 0, 1])
            // >>> y
            // array([1, 0, 1])
            // 

#if TODO
             given = x = cp.array({-cp.inf, 0., cp.inf});
             given = y = cp.array({2, 2, 2});
             given = cp.isinf(x, y);
             expected =
                "array([1, 0, 1])";
            Assert.AreEqual(expected, given.repr);
             given = y;
             expected =
                "array([1, 0, 1])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void isnanTest()
        {
            // >>> cp.isnan(cp.nan)
            // True
            // >>> cp.isnan(cp.inf)
            // False
            // >>> cp.isnan([cp.log(-1.),1.,cp.log(0)])
            // array([ True, False, False])
            // 

#if TODO
            var given = cp.isnan(cp.nan);
            var expected =
                "True";
            Assert.AreEqual(expected, given.repr);
             given = cp.isnan(cp.inf);
             expected =
                "False";
            Assert.AreEqual(expected, given.repr);
             given = cp.isnan({cp.log(-1.),1.,cp.log(0)});
             expected =
                "array([ True, False, False])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void isnatTest()
        {
            // >>> cp.isnat(cp.datetime64("NaT"))
            // True
            // >>> cp.isnat(cp.datetime64("2016-01-01"))
            // False
            // >>> cp.isnat(cp.array(["NaT", "2016-01-01"], dtype="datetime64[ns]"))
            // array([ True, False])
            // 

#if TODO
            var given = cp.isnat(cp.datetime64("NaT"));
            var expected =
                "True";
            Assert.AreEqual(expected, given.repr);
             given = cp.isnat(cp.datetime64("2016-01-01"));
             expected =
                "False";
            Assert.AreEqual(expected, given.repr);
             given = cp.isnat(cp.array({"NaT", "2016-01-01"}, dtype = "datetime64{ns}"));
             expected =
                "array([ True, False])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void isneginfTest()
        {
            // >>> cp.isneginf(cp.NINF)
            // array(True, dtype=bool)
            // >>> cp.isneginf(cp.inf)
            // array(False, dtype=bool)
            // >>> cp.isneginf(cp.PINF)
            // array(False, dtype=bool)
            // >>> cp.isneginf([-cp.inf, 0., cp.inf])
            // array([ True, False, False])
            // 

#if TODO
            var given = cp.isneginf(cp.NINF);
            var expected =
                "array(True, dtype=bool)";
            Assert.AreEqual(expected, given.repr);
             given = cp.isneginf(cp.inf);
             expected =
                "array(False, dtype=bool)";
            Assert.AreEqual(expected, given.repr);
             given = cp.isneginf(cp.PINF);
             expected =
                "array(False, dtype=bool)";
            Assert.AreEqual(expected, given.repr);
             given = cp.isneginf({-cp.inf, 0., cp.inf});
             expected =
                "array([ True, False, False])";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> x = cp.array([-cp.inf, 0., cp.inf])
            // >>> y = cp.array([2, 2, 2])
            // >>> cp.isneginf(x, y)
            // array([1, 0, 0])
            // >>> y
            // array([1, 0, 0])
            // 

#if TODO
             given = x = cp.array({-cp.inf, 0., cp.inf});
             given = y = cp.array({2, 2, 2});
             given = cp.isneginf(x, y);
             expected =
                "array([1, 0, 0])";
            Assert.AreEqual(expected, given.repr);
             given = y;
             expected =
                "array([1, 0, 0])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void isposinfTest()
        {
            // >>> cp.isposinf(cp.PINF)
            // array(True, dtype=bool)
            // >>> cp.isposinf(cp.inf)
            // array(True, dtype=bool)
            // >>> cp.isposinf(cp.NINF)
            // array(False, dtype=bool)
            // >>> cp.isposinf([-cp.inf, 0., cp.inf])
            // array([False, False,  True])
            // 

#if TODO
            var given = cp.isposinf(cp.PINF);
            var expected =
                "array(True, dtype=bool)";
            Assert.AreEqual(expected, given.repr);
             given = cp.isposinf(cp.inf);
             expected =
                "array(True, dtype=bool)";
            Assert.AreEqual(expected, given.repr);
             given = cp.isposinf(cp.NINF);
             expected =
                "array(False, dtype=bool)";
            Assert.AreEqual(expected, given.repr);
             given = cp.isposinf({-cp.inf, 0., cp.inf});
             expected =
                "array([False, False,  True])";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> x = cp.array([-cp.inf, 0., cp.inf])
            // >>> y = cp.array([2, 2, 2])
            // >>> cp.isposinf(x, y)
            // array([0, 0, 1])
            // >>> y
            // array([0, 0, 1])
            // 

#if TODO
             given = x = cp.array({-cp.inf, 0., cp.inf});
             given = y = cp.array({2, 2, 2});
             given = cp.isposinf(x, y);
             expected =
                "array([0, 0, 1])";
            Assert.AreEqual(expected, given.repr);
             given = y;
             expected =
                "array([0, 0, 1])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void iscomplexTest()
        {
            // >>> cp.iscomplex([1+1j, 1+0j, 4.5, 3, 2, 2j])
            // array([ True, False, False, False, False,  True])
            // 

#if TODO
            var given = cp.iscomplex({1+1j, 1+0j, 4.5, 3, 2, 2j});
            var expected =
                "array([ True, False, False, False, False,  True])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void iscomplexobjTest()
        {
            // >>> cp.iscomplexobj(1)
            // False
            // >>> cp.iscomplexobj(1+0j)
            // True
            // >>> cp.iscomplexobj([3, 1+0j, True])
            // True
            // 

#if TODO
            var given = cp.iscomplexobj(1);
            var expected =
                "False";
            Assert.AreEqual(expected, given.repr);
             given = cp.iscomplexobj(1+0j);
             expected =
                "True";
            Assert.AreEqual(expected, given.repr);
             given = cp.iscomplexobj({3, 1+0j, True});
             expected =
                "True";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void isfortranTest()
        {
            // cp.array allows to specify whether the array is written in C-contiguous
            // order (last index varies the fastest), or FORTRAN-contiguous order in
            // memory (first index varies the fastest).

            // >>> a = cp.array([[1, 2, 3], [4, 5, 6]], order='C')
            // >>> a
            // array([[1, 2, 3],
            //        [4, 5, 6]])
            // >>> cp.isfortran(a)
            // False
            // 

#if TODO
            var given = a = cp.array({{1, 2, 3}, {4, 5, 6}}, order = 'C');
             given = a;
            var expected =
                "array([[1, 2, 3],\n" +
                "       [4, 5, 6]])";
            Assert.AreEqual(expected, given.repr);
             given = cp.isfortran(a);
             expected =
                "False";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> b = cp.array([[1, 2, 3], [4, 5, 6]], order='FORTRAN')
            // >>> b
            // array([[1, 2, 3],
            //        [4, 5, 6]])
            // >>> cp.isfortran(b)
            // True
            // 

#if TODO
             given = b = cp.array({{1, 2, 3}, {4, 5, 6}}, order = 'FORTRAN');
             given = b;
             expected =
                "array([[1, 2, 3],\n" +
                "       [4, 5, 6]])";
            Assert.AreEqual(expected, given.repr);
             given = cp.isfortran(b);
             expected =
                "True";
            Assert.AreEqual(expected, given.repr);
#endif
            // The transpose of a C-ordered array is a FORTRAN-ordered array.

            // >>> a = cp.array([[1, 2, 3], [4, 5, 6]], order='C')
            // >>> a
            // array([[1, 2, 3],
            //        [4, 5, 6]])
            // >>> cp.isfortran(a)
            // False
            // >>> b = a.T
            // >>> b
            // array([[1, 4],
            //        [2, 5],
            //        [3, 6]])
            // >>> cp.isfortran(b)
            // True
            // 

#if TODO
             given = a = cp.array({{1, 2, 3}, {4, 5, 6}}, order = 'C');
             given = a;
             expected =
                "array([[1, 2, 3],\n" +
                "       [4, 5, 6]])";
            Assert.AreEqual(expected, given.repr);
             given = cp.isfortran(a);
             expected =
                "False";
            Assert.AreEqual(expected, given.repr);
             given = b = a.T;
             given = b;
             expected =
                "array([[1, 4],\n" +
                "       [2, 5],\n" +
                "       [3, 6]])";
            Assert.AreEqual(expected, given.repr);
             given = cp.isfortran(b);
             expected =
                "True";
            Assert.AreEqual(expected, given.repr);
#endif
            // C-ordered arrays evaluate as False even if they are also FORTRAN-ordered.

            // >>> cp.isfortran(cp.array([1, 2], order='FORTRAN'))
            // False
            // 

#if TODO
             given = cp.isfortran(cp.array({1, 2}, order = 'FORTRAN'));
             expected =
                "False";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void isrealTest()
        {
            // >>> cp.isreal([1+1j, 1+0j, 4.5, 3, 2, 2j])
            // array([False,  True,  True,  True,  True, False])
            // 

#if TODO
            var given = cp.isreal({1+1j, 1+0j, 4.5, 3, 2, 2j});
            var expected =
                "array([False,  True,  True,  True,  True, False])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void isrealobjTest()
        {
            // >>> cp.isrealobj(1)
            // True
            // >>> cp.isrealobj(1+0j)
            // False
            // >>> cp.isrealobj([3, 1+0j, True])
            // False
            // 

#if TODO
            var given = cp.isrealobj(1);
            var expected =
                "True";
            Assert.AreEqual(expected, given.repr);
             given = cp.isrealobj(1+0j);
             expected =
                "False";
            Assert.AreEqual(expected, given.repr);
             given = cp.isrealobj({3, 1+0j, True});
             expected =
                "False";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void isscalarTest()
        {
            // >>> cp.isscalar(3.1)
            // True
            // >>> cp.isscalar(cp.array(3.1))
            // False
            // >>> cp.isscalar([3.1])
            // False
            // >>> cp.isscalar(False)
            // True
            // >>> cp.isscalar('Cupy')
            // True
            // 

#if TODO
            var given = cp.isscalar(3.1);
            var expected =
                "True";
            Assert.AreEqual(expected, given.repr);
             given = cp.isscalar(cp.array(3.1));
             expected =
                "False";
            Assert.AreEqual(expected, given.repr);
             given = cp.isscalar({3.1});
             expected =
                "False";
            Assert.AreEqual(expected, given.repr);
             given = cp.isscalar(False);
             expected =
                "True";
            Assert.AreEqual(expected, given.repr);
             given = cp.isscalar('Cupy');
             expected =
                "True";
            Assert.AreEqual(expected, given.repr);
#endif
            // Cupy supports PEP 3141 numbers:

            // >>> from fractions import Fraction
            // >>> isscalar(Fraction(5, 17))
            // True
            // >>> from numbers import Number
            // >>> isscalar(Number())
            // True
            // 

#if TODO
             given = from fractions import Fraction;
             given = isscalar(Fraction(5, 17));
             expected =
                "True";
            Assert.AreEqual(expected, given.repr);
             given = from numbers import Number;
             given = isscalar(Number());
             expected =
                "True";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void logical_andTest()
        {
            // >>> cp.logical_and(True, False)
            // False
            // >>> cp.logical_and([True, False], [False, False])
            // array([False, False])
            // 

#if TODO
            var given = cp.logical_and(True, False);
            var expected =
                "False";
            Assert.AreEqual(expected, given.repr);
             given = cp.logical_and({True, False}, {False, False});
             expected =
                "array([False, False])";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> x = cp.arange(5)
            // >>> cp.logical_and(x>1, x<4)
            // array([False, False,  True,  True, False])
            // 

#if TODO
             given = x = cp.arange(5);
             given = cp.logical_and(x>1, x<4);
             expected =
                "array([False, False,  True,  True, False])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void logical_orTest()
        {
            // >>> cp.logical_or(True, False)
            // True
            // >>> cp.logical_or([True, False], [False, False])
            // array([ True, False])
            // 

#if TODO
            var given = cp.logical_or(True, False);
            var expected =
                "True";
            Assert.AreEqual(expected, given.repr);
             given = cp.logical_or({True, False}, {False, False});
             expected =
                "array([ True, False])";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> x = cp.arange(5)
            // >>> cp.logical_or(x < 1, x > 3)
            // array([ True, False, False, False,  True])
            // 

#if TODO
             given = x = cp.arange(5);
             given = cp.logical_or(x < 1, x > 3);
             expected =
                "array([ True, False, False, False,  True])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void logical_notTest()
        {
            // >>> cp.logical_not(3)
            // False
            // >>> cp.logical_not([True, False, 0, 1])
            // array([False,  True,  True, False])
            // 

#if TODO
            var given = cp.logical_not(3);
            var expected =
                "False";
            Assert.AreEqual(expected, given.repr);
             given = cp.logical_not({True, False, 0, 1});
             expected =
                "array([False,  True,  True, False])";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> x = cp.arange(5)
            // >>> cp.logical_not(x<3)
            // array([False, False, False,  True,  True])
            // 

#if TODO
             given = x = cp.arange(5);
             given = cp.logical_not(x<3);
             expected =
                "array([False, False, False,  True,  True])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void logical_xorTest()
        {
            // >>> cp.logical_xor(True, False)
            // True
            // >>> cp.logical_xor([True, True, False, False], [True, False, True, False])
            // array([False,  True,  True, False])
            // 

#if TODO
            var given = cp.logical_xor(True, False);
            var expected =
                "True";
            Assert.AreEqual(expected, given.repr);
             given = cp.logical_xor({True, True, False, False}, {True, False, True, False});
             expected =
                "array([False,  True,  True, False])";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> x = cp.arange(5)
            // >>> cp.logical_xor(x < 1, x > 3)
            // array([ True, False, False, False,  True])
            // 

#if TODO
             given = x = cp.arange(5);
             given = cp.logical_xor(x < 1, x > 3);
             expected =
                "array([ True, False, False, False,  True])";
            Assert.AreEqual(expected, given.repr);
#endif
            // Simple example showing support of broadcasting

            // >>> cp.logical_xor(0, cp.eye(2))
            // array([[ True, False],
            //        [False,  True]])
            // 

#if TODO
             given = cp.logical_xor(0, cp.eye(2));
             expected =
                "array([[ True, False],\n" +
                "       [False,  True]])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void allcloseTest()
        {
            // >>> cp.allclose([1e10,1e-7], [1.00001e10,1e-8])
            // False
            // >>> cp.allclose([1e10,1e-8], [1.00001e10,1e-9])
            // True
            // >>> cp.allclose([1e10,1e-8], [1.0001e10,1e-9])
            // False
            // >>> cp.allclose([1.0, cp.nan], [1.0, cp.nan])
            // False
            // >>> cp.allclose([1.0, cp.nan], [1.0, cp.nan], equal_nan=True)
            // True
            // 

#if TODO
            var given = cp.allclose({1e10,1e-7}, {1.00001e10,1e-8});
            var expected =
                "False";
            Assert.AreEqual(expected, given.repr);
             given = cp.allclose({1e10,1e-8}, {1.00001e10,1e-9});
             expected =
                "True";
            Assert.AreEqual(expected, given.repr);
             given = cp.allclose({1e10,1e-8}, {1.0001e10,1e-9});
             expected =
                "False";
            Assert.AreEqual(expected, given.repr);
             given = cp.allclose({1.0, cp.nan}, {1.0, cp.nan});
             expected =
                "False";
            Assert.AreEqual(expected, given.repr);
             given = cp.allclose({1.0, cp.nan}, {1.0, cp.nan}, equal_nan = True);
             expected =
                "True";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void iscloseTest()
        {
            // >>> cp.isclose([1e10,1e-7], [1.00001e10,1e-8])
            // array([True, False])
            // >>> cp.isclose([1e10,1e-8], [1.00001e10,1e-9])
            // array([True, True])
            // >>> cp.isclose([1e10,1e-8], [1.0001e10,1e-9])
            // array([False, True])
            // >>> cp.isclose([1.0, cp.nan], [1.0, cp.nan])
            // array([True, False])
            // >>> cp.isclose([1.0, cp.nan], [1.0, cp.nan], equal_nan=True)
            // array([True, True])
            // >>> cp.isclose([1e-8, 1e-7], [0.0, 0.0])
            // array([ True, False], dtype=bool)
            // >>> cp.isclose([1e-100, 1e-7], [0.0, 0.0], atol=0.0)
            // array([False, False], dtype=bool)
            // >>> cp.isclose([1e-10, 1e-10], [1e-20, 0.0])
            // array([ True,  True], dtype=bool)
            // >>> cp.isclose([1e-10, 1e-10], [1e-20, 0.999999e-10], atol=0.0)
            // array([False,  True], dtype=bool)
            // 

#if TODO
            var given = cp.isclose({1e10,1e-7}, {1.00001e10,1e-8});
            var expected =
                "array([True, False])";
            Assert.AreEqual(expected, given.repr);
             given = cp.isclose({1e10,1e-8}, {1.00001e10,1e-9});
             expected =
                "array([True, True])";
            Assert.AreEqual(expected, given.repr);
             given = cp.isclose({1e10,1e-8}, {1.0001e10,1e-9});
             expected =
                "array([False, True])";
            Assert.AreEqual(expected, given.repr);
             given = cp.isclose({1.0, cp.nan}, {1.0, cp.nan});
             expected =
                "array([True, False])";
            Assert.AreEqual(expected, given.repr);
             given = cp.isclose({1.0, cp.nan}, {1.0, cp.nan}, equal_nan = True);
             expected =
                "array([True, True])";
            Assert.AreEqual(expected, given.repr);
             given = cp.isclose({1e-8, 1e-7}, {0.0, 0.0});
             expected =
                "array([ True, False], dtype=bool)";
            Assert.AreEqual(expected, given.repr);
             given = cp.isclose({1e-100, 1e-7}, {0.0, 0.0}, atol = 0.0);
             expected =
                "array([False, False], dtype=bool)";
            Assert.AreEqual(expected, given.repr);
             given = cp.isclose({1e-10, 1e-10}, {1e-20, 0.0});
             expected =
                "array([ True,  True], dtype=bool)";
            Assert.AreEqual(expected, given.repr);
             given = cp.isclose({1e-10, 1e-10}, {1e-20, 0.999999e-10}, atol = 0.0);
             expected =
                "array([False,  True], dtype=bool)";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void array_equalTest()
        {
            // >>> cp.array_equal([1, 2], [1, 2])
            // True
            // >>> cp.array_equal(cp.array([1, 2]), cp.array([1, 2]))
            // True
            // >>> cp.array_equal([1, 2], [1, 2, 3])
            // False
            // >>> cp.array_equal([1, 2], [1, 4])
            // False
            // 

#if TODO
            var given = cp.array_equal({1, 2}, {1, 2});
            var expected =
                "True";
            Assert.AreEqual(expected, given.repr);
             given = cp.array_equal(cp.array({1, 2}), cp.array({1, 2}));
             expected =
                "True";
            Assert.AreEqual(expected, given.repr);
             given = cp.array_equal({1, 2}, {1, 2, 3});
             expected =
                "False";
            Assert.AreEqual(expected, given.repr);
             given = cp.array_equal({1, 2}, {1, 4});
             expected =
                "False";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void array_equivTest()
        {
            // >>> cp.array_equiv([1, 2], [1, 2])
            // True
            // >>> cp.array_equiv([1, 2], [1, 3])
            // False
            // 

#if TODO
            var given = cp.array_equiv({1, 2}, {1, 2});
            var expected =
                "True";
            Assert.AreEqual(expected, given.repr);
             given = cp.array_equiv({1, 2}, {1, 3});
             expected =
                "False";
            Assert.AreEqual(expected, given.repr);
#endif
            // Showing the shape equivalence:

            // >>> cp.array_equiv([1, 2], [[1, 2], [1, 2]])
            // True
            // >>> cp.array_equiv([1, 2], [[1, 2, 1, 2], [1, 2, 1, 2]])
            // False
            // 

#if TODO
             given = cp.array_equiv({1, 2}, {{1, 2}, {1, 2}});
             expected =
                "True";
            Assert.AreEqual(expected, given.repr);
             given = cp.array_equiv({1, 2}, {{1, 2, 1, 2}, {1, 2, 1, 2}});
             expected =
                "False";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> cp.array_equiv([1, 2], [[1, 2], [1, 3]])
            // False
            // 

#if TODO
             given = cp.array_equiv({1, 2}, {{1, 2}, {1, 3}});
             expected =
                "False";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void greaterTest()
        {
            // >>> cp.greater([4,2],[2,2])
            // array([ True, False])
            // 

#if TODO
            var given = cp.greater({4,2},{2,2});
            var expected =
                "array([ True, False])";
            Assert.AreEqual(expected, given.repr);
#endif
            // If the inputs are ndarrays, then cp.greater is equivalent to ‘>’.

            // >>> a = cp.array([4,2])
            // >>> b = cp.array([2,2])
            // >>> a > b
            // array([ True, False])
            // 

#if TODO
             given = a = cp.array({4,2});
             given = b = cp.array({2,2});
             given = a > b;
             expected =
                "array([ True, False])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void greater_equalTest()
        {
            // >>> cp.greater_equal([4, 2, 1], [2, 2, 2])
            // array([ True, True, False])
            // 

#if TODO
            var given = cp.greater_equal({4, 2, 1}, {2, 2, 2});
            var expected =
                "array([ True, True, False])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void lessTest()
        {
            // >>> cp.less([1, 2], [2, 2])
            // array([ True, False])
            // 

#if TODO
            var given = cp.less({1, 2}, {2, 2});
            var expected =
                "array([ True, False])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void less_equalTest()
        {
            // >>> cp.less_equal([4, 2, 1], [2, 2, 2])
            // array([False,  True,  True])
            // 

#if TODO
            var given = cp.less_equal({4, 2, 1}, {2, 2, 2});
            var expected =
                "array([False,  True,  True])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void equalTest()
        {
            // >>> cp.equal([0, 1, 3], cp.arange(3))
            // array([ True,  True, False])
            // 

#if TODO
            var given = cp.equal({0, 1, 3}, cp.arange(3));
            var expected =
                "array([ True,  True, False])";
            Assert.AreEqual(expected, given.repr);
#endif
            // What is compared are values, not types. So an int (1) and an array of
            // length one can evaluate as True:

            // >>> cp.equal(1, cp.ones(1))
            // array([ True])
            // 

#if TODO
             given = cp.equal(1, cp.ones(1));
             expected =
                "array([ True])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void not_equalTest()
        {
            // >>> cp.not_equal([1.,2.], [1., 3.])
            // array([False,  True])
            // >>> cp.not_equal([1, 2], [[1, 3],[1, 4]])
            // array([[False,  True],
            //        [False,  True]])
            // 

#if TODO
            var given = cp.not_equal({1.,2.}, {1., 3.});
            var expected =
                "array([False,  True])";
            Assert.AreEqual(expected, given.repr);
             given = cp.not_equal({1, 2}, {{1, 3},{1, 4}});
             expected =
                "array([[False,  True],\n" +
                "       [False,  True]])";
            Assert.AreEqual(expected, given.repr);
#endif
        }
    }
}