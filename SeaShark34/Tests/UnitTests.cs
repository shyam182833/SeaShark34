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
        [TestMethod(), TestCategory(Constants.UNIT_TESTS)]
        public void TestJsonRead()
        {

            Dictionary<string, string> f = Helper.JsonHelper.LoadJsonDictionary(Constants.DATADIRECTORY + "DictionaryJSONExample.json");
            var environments = Helper.JsonHelper.GetObjectData<Data.DataObjects.EnvironmentSettings>(Constants.DATADIRECTORY + Constants.ENVIRONMENTSETTINGSFILENAME);
            var users = Helper.JsonHelper.GetObjectData<Data.DataObjects.UserSettings>(Constants.DATADIRECTORY + Constants.USERSETTINGSFILENAME);
            var tc1Object = Helper.JsonHelper.GetObjectData<Data.DataObjects.TC1>(Constants.DATADIRECTORY + "TC1" + Constants.DATAFILEEXT);
            dynamic tc1Dynamic = Helper.JsonHelper.LoadJsonDynamic(Constants.DATADIRECTORY + "TC1.json");
            Assert.AreEqual(1,1);
        }

        
    }
}
