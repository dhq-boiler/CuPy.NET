// Copyright (c) 2019 by the SciSharp Team
// Code generated by CodeMinion: https://github.com/SciSharp/CodeMinion

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cupy.UnitTest
{
    [TestClass]
    public class Cupy_sortingTest : BaseTestCase
    {
        [TestMethod]
        public void sortTest()
        {
            // >>> a = cp.array([[1,4],[3,1]])
            // >>> cp.sort(a)                # sort along the last axis
            // array([[1, 4],
            //        [1, 3]])
            // >>> cp.sort(a, axis=None)     # sort the flattened array
            // array([1, 1, 3, 4])
            // >>> cp.sort(a, axis=0)        # sort along the first axis
            // array([[1, 1],
            //        [3, 4]])
            // 

            var a = cp.array(new[,] { { 1, 4 }, { 3, 1 } });
            var given = a.sort(); // sort along the last axis
            var expected =
                "array([[1, 4],\n" +
                "       [1, 3]])";
            Assert.AreEqual(expected, given.repr);
            given = a.sort(null); // sort the flattened array
            expected =
                "array([1, 1, 3, 4])";
            Assert.AreEqual(expected, given.repr);
            given = a.sort(0); // sort along the first axis
            expected =
                "array([[1, 1],\n" +
                "       [3, 4]])";
            Assert.AreEqual(expected, given.repr);

            // Use the order keyword to specify a field to use when sorting a
            // structured array:

            // >>> dtype = [('name', 'S10'), ('height', float), ('age', int)]
            // >>> values = [('Arthur', 1.8, 41), ('Lancelot', 1.9, 38),
            // ...           ('Galahad', 1.7, 38)]
            // >>> a = cp.array(values, dtype=dtype)       # create a structured array
            // >>> cp.sort(a, order='height')                        
            // array([('Galahad', 1.7, 38), ('Arthur', 1.8, 41),
            //        ('Lancelot', 1.8999999999999999, 38)],
            //       dtype=[('name', '|S10'), ('height', '<f8'), ('age', '<i4')])
            // 

#if TODO
             given = dtype = [('name', 'S10'), ('height', float), ('age', int)];
             given = values = [('Arthur', 1.8, 41), ('Lancelot', 1.9, 38),;
             expected =
                "...           ('Galahad', 1.7, 38)]";
            Assert.AreEqual(expected, given.repr);
             given = a = cp.array(values, dtype = dtype)       # create a structured array;
             given = cp.sort(a, order = 'height')                        ;
             expected =
                "array([('Galahad', 1.7, 38), ('Arthur', 1.8, 41),\n" +
                "       ('Lancelot', 1.8999999999999999, 38)],\n" +
                "      dtype=[('name', '|S10'), ('height', '<f8'), ('age', '<i4')])";
            Assert.AreEqual(expected, given.repr);
#endif
            // Sort by age, then height if ages are equal:

            // >>> cp.sort(a, order=['age', 'height'])               
            // array([('Galahad', 1.7, 38), ('Lancelot', 1.8999999999999999, 38),
            //        ('Arthur', 1.8, 41)],
            //       dtype=[('name', '|S10'), ('height', '<f8'), ('age', '<i4')])
            // 

#if TODO
             given = cp.sort(a, order = {'age', 'height'})               ;
             expected =
                "array([('Galahad', 1.7, 38), ('Lancelot', 1.8999999999999999, 38),\n" +
                "       ('Arthur', 1.8, 41)],\n" +
                "      dtype=[('name', '|S10'), ('height', '<f8'), ('age', '<i4')])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void lexsortTest()
        {
            // Sort names: first by surname, then by name.

            // >>> surnames =    ('Hertz',    'Galilei', 'Hertz')
            // >>> first_names = ('Heinrich', 'Galileo', 'Gustav')
            // >>> ind = cp.lexsort((first_names, surnames))
            // >>> ind
            // array([1, 2, 0])
            // 

#if TODO
            var given = surnames = ('Hertz',    'Galilei', 'Hertz');
             given = first_names = ('Heinrich', 'Galileo', 'Gustav');
             given = ind = cp.lexsort((first_names, surnames));
             given = ind;
            var expected =
                "array([1, 2, 0])";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> [surnames[i] + ", " + first_names[i] for i in ind]
            // ['Galilei, Galileo', 'Hertz, Gustav', 'Hertz, Heinrich']
            // 

#if TODO
             given = [surnames[i] + ", " + first_names[i] for i in ind];
             expected =
                "['Galilei, Galileo', 'Hertz, Gustav', 'Hertz, Heinrich']";
            Assert.AreEqual(expected, given.repr);
#endif
            // Sort two columns of numbers:

            // >>> a = [1,5,1,4,3,4,4] # First column
            // >>> b = [9,4,0,4,0,2,1] # Second column
            // >>> ind = cp.lexsort((b,a)) # Sort by a, then by b
            // >>> print(ind)
            // [2 0 4 6 5 3 1]
            // 

#if TODO
             given = a = [1,5,1,4,3,4,4] # First column;
             given = b = [9,4,0,4,0,2,1] # Second column;
             given = ind = cp.lexsort((b,a)) # Sort by a, then by b;
             given = print(ind);
             expected =
                "[2 0 4 6 5 3 1]";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> [(a[i],b[i]) for i in ind]
            // [(1, 0), (1, 9), (3, 0), (4, 1), (4, 2), (4, 4), (5, 4)]
            // 

#if TODO
             given = [(a[i],b[i]) for i in ind];
             expected =
                "[(1, 0), (1, 9), (3, 0), (4, 1), (4, 2), (4, 4), (5, 4)]";
            Assert.AreEqual(expected, given.repr);
#endif
            // Note that sorting is first according to the elements of a.
            // Secondary sorting is according to the elements of b.

            // A normal argsort would have yielded:

            // >>> [(a[i],b[i]) for i in cp.argsort(a)]
            // [(1, 9), (1, 0), (3, 0), (4, 4), (4, 2), (4, 1), (5, 4)]
            // 

#if TODO
             given = {(a{i},b{i}) for i in cp.argsort(a)};
             expected =
                "[(1, 9), (1, 0), (3, 0), (4, 4), (4, 2), (4, 1), (5, 4)]";
            Assert.AreEqual(expected, given.repr);
#endif
            // Structured arrays are sorted lexically by argsort:

            // >>> x = cp.array([(1,9), (5,4), (1,0), (4,4), (3,0), (4,2), (4,1)],
            // ...              dtype=cp.dtype([('x', int), ('y', int)]))
            // 

#if TODO
             given = x = cp.array({(1,9), (5,4), (1,0), (4,4), (3,0), (4,2), (4,1)},;
             expected =
                "...              dtype=cp.dtype([('x', int), ('y', int)]))";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> cp.argsort(x) # or cp.argsort(x, order=('x', 'y'))
            // array([2, 0, 4, 6, 5, 3, 1])
            // 

#if TODO
             given = cp.argsort(x) # or cp.argsort(x, order = ('x', 'y'));
             expected =
                "array([2, 0, 4, 6, 5, 3, 1])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void argsortTest()
        {
            // One dimensional array:

            // >>> x = cp.array([3, 1, 2])
            // >>> cp.argsort(x)
            // array([1, 2, 0])
            // 

#if TODO
            var given = x = cp.array({3, 1, 2});
             given = cp.argsort(x);
            var expected =
                "array([1, 2, 0])";
            Assert.AreEqual(expected, given.repr);
#endif
            // Two-dimensional array:

            // >>> x = cp.array([[0, 3], [2, 2]])
            // >>> x
            // array([[0, 3],
            //        [2, 2]])
            // 

#if TODO
             given = x = cp.array({{0, 3}, {2, 2}});
             given = x;
             expected =
                "array([[0, 3],\n" +
                "       [2, 2]])";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> cp.argsort(x, axis=0)  # sorts along first axis (down)
            // array([[0, 1],
            //        [1, 0]])
            // 

#if TODO
             given = cp.argsort(x, axis = 0)  # sorts along first axis (down);
             expected =
                "array([[0, 1],\n" +
                "       [1, 0]])";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> cp.argsort(x, axis=1)  # sorts along last axis (across)
            // array([[0, 1],
            //        [0, 1]])
            // 

#if TODO
             given = cp.argsort(x, axis = 1)  # sorts along last axis (across);
             expected =
                "array([[0, 1],\n" +
                "       [0, 1]])";
            Assert.AreEqual(expected, given.repr);
#endif
            // Indices of the sorted elements of a N-dimensional array:

            // >>> ind = cp.unravel_index(cp.argsort(x, axis=None), x.shape)
            // >>> ind
            // (array([0, 1, 1, 0]), array([0, 0, 1, 1]))
            // >>> x[ind]  # same as cp.sort(x, axis=None)
            // array([0, 2, 2, 3])
            // 

#if TODO
             given = ind = cp.unravel_index(cp.argsort(x, axis = None), x.shape);
             given = ind;
             expected =
                "(array([0, 1, 1, 0]), array([0, 0, 1, 1]))";
            Assert.AreEqual(expected, given.repr);
             given = x{ind}  # same as cp.sort(x, axis = None);
             expected =
                "array([0, 2, 2, 3])";
            Assert.AreEqual(expected, given.repr);
#endif
            // Sorting with keys:

            // >>> x = cp.array([(1, 0), (0, 1)], dtype=[('x', '<i4'), ('y', '<i4')])
            // >>> x
            // array([(1, 0), (0, 1)],
            //       dtype=[('x', '<i4'), ('y', '<i4')])
            // 

#if TODO
             given = x = cp.array({(1, 0), (0, 1)}, dtype = {('x', '<i4'), ('y', '<i4')});
             given = x;
             expected =
                "array([(1, 0), (0, 1)],\n" +
                "      dtype=[('x', '<i4'), ('y', '<i4')])";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> cp.argsort(x, order=('x','y'))
            // array([1, 0])
            // 

#if TODO
             given = cp.argsort(x, order = ('x','y'));
             expected =
                "array([1, 0])";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> cp.argsort(x, order=('y','x'))
            // array([0, 1])
            // 

#if TODO
             given = cp.argsort(x, order = ('y','x'));
             expected =
                "array([0, 1])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void sort_complexTest()
        {
            // >>> cp.sort_complex([5, 3, 6, 2, 1])
            // array([ 1.+0.j,  2.+0.j,  3.+0.j,  5.+0.j,  6.+0.j])
            // 

#if TODO
            var given = cp.sort_complex({5, 3, 6, 2, 1});
            var expected =
                "array([ 1.+0.j,  2.+0.j,  3.+0.j,  5.+0.j,  6.+0.j])";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> cp.sort_complex([1 + 2j, 2 - 1j, 3 - 2j, 3 - 3j, 3 + 5j])
            // array([ 1.+2.j,  2.-1.j,  3.-3.j,  3.-2.j,  3.+5.j])
            // 

#if TODO
             given = cp.sort_complex({1 + 2j, 2 - 1j, 3 - 2j, 3 - 3j, 3 + 5j});
             expected =
                "array([ 1.+2.j,  2.-1.j,  3.-3.j,  3.-2.j,  3.+5.j])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void partitionTest()
        {
            // >>> a = cp.array([3, 4, 2, 1])
            // >>> cp.partition(a, 3)
            // array([2, 1, 3, 4])
            // 

#if TODO
            var given = a = cp.array({3, 4, 2, 1});
             given = cp.partition(a, 3);
            var expected =
                "array([2, 1, 3, 4])";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> cp.partition(a, (1, 3))
            // array([1, 2, 3, 4])
            // 

#if TODO
             given = cp.partition(a, (1, 3));
             expected =
                "array([1, 2, 3, 4])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void argpartitionTest()
        {
            // One dimensional array:

            // >>> x = cp.array([3, 4, 2, 1])
            // >>> x[cp.argpartition(x, 3)]
            // array([2, 1, 3, 4])
            // >>> x[cp.argpartition(x, (1, 3))]
            // array([1, 2, 3, 4])
            // 

#if TODO
            var given = x = cp.array({3, 4, 2, 1});
             given = x{cp.argpartition(x, 3)};
            var expected =
                "array([2, 1, 3, 4])";
            Assert.AreEqual(expected, given.repr);
             given = x{cp.argpartition(x, (1, 3))};
             expected =
                "array([1, 2, 3, 4])";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> x = [3, 4, 2, 1]
            // >>> cp.array(x)[cp.argpartition(x, 3)]
            // array([2, 1, 3, 4])
            // 

#if TODO
             given = x = [3, 4, 2, 1];
             given = cp.array(x){cp.argpartition(x, 3)};
             expected =
                "array([2, 1, 3, 4])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void argmaxTest()
        {
            // >>> a = cp.arange(6).reshape(2,3) + 10
            // >>> a
            // array([[10, 11, 12],
            //        [13, 14, 15]])
            // >>> cp.argmax(a)
            // 5
            // >>> cp.argmax(a, axis=0)
            // array([1, 1, 1])
            // >>> cp.argmax(a, axis=1)
            // array([2, 2])
            // 

#if TODO
            var given = a = cp.arange(6).reshape(2,3) + 10;
             given = a;
            var expected =
                "array([[10, 11, 12],\n" +
                "       [13, 14, 15]])";
            Assert.AreEqual(expected, given.repr);
             given = cp.argmax(a);
             expected =
                "5";
            Assert.AreEqual(expected, given.repr);
             given = cp.argmax(a, axis = 0);
             expected =
                "array([1, 1, 1])";
            Assert.AreEqual(expected, given.repr);
             given = cp.argmax(a, axis = 1);
             expected =
                "array([2, 2])";
            Assert.AreEqual(expected, given.repr);
#endif
            // Indexes of the maximal elements of a N-dimensional array:

            // >>> ind = cp.unravel_index(cp.argmax(a, axis=None), a.shape)
            // >>> ind
            // (1, 2)
            // >>> a[ind]
            // 15
            // 

#if TODO
             given = ind = cp.unravel_index(cp.argmax(a, axis = None), a.shape);
             given = ind;
             expected =
                "(1, 2)";
            Assert.AreEqual(expected, given.repr);
             given = a[ind];
             expected =
                "15";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> b = cp.arange(6)
            // >>> b[1] = 5
            // >>> b
            // array([0, 5, 2, 3, 4, 5])
            // >>> cp.argmax(b)  # Only the first occurrence is returned.
            // 1
            // 

#if TODO
             given = b = cp.arange(6);
             given = b[1] = 5;
             given = b;
             expected =
                "array([0, 5, 2, 3, 4, 5])";
            Assert.AreEqual(expected, given.repr);
             given = cp.argmax(b)  # Only the first occurrence is returned.;
             expected =
                "1";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void nanargmaxTest()
        {
            // >>> a = cp.array([[cp.nan, 4], [2, 3]])
            // >>> cp.argmax(a)
            // 0
            // >>> cp.nanargmax(a)
            // 1
            // >>> cp.nanargmax(a, axis=0)
            // array([1, 0])
            // >>> cp.nanargmax(a, axis=1)
            // array([1, 1])
            // 

#if TODO
            var given = a = cp.array({{cp.nan, 4}, {2, 3}});
             given = cp.argmax(a);
            var expected =
                "0";
            Assert.AreEqual(expected, given.repr);
             given = cp.nanargmax(a);
             expected =
                "1";
            Assert.AreEqual(expected, given.repr);
             given = cp.nanargmax(a, axis = 0);
             expected =
                "array([1, 0])";
            Assert.AreEqual(expected, given.repr);
             given = cp.nanargmax(a, axis = 1);
             expected =
                "array([1, 1])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void argminTest()
        {
            // >>> a = cp.arange(6).reshape(2,3) + 10
            // >>> a
            // array([[10, 11, 12],
            //        [13, 14, 15]])
            // >>> cp.argmin(a)
            // 0
            // >>> cp.argmin(a, axis=0)
            // array([0, 0, 0])
            // >>> cp.argmin(a, axis=1)
            // array([0, 0])
            // 

#if TODO
            var given = a = cp.arange(6).reshape(2,3) + 10;
             given = a;
            var expected =
                "array([[10, 11, 12],\n" +
                "       [13, 14, 15]])";
            Assert.AreEqual(expected, given.repr);
             given = cp.argmin(a);
             expected =
                "0";
            Assert.AreEqual(expected, given.repr);
             given = cp.argmin(a, axis = 0);
             expected =
                "array([0, 0, 0])";
            Assert.AreEqual(expected, given.repr);
             given = cp.argmin(a, axis = 1);
             expected =
                "array([0, 0])";
            Assert.AreEqual(expected, given.repr);
#endif
            // Indices of the minimum elements of a N-dimensional array:

            // >>> ind = cp.unravel_index(cp.argmin(a, axis=None), a.shape)
            // >>> ind
            // (0, 0)
            // >>> a[ind]
            // 10
            // 

#if TODO
             given = ind = cp.unravel_index(cp.argmin(a, axis = None), a.shape);
             given = ind;
             expected =
                "(0, 0)";
            Assert.AreEqual(expected, given.repr);
             given = a[ind];
             expected =
                "10";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> b = cp.arange(6) + 10
            // >>> b[4] = 10
            // >>> b
            // array([10, 11, 12, 13, 10, 15])
            // >>> cp.argmin(b)  # Only the first occurrence is returned.
            // 0
            // 

#if TODO
             given = b = cp.arange(6) + 10;
             given = b[4] = 10;
             given = b;
             expected =
                "array([10, 11, 12, 13, 10, 15])";
            Assert.AreEqual(expected, given.repr);
             given = cp.argmin(b)  # Only the first occurrence is returned.;
             expected =
                "0";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void nanargminTest()
        {
            // >>> a = cp.array([[cp.nan, 4], [2, 3]])
            // >>> cp.argmin(a)
            // 0
            // >>> cp.nanargmin(a)
            // 2
            // >>> cp.nanargmin(a, axis=0)
            // array([1, 1])
            // >>> cp.nanargmin(a, axis=1)
            // array([1, 0])
            // 

#if TODO
            var given = a = cp.array({{cp.nan, 4}, {2, 3}});
             given = cp.argmin(a);
            var expected =
                "0";
            Assert.AreEqual(expected, given.repr);
             given = cp.nanargmin(a);
             expected =
                "2";
            Assert.AreEqual(expected, given.repr);
             given = cp.nanargmin(a, axis = 0);
             expected =
                "array([1, 1])";
            Assert.AreEqual(expected, given.repr);
             given = cp.nanargmin(a, axis = 1);
             expected =
                "array([1, 0])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void argwhereTest()
        {
            // >>> x = cp.arange(6).reshape(2,3)
            // >>> x
            // array([[0, 1, 2],
            //        [3, 4, 5]])
            // >>> cp.argwhere(x>1)
            // array([[0, 2],
            //        [1, 0],
            //        [1, 1],
            //        [1, 2]])
            // 

#if TODO
            var given = x = cp.arange(6).reshape(2,3);
             given = x;
            var expected =
                "array([[0, 1, 2],\n" +
                "       [3, 4, 5]])";
            Assert.AreEqual(expected, given.repr);
             given = cp.argwhere(x>1);
             expected =
                "array([[0, 2],\n" +
                "       [1, 0],\n" +
                "       [1, 1],\n" +
                "       [1, 2]])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void nonzeroTest()
        {
            // >>> x = cp.array([[3, 0, 0], [0, 4, 0], [5, 6, 0]])
            // >>> x
            // array([[3, 0, 0],
            //        [0, 4, 0],
            //        [5, 6, 0]])
            // >>> cp.nonzero(x)
            // (array([0, 1, 2, 2]), array([0, 1, 0, 1]))
            // 

#if TODO
            var given = x = cp.array({{3, 0, 0}, {0, 4, 0}, {5, 6, 0}});
             given = x;
            var expected =
                "array([[3, 0, 0],\n" +
                "       [0, 4, 0],\n" +
                "       [5, 6, 0]])";
            Assert.AreEqual(expected, given.repr);
             given = cp.nonzero(x);
             expected =
                "(array([0, 1, 2, 2]), array([0, 1, 0, 1]))";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> x[cp.nonzero(x)]
            // array([3, 4, 5, 6])
            // >>> cp.transpose(cp.nonzero(x))
            // array([[0, 0],
            //        [1, 1],
            //        [2, 0],
            //        [2, 1])
            // 

#if TODO
             given = x{cp.nonzero(x)};
             expected =
                "array([3, 4, 5, 6])";
            Assert.AreEqual(expected, given.repr);
             given = cp.transpose(cp.nonzero(x));
             expected =
                "array([[0, 0],\n" +
                "       [1, 1],\n" +
                "       [2, 0],\n" +
                "       [2, 1])";
            Assert.AreEqual(expected, given.repr);
#endif
            // A common use for nonzero is to find the indices of an array, where
            // a condition is True.  Given an array a, the condition a > 3 is a
            // boolean array and since False is interpreted as 0, cp.nonzero(a > 3)
            // yields the indices of the a where the condition is true.

            // >>> a = cp.array([[1, 2, 3], [4, 5, 6], [7, 8, 9]])
            // >>> a > 3
            // array([[False, False, False],
            //        [ True,  True,  True],
            //        [ True,  True,  True]])
            // >>> cp.nonzero(a > 3)
            // (array([1, 1, 1, 2, 2, 2]), array([0, 1, 2, 0, 1, 2]))
            // 

#if TODO
             given = a = cp.array({{1, 2, 3}, {4, 5, 6}, {7, 8, 9}});
             given = a > 3;
             expected =
                "array([[False, False, False],\n" +
                "       [ True,  True,  True],\n" +
                "       [ True,  True,  True]])";
            Assert.AreEqual(expected, given.repr);
             given = cp.nonzero(a > 3);
             expected =
                "(array([1, 1, 1, 2, 2, 2]), array([0, 1, 2, 0, 1, 2]))";
            Assert.AreEqual(expected, given.repr);
#endif
            // Using this result to index a is equivalent to using the mask directly:

            // >>> a[cp.nonzero(a > 3)]
            // array([4, 5, 6, 7, 8, 9])
            // >>> a[a > 3]  # prefer this spelling
            // array([4, 5, 6, 7, 8, 9])
            // 

#if TODO
             given = a{cp.nonzero(a > 3)};
             expected =
                "array([4, 5, 6, 7, 8, 9])";
            Assert.AreEqual(expected, given.repr);
             given = a[a > 3]  # prefer this spelling;
             expected =
                "array([4, 5, 6, 7, 8, 9])";
            Assert.AreEqual(expected, given.repr);
#endif
            // nonzero can also be called as a method of the array.

            // >>> (a > 3).nonzero()
            // (array([1, 1, 1, 2, 2, 2]), array([0, 1, 2, 0, 1, 2]))
            // 

#if TODO
             given = (a > 3).nonzero();
             expected =
                "(array([1, 1, 1, 2, 2, 2]), array([0, 1, 2, 0, 1, 2]))";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void flatnonzeroTest()
        {
            // >>> x = cp.arange(-2, 3)
            // >>> x
            // array([-2, -1,  0,  1,  2])
            // >>> cp.flatnonzero(x)
            // array([0, 1, 3, 4])
            // 

#if TODO
            var given = x = cp.arange(-2, 3);
             given = x;
            var expected =
                "array([-2, -1,  0,  1,  2])";
            Assert.AreEqual(expected, given.repr);
             given = cp.flatnonzero(x);
             expected =
                "array([0, 1, 3, 4])";
            Assert.AreEqual(expected, given.repr);
#endif
            // Use the indices of the non-zero elements as an index array to extract
            // these elements:

            // >>> x.ravel()[cp.flatnonzero(x)]
            // array([-2, -1,  1,  2])
            // 

#if TODO
             given = x.ravel(){cp.flatnonzero(x)};
             expected =
                "array([-2, -1,  1,  2])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void whereTest()
        {
            // >>> a = cp.arange(10)
            // >>> a
            // array([0, 1, 2, 3, 4, 5, 6, 7, 8, 9])
            // >>> cp.where(a < 5, a, 10*a)
            // array([ 0,  1,  2,  3,  4, 50, 60, 70, 80, 90])
            // 

#if TODO
            var given = a = cp.arange(10);
             given = a;
            var expected =
                "array([0, 1, 2, 3, 4, 5, 6, 7, 8, 9])";
            Assert.AreEqual(expected, given.repr);
             given = cp.where(a < 5, a, 10*a);
             expected =
                "array([ 0,  1,  2,  3,  4, 50, 60, 70, 80, 90])";
            Assert.AreEqual(expected, given.repr);
#endif
            // This can be used on multidimensional arrays too:

            // >>> cp.where([[True, False], [True, True]],
            // ...          [[1, 2], [3, 4]],
            // ...          [[9, 8], [7, 6]])
            // array([[1, 8],
            //        [3, 4]])
            // 

#if TODO
             given = cp.where({{True, False}, {True, True}},;
             expected =
                "...          [[1, 2], [3, 4]],\n" +
                "...          [[9, 8], [7, 6]])\n" +
                "array([[1, 8],\n" +
                "       [3, 4]])";
            Assert.AreEqual(expected, given.repr);
#endif
            // The shapes of x, y, and the condition are broadcast together:

            // >>> x, y = cp.ogrid[:3, :4]
            // >>> cp.where(x < y, x, 10 + y)  # both x and 10+y are broadcast
            // array([[10,  0,  0,  0],
            //        [10, 11,  1,  1],
            //        [10, 11, 12,  2]])
            // 

#if TODO
             given = x, y = cp.ogrid{:3, :4};
             given = cp.where(x < y, x, 10 + y)  # both x and 10+y are broadcast;
             expected =
                "array([[10,  0,  0,  0],\n" +
                "       [10, 11,  1,  1],\n" +
                "       [10, 11, 12,  2]])";
            Assert.AreEqual(expected, given.repr);
#endif
            // >>> a = cp.array([[0, 1, 2],
            // ...               [0, 2, 4],
            // ...               [0, 3, 6]])
            // >>> cp.where(a < 4, a, -1)  # -1 is broadcast
            // array([[ 0,  1,  2],
            //        [ 0,  2, -1],
            //        [ 0,  3, -1]])
            // 

#if TODO
             given = a = cp.array({{0, 1, 2},;
             expected =
                "...               [0, 2, 4],\n" +
                "...               [0, 3, 6]])";
            Assert.AreEqual(expected, given.repr);
             given = cp.where(a < 4, a, -1)  # -1 is broadcast;
             expected =
                "array([[ 0,  1,  2],\n" +
                "       [ 0,  2, -1],\n" +
                "       [ 0,  3, -1]])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void searchsortedTest()
        {
            // >>> cp.searchsorted([1,2,3,4,5], 3)
            // 2
            // >>> cp.searchsorted([1,2,3,4,5], 3, side='right')
            // 3
            // >>> cp.searchsorted([1,2,3,4,5], [-10, 10, 2, 3])
            // array([0, 5, 1, 2])
            // 

#if TODO
            var given = cp.searchsorted({1,2,3,4,5}, 3);
            var expected =
                "2";
            Assert.AreEqual(expected, given.repr);
             given = cp.searchsorted({1,2,3,4,5}, 3, side = 'right');
             expected =
                "3";
            Assert.AreEqual(expected, given.repr);
             given = cp.searchsorted({1,2,3,4,5}, {-10, 10, 2, 3});
             expected =
                "array([0, 5, 1, 2])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void extractTest()
        {
            // >>> arr = cp.arange(12).reshape((3, 4))
            // >>> arr
            // array([[ 0,  1,  2,  3],
            //        [ 4,  5,  6,  7],
            //        [ 8,  9, 10, 11]])
            // >>> condition = cp.mod(arr, 3)==0
            // >>> condition
            // array([[ True, False, False,  True],
            //        [False, False,  True, False],
            //        [False,  True, False, False]])
            // >>> cp.extract(condition, arr)
            // array([0, 3, 6, 9])
            // 

#if TODO
            var given = arr = cp.arange(12).reshape((3, 4));
             given = arr;
            var expected =
                "array([[ 0,  1,  2,  3],\n" +
                "       [ 4,  5,  6,  7],\n" +
                "       [ 8,  9, 10, 11]])";
            Assert.AreEqual(expected, given.repr);
             given = condition = cp.mod(arr, 3)==0;
             given = condition;
             expected =
                "array([[ True, False, False,  True],\n" +
                "       [False, False,  True, False],\n" +
                "       [False,  True, False, False]])";
            Assert.AreEqual(expected, given.repr);
             given = cp.extract(condition, arr);
             expected =
                "array([0, 3, 6, 9])";
            Assert.AreEqual(expected, given.repr);
#endif
            // If condition is boolean:

            // >>> arr[condition]
            // array([0, 3, 6, 9])
            // 

#if TODO
             given = arr[condition];
             expected =
                "array([0, 3, 6, 9])";
            Assert.AreEqual(expected, given.repr);
#endif
        }


        [TestMethod]
        public void count_nonzeroTest()
        {
            // >>> cp.count_nonzero(cp.eye(4))
            // 4
            // >>> cp.count_nonzero([[0,1,7,0,0],[3,0,0,2,19]])
            // 5
            // >>> cp.count_nonzero([[0,1,7,0,0],[3,0,0,2,19]], axis=0)
            // array([1, 1, 1, 1, 1])
            // >>> cp.count_nonzero([[0,1,7,0,0],[3,0,0,2,19]], axis=1)
            // array([2, 3])
            // 

#if TODO
            var given = cp.count_nonzero(cp.eye(4));
            var expected =
                "4";
            Assert.AreEqual(expected, given.repr);
             given = cp.count_nonzero({{0,1,7,0,0},{3,0,0,2,19}});
             expected =
                "5";
            Assert.AreEqual(expected, given.repr);
             given = cp.count_nonzero({{0,1,7,0,0},{3,0,0,2,19}}, axis = 0);
             expected =
                "array([1, 1, 1, 1, 1])";
            Assert.AreEqual(expected, given.repr);
             given = cp.count_nonzero({{0,1,7,0,0},{3,0,0,2,19}}, axis = 1);
             expected =
                "array([2, 3])";
            Assert.AreEqual(expected, given.repr);
#endif
        }
    }
}