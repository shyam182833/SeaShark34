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
    static class JsonHelper
    {
        public static DataSet LoadJsonTestTable(string path)
        {       
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return  JsonConvert.DeserializeObject<DataSet>(json);
            }
        }

        public static DesiredCapabilities LoadJsonDesiredCapabilities(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<DesiredCapabilities>(json);
            }
        }

        //todo
        //public static void WriteJsonDesiredCapabilities(string path, DesiredCapabilities caps)
        //{
        //    Newtonsoft.Json.JsonSerializerSettings jss = new Newtonsoft.Json.JsonSerializerSettings();

        //        Newtonsoft.Json.Serialization.DefaultContractResolver dcr = new Newtonsoft.Json.Serialization.DefaultContractResolver();
        // dcr.
        //    dcr.DefaultMembersSearchFlags |= System.Reflection.BindingFlags.NonPublic;
        //        jss.ContractResolver = dcr;

        //    using (StreamWriter r = new StreamWriter(path))
        //    {
        //        string json = JsonConvert.SerializeObject(caps, Formatting.Indented, jss);
        //        r.Write(json);
        //        r.Close();
        //    }
        //}
    }
}
