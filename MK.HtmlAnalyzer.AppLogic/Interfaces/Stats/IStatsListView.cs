using MK.HtmlAnalyzer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.HtmlAnalyzer.AppLogic.Interfaces.Stats
{
    public interface IStatsListView
    {
        IList<KeywordStat> Stats { set; }
        string Url { get; }
        string Info { set; }
    }
}
