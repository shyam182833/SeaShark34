using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;

namespace SimpleCSharpSelenium.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestJsonRead()
        {
            var g = Helper.JsonHelper.LoadJsonTestTable(Constants.DATA_DIRECTORY + "TC1.json");
            Assert.IsNotNull(g);
        }
        
        //[TestMethod]
        //public void TestJsonWriteCaps()
        //{
        //     DesiredCapabilities caps = DesiredCapabilities.Firefox();
        //            caps.SetCapability(CapabilityType.Platform, "Windows 7");
        //            caps.SetCapability(CapabilityType.Version, "27");
        //            caps.SetCapability("name", "testing");
        //            caps.SetCapability("username", Constants.SAUCE_USER);
        //            caps.SetCapability("accessKey", Constants.SAUCE_ACCESS_KEY);
        //    Helper.JsonHelper.WriteJsonDesiredCapabilities(@"C:/data/watwat.json",caps);
        //}

        //[TestMethod]
        //public void TestJsonReadCaps()
        //{
        //    DesiredCapabilities caps = Helper.JsonHelper.LoadJsonDesiredCapabilities(@"C:/data/watwat.json");
        //    Helper.JsonHelper.WriteJsonDesiredCapabilities(@"C:/data/watwat2.json", caps);
        //}
    }
}
