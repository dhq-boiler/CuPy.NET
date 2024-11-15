
using NUnit.Framework;
using System;

namespace Cupy.UnitTest
{
    [TestFixture]
    public class CuPyConstants
    {
        [Test]
        public void infTest()
        {
            //>>> cp.inf
            //inf
            //>>> cp.array([1]) / 0.
            //array([Inf])
            Console.WriteLine(cp.inf);
            var x = cp.array(1) / 0.0;
            Assert.That(cp.array(cp.inf), Is.EqualTo(x));
            Assert.That(cp.array(0f), Is.Not.EqualTo(x));
            Assert.That(float.PositiveInfinity, Is.EqualTo(cp.inf));
        }

        [Test]
        public void ninfTest()
        {
            //>>> cp.NINF
            //-inf
            //>>> cp.log(0)
            //-inf
            Assert.That(-cp.inf, Is.EqualTo(cp.NINF));
            Assert.That(-cp.inf, Is.EqualTo((float)((NDarray)0).log()));
        }

        [Test]
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
            Assert.That(-0.0f, Is.EqualTo(cp.NZERO));
            Assert.That(0.0f, Is.EqualTo(cp.PZERO));
            Assert.That((bool)((NDarray)cp.NZERO).isfinite());
            Assert.That((bool)((NDarray)cp.NZERO).isnan(), Is.False);
            Assert.That((bool)((NDarray)cp.NZERO).isinf(), Is.False);
        }

        [Test]
        public void nanTest()
        {
            //>>> cp.nan
            //nan
            //>>> cp.log(-1)
            //nan
            //>>> cp.log([-1, 1, 2])
            //array([NaN,  0.        ,  0.69314718])
            Assert.That(float.NaN, Is.EqualTo(cp.nan));
            Assert.That(cp.nan, Is.EqualTo((float)((NDarray)(-1)).log()));
            Assert.That("array([       nan, 0.        , 0.69314718], dtype=float64)", Is.EqualTo(cp.log(new[] { -1, 1, 2 }).repr));
        }

        [Test]
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