using MK.HtmlAnalyzer.AppLogic.Interfaces.Stats;
using MK.HtmlAnalyzer.DataAccess;
using MK.HtmlAnalyzer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.HtmlAnalyzer.AppLogic.Presenters.Stats
{
    public class StatsListPresenter
    {
        IHtmlRepository _htmlRepo;

        public void Initialize(IStatsListView view)
        {
            view.Info = "";
            _htmlRepo = new HtmlRepository();

            if (string.IsNullOrEmpty(view.Url))
            {
                view.Info = "Uzupełnij URL";
                return;
            }

            try
            {
                view.Stats = _htmlRepo.GetStats(view.Url);
            }
            catch (Exception ex)
            {
                view.Info = "Wystąpił nieoczekiwany błąd";
            }
        }
    }
}
