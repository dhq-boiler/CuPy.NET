using Python.Runtime;

namespace Cupy
{
    public static partial class cp
    {
        public static R ElementwiseKernel<R, T1>(string in_params, string out_params, string operation, T1 t1,
                                                 string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
                                                 bool return_tuple = false)
        {
            var pyName = name != "kernel" ? ToPython(name) : null;
            var pyReduce = reduce_dims != true ? ToPython(reduce_dims) : null;
            var pyPreamble = preamble != "" ? ToPython(preamble) : null;
            var pyNoReturn = no_return != false ? ToPython(no_return) : null;
            var pyReturnTuple = return_tuple != false ? ToPython(return_tuple) : null;

            try
            {
                using var pyargs = ToTuple(new object[]
                {
                   in_params,
                   out_params,
                   operation
                });
                using var kwargs = new PyDict();
                if (name != "kernel") kwargs["name"] = pyName;
                if (reduce_dims != true) kwargs["reduce_dims"] = pyReduce;
                if (preamble != "") kwargs["preamble"] = pyPreamble;
                if (no_return != false) kwargs["no_return"] = pyNoReturn;
                if (return_tuple != false) kwargs["return_tuple"] = pyReturnTuple;
                using dynamic elmKernel = self.GetAttr("ElementwiseKernel");
                using dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                    preamble: preamble, no_return: no_return, return_tuple: return_tuple);
                using dynamic pyT1 = t1.ToPython();
                using dynamic result = instance.__call__(pyT1);
                return result.As<R>();
            }
            finally
            {
                if (pyName != null) pyName.Dispose();
                if (pyReduce != null) pyReduce.Dispose();
                if (pyPreamble != null) pyPreamble.Dispose();
                if (pyNoReturn != null) pyNoReturn.Dispose();
                if (pyReturnTuple != null) pyReturnTuple.Dispose();
            }
        }

        public static R ElementwiseKernel<R, T1, T2>(string in_params, string out_params, string operation, T1 t1, T2 t2,
                                                     string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
                                                     bool return_tuple = false)
        {
            var pyName = name != "kernel" ? ToPython(name) : null;
            var pyReduce = reduce_dims != true ? ToPython(reduce_dims) : null;
            var pyPreamble = preamble != "" ? ToPython(preamble) : null;
            var pyNoReturn = no_return != false ? ToPython(no_return) : null;
            var pyReturnTuple = return_tuple != false ? ToPython(return_tuple) : null;

            try
            {
                using var pyargs = ToTuple(new object[]
                {
                   in_params,
                   out_params,
                   operation
                });
                using var kwargs = new PyDict();
                if (name != "kernel") kwargs["name"] = pyName;
                if (reduce_dims != true) kwargs["reduce_dims"] = pyReduce;
                if (preamble != "") kwargs["preamble"] = pyPreamble;
                if (no_return != false) kwargs["no_return"] = pyNoReturn;
                if (return_tuple != false) kwargs["return_tuple"] = pyReturnTuple;
                using dynamic elmKernel = self.GetAttr("ElementwiseKernel");
                using dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                    preamble: preamble, no_return: no_return, return_tuple: return_tuple);
                using dynamic pyT1 = t1.ToPython();
                using dynamic pyT2 = t2.ToPython();
                using dynamic result = instance.__call__(pyT1, pyT2);
                return result.As<R>();
            }
            finally
            {
                if (pyName != null) pyName.Dispose();
                if (pyReduce != null) pyReduce.Dispose();
                if (pyPreamble != null) pyPreamble.Dispose();
                if (pyNoReturn != null) pyNoReturn.Dispose();
                if (pyReturnTuple != null) pyReturnTuple.Dispose();
            }
        }

        public static R ElementwiseKernel<R, T1, T2, T3>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3,
                                                         string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
                                                         bool return_tuple = false)
        {
            var pyName = name != "kernel" ? ToPython(name) : null;
            var pyReduce = reduce_dims != true ? ToPython(reduce_dims) : null;
            var pyPreamble = preamble != "" ? ToPython(preamble) : null;
            var pyNoReturn = no_return != false ? ToPython(no_return) : null;
            var pyReturnTuple = return_tuple != false ? ToPython(return_tuple) : null;

            try
            {
                using var pyargs = ToTuple(new object[]
                {
                   in_params,
                   out_params,
                   operation
                });
                using var kwargs = new PyDict();
                if (name != "kernel") kwargs["name"] = pyName;
                if (reduce_dims != true) kwargs["reduce_dims"] = pyReduce;
                if (preamble != "") kwargs["preamble"] = pyPreamble;
                if (no_return != false) kwargs["no_return"] = pyNoReturn;
                if (return_tuple != false) kwargs["return_tuple"] = pyReturnTuple;
                using dynamic elmKernel = self.GetAttr("ElementwiseKernel");
                using dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                    preamble: preamble, no_return: no_return, return_tuple: return_tuple);
                using dynamic pyT1 = t1.ToPython();
                using dynamic pyT2 = t2.ToPython();
                using dynamic pyT3 = t3.ToPython();
                using dynamic result = instance.__call__(pyT1, pyT2, pyT3);
                return result.As<R>();
            }
            finally
            {
                if (pyName != null) pyName.Dispose();
                if (pyReduce != null) pyReduce.Dispose();
                if (pyPreamble != null) pyPreamble.Dispose();
                if (pyNoReturn != null) pyNoReturn.Dispose();
                if (pyReturnTuple != null) pyReturnTuple.Dispose();
            }
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4,
                                                             string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
                                                             bool return_tuple = false)
        {
            var pyName = name != "kernel" ? ToPython(name) : null;
            var pyReduce = reduce_dims != true ? ToPython(reduce_dims) : null;
            var pyPreamble = preamble != "" ? ToPython(preamble) : null;
            var pyNoReturn = no_return != false ? ToPython(no_return) : null;
            var pyReturnTuple = return_tuple != false ? ToPython(return_tuple) : null;

            try
            {
                using var pyargs = ToTuple(new object[]
                {
                   in_params,
                   out_params,
                   operation
                });
                using var kwargs = new PyDict();
                if (name != "kernel") kwargs["name"] = pyName;
                if (reduce_dims != true) kwargs["reduce_dims"] = pyReduce;
                if (preamble != "") kwargs["preamble"] = pyPreamble;
                if (no_return != false) kwargs["no_return"] = pyNoReturn;
                if (return_tuple != false) kwargs["return_tuple"] = pyReturnTuple;
                using dynamic elmKernel = self.GetAttr("ElementwiseKernel");
                using dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                    preamble: preamble, no_return: no_return, return_tuple: return_tuple);
                using dynamic pyT1 = t1.ToPython();
                using dynamic pyT2 = t2.ToPython();
                using dynamic pyT3 = t3.ToPython();
                using dynamic pyT4 = t4.ToPython();
                using dynamic result = instance.__call__(pyT1, pyT2, pyT3, pyT4);
                return result.As<R>();
            }
            finally
            {
                if (pyName != null) pyName.Dispose();
                if (pyReduce != null) pyReduce.Dispose();
                if (pyPreamble != null) pyPreamble.Dispose();
                if (pyNoReturn != null) pyNoReturn.Dispose();
                if (pyReturnTuple != null) pyReturnTuple.Dispose();
            }
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5,
                                                                 string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
                                                                 bool return_tuple = false)
        {
            var pyName = name != "kernel" ? ToPython(name) : null;
            var pyReduce = reduce_dims != true ? ToPython(reduce_dims) : null;
            var pyPreamble = preamble != "" ? ToPython(preamble) : null;
            var pyNoReturn = no_return != false ? ToPython(no_return) : null;
            var pyReturnTuple = return_tuple != false ? ToPython(return_tuple) : null;

            try
            {
                using var pyargs = ToTuple(new object[]
                {
                   in_params,
                   out_params,
                   operation
                });
                using var kwargs = new PyDict();
                if (name != "kernel") kwargs["name"] = pyName;
                if (reduce_dims != true) kwargs["reduce_dims"] = pyReduce;
                if (preamble != "") kwargs["preamble"] = pyPreamble;
                if (no_return != false) kwargs["no_return"] = pyNoReturn;
                if (return_tuple != false) kwargs["return_tuple"] = pyReturnTuple;
                using dynamic elmKernel = self.GetAttr("ElementwiseKernel");
                using dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                    preamble: preamble, no_return: no_return, return_tuple: return_tuple);
                using dynamic pyT1 = t1.ToPython();
                using dynamic pyT2 = t2.ToPython();
                using dynamic pyT3 = t3.ToPython();
                using dynamic pyT4 = t4.ToPython();
                using dynamic pyT5 = t5.ToPython();
                using dynamic result = instance.__call__(pyT1, pyT2, pyT3, pyT4, pyT5);
                return result.As<R>();
            }
            finally
            {
                if (pyName != null) pyName.Dispose();
                if (pyReduce != null) pyReduce.Dispose();
                if (pyPreamble != null) pyPreamble.Dispose();
                if (pyNoReturn != null) pyNoReturn.Dispose();
                if (pyReturnTuple != null) pyReturnTuple.Dispose();
            }
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5, T6>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6,
                                                             string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
                                                             bool return_tuple = false)
        {
            var pyName = name != "kernel" ? ToPython(name) : null;
            var pyReduce = reduce_dims != true ? ToPython(reduce_dims) : null;
            var pyPreamble = preamble != "" ? ToPython(preamble) : null;
            var pyNoReturn = no_return != false ? ToPython(no_return) : null;
            var pyReturnTuple = return_tuple != false ? ToPython(return_tuple) : null;
            try
            {
                using var pyargs = ToTuple(new object[]
                {
                   in_params,
                   out_params,
                   operation
                });
                using var kwargs = new PyDict();
                if (name != "kernel") kwargs["name"] = pyName;
                if (reduce_dims != true) kwargs["reduce_dims"] = pyReduce;
                if (preamble != "") kwargs["preamble"] = pyPreamble;
                if (no_return != false) kwargs["no_return"] = pyNoReturn;
                if (return_tuple != false) kwargs["return_tuple"] = pyReturnTuple;
                using dynamic elmKernel = self.GetAttr("ElementwiseKernel");
                using dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                    preamble: preamble, no_return: no_return, return_tuple: return_tuple);
                using dynamic pyT1 = t1.ToPython();
                using dynamic pyT2 = t2.ToPython();
                using dynamic pyT3 = t3.ToPython();
                using dynamic pyT4 = t4.ToPython();
                using dynamic pyT5 = t5.ToPython();
                using dynamic pyT6 = t6.ToPython();
                using dynamic result = instance.__call__(pyT1, pyT2, pyT3, pyT4, pyT5, pyT6);
                return result.As<R>();
            }
            finally
            {
                if (pyName != null) pyName.Dispose();
                if (pyReduce != null) pyReduce.Dispose();
                if (pyPreamble != null) pyPreamble.Dispose();
                if (pyNoReturn != null) pyNoReturn.Dispose();
                if (pyReturnTuple != null) pyReturnTuple.Dispose();
            }
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5, T6, T7>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7,
                                                                         string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
                                                                         bool return_tuple = false)
        {
            var pyName = name != "kernel" ? ToPython(name) : null;
            var pyReduce = reduce_dims != true ? ToPython(reduce_dims) : null;
            var pyPreamble = preamble != "" ? ToPython(preamble) : null;
            var pyNoReturn = no_return != false ? ToPython(no_return) : null;
            var pyReturnTuple = return_tuple != false ? ToPython(return_tuple) : null;
            try
            {
                using var pyargs = ToTuple(new object[]
                {
                   in_params,
                   out_params,
                   operation
                });
                using var kwargs = new PyDict();
                if (name != "kernel") kwargs["name"] = pyName;
                if (reduce_dims != true) kwargs["reduce_dims"] = pyReduce;
                if (preamble != "") kwargs["preamble"] = pyPreamble;
                if (no_return != false) kwargs["no_return"] = pyNoReturn;
                if (return_tuple != false) kwargs["return_tuple"] = pyReturnTuple;
                using dynamic elmKernel = self.GetAttr("ElementwiseKernel");
                using dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                    preamble: preamble, no_return: no_return, return_tuple: return_tuple);
                using dynamic pyT1 = t1.ToPython();
                using dynamic pyT2 = t2.ToPython();
                using dynamic pyT3 = t3.ToPython();
                using dynamic pyT4 = t4.ToPython();
                using dynamic pyT5 = t5.ToPython();
                using dynamic pyT6 = t6.ToPython();
                using dynamic pyT7 = t7.ToPython();
                using dynamic result = instance.__call__(pyT1, pyT2, pyT3, pyT4, pyT5, pyT6, pyT7);
                return result.As<R>();
            }
            finally
            {
                if (pyName != null) pyName.Dispose();
                if (pyReduce != null) pyReduce.Dispose();
                if (pyPreamble != null) pyPreamble.Dispose();
                if (pyNoReturn != null) pyNoReturn.Dispose();
                if (pyReturnTuple != null) pyReturnTuple.Dispose();
            }
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5, T6, T7, T8>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8,
                                                                             string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
                                                                             bool return_tuple = false)
        {
            var pyName = name != "kernel" ? ToPython(name) : null;
            var pyReduce = reduce_dims != true ? ToPython(reduce_dims) : null;
            var pyPreamble = preamble != "" ? ToPython(preamble) : null;
            var pyNoReturn = no_return != false ? ToPython(no_return) : null;
            var pyReturnTuple = return_tuple != false ? ToPython(return_tuple) : null;
            try
            {
                using var pyargs = ToTuple(new object[]
                {
                   in_params,
                   out_params,
                   operation
                });
                using var kwargs = new PyDict();
                if (name != "kernel") kwargs["name"] = pyName;
                if (reduce_dims != true) kwargs["reduce_dims"] = pyReduce;
                if (preamble != "") kwargs["preamble"] = pyPreamble;
                if (no_return != false) kwargs["no_return"] = pyNoReturn;
                if (return_tuple != false) kwargs["return_tuple"] = pyReturnTuple;
                using dynamic elmKernel = self.GetAttr("ElementwiseKernel");
                using dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                    preamble: preamble, no_return: no_return, return_tuple: return_tuple);
                using dynamic pyT1 = t1.ToPython();
                using dynamic pyT2 = t2.ToPython();
                using dynamic pyT3 = t3.ToPython();
                using dynamic pyT4 = t4.ToPython();
                using dynamic pyT5 = t5.ToPython();
                using dynamic pyT6 = t6.ToPython();
                using dynamic pyT7 = t7.ToPython();
                using dynamic pyT8 = t8.ToPython();
                using dynamic result = instance.__call__(pyT1, pyT2, pyT3, pyT4, pyT5, pyT6, pyT7, pyT8);
                return result.As<R>();
            }
            finally
            {
                if (pyName != null) pyName.Dispose();
                if (pyReduce != null) pyReduce.Dispose();
                if (pyPreamble != null) pyPreamble.Dispose();
                if (pyNoReturn != null) pyNoReturn.Dispose();
                if (pyReturnTuple != null) pyReturnTuple.Dispose();
            }
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9,
                                                                                 string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
                                                                                 bool return_tuple = false)
        {
            var pyName = name != "kernel" ? ToPython(name) : null;
            var pyReduce = reduce_dims != true ? ToPython(reduce_dims) : null;
            var pyPreamble = preamble != "" ? ToPython(preamble) : null;
            var pyNoReturn = no_return != false ? ToPython(no_return) : null;
            var pyReturnTuple = return_tuple != false ? ToPython(return_tuple) : null;
            try
            {
                using var pyargs = ToTuple(new object[]
                {
                   in_params,
                   out_params,
                   operation
                });
                using var kwargs = new PyDict();
                if (name != "kernel") kwargs["name"] = pyName;
                if (reduce_dims != true) kwargs["reduce_dims"] = pyReduce;
                if (preamble != "") kwargs["preamble"] = pyPreamble;
                if (no_return != false) kwargs["no_return"] = pyNoReturn;
                if (return_tuple != false) kwargs["return_tuple"] = pyReturnTuple;
                using dynamic elmKernel = self.GetAttr("ElementwiseKernel");
                using dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                    preamble: preamble, no_return: no_return, return_tuple: return_tuple);
                using dynamic pyT1 = t1.ToPython();
                using dynamic pyT2 = t2.ToPython();
                using dynamic pyT3 = t3.ToPython();
                using dynamic pyT4 = t4.ToPython();
                using dynamic pyT5 = t5.ToPython();
                using dynamic pyT6 = t6.ToPython();
                using dynamic pyT7 = t7.ToPython();
                using dynamic pyT8 = t8.ToPython();
                using dynamic pyT9 = t9.ToPython();
                using dynamic result = instance.__call__(pyT1, pyT2, pyT3, pyT4, pyT5, pyT6, pyT7, pyT8, pyT9);
                return result.As<R>();
            }
            finally
            {
                if (pyName != null) pyName.Dispose();
                if (pyReduce != null) pyReduce.Dispose();
                if (pyPreamble != null) pyPreamble.Dispose();
                if (pyNoReturn != null) pyNoReturn.Dispose();
                if (pyReturnTuple != null) pyReturnTuple.Dispose();
            }
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10,
                                                                                      string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
                                                                                      bool return_tuple = false)
        {
            var pyName = name != "kernel" ? ToPython(name) : null;
            var pyReduce = reduce_dims != true ? ToPython(reduce_dims) : null;
            var pyPreamble = preamble != "" ? ToPython(preamble) : null;
            var pyNoReturn = no_return != false ? ToPython(no_return) : null;
            var pyReturnTuple = return_tuple != false ? ToPython(return_tuple) : null;
            try
            {
                using var pyargs = ToTuple(new object[]
                {
                   in_params,
                   out_params,
                   operation
                });
                using var kwargs = new PyDict();
                if (name != "kernel") kwargs["name"] = pyName;
                if (reduce_dims != true) kwargs["reduce_dims"] = pyReduce;
                if (preamble != "") kwargs["preamble"] = pyPreamble;
                if (no_return != false) kwargs["no_return"] = pyNoReturn;
                if (return_tuple != false) kwargs["return_tuple"] = pyReturnTuple;
                using dynamic elmKernel = self.GetAttr("ElementwiseKernel");
                using dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                    preamble: preamble, no_return: no_return, return_tuple: return_tuple);
                using dynamic pyT1 = t1.ToPython();
                using dynamic pyT2 = t2.ToPython();
                using dynamic pyT3 = t3.ToPython();
                using dynamic pyT4 = t4.ToPython();
                using dynamic pyT5 = t5.ToPython();
                using dynamic pyT6 = t6.ToPython();
                using dynamic pyT7 = t7.ToPython();
                using dynamic pyT8 = t8.ToPython();
                using dynamic pyT9 = t9.ToPython();
                using dynamic pyT10 = t10.ToPython();
                using dynamic result = instance.__call__(pyT1, pyT2, pyT3, pyT4, pyT5, pyT6, pyT7, pyT8, pyT9, pyT10);
                return result.As<R>();
            }
            finally
            {
                if (pyName != null) pyName.Dispose();
                if (pyReduce != null) pyReduce.Dispose();
                if (pyPreamble != null) pyPreamble.Dispose();
                if (pyNoReturn != null) pyNoReturn.Dispose();
                if (pyReturnTuple != null) pyReturnTuple.Dispose();
            }
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11,
                                                                                           string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
                                                                                           bool return_tuple = false)
        {
            var pyName = name != "kernel" ? ToPython(name) : null;
            var pyReduce = reduce_dims != true ? ToPython(reduce_dims) : null;
            var pyPreamble = preamble != "" ? ToPython(preamble) : null;
            var pyNoReturn = no_return != false ? ToPython(no_return) : null;
            var pyReturnTuple = return_tuple != false ? ToPython(return_tuple) : null;
            try
            {
                using var pyargs = ToTuple(new object[]
                {
                   in_params,
                   out_params,
                   operation
                });
                using var kwargs = new PyDict();
                if (name != "kernel") kwargs["name"] = pyName;
                if (reduce_dims != true) kwargs["reduce_dims"] = pyReduce;
                if (preamble != "") kwargs["preamble"] = pyPreamble;
                if (no_return != false) kwargs["no_return"] = pyNoReturn;
                if (return_tuple != false) kwargs["return_tuple"] = pyReturnTuple;
                using dynamic elmKernel = self.GetAttr("ElementwiseKernel");
                using dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                    preamble: preamble, no_return: no_return, return_tuple: return_tuple);
                using dynamic pyT1 = t1.ToPython();
                using dynamic pyT2 = t2.ToPython();
                using dynamic pyT3 = t3.ToPython();
                using dynamic pyT4 = t4.ToPython();
                using dynamic pyT5 = t5.ToPython();
                using dynamic pyT6 = t6.ToPython();
                using dynamic pyT7 = t7.ToPython();
                using dynamic pyT8 = t8.ToPython();
                using dynamic pyT9 = t9.ToPython();
                using dynamic pyT10 = t10.ToPython();
                using dynamic pyT11 = t11.ToPython();
                using dynamic result = instance.__call__(pyT1, pyT2, pyT3, pyT4, pyT5, pyT6, pyT7, pyT8, pyT9, pyT10, pyT11);
                return result.As<R>();
            }
            finally
            {
                if (pyName != null) pyName.Dispose();
                if (pyReduce != null) pyReduce.Dispose();
                if (pyPreamble != null) pyPreamble.Dispose();
                if (pyNoReturn != null) pyNoReturn.Dispose();
                if (pyReturnTuple != null) pyReturnTuple.Dispose();
            }
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12,
                                                                                                string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
                                                                                                bool return_tuple = false)
        {
            var pyName = name != "kernel" ? ToPython(name) : null;
            var pyReduce = reduce_dims != true ? ToPython(reduce_dims) : null;
            var pyPreamble = preamble != "" ? ToPython(preamble) : null;
            var pyNoReturn = no_return != false ? ToPython(no_return) : null;
            var pyReturnTuple = return_tuple != false ? ToPython(return_tuple) : null;
            try
            {
                using var pyargs = ToTuple(new object[]
                {
                   in_params,
                   out_params,
                   operation
                });
                using var kwargs = new PyDict();
                if (name != "kernel") kwargs["name"] = pyName;
                if (reduce_dims != true) kwargs["reduce_dims"] = pyReduce;
                if (preamble != "") kwargs["preamble"] = pyPreamble;
                if (no_return != false) kwargs["no_return"] = pyNoReturn;
                if (return_tuple != false) kwargs["return_tuple"] = pyReturnTuple;
                using dynamic elmKernel = self.GetAttr("ElementwiseKernel");
                using dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                    preamble: preamble, no_return: no_return, return_tuple: return_tuple);
                using dynamic pyT1 = t1.ToPython();
                using dynamic pyT2 = t2.ToPython();
                using dynamic pyT3 = t3.ToPython();
                using dynamic pyT4 = t4.ToPython();
                using dynamic pyT5 = t5.ToPython();
                using dynamic pyT6 = t6.ToPython();
                using dynamic pyT7 = t7.ToPython();
                using dynamic pyT8 = t8.ToPython();
                using dynamic pyT9 = t9.ToPython();
                using dynamic pyT10 = t10.ToPython();
                using dynamic pyT11 = t11.ToPython();
                using dynamic pyT12 = t12.ToPython();
                using dynamic result = instance.__call__(pyT1, pyT2, pyT3, pyT4, pyT5, pyT6, pyT7, pyT8, pyT9, pyT10, pyT11, pyT12);
                return result.As<R>();
            }
            finally
            {
                if (pyName != null) pyName.Dispose();
                if (pyReduce != null) pyReduce.Dispose();
                if (pyPreamble != null) pyPreamble.Dispose();
                if (pyNoReturn != null) pyNoReturn.Dispose();
                if (pyReturnTuple != null) pyReturnTuple.Dispose();
            }
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13,
                                                                                                     string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
                                                                                                     bool return_tuple = false)
        {
            var pyName = name != "kernel" ? ToPython(name) : null;
            var pyReduce = reduce_dims != true ? ToPython(reduce_dims) : null;
            var pyPreamble = preamble != "" ? ToPython(preamble) : null;
            var pyNoReturn = no_return != false ? ToPython(no_return) : null;
            var pyReturnTuple = return_tuple != false ? ToPython(return_tuple) : null;
            try
            {
                using var pyargs = ToTuple(new object[]
                {
                   in_params,
                   out_params,
                   operation
                });
                using var kwargs = new PyDict();
                if (name != "kernel") kwargs["name"] = pyName;
                if (reduce_dims != true) kwargs["reduce_dims"] = pyReduce;
                if (preamble != "") kwargs["preamble"] = pyPreamble;
                if (no_return != false) kwargs["no_return"] = pyNoReturn;
                if (return_tuple != false) kwargs["return_tuple"] = pyReturnTuple;
                using dynamic elmKernel = self.GetAttr("ElementwiseKernel");
                using dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                    preamble: preamble, no_return: no_return, return_tuple: return_tuple);
                using dynamic pyT1 = t1.ToPython();
                using dynamic pyT2 = t2.ToPython();
                using dynamic pyT3 = t3.ToPython();
                using dynamic pyT4 = t4.ToPython();
                using dynamic pyT5 = t5.ToPython();
                using dynamic pyT6 = t6.ToPython();
                using dynamic pyT7 = t7.ToPython();
                using dynamic pyT8 = t8.ToPython();
                using dynamic pyT9 = t9.ToPython();
                using dynamic pyT10 = t10.ToPython();
                using dynamic pyT11 = t11.ToPython();
                using dynamic pyT12 = t12.ToPython();
                using dynamic pyT13 = t13.ToPython();
                using dynamic result = instance.__call__(pyT1, pyT2, pyT3, pyT4, pyT5, pyT6, pyT7, pyT8, pyT9, pyT10, pyT11, pyT12, pyT13);
                return result.As<R>();
            }
            finally
            {
                if (pyName != null) pyName.Dispose();
                if (pyReduce != null) pyReduce.Dispose();
                if (pyPreamble != null) pyPreamble.Dispose();
                if (pyNoReturn != null) pyNoReturn.Dispose();
                if (pyReturnTuple != null) pyReturnTuple.Dispose();
            }
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14,
                                                                                                          string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
                                                                                                          bool return_tuple = false)
        {
            var pyName = name != "kernel" ? ToPython(name) : null;
            var pyReduce = reduce_dims != true ? ToPython(reduce_dims) : null;
            var pyPreamble = preamble != "" ? ToPython(preamble) : null;
            var pyNoReturn = no_return != false ? ToPython(no_return) : null;
            var pyReturnTuple = return_tuple != false ? ToPython(return_tuple) : null;
            try
            {
                using var pyargs = ToTuple(new object[]
                {
                   in_params,
                   out_params,
                   operation
                });
                using var kwargs = new PyDict();
                if (name != "kernel") kwargs["name"] = pyName;
                if (reduce_dims != true) kwargs["reduce_dims"] = pyReduce;
                if (preamble != "") kwargs["preamble"] = pyPreamble;
                if (no_return != false) kwargs["no_return"] = pyNoReturn;
                if (return_tuple != false) kwargs["return_tuple"] = pyReturnTuple;
                using dynamic elmKernel = self.GetAttr("ElementwiseKernel");
                using dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                    preamble: preamble, no_return: no_return, return_tuple: return_tuple);
                using dynamic pyT1 = t1.ToPython();
                using dynamic pyT2 = t2.ToPython();
                using dynamic pyT3 = t3.ToPython();
                using dynamic pyT4 = t4.ToPython();
                using dynamic pyT5 = t5.ToPython();
                using dynamic pyT6 = t6.ToPython();
                using dynamic pyT7 = t7.ToPython();
                using dynamic pyT8 = t8.ToPython();
                using dynamic pyT9 = t9.ToPython();
                using dynamic pyT10 = t10.ToPython();
                using dynamic pyT11 = t11.ToPython();
                using dynamic pyT12 = t12.ToPython();
                using dynamic pyT13 = t13.ToPython();
                using dynamic pyT14 = t14.ToPython();
                using dynamic result = instance.__call__(pyT1, pyT2, pyT3, pyT4, pyT5, pyT6, pyT7, pyT8, pyT9, pyT10, pyT11, pyT12, pyT13, pyT14);
                return result.As<R>();
            }
            finally
            {
                if (pyName != null) pyName.Dispose();
                if (pyReduce != null) pyReduce.Dispose();
                if (pyPreamble != null) pyPreamble.Dispose();
                if (pyNoReturn != null) pyNoReturn.Dispose();
                if (pyReturnTuple != null) pyReturnTuple.Dispose();
            }
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15,
                                                                                                               string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
                                                                                                               bool return_tuple = false)
        {
            var pyName = name != "kernel" ? ToPython(name) : null;
            var pyReduce = reduce_dims != true ? ToPython(reduce_dims) : null;
            var pyPreamble = preamble != "" ? ToPython(preamble) : null;
            var pyNoReturn = no_return != false ? ToPython(no_return) : null;
            var pyReturnTuple = return_tuple != false ? ToPython(return_tuple) : null;
            try
            {
                using var pyargs = ToTuple(new object[]
                {
                   in_params,
                   out_params,
                   operation
                });
                using var kwargs = new PyDict();
                if (name != "kernel") kwargs["name"] = pyName;
                if (reduce_dims != true) kwargs["reduce_dims"] = pyReduce;
                if (preamble != "") kwargs["preamble"] = pyPreamble;
                if (no_return != false) kwargs["no_return"] = pyNoReturn;
                if (return_tuple != false) kwargs["return_tuple"] = pyReturnTuple;
                using dynamic elmKernel = self.GetAttr("ElementwiseKernel");
                using dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                    preamble: preamble, no_return: no_return, return_tuple: return_tuple);
                using dynamic pyT1 = t1.ToPython();
                using dynamic pyT2 = t2.ToPython();
                using dynamic pyT3 = t3.ToPython();
                using dynamic pyT4 = t4.ToPython();
                using dynamic pyT5 = t5.ToPython();
                using dynamic pyT6 = t6.ToPython();
                using dynamic pyT7 = t7.ToPython();
                using dynamic pyT8 = t8.ToPython();
                using dynamic pyT9 = t9.ToPython();
                using dynamic pyT10 = t10.ToPython();
                using dynamic pyT11 = t11.ToPython();
                using dynamic pyT12 = t12.ToPython();
                using dynamic pyT13 = t13.ToPython();
                using dynamic pyT14 = t14.ToPython();
                using dynamic pyT15 = t15.ToPython();
                using dynamic result = instance.__call__(pyT1, pyT2, pyT3, pyT4, pyT5, pyT6, pyT7, pyT8, pyT9, pyT10, pyT11, pyT12, pyT13, pyT14, pyT15);
                return result.As<R>();
            }
            finally
            {
                if (pyName != null) pyName.Dispose();
                if (pyReduce != null) pyReduce.Dispose();
                if (pyPreamble != null) pyPreamble.Dispose();
                if (pyNoReturn != null) pyNoReturn.Dispose();
                if (pyReturnTuple != null) pyReturnTuple.Dispose();
            }
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16,
                                                                                                                    string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
                                                                                                                    bool return_tuple = false)
        {
            var pyName = name != "kernel" ? ToPython(name) : null;
            var pyReduce = reduce_dims != true ? ToPython(reduce_dims) : null;
            var pyPreamble = preamble != "" ? ToPython(preamble) : null;
            var pyNoReturn = no_return != false ? ToPython(no_return) : null;
            var pyReturnTuple = return_tuple != false ? ToPython(return_tuple) : null;
            try
            {
                using var pyargs = ToTuple(new object[]
                {
                   in_params,
                   out_params,
                   operation
                });
                using var kwargs = new PyDict();
                if (name != "kernel") kwargs["name"] = pyName;
                if (reduce_dims != true) kwargs["reduce_dims"] = pyReduce;
                if (preamble != "") kwargs["preamble"] = pyPreamble;
                if (no_return != false) kwargs["no_return"] = pyNoReturn;
                if (return_tuple != false) kwargs["return_tuple"] = pyReturnTuple;
                using dynamic elmKernel = self.GetAttr("ElementwiseKernel");
                using dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                    preamble: preamble, no_return: no_return, return_tuple: return_tuple);
                using dynamic pyT1 = t1.ToPython();
                using dynamic pyT2 = t2.ToPython();
                using dynamic pyT3 = t3.ToPython();
                using dynamic pyT4 = t4.ToPython();
                using dynamic pyT5 = t5.ToPython();
                using dynamic pyT6 = t6.ToPython();
                using dynamic pyT7 = t7.ToPython();
                using dynamic pyT8 = t8.ToPython();
                using dynamic pyT9 = t9.ToPython();
                using dynamic pyT10 = t10.ToPython();
                using dynamic pyT11 = t11.ToPython();
                using dynamic pyT12 = t12.ToPython();
                using dynamic pyT13 = t13.ToPython();
                using dynamic pyT14 = t14.ToPython();
                using dynamic pyT15 = t15.ToPython();
                using dynamic pyT16 = t16.ToPython();
                using dynamic result = instance.__call__(pyT1, pyT2, pyT3, pyT4, pyT5, pyT6, pyT7, pyT8, pyT9, pyT10, pyT11, pyT12, pyT13, pyT14, pyT15, pyT16);
                return result.As<R>();
            }
            finally
            {
                if (pyName != null) pyName.Dispose();
                if (pyReduce != null) pyReduce.Dispose();
                if (pyPreamble != null) pyPreamble.Dispose();
                if (pyNoReturn != null) pyNoReturn.Dispose();
                if (pyReturnTuple != null) pyReturnTuple.Dispose();
            }
        }
    }
}
