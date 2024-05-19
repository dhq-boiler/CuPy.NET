using Python.Runtime;

namespace Cupy
{
    public static partial class cp
    {
        public static NDarray frombuffer(byte[] buffer, Dtype dtype = null, int count = -1, int offset = 0)
        {
            var __self__ = self;
            var pyargs = ToTuple(new object[]
            {
                buffer.ToPython()

            });
            var kwargs = new PyDict();
            if (dtype != null) kwargs["dtype"] = ToPython(dtype);
            kwargs["count"] = ToPython(count);
            kwargs["offset"] = ToPython(offset);
            dynamic py = __self__.InvokeMethod("frombuffer", pyargs, kwargs);
            return ToCsharp<NDarray>(py);
        }
    }
}