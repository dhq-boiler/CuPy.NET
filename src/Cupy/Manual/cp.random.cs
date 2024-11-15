using Python.Runtime;

namespace Cupy
{
    public static partial class cp
    {
        public static partial class random
        {
            /// <summary>
            ///     Random values in a given shape.<br></br>
            ///     Create an array of the given shape and populate it with
            ///     random samples from a uniform distribution
            ///     over [0, 1).<br></br>
            ///     Notes
            ///     This is a convenience function.<br></br>
            ///     If you want an interface that
            ///     takes a shape-tuple as the first argument, refer to
            ///     cp.random.random_sample .
            /// </summary>
            /// <returns>
            ///     Random values.
            /// </returns>
            public static NDarray rand(params int[] shape)
            {
                var random = self.GetAttr("random");
                using var pyargs = ToTuple(shape);
                using var kwargs = new PyDict();
                dynamic py = random.InvokeMethod("rand", pyargs, kwargs);
                return ToCsharp<NDarray>(py);
            }

            /// <summary>
            ///     Return a sample (or samples) from the “standard normal” distribution.<br></br>
            ///     If positive, int_like or int-convertible arguments are provided,
            ///     randn generates an array of shape (d0, d1, ..., dn), filled
            ///     with random floats sampled from a univariate “normal” (Gaussian)
            ///     distribution of mean 0 and variance 1 (if any of the  are
            ///     floats, they are first converted to integers by truncation).<br></br>
            ///     A single
            ///     float randomly sampled from the distribution is returned if no
            ///     argument is provided.<br></br>
            ///     This is a convenience function.<br></br>
            ///     If you want an interface that takes a
            ///     tuple as the first argument, use Cupy.random.standard_normal instead.<br></br>
            ///     Notes
            ///     For random samples from , use:
            ///     sigma * cp.random.randn(...) + mu
            /// </summary>
            /// <returns>
            ///     A (d0, d1, ..., dn)-shaped array of floating-point samples from
            ///     the standard normal distribution, or a single such float if
            ///     no parameters were supplied.
            /// </returns>
            public static NDarray randn(params int[] shape)
            {
                var random = self.GetAttr("random");
                var __self__ = random;
                using var pyargs = ToTuple(shape);
                using var kwargs = new PyDict();
                dynamic py = __self__.InvokeMethod("randn", pyargs, kwargs);
                return ToCsharp<NDarray>(py);
            }

            /// <summary>
            ///     Draw random samples from a normal (Gaussian) distribution.<br></br>
            ///     The probability density function of the normal distribution, first
            ///     derived by De Moivre and 200 years later by both Gauss and Laplace
            ///     independently [2], is often called the bell curve because of
            ///     its characteristic shape (see the example below).<br></br>
            ///     The normal distributions occurs often in nature.<br></br>
            ///     For example, it
            ///     describes the commonly occurring distribution of samples influenced
            ///     by a large number of tiny, random disturbances, each with its own
            ///     unique distribution [2].<br></br>
            ///     Notes
            ///     The probability density for the Gaussian distribution is
            ///     where  is the mean and  the standard
            ///     deviation.<br></br>
            ///     The square of the standard deviation, ,
            ///     is called the variance.<br></br>
            ///     The function has its peak at the mean, and its “spread” increases with
            ///     the standard deviation (the function reaches 0.607 times its maximum at
            ///     and  [2]).<br></br>
            ///     This implies that
            ///     Cupy.random.normal is more likely to return samples lying close to
            ///     the mean, rather than those far away.<br></br>
            ///     References
            /// </summary>
            /// <param name="loc">
            ///     Mean (“centre”) of the distribution.
            /// </param>
            /// <param name="scale">
            ///     Standard deviation (spread or “width”) of the distribution.
            /// </param>
            /// <param name="size">
            ///     Output shape.<br></br>
            ///     If the given shape is, e.g., (m, n, k), then
            ///     m * n * k samples are drawn.<br></br>
            ///     If size is None (default),
            ///     a single value is returned if loc and scale are both scalars.<br></br>
            ///     Otherwise, cp.broadcast(loc, scale).size samples are drawn.
            /// </param>
            /// <returns>
            ///     Drawn samples from the parameterized normal distribution.
            /// </returns>
            public static NDarray normal(NDarray<float> loc, NDarray<float> scale = null, int[] size = null)
            {
                var random = self.GetAttr("random");
                using var pyargs = ToTuple(new object[] { });
                using var kwargs = new PyDict();
                using var locPy = loc != null ? ToPython(loc) : null;
                using var scalePy = scale != null ? ToPython(scale) : null;
                using var sizePy = size != null ? ToPython(size) : null;
                if (locPy != null) kwargs["loc"] = locPy;
                if (scalePy != null) kwargs["scale"] = scalePy;
                if (sizePy != null) kwargs["size"] = sizePy;
                var py = random.InvokeMethod("normal", pyargs, kwargs);
                return ToCsharp<NDarray>(py);
            }

            public static NDarray normal(float? loc = null, float? scale = null, int[] size = null)
            {
                var random = self.GetAttr("random");
                using var pyargs = ToTuple(new object[] { });
                using var kwargs = new PyDict();
                using var locPy = loc != null ? ToPython(loc) : null;
                using var scalePy = scale != null ? ToPython(scale) : null;
                using var sizePy = size != null ? ToPython(size) : null;
                if (locPy != null) kwargs["loc"] = locPy;
                if (scalePy != null) kwargs["scale"] = scalePy;
                if (sizePy != null) kwargs["size"] = sizePy;
                var py = random.InvokeMethod("normal", pyargs, kwargs);
                return ToCsharp<NDarray>(py);
            }

            public static NDarray normal(float loc)
            {
                return normal(loc, null);
            }

            public static NDarray normal(float loc, float scale)
            {
                return normal(loc, scale, null);
            }

            public static NDarray normal(float loc, float scale, int size)
            {
                var random = self.GetAttr("random");
                using var pyargs = ToTuple(new object[] { });
                using var kwargs = new PyDict();
                using var locPy = ToPython(loc);
                using var scalePy = ToPython(scale);
                using var sizePy = ToPython(size);
                kwargs["loc"] = locPy;
                kwargs["scale"] = scalePy;
                kwargs["size"] = sizePy;
                var py = random.InvokeMethod("normal", pyargs, kwargs);
                return ToCsharp<NDarray>(py);
            }
        }
    }
}