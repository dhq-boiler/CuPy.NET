using System;

namespace CodeMinion.Core.Attributes
{
    public class TemplateAttribute : Attribute
    {
        public TemplateAttribute(string api_function)
        {
            ApiFunction = api_function;
        }

        public string ApiFunction { get; set; }
    }
}