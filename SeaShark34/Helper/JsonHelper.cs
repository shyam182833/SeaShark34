using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Dynamic;
using OpenQA.Selenium.Remote;
using System.IO;
using System.Data;

namespace SimpleCSharpSelenium.Helper
{
    public static class JsonHelper
    {
        public static dynamic LoadJsonDynamic(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<dynamic>(json);
            }
        }
        
        public static Dictionary<string,string> LoadJsonDictionary(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<Dictionary<string,string>>(json);
            }
        }

        public static void MakeJSON(object obj, string path)
        {
            
            using (StreamWriter r = new StreamWriter(path))
            {
                r.Write(JsonConvert.SerializeObject(obj, Formatting.Indented));
            }
        }

        public static String GetStringValue(object node)
        {
            return Convert.ToString(node);
        }
    }
}
