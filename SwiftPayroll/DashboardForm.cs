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
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

      

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoginUC user = new LoginUC();
            string title ="";
            SQLiteConnection connection = new SQLiteConnection("Data Source=Accounts.db;Version=3;");
            string query = "SELECT title FROM Accounts WHERE username=@Username";
            connection.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, connection);
            cmd.Parameters.AddWithValue("@Username", user.CurrentUser);
            //return The first column of the first row in the result set.
            SQLiteDataReader data = cmd.ExecuteReader();


            if (data.HasRows)
            {
                while (data.Read())
                {
                    title = $"{data["title"]}";
                }
            }

            if (title == "admin")
            {
                MessageBox.Show("You're an Admin");
            }
            else if (title == "HR")
            {
                MessageBox.Show("You're a HR");

            }
            else
            {
                RegularEmployeeVIEW employeeVIEW = new RegularEmployeeVIEW();
                DashboardFormPanel.Controls.Add(employeeVIEW);
                employeeVIEW.BringToFront();
            }



        }

        private void DashboardFormPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
