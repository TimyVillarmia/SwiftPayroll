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
