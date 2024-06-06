using Python.Runtime;
using System;

namespace Cupy.Models
{
    public class MemMapMode : PythonObject
    {
        public MemMapMode(PyObject pyobject) : base(pyobject)
        {
        }

        ~MemMapMode()
        {
            GC.SuppressFinalize(this);
            Dispose();
            GC.ReRegisterForFinalize(this);
        }
    }
}