using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MK.HtmlAnalyzer.DataAccess;
using MK.HtmlAnalyzer.Model;

namespace MK.HtmlAnalyzer.Tests
{
    [TestClass]
    public class CountKeywordsTest
    {
        [TestMethod]
        public void CountKeywords_CheckOccurences()
        {
            PrivateObject objToTestPrivateMethod = new PrivateObject(typeof(HtmlRepository));
            HtmlDocument html = new HtmlDocument();
            html.Load("../../case4_withTwoKeywords.html");

            var list = objToTestPrivateMethod.Invoke("GetKeywords", html) as List<KeywordStat>;

            objToTestPrivateMethod.Invoke("CountKeywords", list, html);


            var firstNameExpected = "python";
            var secondNameExpected = "dev";
            var firstCountExpected = 2;
            var secondCountExpected = 1;

            Assert.IsTrue(
                list[0].Keyword == firstNameExpected &&
                list[0].Occurences == firstCountExpected &&
                list[1].Keyword == secondNameExpected &&
                list[1].Occurences == secondCountExpected
                );
        }

        [TestMethod]
        public void CountKeywords_CheckOccurencesWithNestedTags()
        {
            PrivateObject objToTestPrivateMethod = new PrivateObject(typeof(HtmlRepository));
            HtmlDocument html = new HtmlDocument();
            html.Load("../../case5_withNestedTag.html");

            var list = objToTestPrivateMethod.Invoke("GetKeywords", html) as List<KeywordStat>;
            objToTestPrivateMethod.Invoke("CountKeywords", list, html);

            var devCountExpected = 1;

            var devStats = list.Find(x => x.Keyword == "dev");
            Assert.AreEqual(devCountExpected, devStats.Occurences);
        }
    }
}
