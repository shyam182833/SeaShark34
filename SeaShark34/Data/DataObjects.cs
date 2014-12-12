using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCSharpSelenium.Data
{
    public class DataObjects
    {
        
        public class EnvironmentSettings
        {
            public List<Environment> Environments { get; set; }
        }
        public class Environment
        {
            public string Description { get; set; }
            public string Active { get; set; }
            public List<string> Browsers { get; set; }
            public string Url { get; set; }
        }
        public class UserSettings
        {
            public List<User> Users { get; set; }
        }
        public class User
        {
            public string Description { get; set; }
            public string Active {get; set; }
            public string Username {get; set; }
            public string Password {get; set; }
            public string Role { get; set; }
        }
        public class TC1
        {
            public List<string> Terms { get; set; }
        }
    }
}
