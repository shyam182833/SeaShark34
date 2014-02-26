using System;
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
    class NewPageTemplate
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
            Assert.IsNotNull(SomeInput(),"Input Missing");
            Assert.IsNotNull(SomeBtn(), "Button Missing");
        }

        #endregion

        #region Controls
        public IWebElement SomeInput()
        {
            return null;
        }
        public IWebElement SomeBtn()
        {
            return null;
        }
        #endregion
    }
}
