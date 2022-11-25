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
            DatabaseClass db = new DatabaseClass();
            //SQLiteConnection connection = new SQLiteConnection("Data Source=Accounts.db;Version=3;");
            db.connect.Open();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM Accounts", db.connect);
            DataSet dset = new DataSet();
            adapter.Fill(dset);
            DataGridView.DataSource = dset.Tables[0];
            db.connect.Close();
            db.connect.Dispose();
        }
    }
}
