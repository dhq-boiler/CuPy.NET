using System.Linq;

namespace Cupy.UnitTest
{
    public static class TestingExtensions
    {
        // use this to simulate Python tuples, because we use arrays instead
        public static string repr(this NDarray[] self)
        {
            return "(" + string.Join(", ", self.Select(a => a.repr)) + ")";
        }
    }
}