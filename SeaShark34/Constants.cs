using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpleCSharpSelenium
{
    static class Constants
    {
        //////////CUSTOMIZE/////////////////////////
        ///TFS stuff this is the service account
        public const string TFS_URL = null;  //  "https://???.visualstudio.com/DefaultCollection";
        public const string TFS_PROJECT_NAME = null;
        public static string TFS_USER_NAME = null;
        public static string TFS_USER_PASSWORD = null;
        public static string TFS_DOMAIN = null; //remains null if using visualstudio.com
        //Sauce
        public static object SAUCE_USER = null;
        public static object SAUCE_ACCESS_KEY = null;
        //////////CUSTOMIZE/////////////////////////
        
        //JSON
        public static string DATA_DIRECTORY = Directory.GetCurrentDirectory() + @"\Data\";
        public static string ENVIRONMENTSETTINGS = "EnvironmentSettings.json";
        public static bool USE_LOCAL = true; 

        //Browsers
        public const int IMPLICIT_WAIT_DEFAULT = 10;
        public const string CHROMEDRIVERPATH = null;
        public const string FIREFOX = "firefox";
        public const string CHROME = "chrome";
        public const string IE = "ie";
        public const string SAUCE = "sauce";
      
        
    }
}

