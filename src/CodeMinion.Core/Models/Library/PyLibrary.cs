using System.Collections.Generic;
using Newtonsoft.Json;

namespace CodeMinion.Core.Models
{
    /// <summary>
    ///     Instance of the python libray with modules and function
    /// </summary>
    public class PyLibrary
    {
        /// <summary>
        ///     Gets or sets the modules.
        /// </summary>
        /// <value>
        ///     The modules.
        /// </value>
        public List<PyModule> Modules { get; set; }

        /// <summary>
        ///     Loads the json.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns></returns>
        public static PyLibrary LoadJson(string json)
        {
            var lib = new PyLibrary();
            lib.Modules = JsonConvert.DeserializeObject<List<PyModule>>(json);
            //lib.Modules.ForEach(x => { x.InferArg(); });
            return lib;
        }
    }
}