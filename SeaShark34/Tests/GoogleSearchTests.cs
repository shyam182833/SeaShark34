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
            TestRunner.EnvironmentSetup();
            TestRunner.StartDriver(TestRunner.EnvironmentParameters["browser"], MethodBase.GetCurrentMethod().Name);
            TestRunner.SetupIterations(MethodBase.GetCurrentMethod().Name);
            foreach(var iteration in TestRunner.Parameters)
            { 
            TestRunner.Driver.Navigate().GoToUrl(TestRunner.EnvironmentParameters["url"]);
            TestRunner.GoogleSearchPage.VerifyThisPageLoaded();
            TestRunner.GoogleSearchPage.InPutSearchStringAndPressEnter(iteration["term"]);
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
