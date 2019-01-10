using MK.HtmlAnalyzer.AppLogic.Interfaces.Stats;
using MK.HtmlAnalyzer.DataAccess;
using System;

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
                view.Info = "Put URL";
                return;
            }

            try
            {
                view.Stats = _htmlRepo.GetStats(view.Url);
            }
            catch (UriFormatException)
            {
                view.Info = "Invalid URL";
            }
            catch (ArgumentNullException)
            {
                view.Info = "No page has been found under given URL";
            }
            catch (NullReferenceException ex)
            {
                view.Info = GetErrorMsg(ex.Message);
            }
            catch (Exception)
            {
                view.Info = "Unexpected error";
            }
        }

        private string GetErrorMsg(string nullParam)
        {
            switch(nullParam)
            {
                case "metaKeywordNode": return "No meta keyword tag";
                case "contentAttr": return "No content for meta keyword tag";
                case "empty keyword content": return "Empty content for meta keyword tag";
            }
            return "";
        }
    }
}
