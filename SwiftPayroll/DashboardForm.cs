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
            DatabaseClass db = new DatabaseClass();
            //SQLiteConnection connection = new SQLiteConnection("Data Source=Accounts.db;Version=3;");
            string query = "SELECT title FROM Accounts WHERE username=@Username";
            db.connect.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, db.connect);
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
                AdminVIEW AdminVIEW = new AdminVIEW();
                DashboardFormPanel.Controls.Add(AdminVIEW);
                AdminVIEW.BringToFront();
            }
            else if (title == "HR")
            {
                HumanResourceVIEW HrView = new HumanResourceVIEW();
                DashboardFormPanel.Controls.Add(HrView);
                HrView.BringToFront();

            }
            else
            {
                RegularEmployeeVIEW employeeVIEW = new RegularEmployeeVIEW();
                DashboardFormPanel.Controls.Add(employeeVIEW);
                employeeVIEW.BringToFront();
            }

            db.connect.Close();
            db.connect.Dispose();



        }

        private void DashboardFormPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
