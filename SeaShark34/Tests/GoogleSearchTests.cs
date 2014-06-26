using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Dynamic;

namespace SimpleCSharpSelenium.Tests
{
    [TestClass]
    public class GoogleSearchTests
    {
        [TestMethod]
        public void TC1()
        {
            TestRunner.ParametersSetup(Constants.DATADIRECTORY + MethodBase.GetCurrentMethod().Name + Constants.DATAFILEEXT );
            TestRunner.EnvironmentSetup(Constants.DATADIRECTORY + Constants.ENVIRONMENTSETTINGSFILENAME);
            TestRunner.StartDriver( TestRunner.EnvironmentParameters["browser"], MethodBase.GetCurrentMethod().Name);

            TestRunner.Driver.Navigate().GoToUrl(TestRunner.EnvironmentParameters["url"]);
            TestRunner.GoogleSearchPage.VerifyThisPageLoaded();

            foreach (var term in TestRunner.Parameters.Terms)
            {
                TestRunner.GoogleSearchPage.InPutSearchStringAndPressEnter(Convert.ToString(term.term));
                //Use this when building tests if having issues to make sure you are identifying elements you want to!
                TestRunner.GoogleSearchResults.VerifyThisPageLoaded();
                Helper.SeleniumHelper.HighlightElement(TestRunner.GoogleSearchResults.BodySearchResultsDiv(), 5000);
                var i = TestRunner.GoogleSearchResults.GetBodyResultsHref();
                var q = TestRunner.GoogleSearchResults.GetAllResultsHref();
                Helper.JsonHelper.MakeJSON(q, Constants.JSON_OUTPUT);
                var inn = Helper.JsonHelper.LoadJsonDynamic(Constants.JSON_OUTPUT);
                var top = TestRunner.GoogleSearchResults.TopCite();

                int hi = 0;
                //verify top result
                //scrape some data
                //write the data
            }
        }

        [TestMethod]
        public void TC2()
        {

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
