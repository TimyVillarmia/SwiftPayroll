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
    public partial class AdminVIEW : UserControl
    {
        public AdminVIEW()
        {
            InitializeComponent();
        }

        private void SignOutBtn_Click(object sender, EventArgs e)
        {
            ParentForm.Hide();
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
            ParentForm.Close();
        }

        private void AdminVIEW_Load(object sender, EventArgs e)
        {
            AdminDatabase database = new AdminDatabase();
            DashBoardPanel.Controls.Add(database);
            database.BringToFront();

        }
    }
}
