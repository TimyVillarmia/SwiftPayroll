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

        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email_Address { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }




        public UserInfo(string first,string last, string sex,string username, string password, string email_Address,string address, string title,string type)
        {
            FirstName = first;
            LastName = last;
            Sex = sex;
            UserName = username;
            Password = password;
            Email_Address = email_Address;
            Address = address;
            Title = title;
            Type = type;
        }


    }
}
