using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
            SearchInput().SendKeys(text + OpenQA.Selenium.Keys.Enter);
        }
        #endregion

        #region Verifications

        public void VerifyThisPageLoaded()
        {
            Assert.IsNotNull(SearchInput());
     
        }

        #endregion

        #region Controls
        private IWebElement SearchInput()
        {
            return TestRunner.Driver.FindElement(By.Name("q"));
        }
      
        #endregion
    }
}
