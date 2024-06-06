using Python.Runtime;
using System;

namespace Cupy.Models
{
    public class Matrix : PythonObject
    {
        public Matrix(PyObject pyobject) : base(pyobject)
        {
        }

        ~Matrix()
        {
            GC.SuppressFinalize(this);
            Dispose();
            GC.ReRegisterForFinalize(this);
        }
    }
}