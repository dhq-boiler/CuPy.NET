// Copyright (c) 2019 by Meinrad Recheis and the SciSharp Team

using System;
using Python.Runtime;
#if PYTHON_INCLUDED
#endif

namespace Cupy
{
    public static partial class ctypes
    {
        private static readonly Lazy<PyObject> _lazy_self = new Lazy<PyObject>(() =>
        {
            var x = cp.self; // <-- make sure np initializes the python engine
            var mod = Py.Import("ctypes");
            return mod;
        });

        public static PyObject self => _lazy_self.Value;

        public static dynamic dynamic_self => self;
        private static bool IsInitialized => self != null;

        public static PyObject data => self.GetAttr("data");

        public static void Dispose()
        {
            self?.Dispose();
        }
    }
}