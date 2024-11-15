using Python.Runtime;

namespace Cupy
{
    public static partial class cp
    {
        public static NDarray frombuffer(byte[] buffer, Dtype dtype = null, int count = -1, int offset = 0)
        {
            using var bufferPy = buffer.ToPython();
            using var pyargs = ToTuple(new object[] { bufferPy });
            using var kwargs = new PyDict();
            using var dtypePy = dtype != null ? ToPython(dtype) : null;
            using var countPy = ToPython(count);
            using var offsetPy = ToPython(offset);

            if (dtypePy != null) kwargs["dtype"] = dtypePy;
            kwargs["count"] = countPy;
            kwargs["offset"] = offsetPy;

            var py = self.InvokeMethod("frombuffer", pyargs, kwargs);
            return ToCsharp<NDarray>(py);
        }
    }
}