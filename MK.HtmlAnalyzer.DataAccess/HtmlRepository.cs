using HtmlAgilityPack;
using MK.HtmlAnalyzer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MK.HtmlAnalyzer.DataAccess
{
    public class HtmlRepository : IHtmlRepository
    {
        private const char SEPARATOR = ',';
        private const string KEYWORDS_XPATH = "//head/meta[@name='keywords']";
        private const string BODY_XPATH = "//body";
        private const string TEXT_XPATH = "//body//text()[normalize-space(.) != '']";
        private const string REGEX = @"\b({0})\b";
        private List<string> BODY_NODES_TO_DELETE = new List<string>() { "script", "style" };

        public IList<KeywordStat> GetStats(string url)
        {
            HtmlDocument htmlDoc = new HtmlWeb().Load(url);

            if (htmlDoc == null)
                return null;

            var list = GetKeywords(htmlDoc);

            if (list != null && list.Any())
            {
                RemoveUnwantedNodes(htmlDoc);
                CountKeywords(list, htmlDoc);
            }
            
            return list;
        }

        private List<KeywordStat> GetKeywords(HtmlDocument html)
        {
            if (html == null)
                return null;

            List<KeywordStat> keywords = new List<KeywordStat>();

            var headNode = html.DocumentNode.SelectSingleNode(KEYWORDS_XPATH); ;

            if (headNode.Attributes == null)
                return null;

            var contentAttr = headNode.Attributes.FirstOrDefault(x => x.Name == "content");

            if (contentAttr != null)
            {
                var arr = contentAttr.Value.ToString().Split(SEPARATOR);

                if (arr != null && arr.Length > 0)
                {
                    foreach (var word in arr)
                        keywords.Add(new KeywordStat() { Keyword = word });
                }
            }
            return keywords;
        }

        private void RemoveUnwantedNodes(HtmlDocument doc)
        {
            if (doc == null || doc.DocumentNode == null)
                return;

            var body = doc.DocumentNode.SelectSingleNode(BODY_XPATH);
            body.Descendants().Where(n => BODY_NODES_TO_DELETE.Any(x => x == n.Name)).ToList().ForEach(n => n.Remove());
        }

        private void CountKeywords(List<KeywordStat> list, HtmlDocument doc)
        {
            if (list == null)
                return;

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes(TEXT_XPATH))
            {
                var text = node.InnerText.Trim();
                foreach (var key in list)
                {
                    key.Occurences += CountOccurences(key.Keyword, text);
                }
            }
        }

        private int CountOccurences(string key, string text)
        {
            return Regex.Matches(text, String.Format(REGEX, key)).Count;
        }

    }
}
