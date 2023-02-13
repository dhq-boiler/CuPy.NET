using System.Collections.Generic;

namespace CodeMinion.Core.Models
{
    /// <summary>
    ///     Represents the methods of a non-static class which should be generated.
    ///     Note: the class itself is set up manually, this only generates more methods into that class.
    ///     To generate a full class from scratch use ApiClass
    /// </summary>
    public class DynamicApi : Api
    {
        /// <summary>
        ///     Class name is the name of a non-static class, i.e. NDArray
        /// </summary>
        public string ClassName { get; set; }
    }

    /// <summary>
    ///     Represents a non-static class which should be generated.
    /// </summary>
    public class ApiClass : Api
    {
        public List<Function> Constructors = new List<Function>();
        public string DocString;

        /// <summary>
        ///     Class name is the name of a non-static class, i.e. NDArray
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        ///     Do not generate this class
        /// </summary>
        public bool Ignore { get; set; }

        public string BaseClass { get; set; } = "PythonObject";
    }
}