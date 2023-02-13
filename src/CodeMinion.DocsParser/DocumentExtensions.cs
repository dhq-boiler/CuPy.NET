using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace CodeMinion.Parser
{
    public static class HtmlNodeExtensions
    {
        public static IEnumerable<HtmlNode> DescendantsOfClass(this HtmlNode self, string tag, string @class)
        {
            return self.Descendants(tag).Where(x => x.Attributes["class"]?.Value == @class);
        }
    }
}