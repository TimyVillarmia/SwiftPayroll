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
    public partial class RegularEmployeeVIEW : UserControl
    {

     
        public RegularEmployeeVIEW()
        {
            InitializeComponent();
        }

        private void RegularEmployeeVIEW_Load(object sender, EventArgs e)
        {
            LoginUC user = new LoginUC();
            DatabaseClass db = new DatabaseClass();

            string query = "SELECT * FROM Accounts WHERE username=@Username";
            db.connect.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, db.connect);
            cmd.Parameters.AddWithValue("@Username", user.CurrentUser);
            //return The first column of the first row in the result set.
            SQLiteDataReader data = cmd.ExecuteReader();
            data.Read();


            UsernameLbl.Text = $"{data["firstname"]} {data["lastname"]}";
        }

        private void SignOutBtn_Click(object sender, EventArgs e)
        {
            ParentForm.Hide();
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
            ParentForm.Close();
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            UserProfile profile = new UserProfile();
            if (!DashBoardPanel.Controls.Contains(profile))
            {
                DashBoardPanel.Controls.Add(profile);
            }
            profile.BringToFront();
        }
    }
}
