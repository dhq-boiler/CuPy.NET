using System;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;
using Python.Runtime;

namespace Cupy.UnitTest
{
    [TestFixture]
    public class BaseTestCase
    {
        private const string PYTHON_DLL = @"C:\Users\boiler\AppData\Local\Programs\Python\Python311\python311.dll";

        [SetUp]
        public void OneTimeSetUp()
        {
            if (Runtime.PythonDLL != PYTHON_DLL)
            {
                Runtime.PythonDLL = PYTHON_DLL;
            }

            PythonEngine.Initialize();
        }

        [TearDown]
        public void OneTimeTearDown()
        {
            PythonEngine.Shutdown();
        }
    }
}