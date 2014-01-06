﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SimpleCSharpSelenium.Pages
{
    class GoogleSearchPage
    {

        #region Actions
        public void ClickSomething()
        {
            SomeBtn().Click();
        }
        public void InPutextInAField(string text)
        {
            SomeInput().SendKeys(text);
        }
        #endregion

        #region Verifications

        public void VerifyThisPageLoaded()
        {
            Assert.IsTrue(true);
        }

        #endregion

        #region Controls
        private IWebElement SomeInput()
        {
            return null;
        }
        private IWebElement SomeBtn()
        {
            return null;
        }
        #endregion
    }
}