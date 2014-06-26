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
        [TestMethod]
        public void TestJsonRead()
        {
            dynamic g = Helper.JsonHelper.LoadJsonDynamic(Constants.DATADIRECTORY +  "TC1.json");
            Dictionary<string, string> f = Helper.JsonHelper.LoadJsonDictionary(Constants.DATADIRECTORY + Constants.ENVIRONMENTSETTINGSFILENAME);
            Assert.AreEqual(1, 1);
        }

    }
}
