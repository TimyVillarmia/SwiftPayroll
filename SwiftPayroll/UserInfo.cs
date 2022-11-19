using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SwiftPayroll

{
    internal class UserInfo
    {
        // Auto-implemented properties
        //creating a property to be able to access it from other classes
        // necessary entries for user
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email_Address { get; set; }
        public string Role { get; set; }
        public string Type { get; set; }


        public UserInfo(string username, string password, string email_Address, string role,string type)
        {
            UserName = username;
            Password = password;
            Email_Address = email_Address;
            Role = role;
            Type = type;
        }
    }
}
