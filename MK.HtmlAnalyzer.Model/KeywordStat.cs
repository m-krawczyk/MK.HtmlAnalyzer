namespace MK.HtmlAnalyzer.Model
{
    public class KeywordStat
    {
        public KeywordStat(string keyword)
        {
            Keyword = keyword;
        }
        public string Keyword { get; }
        public int Occurences { get; set; }
    }
}
