
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cupy.UnitTest
{
    [TestClass]
    public class CuPyConstants
    {
        [TestMethod]
        public void infTest()
        {
            //>>> cp.inf
            //inf
            //>>> cp.array([1]) / 0.
            //array([Inf])
            Console.WriteLine(cp.inf);
            var x = cp.array(1) / 0.0;
            Assert.AreEqual(cp.array(cp.inf), x);
            Assert.AreNotEqual(cp.array(0f), x);
            Assert.AreEqual(float.PositiveInfinity, cp.inf);
        }

        [TestMethod]
        public void ninfTest()
        {
            //>>> cp.NINF
            //-inf
            //>>> cp.log(0)
            //-inf
            Assert.AreEqual(-cp.inf, cp.NINF);
            Assert.AreEqual(-cp.inf, (float)((NDarray)0).log());
        }

        [TestMethod]
        public void NZERO_Test()
        {
            //>>> cp.NZERO
            //-0.0
            //>>> cp.PZERO
            //0.0
            //>>>
            //>>> cp.isfinite([cp.NZERO])
            //array([True])
            //>>> cp.isnan([cp.NZERO])
            //array([False])
            //>>> cp.isinf([cp.NZERO])
            //array([False])
            Assert.AreEqual(-0.0f, cp.NZERO);
            Assert.AreEqual(0.0f, cp.PZERO);
            Assert.IsTrue((bool)((NDarray)cp.NZERO).isfinite());
            Assert.IsFalse((bool)((NDarray)cp.NZERO).isnan());
            Assert.IsFalse((bool)((NDarray)cp.NZERO).isinf());
        }

        [TestMethod]
        public void nanTest()
        {
            //>>> cp.nan
            //nan
            //>>> cp.log(-1)
            //nan
            //>>> cp.log([-1, 1, 2])
            //array([NaN,  0.        ,  0.69314718])
            Assert.AreEqual(float.NaN, cp.nan);
            Assert.AreEqual(cp.nan, (float)((NDarray)(-1)).log());
            Assert.AreEqual("array([       nan, 0.        , 0.69314718])", cp.log(new[] { -1, 1, 2 }).repr);
        }

        [TestMethod]
        public void newaxisTest()
        {
            //>>> newaxis is None
            //True
            //>>> x = cp.arange(3)
            //>>> x
            //array([0, 1, 2])
            //>>> x[:, newaxis]
            //array([[0],
            //[1],
            //[2]])
            //>>> x[:, newaxis, newaxis]
            //array([[[0]],
            //[[1]],
            //[[2]]])
            //>>> x[:, newaxis] * x
            //array([[0, 0, 0],
            //[0, 1, 2],
            //[0, 2, 4]])
            //Outer product, same as outer(x, y) :

            //>>>
            //>>> y = cp.arange(3, 6)
            //>>> x[:, newaxis] * y
            //array([[ 0,  0,  0],
            //[ 3,  4,  5],
            //[ 6,  8, 10]])
            //x[newaxis, :] is equivalent to x[newaxis] and x[None]:

            //>>>
            //>>> x[newaxis, :].shape
            //(1, 3)
            //>>> x[newaxis].shape
            //(1, 3)
            //>>> x[None].shape
            //(1, 3)
            //>>> x[:, newaxis].shape
            //(3, 1)
        }
    }
}