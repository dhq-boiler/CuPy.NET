using Python.Runtime;
using System;

namespace Cupy.Models
{
    public class Flags : PythonObject
    {
        public Flags(PyObject pyobject) : base(pyobject)
        {
        }

        ~Flags()
        {
            GC.SuppressFinalize(this);
            Dispose();
            GC.ReRegisterForFinalize(this);
        }
    }
}