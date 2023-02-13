using System.Collections.Generic;

namespace CodeMinion.Core.Models
{
    public class TestCase
    {
        /// <summary>
        ///     Name of the test function, if Null the test cases are numbered through
        /// </summary>
        public string Name { get; set; }

        public List<TestPart> TestParts { get; set; } = new List<TestPart>();
    }

    public class TestPart
    {
    }

    public class Comment : TestPart
    {
        public string Text { get; set; }
    }

    public class ExampleCode : TestPart
    {
        public List<CodeLine> Lines = new List<CodeLine>();
        public string Text { get; set; }
    }

    public class CodeLine
    {
        public string Type { get; set; }
        public List<string> Text { get; set; } = new List<string>();
    }
}