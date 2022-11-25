using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace SwiftPayroll
{
    class DatabaseClass
    {
        public SQLiteConnection connect;

        //D:\New folder\OOP - Final Project\SwiftPayroll\
        public DatabaseClass()
        {
            connect = new SQLiteConnection(@"Data Source=Database\Accounts.db");


        }
        
    }
}
