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
        //////////CUSTOMIZE For TFS USE/////////////////////////
        ///TFS stuff this is the service account
        public const string TFS_URL = null;  //  "https://???.visualstudio.com/DefaultCollection";
        public const string TFS_PROJECT_NAME = null;
        public static string TFS_USER_NAME = null;
        public static string TFS_USER_PASSWORD = null;
        public static string TFS_DOMAIN = null; //remains null if using visualstudio.com
        //////////CUSTOMIZE/////////////////////////
        
        //Data
        public static string DATADIRECTORY = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Data\";
        public static string CURRENTDIRECTORY = Directory.GetCurrentDirectory();
        public static string DATAFILEEXT = ".json";
        public static string ENVIRONMENTSETTINGSFILENAME = "EnvironmentSettings.json";
        public static string JSON_OUTPUT = @"C:\Data\wuty.json";
        public static string GOOGLEURL = @"https://google.com";

        //Browsers
        public const int IMPLICIT_WAIT_DEFAULT = 10;
        public const string CHROMEDRIVERPATH = null;
        public const string IEDRIVERPATH = null;
        public const string FIREFOX = "firefox";
        public const string CHROME = "chrome";
        public const string IE = "ie";
        public const string SAUCE = "sauce";
      
        
    }
}

