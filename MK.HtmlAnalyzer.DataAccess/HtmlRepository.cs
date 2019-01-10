using HtmlAgilityPack;
using MK.HtmlAnalyzer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MK.HtmlAnalyzer.DataAccess
{
    public class HtmlRepository : IHtmlRepository
    {
        #region PRIVATE FIELDS

        private const char SEPARATOR = ',';
        private const string META_KEYWORD_ATTRIBUTE_NAME = "content";
        private const string KEYWORDS_XPATH = "//head/meta[@name='keywords']";
        private const string BODY_XPATH = "//body";
        private const string TEXT_XPATH = "//body//text()[normalize-space(.) != '']";
        private const string REGEX = @"\b({0})\b";
        private readonly List<string> BODY_NODES_TO_DELETE = new List<string>() { "script", "style" };

        #endregion

        #region PUBLIC METHODS

        public IList<KeywordStat> GetStats(string url)
        {
            var htmlWeb = new HtmlWeb();
            HtmlDocument htmlDoc = htmlWeb.Load(url);

            if (htmlDoc == null)
                throw new NullReferenceException("htmlDoc");

            var list = GetKeywords(htmlDoc);

            if (list != null && list.Any())
            {
                RemoveUnwantedNodes(htmlDoc);
                CountKeywords(list, htmlDoc);
            }

            return list;
        }

        #endregion

        #region PRIVATE METHODS

        private List<KeywordStat> GetKeywords(HtmlDocument htmlDoc)
        {
            if (htmlDoc == null)
                throw new ArgumentNullException("htmlDoc");

            List<KeywordStat> keywords = new List<KeywordStat>();

            var metaKeywordNode = htmlDoc.DocumentNode.SelectSingleNode(KEYWORDS_XPATH); ;

            if (metaKeywordNode == null)
                throw new NullReferenceException("metaKeywordNode");

            var contentAttr = metaKeywordNode
                .Attributes
                .FirstOrDefault(x => x.Name == META_KEYWORD_ATTRIBUTE_NAME);

            if (contentAttr == null)
                throw new NullReferenceException("contentAttr");

            var arr = contentAttr.Value.ToString().Split(new char[] { SEPARATOR }, StringSplitOptions.RemoveEmptyEntries);

            if (arr == null || arr.Length == 0)
                throw new NullReferenceException("empty keyword content");

            foreach (var word in arr)
                keywords.Add(new KeywordStat(word));

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
            return Regex.Matches(text, String.Format(REGEX, key), RegexOptions.IgnoreCase).Count;
        }

        #endregion
    }
}
