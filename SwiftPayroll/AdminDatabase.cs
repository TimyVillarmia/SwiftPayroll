using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwiftPayroll
{
    public partial class AdminDatabase : UserControl
    {
        public AdminDatabase()
        {
            InitializeComponent();
        }

        private void AdminDatabase_Load(object sender, EventArgs e)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=Accounts.db;Version=3;");
            connection.Open();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM Accounts", connection);
            DataSet dset = new DataSet();
            adapter.Fill(dset);
            DataGridView.DataSource = dset.Tables[0];
            connection.Close();
            connection.Dispose();
        }
    }
}
