using Python.Runtime;
using System;

namespace Cupy
{
    public partial class PythonObject : IDisposable
    {
        public PyObject self; // can not be made readonly because of NDarray(IntPtr ... )

        public PythonObject(PyObject pyobject)
        {
            self = pyobject;
        }

        public PythonObject(PythonObject t)
        {
            self = t.PyObject;
        }

        protected PythonObject()
        {
        } // required for some constructors

        public dynamic PyObject => self;

        public IntPtr Handle => self.Handle;


        /// <summary>
        ///     An object to simplify the interaction of the array with the ctypes module.
        /// </summary>
        //public PyObject ctypes => self.GetAttr("ctypes"); // TODO: wrap ctypes
        public PyObject ctypes => Cupy.ctypes.self;//.GetAttr("ctypes");

        ~PythonObject()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // マネージドリソースの解放
                if (self != null)
                {
                    self.Dispose();
                    self = null;
                }
            }
            // アンマネージドリソースの解放（必要な場合）
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            switch (obj)
            {
                case PythonObject other:
                    return self.Equals(other.self);
                case PyObject other:
                    return self.Equals(other);
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            if (self.Handle == IntPtr.Zero)
            {
                return 0;
            }
            return self.GetHashCode();
        }

        public override string ToString()
        {
            if (self.Handle == IntPtr.Zero)
            {
                return "<<disposed>>";
            }
            return self.ToString();
        }

        public static PythonObject Create<T>(string python_class)
        {
            throw new NotImplementedException();
        }

        public static bool IsNDarray(dynamic py)
        {
            return cp.ToCsharp<string>(py.__class__.__name__) == "ndarray";
        }

        public static bool IsTuple(dynamic py)
        {
            return cp.ToCsharp<string>(py.__class__.__name__) == "tuple";
        }
    }
}