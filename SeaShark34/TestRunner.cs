using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

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
        public static void StartDriver(Browsers browser, int implicitWaitSec = Constants.IMPLICIT_WAIT_DEFAULT)
        {
            //cleanupDriver();
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
            }

            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(implicitWaitSec)); //sets global implicit wait
            Driver.Manage().Window.Maximize();
        }
        
        public enum Browsers {Firefox,Chrome,IE};


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
    }
}
