using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Drawing;
using System.Runtime.InteropServices;


namespace SimpleCSharpSelenium.Helper
{
    public static class SeleniumHelper
    {
        /// <summary>
        /// Waits for an element's .displayed attribute to be false.  Sometimes unreliable 
        /// </summary>
        /// <param name="id">HTML element id</param>
        public static void WaitForElementInvisible(string id, int waitSecs = 60)
        {
            WebDriverWait wait = new WebDriverWait(TestRunner.Driver, TimeSpan.FromSeconds(waitSecs));
            wait.Until<bool>((d) =>
            {
                try
                {
                    IWebElement element = d.FindElement(By.Id(id));
                    return !element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }

        /// <summary>
        /// Waits for an element's .displayed attribute to be false.  Sometimes unreliable
        /// </summary>
        /// <param name="className"> Class name from HTML</param>
        public static void WaitForElementInvisibleByClassName(string className)
        {
            WebDriverWait wait = new WebDriverWait(TestRunner.Driver, TimeSpan.FromSeconds(10));
            wait.Until<bool>((d) =>
            {
                try
                {
                    IWebElement element = d.FindElement(By.ClassName(className));
                    return !element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }

        /// <summary>
        /// Waits for an element's .displayed attribute to be true.  Sometimes unreliable
        /// </summary>
        /// <param name="id">HTML id of the element</param>
        /// <param name="waitSecs">seconds to wait before timeout</param>
        public static void WaitForElementVisible(string id, int waitSecs)
        {
            WebDriverWait Wait = new WebDriverWait(TestRunner.Driver, TimeSpan.FromSeconds(waitSecs));
            Wait.Until<bool>((d) =>
            {
                try
                {
                    IWebElement element = d.FindElement(By.Id(id));
                    return element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }

        /// <summary>
        /// Waits for an elements test to change form the passed in intial state.
        /// </summary>
        /// <param name="id">HTML id of the element</param>
        /// <param name="initialText">starting text of the element</param>
        public static void WaitForTextChanged(string id, string initialText)
        {
            WebDriverWait wait = new WebDriverWait(TestRunner.Driver, TimeSpan.FromSeconds(25));
            wait.Until<bool>((d) =>
            {
                try
                {
                    IWebElement element = d.FindElement(By.Id(id));
                    if (String.Compare(element.Text, "", true) != 0)
                    {
                        if (String.Compare(element.Text, initialText, true) != 0)
                        {
                            return true;
                        }
                        else { return false; }
                    }
                    else { return false; }
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }


        /// <summary>
        /// Waits for an element to have no child image.  
        /// Good for use when spinners are employed
        /// </summary>
        /// <param name="id">HTML id of element</param>
        public static void WaitForElementHaveNoChildImg(string id)
        {
            WebDriverWait wait = new WebDriverWait(TestRunner.Driver, TimeSpan.FromSeconds(25));
            wait.Until<bool>((d) =>
            {
                try
                {
                    IWebElement element = d.FindElement(By.Id(id));
                    element.FindElement(By.TagName("img"));
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }

        /// <summary>
        /// Waits for an image to be not found on the page using 
        /// the source path to identify the image
        /// </summary>
        /// <param name="src">source path</param>
        public static void WaitForImageBySourceInvisible(string src)
        {
            WebDriverWait wait = new WebDriverWait(TestRunner.Driver, TimeSpan.FromSeconds(25));
            wait.Until<bool>((d) =>
            {
                try
                {
                    IWebElement element = d.FindElement(By.XPath("//img[contains(@src,'" + src + "')]"));
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }

        /// <summary>
        /// Waits for the inner text of an element to contain text
        /// </summary>
        /// <param name="id"> the HTML id of the element</param>
        public static void WaitForInnerText(string id)
        {
            WebDriverWait wait = new WebDriverWait(TestRunner.Driver, TimeSpan.FromSeconds(30));
            wait.Until<bool>((d) =>
            {
                try
                {
                    IWebElement element = d.FindElement(By.Id(id));
                    if (string.IsNullOrEmpty(element.Text))
                    {
                        return false;
                    }
                    else { return true; }

                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }
        
        /// <summary>
        /// Uses javascript execute to click an element
        /// Useful when DOM thinks an element is invisible and it is not
        /// Also helpful when scrolling to an element in a list doesn't work
        /// </summary>
        /// <param name="id">the HTML id of the element</param>
        public static void ClickWithJs(string id)
        {
            IJavaScriptExecutor js = TestRunner.Driver as IJavaScriptExecutor;
            js.ExecuteScript("javascript:document.getElementById('" + id + "').click();");
        }

        /// <summary>
        /// Uses javascript execute to click an element
        /// Useful when DOM thinks an element is invisible and it is not
        /// Also helpful when scrolling to an element in a list doesn't work
        /// </summary>
        /// <param name="element">the element to click</param>
        public static void ClickWithJs(IWebElement element)
        {
            IJavaScriptExecutor js = TestRunner.Driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].click();", element);
        }

        public static void ClickWithMouseEvent(IWebElement element)
        {
            IJavaScriptExecutor js = TestRunner.Driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].dispatchEvent(new MouseEvent('click', {view: window, bubbles:true, cancelable: true}))", element);
        }


        /// <summary>
        /// Highlight an element for a time 
        /// Useful in debugging
        /// </summary>
        /// <param name="element">the eleement to highlight</param>
        /// <param name="time">time to highlight before returning to normal</param>
        public static void HighlightElement(IWebElement element, int time = 20000)
        {
            IJavaScriptExecutor js = TestRunner.Driver as IJavaScriptExecutor;
            String oldStyle = element.GetAttribute("style");
            String args = "arguments[0].setAttribute('style', arguments[1]);";
            js.ExecuteScript(args, element, "border: 4px solid yellow;display:block;");
            Thread.Sleep(time);
            js.ExecuteScript(args, element, oldStyle);

        }

        /// <summary>
        /// Checks if a string is null or empty
        /// </summary>
        /// <param name="toCheck">string to check</param>
        /// <returns></returns>
        public static bool CheckNull(string toCheck)
        {
            if (string.IsNullOrEmpty(toCheck)) { return true; }
            else { return false; }
        }
       
        /// <summary>
        /// Clear and then fill a textbox
        /// Great to ensure textbox filled as desired
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="text"></param>
        public static void ClearAndFillTextBox(IWebElement elem, string text)
        {
            elem.Clear();
            if (!CheckNull(text))
            {
                elem.SendKeys(text.Trim());
            }
        }

        /// <summary>
        /// Selects an item in a dropdown. if you pass an empty text prameter it will select the passed default
        /// </summary>
        /// <param name="elem">DD element</param>
        /// <param name="text">text to select or empty if you want th edefault</param>
        /// <param name="defaultSelection">the default to use</param>
        public static void SelectDropDownbyTextWithEmptyDefault(SelectElement elem, string text, string defaultSelection)
        {
            if (!CheckNull(text))
            {
                elem.SelectByText(text.Trim());
            }
            else { elem.SelectByText(defaultSelection); }
        }


        /// <summary>
        /// When interacting with more than one window, wait until the count of windows equals what you want
        /// </summary>
        /// <param name="numberOfWindows">number of windows</param>
        /// <param name="timeoutSecs">seconds to wait before timeout</param>
        public static void WaitForNumberOfWindowsToEqual(int numberOfWindows, int timeoutSecs)
        {
            WebDriverWait wait = new WebDriverWait(TestRunner.Driver, TimeSpan.FromSeconds(timeoutSecs));
            wait.Until(drv => drv.WindowHandles.Count == numberOfWindows);
        }

        /// <summary>
        /// Returns windows title text by given handle number.
        /// </summary>
        /// <param name="WindowHandle"></param>
        /// <returns></returns>
        public static string GetWindowTitleByWindowHandleIndex(int WindowHandle = 0)
        {
            string winTitle = String.Empty;
            string currentWindowHandle = TestRunner.Driver.WindowHandles[0];
            if (TestRunner.Driver.WindowHandles.Count > 1)
            {
                TestRunner.Driver.SwitchTo().Window(TestRunner.Driver.WindowHandles[WindowHandle]);
                winTitle = TestRunner.Driver.Title;
                // Reset back to calling window as active window.
                TestRunner.Driver.SwitchTo().Window(currentWindowHandle);
            }
            return winTitle;
        }

        /// <summary>
        /// Returns the inner HTML for input element.
        /// </summary>
        /// <param name="webElement"></param>
        /// <returns></returns>
        public static string GetInnerHTML(IWebElement webElement)
        {
            //In case of hidden element "Text" property do not return value even it is present. 
            //In such case this method is useful
            IJavaScriptExecutor js = TestRunner.Driver as IJavaScriptExecutor;
            var innerHTML = js.ExecuteScript("return arguments[0].innerHTML", webElement);
            return innerHTML.ToString();
        }

        /// <summary>
        /// Run javascript
        /// </summary>
        /// <param name="jscriptToRun"></param>
        /// <param name="currentWindowHandle"></param>
        /// <returns></returns>
        public static string RunJavaScript(string jscriptToRun, string currentWindowHandle)
        {
            IJavaScriptExecutor js = TestRunner.Driver as IJavaScriptExecutor;
            return js.ExecuteScript("return " + jscriptToRun, currentWindowHandle).ToString();
        }
    }
}
