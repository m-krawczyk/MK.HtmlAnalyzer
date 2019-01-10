using MK.HtmlAnalyzer.Model;
using System.Collections.Generic;

namespace MK.HtmlAnalyzer.AppLogic.Interfaces.Stats
{
    public interface IStatsListView
    {
        IList<KeywordStat> Stats { set; }
        string Url { get; }
        string Info { set; }
    }
}
