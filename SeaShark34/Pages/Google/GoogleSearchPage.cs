using System;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;

namespace SimpleCSharpSelenium.Pages
{
    public class GoogleSearchPage
    {
        public GoogleSearchPage()
        {
        }

        #region Actions

        public void InPutSearchStringAndPressEnter(string text)
        {
            Actions action = new Actions(TestRunner.Driver);
            action.DoubleClick(SearchInput()).Build().Perform();
            SearchInput().Clear();
            SearchInput().SendKeys(text + OpenQA.Selenium.Keys.Enter);
        }
        #endregion

        #region Verifications

        public void VerifyThisPageLoaded()
        {
            Assert.IsNotNull(SearchInput());
            Assert.IsNotNull(SearchBtn());
        }

        #endregion

        #region Controls

        public IWebElement SearchInput()
        {
            return TestRunner.Driver.FindElement(By.Name("q"));
        }

        public IWebElement SearchBtn()
        {
            return TestRunner.Driver.FindElement(By.Name("btnK"));
        }

        #endregion
       
        #region Methods
        
        #endregion
    }
}
