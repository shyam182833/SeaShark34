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
using System.IO;

namespace SimpleCSharpSelenium
{
    public static class TestRunner
    {
        public static IWebDriver Driver { get; set; }
        public static Data.DataObjects.UserSettings UserSettings { get; set; }
        public static Data.DataObjects.User ActiveUser { get; set; }
        public static Data.DataObjects.EnvironmentSettings EnvironmentSettings { get; set; }
        public static Data.DataObjects.Environment ActiveEnvironment { get; set; }
        public static Object Parameters { get; set; }

        #region Pages

        private static Pages.GoogleSearchPage googleSearchPage = null;
        private static Pages.GoogleSearchResults googleSearchResults = null;
        
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
        public static Pages.GoogleSearchResults GoogleSearchResults
        {
            get
            {
                if (googleSearchResults == null)
                {
                    googleSearchResults = new Pages.GoogleSearchResults();
                }
                return googleSearchResults;
            }
        } 

        #endregion
        
        #region Driver Management

        /// <summary>
        /// Creates a new browser, sets the global implicit wait and maximizes the browser
        /// </summary>
        /// <param name="browser">Testrunner Browsers Enum of options</param>
        /// <param name="implicitwaitsec">set or allow Constant as the default in seconds</param>
        public static void StartDriver(string browser, int implicitWaitSec = Constants.IMPLICIT_WAIT_DEFAULT)
        {
            switch (browser.ToLower())
            {
                case Constants.CHROME:
                    Driver = new ChromeDriver(Constants.CHROMEDRIVERPATH);
                    break;
                case Constants.FIREFOX:
                    Driver = new FirefoxDriver();  //expecting Firefox to be installed on the local machine in default location
                    break;
                case Constants.IE:
                    Driver = new InternetExplorerDriver(Constants.IEDRIVERPATH);
                    break;
            }

            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(implicitWaitSec)); //sets global implicit wait
            Driver.Manage().Window.Maximize();
        }
        
        


        /// <summary>
        /// Closes, quits and sets Driver to null
        /// </summary>
        public static void CleanupDriver()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
        }

        #endregion
        
        #region Environment and Parameters Management

        public static void EnvironmentSetup(string path = null )
        {
           if(path == null)
           {
               EnvironmentSettings = Helper.JsonHelper.GetObjectData<Data.DataObjects.EnvironmentSettings>(
                   Constants.DATADIRECTORY + Constants.ENVIRONMENTSETTINGSFILENAME);
           }
           else
           {
               EnvironmentSettings = Helper.JsonHelper.GetObjectData<Data.DataObjects.EnvironmentSettings>(path);
           }
           ActiveEnvironment = EnvironmentSettings.Environments.FirstOrDefault(a => a.Active == Constants.ACTIVE);
 
        }

        public static void UserSetup(string path = null)
        {
            if (path == null)
            {
                UserSettings = Helper.JsonHelper.GetObjectData<Data.DataObjects.UserSettings>(
                    Constants.DATADIRECTORY + Constants.USERSETTINGSFILENAME);
            }
            else
            {
               UserSettings = Helper.JsonHelper.GetObjectData<Data.DataObjects.UserSettings>(path);
            }
            ActiveUser = UserSettings.Users.FirstOrDefault(a => a.Active == Constants.ACTIVE);

        }

        public static void ParametersSetup<T>(string filename)
        {
            Parameters = Helper.JsonHelper.GetObjectData<T>(filename);
        }


        #endregion


        #region TFS Tools

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
