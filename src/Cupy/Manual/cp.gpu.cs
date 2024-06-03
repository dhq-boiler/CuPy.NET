using Python.Runtime;
using System.Linq;

namespace Cupy
{
    public static partial class cp
    {
        public static R ElementwiseKernel<R, T1>(string in_params, string out_params, string operation, T1 t1,
            string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
            bool return_tuple = false)
        {
            var __self__ = self;
            using var pyargs = ToTuple(new object[]
            {
                in_params,
                out_params,
                operation
            });
            using var kwargs = new PyDict();
            if (name != "kernel") kwargs["name"] = ToPython(name);
            if (reduce_dims != true) kwargs["reduce_dims"] = ToPython(reduce_dims);
            if (preamble != "") kwargs["preamble"] = ToPython(preamble);
            if (no_return != false) kwargs["no_return"] = ToPython(no_return);
            if (return_tuple != false) kwargs["return_tuple"] = ToPython(return_tuple);

            dynamic elmKernel = __self__.GetAttr("ElementwiseKernel");
            dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                preamble: preamble, no_return: no_return, return_tuple: return_tuple);
            dynamic result = instance.__call__(t1.ToPython());
            return result.As<R>();
        }

        public static R ElementwiseKernel<R, T1, T2>(string in_params, string out_params, string operation, T1 t1, T2 t2,
            string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
            bool return_tuple = false)
        {
            var __self__ = self;
            using var pyargs = ToTuple(new object[]
            {
                in_params,
                out_params,
                operation
            });
            using var kwargs = new PyDict();
            if (name != "kernel") kwargs["name"] = ToPython(name);
            if (reduce_dims != true) kwargs["reduce_dims"] = ToPython(reduce_dims);
            if (preamble != "") kwargs["preamble"] = ToPython(preamble);
            if (no_return != false) kwargs["no_return"] = ToPython(no_return);
            if (return_tuple != false) kwargs["return_tuple"] = ToPython(return_tuple);

            dynamic elmKernel = __self__.GetAttr("ElementwiseKernel");
            dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                preamble: preamble, no_return: no_return, return_tuple: return_tuple);
            dynamic result = instance.__call__(t1.ToPython(), t2.ToPython());
            return result.As<R>();
        }

        public static R ElementwiseKernel<R, T1, T2, T3>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3,
            string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
            bool return_tuple = false)
        {
            var __self__ = self;
            using var pyargs = ToTuple(new object[]
            {
                in_params,
                out_params,
                operation
            });
            using var kwargs = new PyDict();
            if (name != "kernel") kwargs["name"] = ToPython(name);
            if (reduce_dims != true) kwargs["reduce_dims"] = ToPython(reduce_dims);
            if (preamble != "") kwargs["preamble"] = ToPython(preamble);
            if (no_return != false) kwargs["no_return"] = ToPython(no_return);
            if (return_tuple != false) kwargs["return_tuple"] = ToPython(return_tuple);

            dynamic elmKernel = __self__.GetAttr("ElementwiseKernel");
            dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                preamble: preamble, no_return: no_return, return_tuple: return_tuple);
            dynamic result = instance.__call__(t1.ToPython(), t2.ToPython(), t3.ToPython());
            return result.As<R>();
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4,
            string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
            bool return_tuple = false)
        {
            var __self__ = self;
            using var pyargs = ToTuple(new object[]
            {
                in_params,
                out_params,
                operation
            });
            using var kwargs = new PyDict();
            if (name != "kernel") kwargs["name"] = ToPython(name);
            if (reduce_dims != true) kwargs["reduce_dims"] = ToPython(reduce_dims);
            if (preamble != "") kwargs["preamble"] = ToPython(preamble);
            if (no_return != false) kwargs["no_return"] = ToPython(no_return);
            if (return_tuple != false) kwargs["return_tuple"] = ToPython(return_tuple);

            dynamic elmKernel = __self__.GetAttr("ElementwiseKernel");
            dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                preamble: preamble, no_return: no_return, return_tuple: return_tuple);
            dynamic result = instance.__call__(t1.ToPython(), t2.ToPython(), t3.ToPython(), t4.ToPython());
            return result.As<R>();
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5,
            string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
            bool return_tuple = false)
        {
            var __self__ = self;
            using var pyargs = ToTuple(new object[]
            {
                in_params,
                out_params,
                operation
            });
            using var kwargs = new PyDict();
            if (name != "kernel") kwargs["name"] = ToPython(name);
            if (reduce_dims != true) kwargs["reduce_dims"] = ToPython(reduce_dims);
            if (preamble != "") kwargs["preamble"] = ToPython(preamble);
            if (no_return != false) kwargs["no_return"] = ToPython(no_return);
            if (return_tuple != false) kwargs["return_tuple"] = ToPython(return_tuple);

            dynamic elmKernel = __self__.GetAttr("ElementwiseKernel");
            dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                preamble: preamble, no_return: no_return, return_tuple: return_tuple);
            dynamic result = instance.__call__(t1.ToPython(), t2.ToPython(), t3.ToPython(), t4.ToPython(), t5.ToPython());
            return result.As<R>();
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5, T6>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6,
            string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
            bool return_tuple = false)
        {
            var __self__ = self;
            using var pyargs = ToTuple(new object[]
            {
                in_params,
                out_params,
                operation
            });
            using var kwargs = new PyDict();
            if (name != "kernel") kwargs["name"] = ToPython(name);
            if (reduce_dims != true) kwargs["reduce_dims"] = ToPython(reduce_dims);
            if (preamble != "") kwargs["preamble"] = ToPython(preamble);
            if (no_return != false) kwargs["no_return"] = ToPython(no_return);
            if (return_tuple != false) kwargs["return_tuple"] = ToPython(return_tuple);

            dynamic elmKernel = __self__.GetAttr("ElementwiseKernel");
            dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                preamble: preamble, no_return: no_return, return_tuple: return_tuple);
            dynamic result = instance.__call__(t1.ToPython(), t2.ToPython(), t3.ToPython(), t4.ToPython(), t5.ToPython(), t6.ToPython());
            return result.As<R>();
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5, T6, T7>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7,
            string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
            bool return_tuple = false)
        {
            var __self__ = self;
            using var pyargs = ToTuple(new object[]
            {
                in_params,
                out_params,
                operation
            });
            using var kwargs = new PyDict();
            if (name != "kernel") kwargs["name"] = ToPython(name);
            if (reduce_dims != true) kwargs["reduce_dims"] = ToPython(reduce_dims);
            if (preamble != "") kwargs["preamble"] = ToPython(preamble);
            if (no_return != false) kwargs["no_return"] = ToPython(no_return);
            if (return_tuple != false) kwargs["return_tuple"] = ToPython(return_tuple);

            dynamic elmKernel = __self__.GetAttr("ElementwiseKernel");
            dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                preamble: preamble, no_return: no_return, return_tuple: return_tuple);
            dynamic result = instance.__call__(t1.ToPython(), t2.ToPython(), t3.ToPython(), t4.ToPython(), t5.ToPython(), t6.ToPython(), t7.ToPython());
            return result.As<R>();
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5, T6, T7, T8>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8,
            string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
            bool return_tuple = false)
        {
            var __self__ = self;
            using var pyargs = ToTuple(new object[]
            {
                in_params,
                out_params,
                operation
            });
            using var kwargs = new PyDict();
            if (name != "kernel") kwargs["name"] = ToPython(name);
            if (reduce_dims != true) kwargs["reduce_dims"] = ToPython(reduce_dims);
            if (preamble != "") kwargs["preamble"] = ToPython(preamble);
            if (no_return != false) kwargs["no_return"] = ToPython(no_return);
            if (return_tuple != false) kwargs["return_tuple"] = ToPython(return_tuple);

            dynamic elmKernel = __self__.GetAttr("ElementwiseKernel");
            dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                preamble: preamble, no_return: no_return, return_tuple: return_tuple);
            dynamic result = instance.__call__(t1.ToPython(), t2.ToPython(), t3.ToPython(), t4.ToPython(), t5.ToPython(), t6.ToPython(), t7.ToPython(), t8.ToPython());
            return result.As<R>();
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9,
            string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
            bool return_tuple = false)
        {
            var __self__ = self;
            using var pyargs = ToTuple(new object[]
            {
                in_params,
                out_params,
                operation
            });
            using var kwargs = new PyDict();
            if (name != "kernel") kwargs["name"] = ToPython(name);
            if (reduce_dims != true) kwargs["reduce_dims"] = ToPython(reduce_dims);
            if (preamble != "") kwargs["preamble"] = ToPython(preamble);
            if (no_return != false) kwargs["no_return"] = ToPython(no_return);
            if (return_tuple != false) kwargs["return_tuple"] = ToPython(return_tuple);

            dynamic elmKernel = __self__.GetAttr("ElementwiseKernel");
            dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                preamble: preamble, no_return: no_return, return_tuple: return_tuple);
            dynamic result = instance.__call__(t1.ToPython(), t2.ToPython(), t3.ToPython(), t4.ToPython(), t5.ToPython(), t6.ToPython(), t7.ToPython(), t8.ToPython(), t9.ToPython());
            return result.As<R>();
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10,
            string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
            bool return_tuple = false)
        {
            var __self__ = self;
            using var pyargs = ToTuple(new object[]
            {
                in_params,
                out_params,
                operation
            });
            using var kwargs = new PyDict();
            if (name != "kernel") kwargs["name"] = ToPython(name);
            if (reduce_dims != true) kwargs["reduce_dims"] = ToPython(reduce_dims);
            if (preamble != "") kwargs["preamble"] = ToPython(preamble);
            if (no_return != false) kwargs["no_return"] = ToPython(no_return);
            if (return_tuple != false) kwargs["return_tuple"] = ToPython(return_tuple);

            dynamic elmKernel = __self__.GetAttr("ElementwiseKernel");
            dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                preamble: preamble, no_return: no_return, return_tuple: return_tuple);
            dynamic result = instance.__call__(t1.ToPython(), t2.ToPython(), t3.ToPython(), t4.ToPython(), t5.ToPython(), t6.ToPython(), t7.ToPython(), t8.ToPython(), t9.ToPython(), t10.ToPython());
            return result.As<R>();
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11,
            string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
            bool return_tuple = false)
        {
            var __self__ = self;
            using var pyargs = ToTuple(new object[]
            {
                in_params,
                out_params,
                operation
            });
            using var kwargs = new PyDict();
            if (name != "kernel") kwargs["name"] = ToPython(name);
            if (reduce_dims != true) kwargs["reduce_dims"] = ToPython(reduce_dims);
            if (preamble != "") kwargs["preamble"] = ToPython(preamble);
            if (no_return != false) kwargs["no_return"] = ToPython(no_return);
            if (return_tuple != false) kwargs["return_tuple"] = ToPython(return_tuple);

            dynamic elmKernel = __self__.GetAttr("ElementwiseKernel");
            dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                preamble: preamble, no_return: no_return, return_tuple: return_tuple);
            dynamic result = instance.__call__(t1.ToPython(), t2.ToPython(), t3.ToPython(), t4.ToPython(), t5.ToPython(), t6.ToPython(), t7.ToPython(), t8.ToPython(), t9.ToPython(), t10.ToPython(), t11.ToPython());
            return result.As<R>();
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12,
            string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
            bool return_tuple = false)
        {
            var __self__ = self;
            using var pyargs = ToTuple(new object[]
            {
                in_params,
                out_params,
                operation
            });
            using var kwargs = new PyDict();
            if (name != "kernel") kwargs["name"] = ToPython(name);
            if (reduce_dims != true) kwargs["reduce_dims"] = ToPython(reduce_dims);
            if (preamble != "") kwargs["preamble"] = ToPython(preamble);
            if (no_return != false) kwargs["no_return"] = ToPython(no_return);
            if (return_tuple != false) kwargs["return_tuple"] = ToPython(return_tuple);

            dynamic elmKernel = __self__.GetAttr("ElementwiseKernel");
            dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                preamble: preamble, no_return: no_return, return_tuple: return_tuple);
            dynamic result = instance.__call__(t1.ToPython(), t2.ToPython(), t3.ToPython(), t4.ToPython(), t5.ToPython(), t6.ToPython(), t7.ToPython(), t8.ToPython(), t9.ToPython(), t10.ToPython(), t11.ToPython(), t12.ToPython());
            return result.As<R>();
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13,
            string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
            bool return_tuple = false)
        {
            var __self__ = self;
            using var pyargs = ToTuple(new object[]
            {
                in_params,
                out_params,
                operation
            });
            using var kwargs = new PyDict();
            if (name != "kernel") kwargs["name"] = ToPython(name);
            if (reduce_dims != true) kwargs["reduce_dims"] = ToPython(reduce_dims);
            if (preamble != "") kwargs["preamble"] = ToPython(preamble);
            if (no_return != false) kwargs["no_return"] = ToPython(no_return);
            if (return_tuple != false) kwargs["return_tuple"] = ToPython(return_tuple);

            dynamic elmKernel = __self__.GetAttr("ElementwiseKernel");
            dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                preamble: preamble, no_return: no_return, return_tuple: return_tuple);
            dynamic result = instance.__call__(t1.ToPython(), t2.ToPython(), t3.ToPython(), t4.ToPython(), t5.ToPython(), t6.ToPython(), t7.ToPython(), t8.ToPython(), t9.ToPython(), t10.ToPython(), t11.ToPython(), t12.ToPython(), t13.ToPython());
            return result.As<R>();
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14,
            string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
            bool return_tuple = false)
        {
            var __self__ = self;
            using var pyargs = ToTuple(new object[]
            {
                in_params,
                out_params,
                operation
            });
            using var kwargs = new PyDict();
            if (name != "kernel") kwargs["name"] = ToPython(name);
            if (reduce_dims != true) kwargs["reduce_dims"] = ToPython(reduce_dims);
            if (preamble != "") kwargs["preamble"] = ToPython(preamble);
            if (no_return != false) kwargs["no_return"] = ToPython(no_return);
            if (return_tuple != false) kwargs["return_tuple"] = ToPython(return_tuple);

            dynamic elmKernel = __self__.GetAttr("ElementwiseKernel");
            dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                preamble: preamble, no_return: no_return, return_tuple: return_tuple);
            dynamic result = instance.__call__(t1.ToPython(), t2.ToPython(), t3.ToPython(), t4.ToPython(), t5.ToPython(), t6.ToPython(), t7.ToPython(), t8.ToPython(), t9.ToPython(), t10.ToPython(), t11.ToPython(), t12.ToPython(), t13.ToPython(), t14.ToPython());
            return result.As<R>();
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15,
            string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
            bool return_tuple = false)
        {
            var __self__ = self;
            using var pyargs = ToTuple(new object[]
            {
                in_params,
                out_params,
                operation
            });
            using var kwargs = new PyDict();
            if (name != "kernel") kwargs["name"] = ToPython(name);
            if (reduce_dims != true) kwargs["reduce_dims"] = ToPython(reduce_dims);
            if (preamble != "") kwargs["preamble"] = ToPython(preamble);
            if (no_return != false) kwargs["no_return"] = ToPython(no_return);
            if (return_tuple != false) kwargs["return_tuple"] = ToPython(return_tuple);

            dynamic elmKernel = __self__.GetAttr("ElementwiseKernel");
            dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                preamble: preamble, no_return: no_return, return_tuple: return_tuple);
            dynamic result = instance.__call__(t1.ToPython(), t2.ToPython(), t3.ToPython(), t4.ToPython(), t5.ToPython(), t6.ToPython(), t7.ToPython(), t8.ToPython(), t9.ToPython(), t10.ToPython(), t11.ToPython(), t12.ToPython(), t13.ToPython(), t14.ToPython(), t15.ToPython());
            return result.As<R>();
        }

        public static R ElementwiseKernel<R, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string in_params, string out_params, string operation, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16,
            string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
            bool return_tuple = false)
        {
            var __self__ = self;
            using var pyargs = ToTuple(new object[]
            {
                in_params,
                out_params,
                operation
            });
            using var kwargs = new PyDict();
            if (name != "kernel") kwargs["name"] = ToPython(name);
            if (reduce_dims != true) kwargs["reduce_dims"] = ToPython(reduce_dims);
            if (preamble != "") kwargs["preamble"] = ToPython(preamble);
            if (no_return != false) kwargs["no_return"] = ToPython(no_return);
            if (return_tuple != false) kwargs["return_tuple"] = ToPython(return_tuple);

            dynamic elmKernel = __self__.GetAttr("ElementwiseKernel");
            dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                preamble: preamble, no_return: no_return, return_tuple: return_tuple);
            dynamic result = instance.__call__(t1.ToPython(), t2.ToPython(), t3.ToPython(), t4.ToPython(), t5.ToPython(), t6.ToPython(), t7.ToPython(), t8.ToPython(), t9.ToPython(), t10.ToPython(), t11.ToPython(), t12.ToPython(), t13.ToPython(), t14.ToPython(), t15.ToPython(), t16.ToPython());
            return result.As<R>();
        }
    }
}
