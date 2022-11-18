using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SwiftPayroll
{
    internal class Database
    {
        
        public SQLiteConnection connection;
        public Database()
        {
            //Instantiate SQLiteConnect object which is used for opening connection to the database
            connection = new SQLiteConnection("Data Source=Accounts.db;Version=3;");
            //check whether database file exist or not
            if (!File.Exists("./Accounts.db;Version=3;"))
            {
                SQLiteConnection.CreateFile("./Accounts.db;Version=3;");
                Console.WriteLine("Db File Created");
            }
        }

        public void OpenConnection()
        {
            //check if the connection is open or not
            if(connection.State != System.Data.ConnectionState.Open)
            {
                //Accessing the "Open" property of SQLiteConnection to "Open" the connection
                connection.Open();
            }
        }
        public void CloseConnection()
        {
            //check if the connection is close or not
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                //Accessing the "Close" property of SQLiteConnection to "Close" the connection
                connection.Close();
            }
        }
    }
}
