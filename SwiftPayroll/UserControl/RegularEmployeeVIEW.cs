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

            using (var connection = new SQLiteConnection(@"Data Source=Database\Accounts.db"))
            {
                connection.Open();
                string query = "SELECT * FROM Accounts WHERE username=@Username";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.CurrentUser);
                    //return The first column of the first row in the result set.
                    SQLiteDataReader data = command.ExecuteReader();
                    data.Read();


                    UsernameLbl.Text = $"{data["firstname"]} {data["lastname"]}";
                    JobTitleLbl.Text = $"{data["title"]}";
                }

            }

   

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

        private void PayrollBtn_Click(object sender, EventArgs e)
        {
            EmployeePayrollTAB employeePayroll = new EmployeePayrollTAB();
            if (!DashBoardPanel.Controls.Contains(employeePayroll))
            {
                DashBoardPanel.Controls.Add(employeePayroll);
            }
            employeePayroll.BringToFront();
        }
    }
}
