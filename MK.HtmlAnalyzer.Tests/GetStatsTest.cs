using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MK.HtmlAnalyzer.DataAccess;

namespace MK.HtmlAnalyzer.Tests
{
    [TestClass]
    public class GetStatsTest
    {
        [TestMethod]
        [ExpectedException(typeof(UriFormatException))]
        public void GetStats_EmptyUrl_ThrowsException()
        {
            var repo = new HtmlRepository();
            repo.GetStats("");
        }

        [TestMethod]
        [ExpectedException(typeof(UriFormatException))]
        public void GetStats_EmptyHtmldoc_ThrowsException()
        {
            var repo = new HtmlRepository();
            repo.GetStats("https:/www.napewnoniematakiejstrony.com");
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(System.Net.WebException))]
        public void GetStats_InvalidUrl_ThrowsException()
        {
            var repo = new HtmlRepository();
            repo.GetStats("https://123.123");
            Assert.Fail();
        }

    }
}
