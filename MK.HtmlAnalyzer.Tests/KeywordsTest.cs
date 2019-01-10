using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MK.HtmlAnalyzer.DataAccess;
using MK.HtmlAnalyzer.Model;

namespace MK.HtmlAnalyzer.Tests
{
    [TestClass]
    public class KeywordsTest
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetKeywords_LackOfKeywordMetaNode_ThrowsException()
        {
            PrivateObject objToTestPrivateMethod = new PrivateObject(typeof(HtmlRepository));
            HtmlDocument html = new HtmlDocument();
            html.Load("../../case1_noMetaTag.html");
            try
            {
                objToTestPrivateMethod.Invoke("GetKeywords", html);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message == "metaKeywordNode")
                    throw ex.InnerException;
            }

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetKeywords_LackOfAttributesInKeywordMetaNode_ThrowsException()
        {
            PrivateObject objToTestPrivateMethod = new PrivateObject(typeof(HtmlRepository));
            HtmlDocument html = new HtmlDocument();
            html.Load("../../case2_noContentAttribute.html");
            try
            {
                objToTestPrivateMethod.Invoke("GetKeywords", html);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message == "contentAttr")
                    throw ex.InnerException;
            }

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetKeywords_EmptyKeywordContent_ThrowsException()
        {
            PrivateObject objToTestPrivateMethod = new PrivateObject(typeof(HtmlRepository));
            HtmlDocument html = new HtmlDocument();
            html.Load("../../case3_emptyContentAttribute.html");
            try
            {
                objToTestPrivateMethod.Invoke("GetKeywords", html);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message == "empty keyword content")
                    throw ex.InnerException;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void GetKeywords_WithTwoKeywords()
        {
            PrivateObject objToTestPrivateMethod = new PrivateObject(typeof(HtmlRepository));
            HtmlDocument html = new HtmlDocument();
            html.Load("../../case4_withTwoKeywords.html");

            var list = objToTestPrivateMethod.Invoke("GetKeywords", html) as List<KeywordStat>;

            var countExpected = 2;
            Assert.AreEqual(countExpected, list.Count);
        }

        [TestMethod]
        public void GetKeywords_WithPythonAndDevKeywords()
        {
            PrivateObject objToTestPrivateMethod = new PrivateObject(typeof(HtmlRepository));
            HtmlDocument html = new HtmlDocument();
            html.Load("../../case4_withTwoKeywords.html");

            var list = objToTestPrivateMethod.Invoke("GetKeywords", html) as List<KeywordStat>;

            var firstExpected = "python";
            var secondExpected = "dev";
            Assert.IsTrue(firstExpected == list[0].Keyword && secondExpected == list[1].Keyword);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetKeywords_NullHtmlArgument()
        {
            PrivateObject objToTestPrivateMethod = new PrivateObject(typeof(HtmlRepository));
            HtmlDocument html = null;

            var expectedMsg = @"Wartość nie może być zerowa.
Nazwa parametru: htmlDoc";
            try
            {
                objToTestPrivateMethod.Invoke("GetKeywords", html);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message == expectedMsg)
                    throw ex.InnerException;
            }

            Assert.Fail();
        }
    }
}
