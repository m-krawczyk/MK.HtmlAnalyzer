using MK.HtmlAnalyzer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.HtmlAnalyzer.DataAccess
{
    public interface IHtmlRepository
    {
        IList<KeywordStat> GetStats(string url);
    }
}
