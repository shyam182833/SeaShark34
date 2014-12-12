using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Dynamic;
using System.Linq;

namespace SimpleCSharpSelenium.Tests
{
    [TestClass]
    public class GoogleSearchTests
    {
        //Excessive commenting to help those just getting started
        //Thanks for using - Josh

        [TestMethod(), TestCategory(Constants.BUILD_VERIFICATION)]
        public void VerifyBuild()
        {
            //Start a firefox driver (browser)
            TestRunner.StartDriver(Constants.FIREFOX);
            //Navigate to google search page
            TestRunner.Driver.Navigate().GoToUrl(Constants.GOOGLEURL);
            //Verify search page is where we are at!
            TestRunner.GoogleSearchPage.VerifyThisPageLoaded();
            //Highlight the input box because it is cool and useful
            Helper.SeleniumHelper.HighlightElement(TestRunner.GoogleSearchPage.SearchInput(), 10000);
            //Test cleanup will run and kill the driver
        }

        [TestMethod(), TestCategory(Constants.GOOGLE_TEST)]
        public void TC1()
        {
            //Before running this test please set the Constants that are used!!!!!!!!
            //Setup the parameters, constructing the location of the file through constants
            TestRunner.ParametersSetup<Data.DataObjects.TC1>(Constants.DATADIRECTORY + MethodBase.GetCurrentMethod().Name + Constants.DATAFILEEXT );
            Data.DataObjects.TC1 testData = (Data.DataObjects.TC1)TestRunner.Parameters;
            //Setup the Environment and user data - default files used
            TestRunner.EnvironmentSetup();
            TestRunner.UserSetup();
            //Run tests through multiple browsers if applicable
            foreach (string browser in TestRunner.ActiveEnvironment.Browsers)
            {
                //Tell TestRunner to start a browser
                TestRunner.StartDriver(browser);
                //We have designed our test steps and the data to allow
                //iteration without opening new browser instances.
                //We iterate through the search terms
                foreach (string term in testData.Terms)
                {
                    //Navigate to the url being tested
                    TestRunner.Driver.Navigate().GoToUrl(TestRunner.ActiveEnvironment.Url);
                    //Verify the page we expected loaded
                    TestRunner.GoogleSearchPage.VerifyThisPageLoaded();
                    //Grab the current search term into a variable since we will use it a couple times.
                    String searchTerm = term;
                    //Call our Method on the Google search page that enters the search term and presses enter
                    TestRunner.GoogleSearchPage.InPutSearchStringAndPressEnter(searchTerm);
                    //Verify that search results page loaded
                    TestRunner.GoogleSearchResults.VerifyThisPageLoaded();
                    //Use this when building tests if having issues to make sure you are identifying elements you want to!
                    //Take out highlighting once test is built, not needed in test
                    Helper.SeleniumHelper.HighlightElement(TestRunner.GoogleSearchResults.BodySearchResultsDiv(), 5000);
                    //Use our method to get a list of all the search results hrefs as a list
                    List<string> actualResults = TestRunner.GoogleSearchResults.GetAllResultsHref();
                    //Construct the path to the output file, C# string goodies inline
                    string outputFilePath = Constants.CURRENTDIRECTORY + @"\" + searchTerm.Trim().Replace(" ", string.Empty) + Constants.DATAFILEEXT;
                    //Use JSON helper to output a JSON file
                    Helper.JsonHelper.MakeJSON(actualResults, outputFilePath);
                    //Use JSON helper to read that file back in
                    var inn = Helper.JsonHelper.LoadJsonDynamic(outputFilePath);
                    //Use helper method that makes a List<string> out of a simple JSON array
                    //that was read in as a dynamic
                    List<string> listFromFile = Helper.JsonHelper.SimpleListFromDynamic(inn);
                    //Compare the lists
                    //Assert.AreEqual() not very helpful in compareing lists and ojects sometimes so make your own method
                    Assert.IsTrue(ListSame(listFromFile, actualResults));

                }
            }
            //remember that the [TestCleanup] method will run here.
        }

        [TestMethod(), TestCategory("Test all the things!")]
        public void TC2()
        {
            //Automate all the things!
        }

        #region TestInitialize, TestCleanup & Supporting methods
        
        /// <summary>
        /// Compare 2 Lists in order
        /// Will fail is count is different or text at each index is different.
        /// </summary>
        /// <param name="expected">Expected list</param>
        /// <param name="actual">Actual List</param>
        /// <returns>True if lists are the same</returns>
        public bool ListSame(List<string> expected, List<string> actual)
        {
            List<string> results = actual.Except(expected).ToList();
            if (results.Count == 0) { return true; }
            else { return false; }
        }


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
