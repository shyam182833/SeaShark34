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
    public class GoogleSearchResults
    {
        public GoogleSearchResults()
        {
        }

        #region Actions

       
        #endregion

        #region Verifications

        public void VerifyThisPageLoaded()
        {
            Assert.IsNotNull(BodySearchResultsDiv());
        }

        #endregion

        #region Methods
      

        public List<string> GetBodyResultsHref()
        {
            //findelements gets us a list of all the h3 elements on the 
            //page which we have discovered contains all the info we want 
            var headers = BodySearchResultsDiv().FindElements(By.TagName("h3"));
            //look at all the headers
            //findelement means find the first "a"  tag in each header then get its href
            //using linq we do this all in one line and turn it into a list 
            return headers.Select(x => x.FindElement(By.TagName("a")).GetAttribute("href")).ToList();
            //same thing in CssSelector
            //return headers.Select(x => x.FindElement(By.CssSelector("a")).GetAttribute("href")).ToList();

        }

        public List<string> GetAllResultsHref()
        {
            //get the body hrefs list
            List<string> body = GetBodyResultsHref();
            //get the top cite on the page
            //add it to the list at position 0
            body.Insert(0, TopCite().Text);
            return body;
        }
       
        #endregion

        #region Controls

        public IWebElement BodySearchResultsDiv()
        {
            //lucky us classname is unique on the page
            return TestRunner.Driver.FindElement(By.ClassName("srg"));
        }

        public IWebElement TopCite()
        {
           //depend on selenium to get the top cite from page structure.
           //Different format from the rest of the page URLS
           return TestRunner.Driver.FindElement(By.TagName("cite"));
        }
        

        #endregion
    }
}
