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
        /// <summary>
        /// Retruns a dynamic object of the JSON file
        /// </summary>
        /// <param name="path">Absolute path to the file</param>
        /// <returns>dynamic of the JSON object</returns>
        public static dynamic LoadJsonDynamic(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<dynamic>(json);
            }
        }
        
        /// <summary>
        /// Returns a Dictionary of a simple JSON file
        /// Use when you have JSON file of Key value pairs
        /// </summary>
        /// <param name="path">absolute path to the file</param>
        /// <returns>Dictiony of key value pairs as strings</returns>
        public static Dictionary<string,string> LoadJsonDictionary(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<Dictionary<string,string>>(json);
            }
        }

        /// <summary>
        /// Serializes an object into JSON at 
        /// destination path
        /// </summary>
        /// <param name="obj">the object to serialize</param>
        /// <param name="path">destination path</param>
        public static void MakeJSON(object obj, string path)
        {
            
            using (StreamWriter r = new StreamWriter(path))
            {
                r.Write(JsonConvert.SerializeObject(obj, Formatting.Indented));
            }
        }
        /// <summary>
        /// Use with dynamic to get a string value
        /// </summary>
        /// <param name="node">piece of JSON you need a string out of</param>
        /// <returns>string of node passed in</returns>
        public static String GetStringValue(object node)
        {
            return Convert.ToString(node);
        }

        /// <summary>
        /// Creates a list from a dynamic
        /// </summary>
        /// <param name="json">the JSON to turn into a list</param>
        /// <returns></returns>
        public static List<string> SimpleListFromDynamic(dynamic json)
        {
            List<string> mylist = new List<string>();
            foreach(var n in json)
            {
                mylist.Add(n.ToString());
            }
            return mylist;
        }
    }
}
