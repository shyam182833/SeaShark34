using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System.IO;
using System.Collections.Generic;

namespace SimpleCSharpSelenium.Tests
{
    [TestClass]
    public class UnitTests
    {
        //don't forget testers can make unit tests too!
        //test our helper, data reading and reporting support classes
        //tests are just an easy way to run code
        [TestMethod]
        public void TestJsonRead()
        {
            dynamic g = Helper.JsonHelper.LoadJsonDynamic(Constants.DATADIRECTORY +  "TC1.json");
            Dictionary<string, string> f = Helper.JsonHelper.LoadJsonDictionary(Constants.DATADIRECTORY + Constants.ENVIRONMENTSETTINGSFILENAME);
            Assert.AreEqual(1, 1); // garbage to put a breakpoint on
        }

    }
}
