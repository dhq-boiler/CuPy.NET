using Python.Runtime;
using System.Linq;

namespace Cupy
{
    public static partial class cp
    {
        public static T ElementwiseKernel<T>(string in_params, string out_params, string operation,
            string name = "kernel", bool reduce_dims = true, string preamble = "", bool no_return = false,
            bool return_tuple = false, params object[] args)
        {
            var __self__ = self;
            var pyargs = ToTuple(new object[]
            {
                in_params,
                out_params,
                operation
            });
            var kwargs = new PyDict();
            if (name != "kernel") kwargs["name"] = ToPython(name);
            if (reduce_dims != true) kwargs["reduce_dims"] = ToPython(reduce_dims);
            if (preamble != "") kwargs["preamble"] = ToPython(preamble);
            if (no_return != false) kwargs["no_return"] = ToPython(no_return);
            if (return_tuple != false) kwargs["return_tuple"] = ToPython(return_tuple);

            dynamic elmKernel = __self__.GetAttr("ElementwiseKernel");
            dynamic instance = elmKernel(in_params, out_params, operation, name: name, reduce_dims: reduce_dims,
                               preamble: preamble, no_return: no_return, return_tuple: return_tuple);
            dynamic result = instance.__call__(args.Select(x => ToPython(x)).ToArray());
            return result.As<T>();
        }
    }
}
