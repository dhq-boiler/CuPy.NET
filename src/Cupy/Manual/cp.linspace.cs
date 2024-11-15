using Python.Runtime;

namespace Cupy
{
    public static partial class cp
    {
        /// <summary>
        ///     Return evenly spaced numbers over a specified interval.<br></br>
        ///     Returns num evenly spaced samples, calculated over the
        ///     interval [start, stop].<br></br>
        ///     The endpoint of the interval can optionally be excluded.
        /// </summary>
        /// <param name="start">
        ///     The starting value of the sequence.
        /// </param>
        /// <param name="stop">
        ///     The end value of the sequence, unless endpoint is set to False.<br></br>
        ///     In that case, the sequence consists of all but the last of num + 1
        ///     evenly spaced samples, so that stop is excluded.<br></br>
        ///     Note that the step
        ///     size changes when endpoint is False.
        /// </param>
        /// <param name="step">
        ///     Returns the step which is the spacing
        ///     between samples.
        /// </param>
        /// <param name="num">
        ///     Number of samples to generate.<br></br>
        ///     Default is 50. Must be non-negative.
        /// </param>
        /// <param name="endpoint">
        ///     If True, stop is the last sample.<br></br>
        ///     Otherwise, it is not included.<br></br>
        ///     Default is True.
        /// </param>
        /// <param name="dtype">
        ///     The type of the output array.<br></br>
        ///     If dtype is not given, infer the data
        ///     type from the other input arguments.
        /// </param>
        /// <param name="axis">
        ///     The axis in the result to store the samples.<br></br>
        ///     Relevant only if start
        ///     or stop are array-like.<br></br>
        ///     By default (0), the samples will be along a
        ///     new axis inserted at the beginning.<br></br>
        ///     Use -1 to get an axis at the end.
        /// </param>
        /// <returns>
        ///     There are num equally spaced samples in the closed interval
        ///     [start, stop] or the half-open interval [start, stop)
        /// </returns>
        public static NDarray linspace(NDarray start, NDarray stop, out float step, int num = 50, bool endpoint = true,
                                       Dtype dtype = null, int? axis = 0)
        {
            using var pyargs = ToTuple(new object[] { start, stop });
            using var kwargs = new PyDict();
            using var numPy = ToPython(num);
            using var endpointPy = ToPython(endpoint);
            using var retstepPy = ToPython(true);
            using var dtypePy = dtype != null ? ToPython(dtype) : null;
            using var axisPy = axis != 0 ? ToPython(axis) : null;

            kwargs["num"] = numPy;
            kwargs["endpoint"] = endpointPy;
            kwargs["retstep"] = retstepPy;
            if (dtypePy != null) kwargs["dtype"] = dtypePy;
            if (axisPy != null) kwargs["axis"] = axisPy;

            dynamic py = self.InvokeMethod("linspace", pyargs, kwargs);
            var t = py as PyObject;
            step = ToCsharp<float>(t[1]);
            return ToCsharp<NDarray>(t[0]);
        }

        /// <summary>
        ///     Return evenly spaced numbers over a specified interval.<br></br>
        ///     Returns num evenly spaced samples, calculated over the
        ///     interval [start, stop].<br></br>
        ///     The endpoint of the interval can optionally be excluded.
        /// </summary>
        /// <param name="start">
        ///     The starting value of the sequence.
        /// </param>
        /// <param name="stop">
        ///     The end value of the sequence, unless endpoint is set to False.<br></br>
        ///     In that case, the sequence consists of all but the last of num + 1
        ///     evenly spaced samples, so that stop is excluded.<br></br>
        ///     Note that the step
        ///     size changes when endpoint is False.
        /// </param>
        /// <param name="step">
        ///     Returns the step which is the spacing
        ///     between samples.
        /// </param>
        /// <param name="num">
        ///     Number of samples to generate.<br></br>
        ///     Default is 50. Must be non-negative.
        /// </param>
        /// <param name="endpoint">
        ///     If True, stop is the last sample.<br></br>
        ///     Otherwise, it is not included.<br></br>
        ///     Default is True.
        /// </param>
        /// <param name="dtype">
        ///     The type of the output array.<br></br>
        ///     If dtype is not given, infer the data
        ///     type from the other input arguments.
        /// </param>
        /// <param name="axis">
        ///     The axis in the result to store the samples.<br></br>
        ///     Relevant only if start
        ///     or stop are array-like.<br></br>
        ///     By default (0), the samples will be along a
        ///     new axis inserted at the beginning.<br></br>
        ///     Use -1 to get an axis at the end.
        /// </param>
        /// <returns>
        ///     There are num equally spaced samples in the closed interval
        ///     [start, stop] or the half-open interval [start, stop)
        /// </returns>
        public static NDarray linspace(double start, double stop, out float step, int num = 50, bool endpoint = true,
                                       Dtype dtype = null, int? axis = 0)
        {
            using var pyargs = ToTuple(new object[] { start, stop });
            using var kwargs = new PyDict();
            using var numPy = num != 50 ? ToPython(num) : null;
            using var endpointPy = endpoint != true ? ToPython(endpoint) : null;
            using var retstepPy = ToPython(true);
            using var dtypePy = dtype != null ? ToPython(dtype) : null;
            using var axisPy = axis != 0 ? ToPython(axis) : null;

            if (numPy != null) kwargs["num"] = numPy;
            if (endpointPy != null) kwargs["endpoint"] = endpointPy;
            kwargs["retstep"] = retstepPy;
            if (dtypePy != null) kwargs["dtype"] = dtypePy;
            if (axisPy != null) kwargs["axis"] = axisPy;

            dynamic py = self.InvokeMethod("linspace", pyargs, kwargs);
            var t = py as PyObject;
            step = ToCsharp<float>(t[1]);
            return ToCsharp<NDarray>(t[0]);
        }
    }
}