﻿using System;
using Cupy.Models;
using Python.Runtime;

namespace Cupy
{
    public static partial class cp
    {
        public static partial class linalg
        {
            /// <summary>
            ///     Matrix or vector norm.
            ///     This function is able to return one of eight different matrix norms,
            ///     or one of an infinite number of vector norms (described below), depending
            ///     on the value of the ord parameter.
            ///     Notes
            ///     For values of ord &lt;= 0, the result is, strictly speaking, not a
            ///     mathematical ‘norm’, but it may still be useful for various numerical
            ///     purposes.
            ///     The following norms can be calculated:
            ///     The Frobenius norm is given by [1]:
            ///     The nuclear norm is the sum of the singular values.
            ///     References
            /// </summary>
            /// <param name="x">
            ///     Input array.  If axis is None, x must be 1-D or 2-D.
            /// </param>
            /// <param name="ord">
            ///     Order of the norm (see table under Notes). inf means Cupy’s
            ///     inf object.
            /// </param>
            /// <param name="axis">
            ///     If axis is an integer, it specifies the axis of x along which to
            ///     compute the vector norms.  If axis is a 2-tuple, it specifies the
            ///     axes that hold 2-D matrices, and the matrix norms of these matrices
            ///     are computed.  If axis is None then either a vector norm (when x
            ///     is 1-D) or a matrix norm (when x is 2-D) is returned.
            /// </param>
            /// <param name="keepdims">
            ///     If this is set to True, the axes which are normed over are left in the
            ///     result as dimensions with size one.  With this option the result will
            ///     broadcast correctly against the original x.
            /// </param>
            /// <returns>
            ///     Norm of the matrix or vector(s).
            /// </returns>
            public static NDarray norm(NDarray x, int? ord = null, int? axis = null, bool? keepdims = null)
            {
                using var pyargs = ToTuple(new object[] { x });
                using var kwargs = new PyDict();
                using var ordPy = ord != null ? ToPython(ord) : null;
                using var axisPy = axis != null ? ToPython(axis) : null;
                using var keepdimsPy = keepdims != null ? ToPython(keepdims) : null;
                using var linalg = self.GetAttr("linalg");
                if (ordPy != null) kwargs["ord"] = ordPy;
                if (axisPy != null) kwargs["axis"] = axisPy;
                if (keepdimsPy != null) kwargs["keepdims"] = keepdimsPy;
                dynamic py = linalg.InvokeMethod("norm", pyargs, kwargs);
                return ToCsharp<NDarray>(py);
            }

            public static NDarray norm(NDarray x, int[] axis, bool? keepdims = null)
            {
                return norm(x, null, axis, keepdims);
            }

            public static NDarray norm(NDarray x, int? ord, int[] axis, bool? keepdims = null)
            {
                using var pyargs = ToTuple(new object[] { x });
                using var kwargs = new PyDict();
                using var ordPy = ord != null ? ToPython(ord) : null;
                using var axisPy = axis != null ? ToPython(axis) : null;
                using var keepdimsPy = keepdims != null ? ToPython(keepdims) : null;
                if (ordPy != null) kwargs["ord"] = ordPy;
                if (axisPy != null) kwargs["axis"] = axisPy;
                if (keepdimsPy != null) kwargs["keepdims"] = keepdimsPy;
                var linalg = self.GetAttr("linalg");
                dynamic py = linalg.InvokeMethod("norm", pyargs, kwargs);
                return ToCsharp<NDarray>(py);
            }


            //public static float norm(NDarray x, int? ord=null, int? axis = null, bool? keepdims = null)
            //{
            //    using var pyargs = ToTuple(new object[] { x, });
            //    using var kwargs = new PyDict();
            //    if (ord != null) kwargs["ord"] = ToPython(ord);
            //    var linalg = self.GetAttr("linalg");
            //    dynamic py = linalg.InvokeMethod("norm", pyargs, kwargs);

            //    return ToCsharp<float>(py);
            //}

            public static float norm(NDarray x, string ord)
            {
                using var pyargs = ToTuple(new object[] { x });
                using var kwargs = new PyDict();
                using var ordPy = ord != null ? ToPython(ord) : null;
                using var linalg = self.GetAttr("linalg");
                if (ordPy != null) kwargs["ord"] = ordPy;
                dynamic py = linalg.InvokeMethod("norm", pyargs, kwargs);
                return ToCsharp<float>(py);
            }

            public static float norm(NDarray x, Constants? ord)
            {
                if (ord != Constants.inf && ord != Constants.neg_inf)
                    throw new ArgumentException("ord must be either inf or neg_inf");
                using var pyargs = ToTuple(new object[] { x });
                using var kwargs = new PyDict();
                using var linalg = self.GetAttr("linalg");
                if (ord != null)
                {
                    var infValue = ord == Constants.inf ? dynamic_self.inf : -dynamic_self.inf;
                    kwargs["ord"] = infValue;
                }
                dynamic py = linalg.InvokeMethod("norm", pyargs, kwargs);
                return ToCsharp<float>(py);
            }

            /// <summary>
            ///     Compute the qr factorization of a matrix.<br></br>
            ///     Factor the matrix a as qr, where q is orthonormal and r is
            ///     upper-triangular.<br></br>
            ///     Notes
            ///     This is an interface to the LAPACK routines dgeqrf, zgeqrf,
            ///     dorgqr, and zungqr.<br></br>
            ///     For more information on the qr factorization, see for example:
            ///     https://en.wikipedia.org/wiki/QR_factorization
            ///     Subclasses of ndarray are preserved except for the ‘raw’ mode.<br></br>
            ///     So if
            ///     a is of type matrix, all the return values will be matrices too.<br></br>
            ///     New ‘reduced’, ‘complete’, and ‘raw’ options for mode were added in
            ///     Cupy 1.8.0 and the old option ‘full’ was made an alias of ‘reduced’.  In
            ///     addition the options ‘full’ and ‘economic’ were deprecated.<br></br>
            ///     Because
            ///     ‘full’ was the previous default and ‘reduced’ is the new default,
            ///     backward compatibility can be maintained by letting mode default.<br></br>
            ///     The ‘raw’ option was added so that LAPACK routines that can multiply
            ///     arrays by q using the Householder reflectors can be used.<br></br>
            ///     Note that in
            ///     this case the returned arrays are of type cp.double or cp.cdouble and
            ///     the h array is transposed to be FORTRAN compatible.<br></br>
            ///     No routines using
            ///     the ‘raw’ return are currently exposed by Cupy, but some are available
            ///     in lapack_lite and just await the necessary work.
            /// </summary>
            /// <param name="a">
            ///     Matrix to be factored.
            /// </param>
            /// <param name="mode">
            ///     If K = min(M, N), then
            ///     The options ‘reduced’, ‘complete, and ‘raw’ are new in Cupy 1.8,
            ///     see the notes for more information.<br></br>
            ///     The default is ‘reduced’, and to
            ///     maintain backward compatibility with earlier versions of Cupy both
            ///     it and the old default ‘full’ can be omitted.<br></br>
            ///     Note that array h
            ///     returned in ‘raw’ mode is transposed for calling Fortran.<br></br>
            ///     The
            ///     ‘economic’ mode is deprecated.<br></br>
            ///     The modes ‘full’ and ‘economic’ may
            ///     be passed using only the first letter for backwards compatibility,
            ///     but all others must be spelled out.<br></br>
            ///     See the Notes for more
            ///     explanation.
            /// </param>
            /// <returns>
            ///     A tuple of:
            ///     q
            ///     A matrix with orthonormal columns. When mode = ‘complete’ the
            ///     result is an orthogonal/unitary matrix depending on whether or not
            ///     a is real/complex. The determinant may be either +/- 1 in that
            ///     case.
            ///     r
            ///     The upper-triangular matrix.
            ///     (h, tau)
            ///     The array h contains the Householder reflectors that generate q
            ///     along with r. The tau array contains scaling factors for the
            ///     reflectors. In the deprecated  ‘economic’ mode only h is returned.
            /// </returns>
            public static (NDarray, NDarray, NDarray) qr(NDarray a, string mode = "reduced")
            {
                using var linalg = self.GetAttr("linalg");
                using var pyargs = ToTuple(new object[] { a });
                using var kwargs = new PyDict();
                using var modePy = mode != "reduced" ? ToPython(mode) : null;
                if (modePy != null) kwargs["mode"] = modePy;
                dynamic py = linalg.InvokeMethod("qr", pyargs, kwargs);
                if (PythonObject.IsNDarray(py))
                    return (ToCsharp<NDarray>(py), null, null);
                if (PythonObject.IsTuple(py))
                {
                    using var pyLen = py.__len__();
                    if (ToCsharp<int>(pyLen) == 2)
                        return (ToCsharp<NDarray>(py[0]), ToCsharp<NDarray>(py[1]), null);
                    return (ToCsharp<NDarray>(py[0]), ToCsharp<NDarray>(py[1]), ToCsharp<NDarray>(py[2]));
                }
                using var className = py.__class__.__name__;
                throw new NotSupportedException("Unexpected return type: " + ToCsharp<string>(className));
            }
        }
    }
}