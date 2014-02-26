using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System.Configuration;

namespace SimpleCSharpSelenium
{
    public static class TestRunner
    {
        public static IWebDriver Driver { get; set; }
        public static Enum Browser { get; set; }
        private static Pages.GoogleSearchPage googleSearchPage = null;

        public static Pages.GoogleSearchPage GoogleSearchPage
        {
            get
            {
                if (googleSearchPage == null)
                {
                    googleSearchPage = new Pages.GoogleSearchPage();
                }
                return googleSearchPage;
            }
        }
        
        #region Driver Management

        /// <summary>
        /// Creates a new browser, sets the global implicit wait and maximizes the browser
        /// </summary>
        /// <param name="browser">Testrunner Browsers Enum of options</param>
        /// <param name="implicitwaitsec">set or allow Constant as the default</param>
        public static void StartDriver(Browsers browser, string testName, int implicitWaitSec = Constants.IMPLICIT_WAIT_DEFAULT)
        {
            Browser = browser;

            switch (browser)
            {
                case Browsers.Chrome:
                    Driver = new ChromeDriver();//Constants._CROMEDRIVER
                    break;
                case Browsers.Firefox:
                    Driver = new FirefoxDriver();
                    break;
                case Browsers.IE:
                    Driver = new InternetExplorerDriver();//Constants._IEDRIVER
                    break;
                case Browsers.SauceLabs:
                    DesiredCapabilities caps = DesiredCapabilities.Firefox();
                    caps.SetCapability(CapabilityType.Platform, "Windows 7");
                    caps.SetCapability(CapabilityType.Version, "27");
                    caps.SetCapability("name", testName);
                    caps.SetCapability("username", Constants.SAUCE_USER);
                    caps.SetCapability("accessKey", Constants.SAUCE_ACCESS_KEY);
                    Driver = new RemoteWebDriver(
                             new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps);
                    break;
            }

            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(implicitWaitSec)); //sets global implicit wait
            Driver.Manage().Window.Maximize();
        }
        
        public enum Browsers {Firefox,Chrome,IE,SauceLabs};


        /// <summary>
        /// Closes, quits and sets Driver to null
        /// </summary>
        public static void CleanupDriver()
        {
            if (Driver != null)
            {
                //Driver.Close();
                Driver.Quit();
                Driver = null;
            }
        }

        #endregion

        #region Iteration Management

        public static List<Dictionary<string, string>> SetupIterations(string testCaseId)
        {
            List<Dictionary<string, string>> allParms = new List<Dictionary<string, string>>();
            //Get the test case parameters
            //If test case has parameters then add controller test case parametrs in same row.
            DataTable TestCaseParameters = new DataTable();
            
            if( Constants.USE_LOCAL == true)
            {
                TestCaseParameters = Helper.JsonHelper.LoadJsonTestTable(Constants.DATA_DIRECTORY + testCaseId + ".json").Tables[0];
            }
            else {TestCaseParameters = Helper.TFSActions.GetTestCaseParameters(Convert.ToInt32(testCaseId.Replace("TC","")));}
           
            if (TestCaseParameters.Rows.Count > 0)
            {
                foreach (DataRow row in TestCaseParameters.Rows)
                {
                    allParms.Add(FillParameters(row));
                }
            }

            return allParms;
        }
        /// <summary>
        /// Create the list of parameters for each data row of test cases. 
        /// This list will have parameters from test cases as well as from test environment controller
        /// </summary>
        /// <param name="parameterRow">Test case parameter row object</param>
        /// <returns></returns>
        public static Dictionary<string, string> FillParameters(DataRow parameterRow)
        {

            if (!(parameterRow == null))
            {
                Dictionary<string, string> parameterDictionary = parameterRow.Table.Columns.Cast<System.Data.DataColumn>().ToDictionary
                    (col => col.ColumnName, col => parameterRow[col.ColumnName].ToString());
                return parameterDictionary;
            }
            else
            {
                return null;
            }

        } 

        #endregion
     
    }
}
