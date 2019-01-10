using MK.HtmlAnalyzer.Model;
using System.Collections.Generic;

namespace MK.HtmlAnalyzer.DataAccess
{
    public interface IHtmlRepository
    {
        IList<KeywordStat> GetStats(string url);
    }
}
