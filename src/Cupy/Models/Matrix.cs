using Python.Runtime;

namespace Cupy.Models
{
    public class Matrix : PythonObject
    {
        public Matrix(PyObject pyobject) : base(pyobject)
        {
        }

        ~Matrix()
        {
            Dispose();
        }
    }
}