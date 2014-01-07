using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCSharpSelenium.Tests
{
    [TestClass]
    public class GoogleSearchTests
    {
        [TestMethod]
        public void SayMyName()
        {
            TestRunner.StartDriver(TestRunner.Browsers.Firefox, 10);
            TestRunner.Driver.Navigate().GoToUrl(@"https://www.google.com");
            TestRunner.GoogleSearchPage.VerifyThisPageLoaded();
            TestRunner.GoogleSearchPage.InPutSearchStringAndPressEnter("twitter");
        }
    }
}
