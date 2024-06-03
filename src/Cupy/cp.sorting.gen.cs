// Copyright (c) 2020 by Meinrad Recheis (Member of SciSharp)
// Code generated by CodeMinion: https://github.com/SciSharp/CodeMinion

using Cupy.Models;
using Python.Runtime;
#if PYTHON_INCLUDED
#endif

namespace Cupy
{
    public static partial class cp
    {
        /// <summary>
        ///     Return a sorted copy of an array.<br></br>
        ///     Notes
        ///     The various sorting algorithms are characterized by their average speed,
        ///     worst case performance, work space size, and whether they are stable.<br></br>
        ///     A
        ///     stable sort keeps items with the same key in the same relative
        ///     order.<br></br>
        ///     The three available algorithms have the following
        ///     properties:
        ///     All the sort algorithms make temporary copies of the data when
        ///     sorting along any but the last axis.<br></br>
        ///     Consequently, sorting along
        ///     the last axis is faster and uses less space than sorting along
        ///     any other axis.<br></br>
        ///     The sort order for complex numbers is lexicographic.<br></br>
        ///     If both the real
        ///     and imaginary parts are non-nan then the order is determined by the
        ///     real parts except when they are equal, in which case the order is
        ///     determined by the imaginary parts.<br></br>
        ///     Previous to Cupy 1.4.0 sorting real and complex arrays containing nan
        ///     values led to undefined behaviour.<br></br>
        ///     In Cupy versions &gt;= 1.4.0 nan
        ///     values are sorted to the end.<br></br>
        ///     The extended sort order is:
        ///     where R is a non-nan real value.<br></br>
        ///     Complex values with the same nan
        ///     placements are sorted according to the non-nan part if it exists.<br></br>
        ///     Non-nan values are sorted as before.<br></br>
        ///     quicksort has been changed to an introsort which will switch
        ///     heapsort when it does not make enough progress.<br></br>
        ///     This makes its
        ///     worst case O(n*log(n)).<br></br>
        ///     ‘stable’ automatically choses the best stable sorting algorithm
        ///     for the data type being sorted.<br></br>
        ///     It is currently mapped to
        ///     merge sort.
        /// </summary>
        /// <param name="a">
        ///     Array to be sorted.
        /// </param>
        /// <param name="axis">
        ///     Axis along which to sort.<br></br>
        ///     If None, the array is flattened before
        ///     sorting.<br></br>
        ///     The default is -1, which sorts along the last axis.
        /// </param>
        /// <param name="kind">
        ///     Sorting algorithm.<br></br>
        ///     Default is ‘quicksort’.
        /// </param>
        /// <param name="order">
        ///     When a is an array with fields defined, this argument specifies
        ///     which fields to compare first, second, etc.<br></br>
        ///     A single field can
        ///     be specified as a string, and not all fields need be specified,
        ///     but unspecified fields will still be used, in the order in which
        ///     they come up in the dtype, to break ties.
        /// </param>
        /// <returns>
        ///     Array of the same type and shape as a.
        /// </returns>
        public static NDarray sort(this NDarray a, int? axis = -1, string kind = "quicksort", string order = null)
        {
            //auto-generated code, do not change
            var __self__ = self;
            var pyargs = ToTuple(new object[]
            {
                a
            });
            using var kwargs = new PyDict();
            if (axis != -1) kwargs["axis"] = ToPython(axis);
            if (kind != "quicksort") kwargs["kind"] = ToPython(kind);
            if (order != null) kwargs["order"] = ToPython(order);
            dynamic py = __self__.InvokeMethod("sort", pyargs, kwargs);
            return ToCsharp<NDarray>(py);
        }

        /// <summary>
        ///     Perform an indirect stable sort using a sequence of keys.<br></br>
        ///     Given multiple sorting keys, which can be interpreted as columns in a
        ///     spreadsheet, lexsort returns an array of integer indices that describes
        ///     the sort order by multiple columns.<br></br>
        ///     The last key in the sequence is used
        ///     for the primary sort order, the second-to-last key for the secondary sort
        ///     order, and so on.<br></br>
        ///     The keys argument must be a sequence of objects that
        ///     can be converted to arrays of the same shape.<br></br>
        ///     If a 2D array is provided
        ///     for the keys argument, it’s rows are interpreted as the sorting keys and
        ///     sorting is according to the last row, second last row etc.
        /// </summary>
        /// <param name="keys">
        ///     The k different “columns” to be sorted.<br></br>
        ///     The last column (or row if
        ///     keys is a 2D array) is the primary sort key.
        /// </param>
        /// <param name="axis">
        ///     Axis to be indirectly sorted.<br></br>
        ///     By default, sort over the last axis.
        /// </param>
        /// <returns>
        ///     Array of indices that sort the keys along the specified axis.
        /// </returns>
        public static NDarray lexsort(this NDarray keys, int? axis = -1)
        {
            //auto-generated code, do not change
            var __self__ = self;
            var pyargs = ToTuple(new object[]
            {
                keys
            });
            using var kwargs = new PyDict();
            if (axis != -1) kwargs["axis"] = ToPython(axis);
            dynamic py = __self__.InvokeMethod("lexsort", pyargs, kwargs);
            return ToCsharp<NDarray>(py);
        }

        /// <summary>
        ///     Returns the indices that would sort an array.<br></br>
        ///     Perform an indirect sort along the given axis using the algorithm specified
        ///     by the kind keyword.<br></br>
        ///     It returns an array of indices of the same shape as
        ///     a that index data along the given axis in sorted order.<br></br>
        ///     Notes
        ///     See sort for notes on the different sorting algorithms.<br></br>
        ///     As of Cupy 1.4.0 argsort works with real/complex arrays containing
        ///     nan values.<br></br>
        ///     The enhanced sort order is documented in sort.
        /// </summary>
        /// <param name="a">
        ///     Array to sort.
        /// </param>
        /// <param name="axis">
        ///     Axis along which to sort.<br></br>
        ///     The default is -1 (the last axis).<br></br>
        ///     If None,
        ///     the flattened array is used.
        /// </param>
        /// <param name="kind">
        ///     Sorting algorithm.
        /// </param>
        /// <param name="order">
        ///     When a is an array with fields defined, this argument specifies
        ///     which fields to compare first, second, etc.<br></br>
        ///     A single field can
        ///     be specified as a string, and not all fields need be specified,
        ///     but unspecified fields will still be used, in the order in which
        ///     they come up in the dtype, to break ties.
        /// </param>
        /// <returns>
        ///     Array of indices that sort a along the specified axis.<br></br>
        ///     If a is one-dimensional, a[index_array] yields a sorted a.<br></br>
        ///     More generally, cp.take_along_axis(a, index_array, axis=a) always
        ///     yields the sorted a, irrespective of dimensionality.
        /// </returns>
        public static NDarray argsort(this NDarray a, int? axis = -1, string kind = "quicksort", string order = null)
        {
            //auto-generated code, do not change
            var __self__ = self;
            var pyargs = ToTuple(new object[]
            {
                a
            });
            using var kwargs = new PyDict();
            if (axis != -1) kwargs["axis"] = ToPython(axis);
            if (kind != "quicksort") kwargs["kind"] = ToPython(kind);
            if (order != null) kwargs["order"] = ToPython(order);
            dynamic py = __self__.InvokeMethod("argsort", pyargs, kwargs);
            return ToCsharp<NDarray>(py);
        }

        /// <summary>
        ///     Sort an array, in-place.<br></br>
        ///     Notes
        ///     See sort for notes on the different sorting algorithms.
        /// </summary>
        /// <param name="axis">
        ///     Axis along which to sort.<br></br>
        ///     Default is -1, which means sort along the
        ///     last axis.
        /// </param>
        /// <param name="kind">
        ///     Sorting algorithm.<br></br>
        ///     Default is ‘quicksort’.
        /// </param>
        /// <param name="order">
        ///     When a is an array with fields defined, this argument specifies
        ///     which fields to compare first, second, etc.<br></br>
        ///     A single field can
        ///     be specified as a string, and not all fields need be specified,
        ///     but unspecified fields will still be used, in the order in which
        ///     they come up in the dtype, to break ties.
        /// </param>
        public static void sort(int? axis = -1, string kind = null, string order = null)
        {
            //auto-generated code, do not change
            var __self__ = self;
            var pyargs = ToTuple(new object[]
            {
            });
            using var kwargs = new PyDict();
            if (axis != -1) kwargs["axis"] = ToPython(axis);
            if (kind != null) kwargs["kind"] = ToPython(kind);
            if (order != null) kwargs["order"] = ToPython(order);
            dynamic py = __self__.InvokeMethod("sort", pyargs, kwargs);
        }

        /// <summary>
        ///     Return a copy of an array sorted along the first axis.<br></br>
        ///     Notes
        ///     cp.msort(a) is equivalent to  cp.sort(a, axis=0).
        /// </summary>
        /// <param name="a">
        ///     Array to be sorted.
        /// </param>
        /// <returns>
        ///     Array of the same type and shape as a.
        /// </returns>
        public static NDarray msort(this NDarray a)
        {
            //auto-generated code, do not change
            var __self__ = self;
            var pyargs = ToTuple(new object[]
            {
                a
            });
            using var kwargs = new PyDict();
            dynamic py = __self__.InvokeMethod("msort", pyargs, kwargs);
            return ToCsharp<NDarray>(py);
        }

        /// <summary>
        ///     Sort a complex array using the real part first, then the imaginary part.
        /// </summary>
        /// <param name="a">
        ///     Input array
        /// </param>
        /// <returns>
        ///     Always returns a sorted complex array.
        /// </returns>
        public static NDarray sort_complex(this NDarray a)
        {
            //auto-generated code, do not change
            var __self__ = self;
            var pyargs = ToTuple(new object[]
            {
                a
            });
            using var kwargs = new PyDict();
            dynamic py = __self__.InvokeMethod("sort_complex", pyargs, kwargs);
            return ToCsharp<NDarray>(py);
        }

        /// <summary>
        ///     Return a partitioned copy of an array.<br></br>
        ///     Creates a copy of the array with its elements rearranged in such a
        ///     way that the value of the element in k-th position is in the
        ///     position it would be in a sorted array.<br></br>
        ///     All elements smaller than
        ///     the k-th element are moved before this element and all equal or
        ///     greater are moved behind it.<br></br>
        ///     The ordering of the elements in the two
        ///     partitions is undefined.<br></br>
        ///     Notes
        ///     The various selection algorithms are characterized by their average
        ///     speed, worst case performance, work space size, and whether they are
        ///     stable.<br></br>
        ///     A stable sort keeps items with the same key in the same
        ///     relative order.<br></br>
        ///     The available algorithms have the following
        ///     properties:
        ///     All the partition algorithms make temporary copies of the data when
        ///     partitioning along any but the last axis.<br></br>
        ///     Consequently,
        ///     partitioning along the last axis is faster and uses less space than
        ///     partitioning along any other axis.<br></br>
        ///     The sort order for complex numbers is lexicographic.<br></br>
        ///     If both the
        ///     real and imaginary parts are non-nan then the order is determined by
        ///     the real parts except when they are equal, in which case the order
        ///     is determined by the imaginary parts.
        /// </summary>
        /// <param name="a">
        ///     Array to be sorted.
        /// </param>
        /// <param name="kth">
        ///     Element index to partition by.<br></br>
        ///     The k-th value of the element
        ///     will be in its final sorted position and all smaller elements
        ///     will be moved before it and all equal or greater elements behind
        ///     it.<br></br>
        ///     The order of all elements in the partitions is undefined.<br></br>
        ///     If
        ///     provided with a sequence of k-th it will partition all elements
        ///     indexed by k-th  of them into their sorted position at once.
        /// </param>
        /// <param name="axis">
        ///     Axis along which to sort.<br></br>
        ///     If None, the array is flattened before
        ///     sorting.<br></br>
        ///     The default is -1, which sorts along the last axis.
        /// </param>
        /// <param name="kind">
        ///     Selection algorithm.<br></br>
        ///     Default is ‘introselect’.
        /// </param>
        /// <param name="order">
        ///     When a is an array with fields defined, this argument
        ///     specifies which fields to compare first, second, etc.<br></br>
        ///     A single
        ///     field can be specified as a string.<br></br>
        ///     Not all fields need be
        ///     specified, but unspecified fields will still be used, in the
        ///     order in which they come up in the dtype, to break ties.
        /// </param>
        /// <returns>
        ///     Array of the same type and shape as a.
        /// </returns>
        public static NDarray partition(this NDarray a, int[] kth, int? axis = -1, string kind = "introselect",
            string order = null)
        {
            //auto-generated code, do not change
            var __self__ = self;
            var pyargs = ToTuple(new object[]
            {
                a,
                kth
            });
            using var kwargs = new PyDict();
            if (axis != -1) kwargs["axis"] = ToPython(axis);
            if (kind != "introselect") kwargs["kind"] = ToPython(kind);
            if (order != null) kwargs["order"] = ToPython(order);
            dynamic py = __self__.InvokeMethod("partition", pyargs, kwargs);
            return ToCsharp<NDarray>(py);
        }

        /// <summary>
        ///     Perform an indirect partition along the given axis using the
        ///     algorithm specified by the kind keyword.<br></br>
        ///     It returns an array of
        ///     indices of the same shape as a that index data along the given
        ///     axis in partitioned order.<br></br>
        ///     Notes
        ///     See partition for notes on the different selection algorithms.
        /// </summary>
        /// <param name="a">
        ///     Array to sort.
        /// </param>
        /// <param name="kth">
        ///     Element index to partition by.<br></br>
        ///     The k-th element will be in its
        ///     final sorted position and all smaller elements will be moved
        ///     before it and all larger elements behind it.<br></br>
        ///     The order all
        ///     elements in the partitions is undefined.<br></br>
        ///     If provided with a
        ///     sequence of k-th it will partition all of them into their sorted
        ///     position at once.
        /// </param>
        /// <param name="axis">
        ///     Axis along which to sort.<br></br>
        ///     The default is -1 (the last axis).<br></br>
        ///     If
        ///     None, the flattened array is used.
        /// </param>
        /// <param name="kind">
        ///     Selection algorithm.<br></br>
        ///     Default is ‘introselect’
        /// </param>
        /// <param name="order">
        ///     When a is an array with fields defined, this argument
        ///     specifies which fields to compare first, second, etc.<br></br>
        ///     A single
        ///     field can be specified as a string, and not all fields need be
        ///     specified, but unspecified fields will still be used, in the
        ///     order in which they come up in the dtype, to break ties.
        /// </param>
        /// <returns>
        ///     Array of indices that partition a along the specified axis.<br></br>
        ///     If a is one-dimensional, a[index_array] yields a partitioned a.<br></br>
        ///     More generally, cp.take_along_axis(a, index_array, axis=a) always
        ///     yields the partitioned a, irrespective of dimensionality.
        /// </returns>
        public static NDarray argpartition(this NDarray a, int[] kth, int? axis = -1, string kind = "introselect",
            string order = null)
        {
            //auto-generated code, do not change
            var __self__ = self;
            var pyargs = ToTuple(new object[]
            {
                a,
                kth
            });
            using var kwargs = new PyDict();
            if (axis != -1) kwargs["axis"] = ToPython(axis);
            if (kind != "introselect") kwargs["kind"] = ToPython(kind);
            if (order != null) kwargs["order"] = ToPython(order);
            dynamic py = __self__.InvokeMethod("argpartition", pyargs, kwargs);
            return ToCsharp<NDarray>(py);
        }

        /// <summary>
        ///     Returns the indices of the maximum values along an axis.<br></br>
        ///     Notes
        ///     In case of multiple occurrences of the maximum values, the indices
        ///     corresponding to the first occurrence are returned.
        /// </summary>
        /// <param name="a">
        ///     Input array.
        /// </param>
        /// <param name="axis">
        ///     By default, the index is into the flattened array, otherwise
        ///     along the specified axis.
        /// </param>
        /// <param name="out">
        ///     If provided, the result will be inserted into this array.<br></br>
        ///     It should
        ///     be of the appropriate shape and dtype.
        /// </param>
        /// <returns>
        ///     Array of indices into the array.<br></br>
        ///     It has the same shape as a.shape
        ///     with the dimension along axis removed.
        /// </returns>
        public static NDarray argmax(this NDarray a, int? axis = null, NDarray @out = null)
        {
            //auto-generated code, do not change
            var __self__ = self;
            var pyargs = ToTuple(new object[]
            {
                a
            });
            using var kwargs = new PyDict();
            if (axis != null) kwargs["axis"] = ToPython(axis);
            if (@out != null) kwargs["out"] = ToPython(@out);
            dynamic py = __self__.InvokeMethod("argmax", pyargs, kwargs);
            return ToCsharp<NDarray>(py);
        }

        /// <summary>
        ///     Return the indices of the maximum values in the specified axis ignoring
        ///     NaNs.<br></br>
        ///     For all-NaN slices ValueError is raised.<br></br>
        ///     Warning: the
        ///     results cannot be trusted if a slice contains only NaNs and -Infs.
        /// </summary>
        /// <param name="a">
        ///     Input data.
        /// </param>
        /// <param name="axis">
        ///     Axis along which to operate.<br></br>
        ///     By default flattened input is used.
        /// </param>
        /// <returns>
        ///     An array of indices or a single index value.
        /// </returns>
        public static NDarray nanargmax(this NDarray a, int? axis = null)
        {
            //auto-generated code, do not change
            var __self__ = self;
            var pyargs = ToTuple(new object[]
            {
                a
            });
            using var kwargs = new PyDict();
            if (axis != null) kwargs["axis"] = ToPython(axis);
            dynamic py = __self__.InvokeMethod("nanargmax", pyargs, kwargs);
            return ToCsharp<NDarray>(py);
        }

        /// <summary>
        ///     Returns the indices of the minimum values along an axis.<br></br>
        ///     Notes
        ///     In case of multiple occurrences of the minimum values, the indices
        ///     corresponding to the first occurrence are returned.
        /// </summary>
        /// <param name="a">
        ///     Input array.
        /// </param>
        /// <param name="axis">
        ///     By default, the index is into the flattened array, otherwise
        ///     along the specified axis.
        /// </param>
        /// <param name="out">
        ///     If provided, the result will be inserted into this array.<br></br>
        ///     It should
        ///     be of the appropriate shape and dtype.
        /// </param>
        /// <returns>
        ///     Array of indices into the array.<br></br>
        ///     It has the same shape as a.shape
        ///     with the dimension along axis removed.
        /// </returns>
        public static NDarray argmin(this NDarray a, int? axis = null, NDarray @out = null)
        {
            //auto-generated code, do not change
            var __self__ = self;
            var pyargs = ToTuple(new object[]
            {
                a
            });
            using var kwargs = new PyDict();
            if (axis != null) kwargs["axis"] = ToPython(axis);
            if (@out != null) kwargs["out"] = ToPython(@out);
            dynamic py = __self__.InvokeMethod("argmin", pyargs, kwargs);
            return ToCsharp<NDarray>(py);
        }

        /// <summary>
        ///     Return the indices of the minimum values in the specified axis ignoring
        ///     NaNs.<br></br>
        ///     For all-NaN slices ValueError is raised.<br></br>
        ///     Warning: the results
        ///     cannot be trusted if a slice contains only NaNs and Infs.
        /// </summary>
        /// <param name="a">
        ///     Input data.
        /// </param>
        /// <param name="axis">
        ///     Axis along which to operate.<br></br>
        ///     By default flattened input is used.
        /// </param>
        /// <returns>
        ///     An array of indices or a single index value.
        /// </returns>
        public static NDarray nanargmin(this NDarray a, int? axis = null)
        {
            //auto-generated code, do not change
            var __self__ = self;
            var pyargs = ToTuple(new object[]
            {
                a
            });
            using var kwargs = new PyDict();
            if (axis != null) kwargs["axis"] = ToPython(axis);
            dynamic py = __self__.InvokeMethod("nanargmin", pyargs, kwargs);
            return ToCsharp<NDarray>(py);
        }

        /// <summary>
        ///     Find the indices of array elements that are non-zero, grouped by element.<br></br>
        ///     Notes
        ///     cp.argwhere(a) is the same as cp.transpose(cp.nonzero(a)).<br></br>
        ///     The output of argwhere is not suitable for indexing arrays.<br></br>
        ///     For this purpose use nonzero(a) instead.
        /// </summary>
        /// <param name="a">
        ///     Input data.
        /// </param>
        /// <returns>
        ///     Indices of elements that are non-zero.<br></br>
        ///     Indices are grouped by element.
        /// </returns>
        public static NDarray argwhere(this NDarray a)
        {
            //auto-generated code, do not change
            var __self__ = self;
            var pyargs = ToTuple(new object[]
            {
                a
            });
            using var kwargs = new PyDict();
            dynamic py = __self__.InvokeMethod("argwhere", pyargs, kwargs);
            return ToCsharp<NDarray>(py);
        }

        /// <summary>
        ///     Return indices that are non-zero in the flattened version of a.<br></br>
        ///     This is equivalent to cp.nonzero(cp.ravel(a))[0].
        /// </summary>
        /// <param name="a">
        ///     Input data.
        /// </param>
        /// <returns>
        ///     Output array, containing the indices of the elements of a.ravel()
        ///     that are non-zero.
        /// </returns>
        public static NDarray flatnonzero(this NDarray a)
        {
            //auto-generated code, do not change
            var __self__ = self;
            var pyargs = ToTuple(new object[]
            {
                a
            });
            using var kwargs = new PyDict();
            dynamic py = __self__.InvokeMethod("flatnonzero", pyargs, kwargs);
            return ToCsharp<NDarray>(py);
        }

        /// <summary>
        ///     Find indices where elements should be inserted to maintain order.<br></br>
        ///     Find the indices into a sorted array a such that, if the
        ///     corresponding elements in v were inserted before the indices, the
        ///     order of a would be preserved.<br></br>
        ///     Assuming that a is sorted:
        ///     Notes
        ///     Binary search is used to find the required insertion points.<br></br>
        ///     As of Cupy 1.4.0 searchsorted works with real/complex arrays containing
        ///     nan values.<br></br>
        ///     The enhanced sort order is documented in sort.<br></br>
        ///     This function is a faster version of the builtin python bisect.bisect_left
        ///     (side='left') and bisect.bisect_right (side='right') functions,
        ///     which is also vectorized in the v argument.
        /// </summary>
        /// <param name="a">
        ///     Input array.<br></br>
        ///     If sorter is None, then it must be sorted in
        ///     ascending order, otherwise sorter must be an array of indices
        ///     that sort it.
        /// </param>
        /// <param name="v">
        ///     Values to insert into a.
        /// </param>
        /// <param name="side">
        ///     If ‘left’, the index of the first suitable location found is given.<br></br>
        ///     If ‘right’, return the last such index.<br></br>
        ///     If there is no suitable
        ///     index, return either 0 or N (where N is the length of a).
        /// </param>
        /// <param name="sorter">
        ///     Optional array of integer indices that sort array a into ascending
        ///     order.<br></br>
        ///     They are typically the result of argsort.
        /// </param>
        /// <returns>
        ///     Array of insertion points with the same shape as v.
        /// </returns>
        public static NDarray<int> searchsorted(this NDarray a, NDarray v, string side = "left", NDarray sorter = null)
        {
            //auto-generated code, do not change
            var __self__ = self;
            var pyargs = ToTuple(new object[]
            {
                a,
                v
            });
            using var kwargs = new PyDict();
            if (side != "left") kwargs["side"] = ToPython(side);
            if (sorter != null) kwargs["sorter"] = ToPython(sorter);
            dynamic py = __self__.InvokeMethod("searchsorted", pyargs, kwargs);
            return ToCsharp<NDarray<int>>(py);
        }

        /// <summary>
        ///     Return the elements of an array that satisfy some condition.<br></br>
        ///     This is equivalent to cp.compress(ravel(condition), ravel(arr)).<br></br>
        ///     If
        ///     condition is boolean cp.extract is equivalent to arr[condition].<br></br>
        ///     Note that place does the exact opposite of extract.
        /// </summary>
        /// <param name="condition">
        ///     An array whose nonzero or True entries indicate the elements of arr
        ///     to extract.
        /// </param>
        /// <param name="arr">
        ///     Input array of the same size as condition.
        /// </param>
        /// <returns>
        ///     Rank 1 array of values from arr where condition is True.
        /// </returns>
        public static NDarray extract(this NDarray condition, NDarray arr)
        {
            //auto-generated code, do not change
            var __self__ = self;
            var pyargs = ToTuple(new object[]
            {
                condition,
                arr
            });
            using var kwargs = new PyDict();
            dynamic py = __self__.InvokeMethod("extract", pyargs, kwargs);
            return ToCsharp<NDarray>(py);
        }

        /// <summary>
        ///     Counts the number of non-zero values in the array a.<br></br>
        ///     The word “non-zero” is in reference to the Python 2.x
        ///     built-in method __nonzero__() (renamed __bool__()
        ///     in Python 3.x) of Python objects that tests an object’s
        ///     “truthfulness”. For example, any number is considered
        ///     truthful if it is nonzero, whereas any string is considered
        ///     truthful if it is not the empty string.<br></br>
        ///     Thus, this function
        ///     (recursively) counts how many elements in a (and in
        ///     sub-arrays thereof) have their __nonzero__() or __bool__()
        ///     method evaluated to True.
        /// </summary>
        /// <param name="a">
        ///     The array for which to count non-zeros.
        /// </param>
        /// <param name="axis">
        ///     Axis or tuple of axes along which to count non-zeros.<br></br>
        ///     Default is None, meaning that non-zeros will be counted
        ///     along a flattened version of a.
        /// </param>
        /// <returns>
        ///     Number of non-zero values in the array along a given axis.<br></br>
        ///     Otherwise, the total number of non-zero values in the array
        ///     is returned.
        /// </returns>
        public static NDarray<int> count_nonzero(this NDarray a, Axis axis)
        {
            //auto-generated code, do not change
            var __self__ = self;
            var pyargs = ToTuple(new object[]
            {
                a
            });
            using var kwargs = new PyDict();
            if (axis != null) kwargs["axis"] = ToPython(axis);
            dynamic py = __self__.InvokeMethod("count_nonzero", pyargs, kwargs);
            return ToCsharp<NDarray<int>>(py);
        }

        /// <summary>
        ///     Counts the number of non-zero values in the array a.<br></br>
        ///     The word “non-zero” is in reference to the Python 2.x
        ///     built-in method __nonzero__() (renamed __bool__()
        ///     in Python 3.x) of Python objects that tests an object’s
        ///     “truthfulness”. For example, any number is considered
        ///     truthful if it is nonzero, whereas any string is considered
        ///     truthful if it is not the empty string.<br></br>
        ///     Thus, this function
        ///     (recursively) counts how many elements in a (and in
        ///     sub-arrays thereof) have their __nonzero__() or __bool__()
        ///     method evaluated to True.
        /// </summary>
        /// <param name="a">
        ///     The array for which to count non-zeros.
        /// </param>
        /// <returns>
        ///     Number of non-zero values in the array along a given axis.<br></br>
        ///     Otherwise, the total number of non-zero values in the array
        ///     is returned.
        /// </returns>
        public static int count_nonzero(this NDarray a)
        {
            //auto-generated code, do not change
            var __self__ = self;
            var pyargs = ToTuple(new object[]
            {
                a
            });
            using var kwargs = new PyDict();
            dynamic py = __self__.InvokeMethod("count_nonzero", pyargs, kwargs);
            return ToCsharp<int>(py);
        }
    }
}