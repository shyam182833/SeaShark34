using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace SimpleCSharpSelenium.Tests
{
    [TestClass]
    public class GoogleSearchTests
    {
        [TestMethod]
        public void TC1()
        {
            TestRunner.StartDriver(TestRunner.Browsers.Firefox, MethodBase.GetCurrentMethod().Name, 10);
            List<Dictionary<string, string>> Iterations = TestRunner.SetupIterations(MethodBase.GetCurrentMethod().Name);
            foreach(var i in Iterations)
            { 
            TestRunner.Driver.Navigate().GoToUrl(@"https://www.google.com");
            TestRunner.GoogleSearchPage.VerifyThisPageLoaded();
            TestRunner.GoogleSearchPage.InPutSearchStringAndPressEnter(i["term"]);
            //todo
            //verify results page load
            //verify top result
            //scrape some data
            //write the data
            }
        }


        #region TestInitialize, TestCleanup & Supporting methods
        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void InsightTestInitialize()
        {
        }

        ////Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void InsightTestCleanup()
        {
            TestRunner.CleanupDriver();
        } 
        #endregion
    }
}
